using OrdersViewer.Model;
using OrdersViewer.Service;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace OrdersViewer.ViewModel
{
    public class SubdivisionWindowViewModel : INotifyPropertyChanged
    {

        private Subdivision subdivisionTmp;

        /// <summary>
        /// Идентификатор подразделения
        /// </summary>
        private int id;

        /// <summary>
        /// Сохранение подразделение
        /// </summary>
        private void SaveSubdivision()
        {
            subdivisionTmp.Id = id;
            subdivisionTmp.Title = Title;

            subdivisionTmp.EmployeeId = SelectedEmployee.Id;

            OnPropertyChanged("CanClose");
        }



        /// <summary>
        /// Название подразделения
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Руководитель
        /// </summary>
        public Employee SelectedEmployee { get; set; }

        /// <summary>
        /// Коллекция сотрудников
        /// </summary>
        public ObservableCollection<Employee> Employees { get; set; }


        /// <summary>
        /// Подразделение
        /// </summary>
        /// <returns></returns>
        public Subdivision GetSubdivision()
        {
            return subdivisionTmp;
        }


        /// <summary>
        /// Команда сохранения подразделения
        /// </summary>
        public ICommand SaveSubdivisionCommand
        {
            get { return new DelegateCommand(SaveSubdivision); }
        }


        public SubdivisionWindowViewModel(Subdivision subdivision)
        {
            subdivisionTmp = new Subdivision();
            id = subdivision.Id;
            Title = subdivision.Title;
        }

        // реализация обработчиков INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
