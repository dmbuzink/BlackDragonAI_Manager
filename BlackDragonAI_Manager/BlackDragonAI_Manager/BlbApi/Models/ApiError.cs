using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackDragonAI_Manager.BlbApi.Models
{
    public class ApiError
    {
        public string Message { get; set; }
        public int Code { get; set; }
        public DateTime DateTime { get; set; }
    }
}
