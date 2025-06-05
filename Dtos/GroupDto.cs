using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorSuperApp.Dtos
{
    public class GroupDto
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;

        public List<MediaDto> Medias { get; set; } = [];
    }
}