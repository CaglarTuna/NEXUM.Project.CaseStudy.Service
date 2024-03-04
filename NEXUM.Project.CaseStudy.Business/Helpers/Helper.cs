using System;
using System.Text;

namespace NEXUM.Project.CaseStudy.Business.Helpers
{
    public static class Helper
    {
        public static void WriteErrorMessages(string input, string errorCode, string errorDescription)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("------------------------------------------------------------------------------------------------------------------------\n");
            stringBuilder.Append("ErrorCode:" + errorCode + " .. ");
            stringBuilder.Append(input);
            stringBuilder.Append(" " + errorDescription);
            Console.WriteLine(stringBuilder);
        }
    }
}
