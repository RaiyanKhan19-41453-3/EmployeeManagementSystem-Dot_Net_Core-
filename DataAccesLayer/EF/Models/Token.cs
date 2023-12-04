using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.EF.Models
{
    public class Token
    {
        [Key]
        public int Id { get; set; }
        public string TokenKey { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ExpiredAt { get; set;}

        [ForeignKey("User")]
        public string UserName { get; set; }

        public virtual User User { get; set; }
    }
}
