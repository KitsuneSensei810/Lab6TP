using Lab6.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Lab6.ViewModels
{
    class MyViewModel : INotifyPropertyChanged
    {
        
        private int selectedX;
        private List<int> x = new List<int>();//явно указываю все множители Х
        private string _synchronizedText;

        public List<int> X //создание асессоров доступа - с публичными методами для всех полей
        {
            get
            {
                return x;
            }
            set
            {
                //SynchronizedText = "";
                //SelectedX = 0;
                //x = new List<int>();
                x = value;
                RaisePropertyChanged("X");
                RaisePropertyChanged("SynchronizedText");
            }
        }

        public string SynchronizedText {
            get
            {
                return _synchronizedText;
            }

            
            set
            {
                _synchronizedText = value;
                RaisePropertyChanged("SynchronizedText");
            }
        }
        public int SelectedX
        {

            get
            {
                return selectedX;
            }

            set
            {
                selectedX = value;
                RaisePropertyChanged("SelectedX");
            }
        }


        private RelayCommand clickCommand;
        public RelayCommand ClickCommand
        {
            get
            {
                return clickCommand ??
                  (clickCommand = new RelayCommand(obj =>
                  {  //при нажатии на кнопку производится расчет результата умножения
                      Numbers numbers = new Numbers();  //создадим объект класса модели
                      //for(int i = 0; i <= int.Parse(SynchronizedText); ++i)
                      //{
                      //    x.Add(i);
                      //}
                      List<int> Temp = new List<int>();
                      
                      numbers.returnResult(SynchronizedText, ref Temp); //вызовем функцию расчета результата и присвоим ее значение
                      X = Temp;
                      
                      //соответствующему полю Result
                  }));
            }
        }

        
        private RelayCommand resetCommand;
        public RelayCommand ResetCommand
        {
            get
            {
                return resetCommand ??
                  (resetCommand = new RelayCommand(obj =>
                  {
                      SynchronizedText = "";
                      SelectedX = 0;
                      X = new List<int>();//обнуление результата
                      //SelectedX = 0; //и значений выбранных чисел
                  }));
            }
           
            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string p)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(p));
            }
        }


        public MyViewModel() //пустой конструктор
        {
        }
    }
}
