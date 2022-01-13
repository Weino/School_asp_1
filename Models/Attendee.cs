using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace asp_assign_1.Models
{
    public class Attendee
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        public List<Event> Events { get; set; }
    }
}
