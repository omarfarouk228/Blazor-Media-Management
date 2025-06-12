using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSuperApp.Models
{
    public class ResetPasswordModel
    {
        public string Token { get; set; } = string.Empty;

        [Required(ErrorMessage = "Le mot de passe est requis")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Le mot de passe doit contenir entre 8 et 20 caractères")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "La confirmation du mot de passe est requise")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Les mots de passe ne correspondent pas")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Le mot de passe doit contenir entre 8 et 20 caractères")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}