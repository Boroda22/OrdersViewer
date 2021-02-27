using OrdersViewer.Model;
using OrdersViewer.Service;

using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace OrdersViewer.ViewModel
{
    /// <summary>
    /// Модель представления сотрудника
    /// </summary>
    public class EmployeeWindowViewModel : INotifyPropertyChanged
    {

        /// <summary>
        /// Сотрудник
        /// </summary>
        private Employee employeeTmp;
        /// <summary>
        /// Идентификатор сотрудника
        /// </summary>
        private int id;


        /// <summary>
        /// Обработчик сохранения сотрудника
        /// </summary>
        private void SaveEmployee()
        {
            employeeTmp.Id = id;
            employeeTmp.Name = Name;
            employeeTmp.Surname = Surname;
            employeeTmp.Middlename = MiddleName;
            employeeTmp.DateOfBirth = DateOfBirth;
            employeeTmp.SexId = SelectedSex.Id;
            employeeTmp.SubdivisionId = SelecedSubdivision.Id;
            
            OnPropertyChanged("CanClose");
        }



        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// Отчество
        /// </summary>
        public string MiddleName { get; set; }
        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Коллекция подразделений
        /// </summary>
        public ObservableCollection<Subdivision> Subdivisions { get; set; }
        /// <summary>
        /// Половая принадлежность
        /// </summary>
        public ObservableCollection<Sex> Sexes { get; set; }
        /// <summary>
        /// Выбранное подразделение
        /// </summary>
        public Subdivision SelecedSubdivision { get; set; }
        /// <summary>
        /// Выбранный пол
        /// </summary>
        public Sex SelectedSex { get; set; }


        /// <summary>
        /// Возвращает сотрудника
        /// </summary>
        /// <returns></returns>
        public Employee GetEmployee()
        {
            return employeeTmp;
        }



        /// <summary>
        /// Команда сохранения сотрудника
        /// </summary>
        public ICommand SaveEmployeeCommand
        {
            get { return new DelegateCommand(SaveEmployee); }
        }




        public EmployeeWindowViewModel(Employee employee)
        {
            employeeTmp = new Employee();
            id = employee.Id;
            Name = employee.Name;
            Surname = employee.Surname;
            MiddleName = employee.Middlename;
            DateOfBirth = employee.DateOfBirth;
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
