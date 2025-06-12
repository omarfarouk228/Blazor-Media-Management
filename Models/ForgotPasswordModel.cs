using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSuperApp.Models
{
    public class ForgotPasswordModel
    {
        [Required(ErrorMessage = "L'adresse mail est requise")]
        public string Email { get; set; } = string.Empty;
    }
}