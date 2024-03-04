using System.Drawing;

namespace NEXUM.Project.CaseStudy.Domain
{
    public class Robot
    {
        public int RobotId { get; set; }
        public string CurrentDirection { get; set; }
        public Point CurrentLocation { get; set; }
        public string Moves { get; set; }
        public bool IsMyTurn { get; set; }
    }
}
