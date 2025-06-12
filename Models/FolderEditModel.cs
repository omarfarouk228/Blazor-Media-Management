using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSuperApp.Models
{
    public class FolderEditModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Le nom est requis")]
        public string Name { get; set; } = "";

        public int? ParentId { get; set; }
    }
}