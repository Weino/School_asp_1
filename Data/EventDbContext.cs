using asp_assign_1.Models;
using Microsoft.EntityFrameworkCore;

namespace asp_assign_1.Data
{
    public class EventDbContext : DbContext
    {
            public EventDbContext(DbContextOptions<EventDbContext> options)
                : base(options)
            {

            }

            public DbSet<Event> Events { get; set; }
            public DbSet<Organizer> Organizers { get; set; }
            public DbSet<Attendee> Attendees { get; set; }

    }
}
