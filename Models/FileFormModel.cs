using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSuperApp.Models
{
    public class FileFormModel
    {
        [Required(ErrorMessage = "Le nom est requis")]
        public string Name { get; set; } = "";

        [Required(ErrorMessage = "Le dossier est requis")]
        public int FolderId { get; set; }
        public string? Content { get; set; }
    }
}