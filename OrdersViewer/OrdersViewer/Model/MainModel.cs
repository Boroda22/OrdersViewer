using OrdersViewer.Service;

using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;

namespace OrdersViewer.Model
{
    class MainModel
    {
        /// <summary>
        /// Возвращает отсортированную по наименованию коллекцию подразделений
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Subdivision> GetAllSubdivisions()
        {
            ObservableCollection<Subdivision> subdivisions = new ObservableCollection<Subdivision>();

            var dbContext = new ApplicationContext();

            foreach(Subdivision item in dbContext.Subdivisions.Include("Employee").OrderBy(tt => tt.Title))
            {
                subdivisions.Add(item);
            }

            return subdivisions;
        }
        /// <summary>
        /// Возвращает коллекцию сотрудников
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Employee> GetAllEmployees()
        {
            ObservableCollection<Employee> employees = new ObservableCollection<Employee>();

            var dbContext = new ApplicationContext();

            var emplTmp = dbContext.Employees.ToList();

            foreach (var item in emplTmp)
            {
                employees.Add(item);
            }

            return employees;
        }
        /// <summary>
        /// Возвращает коллекцию заказов
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Order> GetAllOrders()
        {
            ObservableCollection<Order> orders = new ObservableCollection<Order>();

            var dbContext = new ApplicationContext();

            foreach(var item in dbContext.Orders.Include("Employee").OrderBy(dd=>dd.DateOfOrder))
            {
                orders.Add(item);
            }

            return orders;
        }
        /// <summary>
        /// Возвращает коллекцию полового положения
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Sex> GetSexes()
        {
            ObservableCollection<Sex> sexes = new ObservableCollection<Sex>();

            var dbContext = new ApplicationContext();

            foreach(var item in dbContext.Sexes)
            {
                sexes.Add(item);
            }

            return sexes;
        }



        /// <summary>
        /// Новый сотрудник
        /// </summary>
        /// <returns></returns>
        public Employee GetNewEmployee()
        {
            return new Employee();
        }
        /// <summary>
        /// Новое подразделение
        /// </summary>
        /// <returns></returns>
        public Subdivision GetNewSubdivision()
        {
            return new Subdivision();
        }
        /// <summary>
        /// Новый заказ
        /// </summary>
        /// <returns></returns>
        public Order GetNewOrder()
        {
            return new Order();
        }
        


        /// <summary>
        /// Добавление нового сотрудника
        /// </summary>
        /// <param name="employee"> Сотрудник</param>
        public void AddNewEmployee(Employee employee)
        {
            var dbContext = new ApplicationContext();
            dbContext.Employees.Add(employee);
            dbContext.SaveChanges();
        }
        /// <summary>
        /// Редактирование сотрудника
        /// </summary>
        /// <param name="employee"> Сотрудник</param>
        public void EditEmployee(Employee employee)
        {
            var dbContext = new ApplicationContext();

            var tmp_employee = dbContext.Employees.Where(ss => ss.Id == employee.Id).FirstOrDefault();
            tmp_employee.Name = employee.Name;
            tmp_employee.Surname = employee.Surname;
            tmp_employee.Middlename = employee.Middlename;
            tmp_employee.DateOfBirth = employee.DateOfBirth;
            tmp_employee.SexId = employee.SexId;
            tmp_employee.SubdivisionId = employee.SubdivisionId;

            dbContext.SaveChanges();
        }
        /// <summary>
        /// Добавление нового подразделения
        /// </summary>
        /// <param name="subdivision"> Подразделение</param>
        public void AddNewSubdivision(Subdivision subdivision)
        {
            var dbContext = new ApplicationContext();
            subdivision.Employee = dbContext.Employees.Where(ss => ss.Id == subdivision.EmployeeId).FirstOrDefault();
            dbContext.Subdivisions.Add(subdivision);
            dbContext.SaveChanges();
        }
        /// <summary>
        /// Редактирование подразделения
        /// </summary>
        /// <param name="subdivision"> Подразделение</param>
        public void EditSubdivision(Subdivision subdivision)
        {
            var dbContext = new ApplicationContext();

            var tmp_division = dbContext.Subdivisions.Where(ss => ss.Id == subdivision.Id).FirstOrDefault();
            tmp_division.Title = subdivision.Title;
            tmp_division.EmployeeId = subdivision.EmployeeId;

            dbContext.SaveChanges();
        }
        /// <summary>
        /// Добавление нового заказа
        /// </summary>
        /// <param name="order"> Заказ</param>
        public void AddNewOrder(Order order)
        {
            var dbContext = new ApplicationContext();
            dbContext.Orders.Add(order);
            dbContext.SaveChanges();
        }
        /// <summary>
        /// Редактирование заказа
        /// </summary>
        /// <param name="order"> Заказ</param>
        public void EditOrder(Order order)
        {
            var dbContext = new ApplicationContext();

            var tmp_order = dbContext.Orders.Where(ss => ss.Id == order.Id).FirstOrDefault();
            tmp_order.NumberOrder = order.NumberOrder;
            tmp_order.Partner = order.Partner;
            tmp_order.EmployeeId = order.EmployeeId;

            dbContext.SaveChanges();
        }
        /// <summary>
        /// Удаление заказа
        /// </summary>
        /// <param name="order"> Заказ</param>
        public void DeleteOrder(Order order)
        {
            var dbContext = new ApplicationContext();

            var tmp_order = dbContext.Orders.Where(ss => ss.Id == order.Id).FirstOrDefault();
            dbContext.Orders.Remove(tmp_order);

            dbContext.SaveChanges();
        }
    }
}
