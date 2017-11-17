using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    class AI : player
    {
        protected Random randomSeed = new Random();

        public AI()
        {
            name = "Al Ingram";
        }

        public override int getMove()
        {
            return randomSeed.Next(0, 5);

        }


    }
}
