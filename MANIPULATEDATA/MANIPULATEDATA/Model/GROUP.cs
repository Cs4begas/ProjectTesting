using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MANIPULATEDATA.Model
{
    public class GROUP
    {
        [Key]
        public int id { get; set; }
        public string groupName { get; set; }
        public List<MEMBER> members { get; set; }
    }
}
