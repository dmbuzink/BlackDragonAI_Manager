using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlackDragonAI_Manager.BlbApi.Models
{
    public class AliasInput
    {
        [Required]
        [StringLength(255, ErrorMessage = "The alias is too long. Should be no longer than 255 characters.")]
        [RegularExpression("[^ !\\n]+", ErrorMessage = "Invalid alias name")]
        public string Alias { get; set; }
    }
}
