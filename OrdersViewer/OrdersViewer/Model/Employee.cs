using System;

namespace OrdersViewer.Model
{
    /// <summary>
    /// Сотрудник
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }
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
        public string Middlename { get; set; }
        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime DateOfBirth { get; set; } = new DateTime(1980, 1, 1);


        public int? SexId { get; set; }
        /// <summary>
        /// Пол
        /// </summary>
        public Sex Sex { get; set; }


        public int? SubdivisionId { get; set; }
        /// <summary>
        /// Подразделение
        /// </summary>
        public Subdivision Subdivision { get; set; }


        /// <summary>
        /// Строковое представление сотрудника
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Name} {Middlename} {Surname}";
        }
    }
}
