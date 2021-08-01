using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MANIPULATEDATA.Model
{

    public class MEMBER
    {
        [Key]
        public int id { get; set; }
        public int groupId { get; set; }
        public string name { get; set; }
        public int score { get; set; }
    }
}
