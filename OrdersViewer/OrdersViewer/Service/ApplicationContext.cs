using OrdersViewer.Model;

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersViewer.Service
{
    /// <summary>
    /// Контекст базы данных
    /// </summary>
    class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("DefaultConnection")
        {
        }

        /// <summary>
        /// Сотрудники
        /// </summary>
        public IDbSet<Employee> Employees { get; set; }
        /// <summary>
        /// Подразделения
        /// </summary>
        public IDbSet<Subdivision> Subdivisions { get; set; }
        /// <summary>
        /// Заказы
        /// </summary>
        public IDbSet<Order> Orders { get; set; }
        /// <summary>
        /// Половая принадлежность
        /// </summary>
        public IDbSet<Sex> Sexes { get; set; }
    }
}
