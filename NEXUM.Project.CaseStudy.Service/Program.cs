using NEXUM.Project.CaseStudy.Business.Extensions;
using NEXUM.Project.CaseStudy.Business.Helpers;
using NEXUM.Project.CaseStudy.Business.Managers;
using NEXUM.Project.CaseStudy.Business.Prompts;
using NEXUM.Project.CaseStudy.Business.Validations;
using NEXUM.Project.CaseStudy.Domain;
using NEXUM.Project.CaseStudy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace NEXUM.Project.CaseStudy.Service
{
    internal class Program
    {
        static string spaceSize = string.Empty;
        static string firstLocationAndDirectionInputForRobot1 = string.Empty;
        static string movesInputForRobot1 = string.Empty;
        static string firstLocationAndDirectionInputForRobot2 = string.Empty;
        static string movesInputForRobot2 = string.Empty;
        static void Main(string[] args)
        {
            #region Params
            string input = string.Empty;
            string errorCode = string.Empty;
            string errorDescription = string.Empty;
            string retVal = string.Empty;
            List<string> firstRobot = new List<string>();
            List<string> secondRobot = new List<string>();
            int XCoordinateRobot1 = 0;
            int YCoordinateRobot1 = 0;
            string directionRobot1 = string.Empty;
            int XCoordinateRobot2 = 0;
            int YCoordinateRobot2 = 0;
            string directionRobot2 = string.Empty;

            bool check = false;
            ConstantPrompts constantPrompts = new ConstantPrompts();
            #endregion

            try
            {
                for (int i = 0; i < 5; i++)
                {
                    while (!check)
                    {
                        Console.WriteLine(constantPrompts.PromptList.First(Prompt => Prompt.PromptNo == i + 1).Prompt);
                        input = Console.ReadLine();
                        check = Validations.IsValid(input, i + 1, out errorCode, out errorDescription);
                        if (!check)
                            Helper.WriteErrorMessages(input, errorCode, errorDescription);
                        else
                            SetVariables(i + 1, input);

                        Console.Write("------------------------------------------------------------------------------------------------------------------------\n");
                    }
                    check = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            #region LastParams

            try
            {
                firstRobot = firstLocationAndDirectionInputForRobot1.Split(' ').ToList();
                secondRobot = firstLocationAndDirectionInputForRobot2.Split(' ').ToList();
                XCoordinateRobot1 = int.TryParse(firstRobot[0], out int xRobot1) ? xRobot1 : 0;
                YCoordinateRobot1 = int.TryParse(firstRobot[1], out int yRobot1) ? yRobot1 : 0;
                directionRobot1 = firstRobot[2];
                XCoordinateRobot2 = int.TryParse(secondRobot[0], out int xRobot2) ? xRobot2 : 0;
                YCoordinateRobot2 = int.TryParse(secondRobot[1], out int yRobot2) ? yRobot2 : 0;
                directionRobot2 = secondRobot[2];
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error While setting parameters.." + ex);
            }


            List<Robot> robots = new List<Robot>
            {
                new Robot
                {
                    RobotId = 1,
                    CurrentLocation = new Point(XCoordinateRobot1, YCoordinateRobot1),
                    CurrentDirection = directionRobot1,
                    IsMyTurn = true,
                    Moves = movesInputForRobot1,
                },
                new Robot
                {
                    RobotId = 2,
                    CurrentLocation = new Point(XCoordinateRobot2,YCoordinateRobot2),
                    CurrentDirection = directionRobot2,
                    Moves = movesInputForRobot2,
                }
            };

            Space space = new Space();
            int XCoordinateSpace = int.TryParse(spaceSize.Split(' ')[0], out int x) ? x : 0;
            int YCoordinateSpace = int.TryParse(spaceSize.Split(' ')[1], out int y) ? y : 0;
            space.Size = new Point(XCoordinateSpace, YCoordinateSpace);

            RobotManager manager = new RobotManager();

            #endregion

            try
            {
                retVal = manager.CheckMoves(space, robots).MakeResultData();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error While Checking Moves.." + ex);
            }

            Console.WriteLine(retVal);
            Console.ReadLine();
        }
        public static void SetVariables(int order, string value)
        {
            switch (order)
            {
                case 1:
                    spaceSize = value;
                    break;
                case 2:
                    firstLocationAndDirectionInputForRobot1 = value;
                    break;
                case 3:
                    movesInputForRobot1 = value;
                    break;
                case 4:
                    firstLocationAndDirectionInputForRobot2 = value;
                    break;
                case 5:
                    movesInputForRobot2 = value;
                    break;
                default: break;
            }
        }
    }
}
