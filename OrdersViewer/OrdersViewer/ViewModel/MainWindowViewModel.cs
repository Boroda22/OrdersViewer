using OrdersViewer.Model;
using OrdersViewer.Service;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace OrdersViewer.ViewModel
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        /// <summary>
		/// Основная модель
		/// </summary>
		private MainModel mainModel;


        /// <summary>
        /// Обновление коллекции сотрудников
        /// </summary>
        private void updateEmpoyees()
        {
            Employees = mainModel.GetAllEmployees();
            OnPropertyChanged("Employees");
        }
        /// <summary>
        /// Обновление коллекции подразделений
        /// </summary>
        private void updateSubdivisions()
        {
            Subdivisions = mainModel.GetAllSubdivisions();
            OnPropertyChanged("Subdivisions");
        }
        /// <summary>
        /// Обновление коллекции заказов
        /// </summary>
        private void updateOrders()
        {
            Orders = mainModel.GetAllOrders();
            OnPropertyChanged("Orders");
        }
        

        /// <summary>
        /// Обработчик подписки сохранения сотрудника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void canSaveEmployeeEvent(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "CanClose")
            {
                var employeeView = sender as EmployeeWindowViewModel;
                mainModel.AddNewEmployee(employeeView.GetEmployee());
            }
        }
        /// <summary>
        /// Обработчик подписки изменения сотрудника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void canEditEmployeeEvent(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "CanClose")
            {
                var employeeView = sender as EmployeeWindowViewModel;
                mainModel.EditEmployee(employeeView.GetEmployee());
            }
        }
        /// <summary>
        /// Обработчик подписки сохранения подразделения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void canSaveSubdivisionEvent(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "CanClose")
            {
                var subdivView = sender as SubdivisionWindowViewModel;
                mainModel.AddNewSubdivision(subdivView.GetSubdivision());
            }
        }
        /// <summary>
        /// Обработчик подписки изменения подразделения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void canEditSubdivisionEvent(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "CanClose")
            {
                var subdivView = sender as SubdivisionWindowViewModel;
                mainModel.EditSubdivision(subdivView.GetSubdivision());
            }
        }
        /// <summary>
        /// Обработчик подписки сохранения заказа
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void canSaveOrderEvent(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "CanClose")
            {
                var orderView = sender as OrderWindowViewModel;
                mainModel.AddNewOrder(orderView.GetOrder());
            }
        }
        /// <summary>
        /// Обработчик подписки изменения заказа
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void canEditOrderEvent(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "CanClose")
            {
                var orderView = sender as OrderWindowViewModel;
                mainModel.EditOrder(orderView.GetOrder());
            }
        }



        #region ОТКРЫТЫЕ СВОЙСТВА

        /// <summary>
        /// Выбранное подразделение
        /// </summary>
        public Subdivision SelectedSubdivision { get; set; }
        /// <summary>
        /// Выбранный сотрудник
        /// </summary>
        public Employee SelectedEmployee { get; set; }
        /// <summary>
        /// Выбранный заказ
        /// </summary>
        public Order SelectedOrder { get; set; }



        /// <summary>
        /// Коллекция подразделений
        /// </summary>
        public ObservableCollection<Subdivision> Subdivisions { get; set; }
        /// <summary>
        /// Коллекция сотрудников
        /// </summary>
        public ObservableCollection<Employee> Employees { get; set; }
        /// <summary>
        /// Коллекция заказов
        /// </summary>
        public ObservableCollection<Order> Orders { get; set; }


        #endregion


        #region ОБРАБОТЧИКИ КОМАНД

        /// <summary>
        /// Добавление нового подразделения
        /// </summary>
        private void AddNewSubdivision()
        {
            SubdivisionWindowViewModel subdivisionWindowViewModel = new SubdivisionWindowViewModel(mainModel.GetNewSubdivision());
            subdivisionWindowViewModel.Employees = mainModel.GetAllEmployees();
            subdivisionWindowViewModel.PropertyChanged += canSaveSubdivisionEvent;

            ChildWindowDialogManager.Show(subdivisionWindowViewModel, true, App.Current.MainWindow);
            updateSubdivisions();
        }
        /// <summary>
        /// Редактирование подразделения
        /// </summary>
        private void EditSubdivision()
        {
            if(SelectedSubdivision != null)
            {
                SubdivisionWindowViewModel subdivisionWindowViewModel = new SubdivisionWindowViewModel(SelectedSubdivision);
                subdivisionWindowViewModel.Employees = mainModel.GetAllEmployees();
                subdivisionWindowViewModel.SelectedEmployee = subdivisionWindowViewModel.Employees.Where(ss => ss.Id == SelectedSubdivision.EmployeeId).FirstOrDefault();
                subdivisionWindowViewModel.PropertyChanged += canEditSubdivisionEvent;

                ChildWindowDialogManager.Show(subdivisionWindowViewModel, true, App.Current.MainWindow);
                updateSubdivisions();
            }
        }
        /// <summary>
        /// Добавление нового сотрудника
        /// </summary>
        private void AddNewEmployee()
        {
            EmployeeWindowViewModel employeeWindowViewModel = new EmployeeWindowViewModel(mainModel.GetNewEmployee());
            employeeWindowViewModel.Subdivisions = mainModel.GetAllSubdivisions();
            employeeWindowViewModel.Sexes = mainModel.GetSexes();
            employeeWindowViewModel.PropertyChanged += canSaveEmployeeEvent;

            ChildWindowDialogManager.Show(employeeWindowViewModel, true, App.Current.MainWindow);
            updateEmpoyees();
        }
        /// <summary>
        /// Редактирование сотрудника
        /// </summary>
        private void EditEmployee()
        {
            if(SelectedEmployee != null)
            {
                EmployeeWindowViewModel employeeWindowViewModel = new EmployeeWindowViewModel(SelectedEmployee);
                employeeWindowViewModel.Subdivisions = mainModel.GetAllSubdivisions();
                employeeWindowViewModel.SelecedSubdivision = employeeWindowViewModel.Subdivisions.Where(ss => ss.Id == SelectedEmployee.SubdivisionId).FirstOrDefault();
                employeeWindowViewModel.Sexes = mainModel.GetSexes();
                employeeWindowViewModel.SelectedSex = employeeWindowViewModel.Sexes.Where(ss => ss.Id == SelectedEmployee.SexId).FirstOrDefault();
                employeeWindowViewModel.PropertyChanged += canEditEmployeeEvent;

                ChildWindowDialogManager.Show(employeeWindowViewModel, true, App.Current.MainWindow);
                updateEmpoyees();
            }
        }
        /// <summary>
        /// Добавление нового заказа
        /// </summary>
        private void AddNewOrder()
        {
            OrderWindowViewModel orderWindowViewModel = new OrderWindowViewModel(mainModel.GetNewOrder());
            orderWindowViewModel.Empoyees = mainModel.GetAllEmployees();
            orderWindowViewModel.PropertyChanged += canSaveOrderEvent;

            ChildWindowDialogManager.Show(orderWindowViewModel, true, App.Current.MainWindow);
            updateOrders();
        }
        /// <summary>
        /// Редактирование заказа
        /// </summary>
        private void EditOrder()
        {
            if(SelectedOrder != null)
            {
                OrderWindowViewModel orderWindowViewModel = new OrderWindowViewModel(SelectedOrder);
                orderWindowViewModel.Empoyees = mainModel.GetAllEmployees();
                orderWindowViewModel.SelectedEmployee = orderWindowViewModel.Empoyees.Where(ss => ss.Id == SelectedOrder.EmployeeId).FirstOrDefault();
                orderWindowViewModel.PropertyChanged += canEditOrderEvent;

                ChildWindowDialogManager.Show(orderWindowViewModel, true, App.Current.MainWindow);
                updateOrders();
            }
        }
        /// <summary>
        /// Удаление заказа
        /// </summary>
        private void DeleteOrder()
        {
            if(SelectedOrder != null)
            {
                mainModel.DeleteOrder(SelectedOrder);
                updateOrders();
            }
        }

        #endregion


        #region КОМАНДЫ

        /// <summary>
        /// Команда добавления нового подразделения
        /// </summary>
        public ICommand AddNewSubdivisionCommand
        {
            get { return new DelegateCommand(AddNewSubdivision); }
        }
        /// <summary>
        /// Команда редактирования подразделения
        /// </summary>
        public ICommand EditSubdivisionCommand
        {
            get { return new DelegateCommand(EditSubdivision); }
        }
        /// <summary>
        /// Команда добавления нового сотрудника
        /// </summary>
        public ICommand AddNewEmployeeCommand
        {
            get { return new DelegateCommand(AddNewEmployee); }
        }
        /// <summary>
        /// Команда редактирования сотрудника
        /// </summary>
        public ICommand EditEmployeeCommand
        {
            get { return new DelegateCommand(EditEmployee); }
        }
        /// <summary>
        /// Команда добавления нового заказа
        /// </summary>
        public ICommand AddNewOrderCommand
        {
            get { return new DelegateCommand(AddNewOrder); }
        }
        /// <summary>
        /// Команда редактирования заказа
        /// </summary>
        public ICommand EditOrderCommand
        {
            get { return new DelegateCommand(EditOrder); }
        }
        /// <summary>
        /// Команда удаления заказа
        /// </summary>
        public ICommand DeleteOrderCommand
        {
            get { return new DelegateCommand(DeleteOrder); }
        }

        #endregion



        public MainWindowViewModel(MainModel model)
        {
            mainModel = model;
            updateEmpoyees();
            updateOrders();
            updateSubdivisions();
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
