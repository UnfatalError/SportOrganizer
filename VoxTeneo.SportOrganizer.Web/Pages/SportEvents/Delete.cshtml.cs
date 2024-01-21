using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VoxTeneo.SportOrganizer.Application.Interfaces;

namespace VoxTeneo.SportOrganizer.Web.Pages.SportEvents
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public int SportEventId { get; set; }
        [BindProperty]
        public int OrganizerId { get; set; }

        private readonly IOrganizerService _service;

        public DeleteModel(IOrganizerService service)
        {
            _service = service;
        }

        public void OnGet(int id, int organizerId)
        {
            SportEventId = id;
            OrganizerId = organizerId;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _service.DeleteSportEvent(SportEventId);

            return RedirectToPage("/Organizers/OrganizerDetails", new { id = OrganizerId });
        }
    }
}
