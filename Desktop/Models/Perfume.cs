using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Models
{
    public class Perfume
    {
        public int? id { get; set; }
        public DateTime? created_at { get; set; }
        public string marca { get; set; }
        public string genero { get; set; }
        public string tipo { get; set; }
        public int tamaño_ml { get; set; }
        public string tipo_envase { get; set; }
        public int? precio { get; set; }
        public string nombre { get; set; }
    }
}
