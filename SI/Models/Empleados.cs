using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace SI.Models
{
    [Table("Empleados")]
    public class Empleados
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(13)]  
        public int Identidad { get; set; }

        [MaxLength(100)]
        public string Nombre { get; set; }

        [Unique]
        public DateTime Fechaing { get; set; }

        [MaxLength(50)]
        public string Puesto { get; set; }

        [MaxLength(100)]
        public string Correo { get; set; }
    }
}
