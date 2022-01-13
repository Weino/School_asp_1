using asp_assign_1.Models;
using Microsoft.EntityFrameworkCore;

namespace asp_assign_1.Data
{
    public class EventDbContext
    {
        public class EventsDbContext : DbContext
        {
            public EventsDbContext(DbContextOptions<EventsDbContext> options)
                : base(options)
            {

            }
            public DbSet<AttendeeEvent> AttendeeEvents { get; set; }
            public DbSet<Organizer> Organizers { get; set; }
            public DbSet<Attendee> Attendees { get; set; }
            public DbSet<Event> Events { get; set; }


        }
    }
}
