using System;
using System.ComponentModel;
using System.Reflection;

namespace NEXUM.Project.CaseStudy.Business
{
    public enum ErrorEnums
    {
        [Description("Success")]
        Success = 0,
        [Description("is not a valid input. Size should be (number whitespace number) format and cannot be (0 0) and should be greater than 0. For Example (5 5)")]
        NotAValidSize = 1,
        [Description("is not a valid input. Directions are 'N' for North , 'S' for South , 'E' for East and 'W' for West. For Example (5 5 N)")]
        NotAValidLocationAndDirection = 2,
        [Description("is not a valid input. Directions are 'L' for 90 degrees left without moving , 'R' for 90 degrees right without moving , 'M' for move 1 unit through the direction you face. For Example (LMLMRMRMMM)")]
        NotAValidMove = 3,
        [Description("Location should not exceed the size of space.")]
        NotAValidLocation = 4,
        [Description("System Error.")]
        SystemError = 5,
    }
    public class ErrorValues
    {
        public string ErrorCode { get; set; }
        public string ErrorDescription { get; set; }
        public ErrorValues(int i)
        {
            ErrorEnums en = (ErrorEnums)i;
            FillValues(en);
        }
        private void FillValues(ErrorEnums en)
        {
            Type type = en.GetType();
            MemberInfo[] memberInfo = type.GetMember(en.ToString());
            if (memberInfo != null && memberInfo.Length > 0)
            {
                object[] attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs != null && attrs.Length > 0)
                {
                    this.ErrorDescription = ((DescriptionAttribute)attrs[0]).Description;
                    this.ErrorCode = ((int)en).ToString("000");
                    if (this.ErrorCode == "000")
                    {
                        this.ErrorCode = string.Empty;
                        this.ErrorDescription = string.Empty;
                    }
                }
            }
        }
    }
}
