using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            //sample data
            if (args.Length == 0)
            {
                args = new List<string>{ 
                    "5 5",
                    "1 2 N",
                    "LMLMLMLMM", 
                    "3 3 E", 
                    "MMRMMRMRRM" }.ToArray();
            }
           

            var terrainInfoRow = args[0];

            var terrain = new Terrain(Convert.ToInt32(terrainInfoRow.Split(' ')[0]),Convert.ToInt32(terrainInfoRow.Split(' ')[1]));

            for (var i = 1; i < args.Length  ; i += 2)
            {
                var position = args[i].Split(' ');
                var actions = args[i+1].Select(p=> Enum.Parse<EAction>(p.ToString())).ToList();

                var roger = new Rover(Convert.ToInt32(position[0]), Convert.ToInt32(position[1]), Enum.Parse<EDirection>(position[2]));

                roger.Operate(actions, terrain);

                Console.WriteLine(roger);
            } 
        }
    }
}