using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSuperApp.Dtos
{
    public class FileDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int FolderId { get; set; }
        public string? Content { get; set; }
    }
}