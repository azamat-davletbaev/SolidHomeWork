using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SolidApp.Models
{
    /// <summary>
    /// Класс реализует геймплей
    /// принцип открытости закрытости, для внесения изменений в геймплей не обязательно менять класс вью или рандомизатор и наоборот
    /// </summary>
    public class Play : IPlay, IRandomizer // принцип разделения интерфейсов -> игра отдельно, рандомизатор в отдельном интерфейсе
    {        
        public int Number { get; set; }
        public Random Rnd { get; set; }
        public IPlay.StatusActionDelegate StatusAction { get; set; }

        public Play()
        {
            Rnd = new Random();
        }

        public void GuessAction(int Num)
        {
            if (Num == Number)
            {
                StatusAction?.Invoke("Угадали!");
                return;
            }

            if (Num > Number)
                StatusAction?.Invoke("Загаданное число меньше..");
            else                
                StatusAction?.Invoke("Загаданное число больше..");
        }

        public void NewGameAction(int minNumber, int maxNumber, int attemptsCount)
        {
            //Принцип подстановки барбары Лисков -> мы можем привести класс Play к базовому классу или интерфейсу!
            Number = ((IRandomizer)this).GetRandomNumber(minNumber, maxNumber);            
            StatusAction?.Invoke("Новая игра: угадайте число!");
        }
    }
}
