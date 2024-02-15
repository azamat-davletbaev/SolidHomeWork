using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SolidApp.Models
{
    public interface IPlay
    {        
        public int Number { get; set; }        
        public void GuessAction(int Num);
        public void NewGameAction(int MinNumber, int MaxNumber, int AttemptsCount);
        
        public delegate void StatusActionDelegate(string status);
        public StatusActionDelegate StatusAction { get; set; }
    }
}
