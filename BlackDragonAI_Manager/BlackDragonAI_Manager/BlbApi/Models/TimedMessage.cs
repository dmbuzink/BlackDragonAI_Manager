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
        [Range(0, int.MaxValue, ErrorMessage = "The interval has to be 0 or greater")]
        public int IntervalInMinutes { get; set; } = 30;
        [Range(0, int.MaxValue, ErrorMessage = "The offset has to be 0 or greater")]
        public int OffsetInMinutes { get; set; } = 0;
    }
}
