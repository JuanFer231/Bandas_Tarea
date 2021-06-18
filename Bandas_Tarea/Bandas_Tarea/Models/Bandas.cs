using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bandas_Tarea.Models
{
    public class Bandas
    {

        [Key]

        public int BandaId { get; set; }

        [Display(Name = "Nombre de la banda")]
        public string BandaNombre { get; set; }

        [Display(Name ="Genero de la banda")]
        public string BandaGenero { get; set; }
    }
}
