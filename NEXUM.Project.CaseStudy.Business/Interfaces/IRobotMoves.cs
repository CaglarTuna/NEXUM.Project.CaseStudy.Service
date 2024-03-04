using NEXUM.Project.CaseStudy.Domain;
using NEXUM.Project.CaseStudy.Domain.Entities;
using System.Collections.Generic;
using System.Drawing;

namespace NEXUM.Project.CaseStudy.Business.Interfaces
{
    public interface IRobotMoves
    {
        List<Robot> CheckMoves(Space space, List<Robot> robots);
        Robot EndTurn(Robot robot, bool isAnyMovesLeftWithOtherRobot);
        Robot CheckMovements(Robot robot);
        Point HandleMove(Point currentLocation, string currentDirection);
        string HandleTurn(string currentDirection, char turn);
        bool CheckIfBothHasNoMovesLeft(List<Robot> robots);
        List<Robot> CheckIfThereIsOverFlow(List<Robot> robots, Space space);
    }
}
