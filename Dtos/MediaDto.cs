using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSuperApp.Dtos
{
    public class MediaDto
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public int GroupID { get; set; }
        public string? Type { get; set; }
        public int Status { get; set; }
        public string? Path { get; set; }
    }
}