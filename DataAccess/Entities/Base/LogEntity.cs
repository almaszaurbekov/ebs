using Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities.Base
{
    public class LogEntity<T>
    {
        [Key]
        public T Id { get; set; }

        [ScaffoldColumn(false)]
        public EbsLoggerLevel Level { get; set; }

        [ScaffoldColumn(false)]
        public string LevelText { get; set; }

        [ScaffoldColumn(false)]
        public string Message { get; set; }

        [ScaffoldColumn(false)]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
