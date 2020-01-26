using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.Entities.Base
{
    public abstract class AuditableEntity<T>
    {
        [Key]
        public T Id { get; set; }

        /// <summary>
        /// Пользователь-создатель
        /// </summary>
        [MaxLength(256)]
        [ScaffoldColumn(false)]
        public string CreatedBy { get; set; } = "ebs";

        /// <summary>
        /// Дата создания
        /// </summary>
        [ScaffoldColumn(false)]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Пользователь, обновивший запись
        /// </summary>
        [MaxLength(256)]
        [ScaffoldColumn(false)]
        public string UpdatedBy { get; set; } = null;

        /// <summary>
        /// Дата обновления
        /// </summary>
        [ScaffoldColumn(false)]
        public DateTime? UpdatedDate { get; set; } = null;

        /// <summary>
        /// Удалена ли запись
        /// </summary>
        [ScaffoldColumn(false)]
        public bool IsDeleted { get; set; } = false;

        /// <summary>
        /// Пользователь, удаливший запись
        /// </summary>
        [MaxLength(256)]
        [ScaffoldColumn(false)]
        public string DeletedBy { get; set; } = null;

        /// <summary>
        /// Дата удаления
        /// </summary>
        [ScaffoldColumn(false)]
        public DateTime? DeletedDate { get; set; } = null;
    }
}
