using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlackDragonAI_Manager.BlbApi.Models
{
    public class TimedMessage
    {
        public Guid Guid { get; set; } = Guid.NewGuid();
        [Required(ErrorMessage = "Command name is required")]
        public string Command { get; set; }
    }
}
