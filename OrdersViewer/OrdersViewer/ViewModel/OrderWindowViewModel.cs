using OrdersViewer.Model;
using OrdersViewer.Service;

using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace OrdersViewer.ViewModel
{
    public class OrderWindowViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Заказ
        /// </summary>
        private Order orderTmp;
        /// <summary>
        /// идентификатор записи
        /// </summary>
        private int id;

        /// <summary>
        /// Опопвещение о сохранении
        /// </summary>
        private void SaveOrder()
        {
            orderTmp.Id = id;
            orderTmp.NumberOrder = NumberOrder;
            orderTmp.Partner = Partner;
            orderTmp.DateOfOrder = DateOfOrder;
            orderTmp.EmployeeId = SelectedEmployee.Id;

            OnPropertyChanged("CanClose");
        }




        /// <summary>
        /// Номер заказа
        /// </summary>
        public int NumberOrder { get; set; }
        /// <summary>
        /// Контрагент
        /// </summary>
        public string Partner { get; set; }
        /// <summary>
        /// Дата заказа
        /// </summary>
        public DateTime DateOfOrder { get; set; }
        /// <summary>
        /// Автор заказа
        /// </summary>
        public Employee SelectedEmployee { get; set; }
        /// <summary>
        /// Коллекция сотрудников
        /// </summary>
        public ObservableCollection<Employee> Empoyees { get; set; }

        /// <summary>
        /// Получить заказ
        /// </summary>
        /// <returns></returns>
        public Order GetOrder()
        {
            return orderTmp;
        }


        /// <summary>
        /// Команда сохранения подразделения
        /// </summary>
        public ICommand SaveOrderCommand
        {
            get { return new DelegateCommand(SaveOrder); }
        }


        public OrderWindowViewModel(Order order)
        {
            orderTmp = new Order();
            id = order.Id;
            NumberOrder = order.NumberOrder;
            Partner = order.Partner;
            DateOfOrder = order.DateOfOrder;
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
