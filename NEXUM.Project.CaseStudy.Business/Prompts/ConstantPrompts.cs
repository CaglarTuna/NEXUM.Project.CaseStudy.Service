using System.Collections.Generic;

namespace NEXUM.Project.CaseStudy.Business.Prompts
{
    public class ConstantPrompts
    {
        public ConstantPrompts()
        {
            PromptList = new List<Prompts>
            {
                new Prompts { Prompt = "Enter Max Size of Space with a whitespace between them. For Example (5 5)" ,PromptNo=1},

                new Prompts { Prompt = "Enter location and direction of the robot. Directions are 'N' for North , 'S' for South , 'E' for East and 'W' for West. For Example (5 5 N)" ,PromptNo=2},

                new Prompts { Prompt = "Enter moves of the robot. Directions are 'L' for 90 degrees left without moving , 'R' for 90 degrees right without moving , 'M' for move 1 unit through the direction you face. For Example (LMLMRMRMMM)" ,PromptNo=3},

                new Prompts { Prompt = "Enter location and direction of the robot. Directions are 'N' for North , 'S' for South , 'E' for East and 'W' for West. For Example (5 5 N)" ,PromptNo=4},

                new Prompts { Prompt = "Enter moves of the robot. Directions are 'L' for 90 degrees left without moving , 'R' for 90 degrees right without moving , 'M' for move 1 unit through the direction you face. For Example (LMLMRMRMMM)" ,PromptNo=5}
            };
        }
        public List<Prompts> PromptList { get; set; }
        public class Prompts
        {
            public int PromptNo { get; set; }
            public string Prompt { get; set; }
        }
    }
}