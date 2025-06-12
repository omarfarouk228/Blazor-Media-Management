using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSuperApp.Dtos
{
    public class FolderDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int? ParentId { get; set; }
        public List<FolderDto> SubFolders { get; set; } = [];
        public List<FileDto> Files { get; set; } = [];
        public bool IsExpanded { get; set; }
        public bool HasFiles { get; set; }

    }
}