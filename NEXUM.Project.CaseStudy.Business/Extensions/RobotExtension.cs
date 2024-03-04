using NEXUM.Project.CaseStudy.Domain;
using NEXUM.Project.CaseStudy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NEXUM.Project.CaseStudy.Business.Extensions
{
    public static class RobotExtension
    {
        public static string MakeResultData(this List<Robot> robot)
        {
            StringBuilder result = new StringBuilder();
            robot.ForEach(r =>
            {
                result.AppendLine(r.CurrentLocation.X.ToString() + " " + r.CurrentLocation.Y.ToString() + " " + r.CurrentDirection);
            });
            return result.ToString();
        }
        public static void MakeLogData(this List<RobotMovementLogs> robot)
        {
            Console.WriteLine("Detailed Logs:\n");
            StringBuilder result = new StringBuilder();
            robot.ForEach(r =>
            {
                Console.WriteLine("RobotId:" + r.RobotId + Environment.NewLine + "CurrentLocation:" + r.CurrentLocation + Environment.NewLine + "CurrentDirection:" + r.CurrentDirection + Environment.NewLine +
                    "TurnNumber:" + r.TurnNumber + Environment.NewLine + "MovesLeft:" + r.MovesLeft);
                Console.Write("------------------------------------------------------------------------------------------------------------------------\n");
            });
            Console.WriteLine(result);
        }
    }
}
