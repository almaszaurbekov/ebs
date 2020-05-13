using Common;
using DataAccess.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.Entities
{
    public class Log
    {
        [Key]
        public int Id { get; set; }

        [ScaffoldColumn(false)]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [ScaffoldColumn(false)]
        public EbsLoggerLevel Level { get; set; }

        [ScaffoldColumn(false)]
        public string LevelText { get; set; }

        [ScaffoldColumn(false)]
        public string Message { get; set; }

        /// <summary>
        /// Identifier of the influenced object
        /// </summary>
        [ScaffoldColumn(false)]
        public string InfluencedObjectId { get; set; }
    }
}
