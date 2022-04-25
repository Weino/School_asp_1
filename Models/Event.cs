using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace asp_assign_1.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Organizer Organizer { get; set; }
        public string Description { get; set; }
        public string Place { get; set; }
        public DateTime Date { get; set; }

        [Display(Name = "Spots Available")]
        public int SpotsAvailable { get; set; }

        public List<Attendee> Attendees { get; set; }
    }
}
