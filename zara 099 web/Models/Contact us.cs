using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace zara_099_web.Models
{
    public class Contact_us
    {

        [Key]
        public int Id { get; set; }
        public string username { get; set; }
        public string lastname { get; set; }
        public string number { get; set; }
        public string email { get; set; }
        public string gender { get; set; }
        public string country { get; set; }
        public string Message { get; set; }

    }
}
