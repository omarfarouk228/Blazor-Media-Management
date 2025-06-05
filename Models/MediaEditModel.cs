using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSuperApp.Models
{
    public class MediaEditModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom est requis")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Le nom doit contenir entre 3 et 100 caractères")]
        public string Name { get; set; } = String.Empty;
        public string? Type { get; set; }
        public int Status { get; set; } = 1;

        [Required(ErrorMessage = "Le groupe est requis")]
        public int GroupID { get; set; }
    }
}