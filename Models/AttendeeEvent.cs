namespace asp_assign_1.Models
{
    public class AttendeeEvent
    {
        public int AttendeeEventId { get; set; }
        public int AttendeeId { get; set; }
        public int EventId { get; set; }

        public Attendee Attendee { get; set; }
        public Event Event { get; set; }
    }
}
