using asp_assign_1.Data;
using asp_assign_1.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace asp_assign_1.Pages
{
    public class MyEventsModel : PageModel
    {
        private readonly EventDbContext _ctx;

        public MyEventsModel(EventDbContext ctx)
        {
            _ctx = ctx;
        }

        public Attendee Attendee {  get; set; }

        public async Task OnGetAsync()
        {
            Attendee = await _ctx.Attendees.Where(a => a.Id == 1)
                .Include(e => e.Events)
                .FirstOrDefaultAsync();
        }
    }
}
