using System.Collections.Generic;
using System.Linq;
using System;
using System.Text.RegularExpressions;

namespace NEXUM.Project.CaseStudy.Business.Validations
{
    public static class Validations
    {
        public static string Size = string.Empty;
        public static bool IsValid(string input, int validationNo, out string errorCode, out string errorDescription)
        {
            errorDescription = string.Empty;
            errorCode = string.Empty;

            return validationNo switch
            {
                1 => IsValidSize(input, out errorCode, out errorDescription),
                2 => IsValidFirstLocation(input, out errorCode, out errorDescription),
                3 => IsValidMoves(input, out errorCode, out errorDescription),
                4 => IsValidFirstLocation(input, out errorCode, out errorDescription),
                5 => IsValidMoves(input, out errorCode, out errorDescription),
                _ => false
            };
        }
        public static bool IsValidSize(string input, out string errorCode, out string errorDescription)
        {
            errorCode = string.Empty;
            errorDescription = string.Empty;
            string pattern = @"^\d+\s\d+$";
            Size = input;
            try
            {
                if (input.Replace(" ", "").Any(x => x == '0') || !Regex.IsMatch(input, pattern))
                {
                    ErrorValues errorValues = new ErrorValues(1);
                    errorCode = errorValues.ErrorCode;
                    errorDescription = errorValues.ErrorDescription;
                    return false;
                }
            }
            catch (Exception ex)
            {
                ErrorValues errorValues = new ErrorValues(5);
                errorCode = errorValues.ErrorCode;
                errorDescription = errorValues.ErrorDescription;
                return false;
            }

            return true;
        }
        public static bool IsValidFirstLocation(string input, out string errorCode, out string errorDescription)
        {
            errorCode = string.Empty;
            errorDescription = string.Empty;
            string pattern = @"^\d+\s\d+\s[EWSN]$";
            try
            {
                if (!Regex.IsMatch(input, pattern))
                {
                    ErrorValues errorValues = new ErrorValues(2);
                    errorCode = errorValues.ErrorCode;
                    errorDescription = errorValues.ErrorDescription;
                    return false;
                }
                string[] locationInput = input.Split(' ');
                string[] sizeCoords = Size.Split(' ');
                int sizeX = int.Parse(sizeCoords[0]);
                int sizeY = int.Parse(sizeCoords[1]);
                int robotX = int.Parse(locationInput[0]);
                int robotY = int.Parse(locationInput[1]);
                if (robotX > sizeX || robotY > sizeY)
                {
                    ErrorValues errorValues = new ErrorValues(4);
                    errorCode = errorValues.ErrorCode;
                    errorDescription = errorValues.ErrorDescription;
                    return false;
                }
            }
            catch (Exception ex)
            {
                ErrorValues errorValues = new ErrorValues(5);
                errorCode = errorValues.ErrorCode;
                errorDescription = errorValues.ErrorDescription;
                return false;
            }

            return true;
        }
        public static bool IsValidMoves(string input, out string errorCode, out string errorDescription)
        {
            errorCode = string.Empty;
            errorDescription = string.Empty;
            string pattern = @"^[LRM]*$";
            try
            {
                if (!Regex.IsMatch(input, pattern))
                {
                    ErrorValues errorValues = new ErrorValues(3);
                    errorCode = errorValues.ErrorCode;
                    errorDescription = errorValues.ErrorDescription;
                    return false;
                }
            }
            catch (Exception ex)
            {
                ErrorValues errorValues = new ErrorValues(5);
                errorCode = errorValues.ErrorCode;
                errorDescription = errorValues.ErrorDescription;
                return false;
            }
            
            return true;
        }
    }
}
