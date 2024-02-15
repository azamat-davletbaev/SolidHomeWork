using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidApp.Models
{
    public interface IRandomizer
    {
        public Random Rnd { get; set; }        
        public int GetRandomNumber(int MinNumber, int MaxNumber)
        {
            return Rnd.Next(MinNumber, MaxNumber);
        }
    }
}
