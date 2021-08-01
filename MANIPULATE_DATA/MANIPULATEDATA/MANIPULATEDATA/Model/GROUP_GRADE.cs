using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MANIPULATEDATA.Model
{
    public class GROUP_GRADE
    {
        [Key]
        public string groupName { get; set; }
        public int groupMembers { get; set; }
        public decimal? groupScore { get; set; }
        public string groupGrade { get; set; }
    }
}
