using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VoxTeneo.SportOrganizer.Application.DTO;
using VoxTeneo.SportOrganizer.Application.Interfaces;

namespace VoxTeneo.SportOrganizer.Web.Pages.Organizers
{
    public class OrganizerDetailsModel : PageModel
    {
        [BindProperty]
        public Organizer Organizer { get; set; }
        public IList<SportEvent> SportEvents { get; set; }
        public string LastPageUrl { get; set; }

        private readonly IOrganizerService _service;

        public OrganizerDetailsModel(IOrganizerService service)
        {
            _service = service;
        }

        public async Task<IActionResult> OnGetAsync(int id, string lastPageUrl)
        {
            Organizer = await _service.GetOrganizer(id);
            if (Organizer == null)
            {
                return NotFound();
            }

            var result = await _service.GetSportEventsByOrganizer(id);
            SportEvents = result?.Data;

            LastPageUrl = lastPageUrl;

            return Page();
        }
    }
}
