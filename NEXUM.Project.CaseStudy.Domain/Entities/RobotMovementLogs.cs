using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEXUM.Project.CaseStudy.Domain.Entities
{
    public class RobotMovementLogs
    {
        public int RobotId { get; set; }
        public int TurnNumber { get; set; }
        public string CurrentLocation { get; set; }
        public string CurrentDirection { get; set; }
        public int MovesLeft { get; set; }
    }
}
