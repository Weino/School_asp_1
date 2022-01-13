using asp_assign_1.Data;
using asp_assign_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
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

        public IList<AttendeeEvent> AttendeeEvent {  get; set; }
        public async void OnGetAsync()
        {
                AttendeeEvent = await _ctx.AttendeeEvents
                .Include(r => r.Event)
                .Include(r => r.Attendee).ToListAsync(); 
        }
    }
}
