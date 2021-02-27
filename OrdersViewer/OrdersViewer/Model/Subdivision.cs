using System.ComponentModel.DataAnnotations;

namespace OrdersViewer.Model
{
    /// <summary>
    /// Подразделение
    /// </summary>
    public class Subdivision
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Название
        /// </summary>
        public string Title { get; set; }


        public int? EmployeeId { get; set; }
        /// <summary>
        /// Руководитель
        /// </summary>
        [Required]
        public virtual Employee Employee { get; set; }
    }
}
