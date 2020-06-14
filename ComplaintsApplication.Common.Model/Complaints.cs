using System;
using System.ComponentModel.DataAnnotations;

namespace ComplaintsApplication.Common.Model
{
    public class Complaints
    {
        public int Id { get; set; }
        public string ComplaintDescription { get; set; }
        public int? ComplaintBy { get; set; }
        public DateTime ComplaintDate { get; set; } = DateTime.Now;
        public bool IsResolved { get; set; } = false;
    }    
}
