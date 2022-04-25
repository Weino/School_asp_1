using asp_assign_1.Data;
using asp_assign_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace asp_assign_1.Pages
{
    public class JoinEventModel : PageModel
    {
        private readonly EventDbContext _ctx;

        public JoinEventModel(EventDbContext ctx)
        {
            _ctx = ctx;
        }

        public Event Event { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Event = await _ctx.Events
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Event == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {

              if (!ModelState.IsValid)
              {
                    return Page();
              }

              if (id == null)
              {
                    return NotFound();
              }

            var attendee = await _ctx.Attendees.Where(a => a.Id == 1)
              .Include(e => e.Events)
              .FirstOrDefaultAsync();
            var join = await _ctx.Events.Where(e => e.Id == id).FirstOrDefaultAsync();

            attendee.Events.Add(join);
            await _ctx.SaveChangesAsync();

            return RedirectToPage("./MyEvents");
        }
    }
}
