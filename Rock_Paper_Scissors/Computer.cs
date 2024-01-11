using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rock_Paper_Scissors
{
    public static class Computer
    {
        public static Move GetComputerMove()
        {
            var random = new Random();
            int chosenMove = random.Next(0, 3);

            return (Move)chosenMove;
        }
    }
}
