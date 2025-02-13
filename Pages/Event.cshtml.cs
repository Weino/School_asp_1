﻿using asp_assign_1.Data;
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
    public class EventModel : PageModel
    {
        private readonly EventDbContext _ctx;

        public EventModel(EventDbContext ctx)
        {
            _ctx = ctx;
        }

        public IList<Event> Event {  get; set; }  

        public async Task OnGetAsync()
        {
            Event = await _ctx.Events.Include(@event => @event.Organizer).ToListAsync();
        }
    }
}
