namespace asp_assign_1.Models
{
    public class AttendeeEvent
    {
        public int Id { get; set; }
        public Attendee Attendee { get; set; }
        public Event Event { get; set; }
    }
}
