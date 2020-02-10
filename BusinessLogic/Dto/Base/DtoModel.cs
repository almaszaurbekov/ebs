using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLogic.Dto.Base
{
    public class DtoModel<T>
    {
        [Key]
        public T Id { get; set; }

        [ScaffoldColumn(false)]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
