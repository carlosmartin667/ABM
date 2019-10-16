using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ABM.Models.viewModels
{
    public class TablaaViewModel
    {

        public int Id { get; set; }

        [Required]
        [Display(Name ="nombre")]
        [StringLength(50)]
        public string nombre { get; set; }
        [EmailAddress]
        [Required]
        [Display(Name = "correo electronico")]
        public string correo { get; set; }



        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "fecha_nacimiento")]
        public DateTime fecha_nacimiento { get; set; }

    }
}