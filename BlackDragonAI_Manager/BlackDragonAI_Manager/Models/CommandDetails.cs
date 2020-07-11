using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlackDragonAI_Manager.Models
{
    public class CommandDetails
    {
        public string Id { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "The command name is too long. Should be no longer than 255 characters.")]
        [RegularExpression("![^ \\n]+", ErrorMessage = "Invalid command name")]
        public string Command { get; set; }

        [Required]
        [StringLength(510, ErrorMessage = "The message is too long. Should be no longer than 510 characters.")]
        public string Message { get; set; }
        public string OriginalCommand { get; set; }

        [Required]
        [EnumDataType(typeof(EPermission), ErrorMessage = "Invalid permission.")]
        public EPermission Permission { get; set; } = EPermission.EVERYONE;
        
        [Required]
        public uint Timer { get; set; } = 60;
    }
}
