using NEXUM.Project.CaseStudy.Business.Extensions;
using NEXUM.Project.CaseStudy.Business.Interfaces;
using NEXUM.Project.CaseStudy.Domain;
using NEXUM.Project.CaseStudy.Domain.Entities;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System;

namespace NEXUM.Project.CaseStudy.Business.Managers
{
    public class RobotManager : IRobotMoves
    {
        public List<Robot> CheckMoves(Space space, List<Robot> robots)
        {
            try
            {
                int counter = robots.Sum(x => x.Moves.Length);
                Robot robot = null;
                Robot otherRobot = null;
                int turn = 1;
                List<RobotMovementLogs> logs = new List<RobotMovementLogs>();
                while (counter != 0)
                {
                    robot = robots.Find(x => x.IsMyTurn);
                    otherRobot = robots.Find(x => !x.IsMyTurn);
                    if (robot.Moves.Length > 0)
                    {
                        //Check movements of current robot
                        robot = CheckMovements(robot);
                        //LogData
                        logs.Add(new RobotMovementLogs
                        {
                            RobotId = robot.RobotId,
                            CurrentDirection = robot.CurrentDirection,
                            CurrentLocation = robot.CurrentLocation.X + " " + robot.CurrentLocation.Y.ToString(),
                            TurnNumber = turn,
                            MovesLeft = counter - 1
                        });
                        //End turn of current robot and check if any robot has moves left then make it false
                        robot = EndTurn(robot, robots.Any(x => !x.Moves.Any()));
                        counter--;
                        turn++;
                    }
                    otherRobot.IsMyTurn = otherRobot.Moves.Length > 0;
                }
                logs.MakeLogData();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
            return CheckIfThereIsOverFlow(robots, space);
        }
        public List<Robot> CheckIfThereIsOverFlow(List<Robot> robots, Space space)
        {
            try
            {
                robots.ForEach(robot =>
                {
                    Point point = new Point();
                    if (robot.CurrentLocation.X > space.Size.X)
                    {
                        point.X = space.Size.X;
                        if (robot.CurrentLocation.Y > space.Size.Y)
                            point.Y = space.Size.Y;
                        point.Y = robot.CurrentLocation.Y;
                        robot.CurrentLocation = point;
                    }
                    else if (robot.CurrentLocation.Y > space.Size.Y)
                    {
                        point.Y = space.Size.Y;
                        point.X = robot.CurrentLocation.X;
                        robot.CurrentLocation = point;
                    }
                });
                return robots;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Robot CheckMovements(Robot robot)
        {
            try
            {
                char moveType = robot.Moves.First();
                switch (moveType)
                {
                    case 'M':
                        robot.CurrentLocation = HandleMove(robot.CurrentLocation, robot.CurrentDirection);
                        break;
                    case 'L':
                        robot.CurrentDirection = HandleTurn(robot.CurrentDirection, moveType);
                        break;
                    case 'R':
                        robot.CurrentDirection = HandleTurn(robot.CurrentDirection, moveType);
                        break;
                    default: break;
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
            return robot;
        }
        public string HandleTurn(string currentDirection, char turn)
        {
            string retVal = string.Empty;
            try
            {
                switch (turn)
                {
                    case 'L':
                        switch (currentDirection)
                        {
                            case "N":
                                retVal = "W";
                                break;
                            case "S":
                                retVal = "E";
                                break;
                            case "E":
                                retVal = "N";
                                break;
                            case "W":
                                retVal = "S";
                                break;
                            default:
                                break;
                        }
                        break;
                    case 'R':
                        switch (currentDirection)
                        {
                            case "N":
                                retVal = "E";
                                break;
                            case "S":
                                retVal = "W";
                                break;
                            case "E":
                                retVal = "S";
                                break;
                            case "W":
                                retVal = "N";
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }
                return retVal;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Point HandleMove(Point currentLocation, string currentDirection)
        {
            try
            {
                switch (currentDirection)
                {
                    case "E":
                        currentLocation.X += 1;
                        break;
                    case "W":
                        currentLocation.X -= 1;
                        break;
                    case "N":
                        currentLocation.Y += 1;
                        break;
                    case "S":
                        currentLocation.Y -= 1;
                        break;
                    default: break;
                };
                return currentLocation;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Robot EndTurn(Robot robot, bool isAnyMovesLeftWithOtherRobot)
        {
            try
            {
                if (robot.Moves.Length > 0)
                {
                    if (isAnyMovesLeftWithOtherRobot)
                        robot.IsMyTurn = true;
                    else
                        robot.IsMyTurn = false;
                    robot.Moves = robot.Moves.Remove(0, 1);
                }
                return robot;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool CheckIfBothHasNoMovesLeft(List<Robot> robots) => robots.All(x => x.Moves.Length == 0);

    }
}