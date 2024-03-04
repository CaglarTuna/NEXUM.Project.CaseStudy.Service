using System.Collections.Generic;
using System.Text;

namespace NEXUM.Project.CaseStudy.Domain.Responses
{
    public class RobotMoveResult
    {
        public List<Robot> Robots { get; set; }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            Robots.ForEach(r =>
            {
                result.AppendLine(r.CurrentLocation.X.ToString() + " " + r.CurrentLocation.Y.ToString() + " " + r.CurrentDirection);
            });
            return result.ToString();
        }
    }
}
