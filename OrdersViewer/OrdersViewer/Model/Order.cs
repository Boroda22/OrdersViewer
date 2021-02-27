using System;

namespace OrdersViewer.Model
{
    /// <summary>
    /// Заказ
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }
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
        public DateTime DateOfOrder { get; set; } = DateTime.Now;


        public int? EmployeeId { get; set; }
        /// <summary>
        /// Автор заказа
        /// </summary>
        public virtual Employee Employee { get; set; }


        public override string ToString()
        {
            return $"Заказ №{NumberOrder} от {DateOfOrder}";
        }
    }
}
