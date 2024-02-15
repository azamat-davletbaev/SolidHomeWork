using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace SolidApp.Models
{
    /// <summary>
    /// Класс модели для вью
    /// Принцип единственной ответственности - этот класс только для вью, вся логика игры вынесена в отдельный класс
    /// </summary>
    public class MainWindowViewModel : ObservableObject
    {        
        private int _num;
        private int _minNumber;
        private int _maxNumber;
        private int _attemptsCount;        
        private string _statusMessage = string.Empty;

        public int Num
        {
            get { return _num; }
            set
            {
                _num = value;
                OnPropertyChanged("Num");
            }
        }

        public int MinNumber
        {
            get { return _minNumber; }
            set
            {
                _minNumber = value;
                OnPropertyChanged("MinNumber");
            }
        }

        public int MaxNumber
        {
            get { return _maxNumber; }
            set
            {
                _maxNumber = value;
                OnPropertyChanged("MaxNumber");
            }
        }

        public int AttemptsCount
        {
            get { return _attemptsCount; }
            set
            {
                _attemptsCount = value;                
                OnPropertyChanged("AttemptsCount");
            }
        }

        public string StatusMessage
        {
            get { return _statusMessage; }
            set
            {
                _statusMessage = value;
                OnPropertyChanged("StatusMessage");
            }
        }

        public RelayCommand GuessApply { get; set; }
        public RelayCommand NewGameApply { get; set; }

        public IPlay play { get; set; } // Принцип инверсии зависимостей-> передаем управление в IPlay

        public MainWindowViewModel()
        {
            play = new Play();
            play.StatusAction = (status) => StatusMessage = status;
            play.StatusAction?.Invoke("Введите диапазон значений, количество попыток и нажмите кнопку 'Новая игра'");

            Num = 0;
            MinNumber = 0;
            MaxNumber = 0;
            AttemptsCount = 0;

            
            GuessApply = new RelayCommand(() => play.GuessAction(Num));
            NewGameApply = new RelayCommand(() => play.NewGameAction(MinNumber, MaxNumber, AttemptsCount));            
        }                
    }
}
