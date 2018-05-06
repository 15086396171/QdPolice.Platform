using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vickn.Platform.EntityTools
{
    public class EntityBase<T>
    {
        protected EntityBase()
        {
            UpdateTime = DateTime.Now;
        }
        [Key]
        public T Id { get; set; }

        public DateTime UpdateTime { get; set; }
    }
}
