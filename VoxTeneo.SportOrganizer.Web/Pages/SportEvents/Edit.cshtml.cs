using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VoxTeneo.SportOrganizer.Application.DTO;
using VoxTeneo.SportOrganizer.Application.Interfaces;

namespace VoxTeneo.SportOrganizer.Web.Pages.SportEvents
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public SportEvent SportEvent { get; set; }
        [BindProperty]
        public int OrganizerId { get; set; }

        private readonly IOrganizerService _service;

        public EditModel(IOrganizerService service)
        {
            _service = service;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var sportEvent = await _service.GetSportEvent(id);
            SportEvent = sportEvent;
            OrganizerId = sportEvent.Organizer.Id;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            SportEvent.OrganizerId = OrganizerId;
            await _service.UpdateSportEvent(SportEvent);

            return RedirectToPage("/Organizers/OrganizerDetails", new { id = OrganizerId });
        }
    }
}
