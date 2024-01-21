using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VoxTeneo.SportOrganizer.Application.DTO;
using VoxTeneo.SportOrganizer.Application.Interfaces;

namespace VoxTeneo.SportOrganizer.Web.Pages.SportEvents
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public SportEvent SportEvent { get; set; } = new SportEvent();
        [BindProperty]
        public int OrganizerId { get; set; }

        private readonly IOrganizerService _service;

        public CreateModel(IOrganizerService service)
        {
            _service = service;
        }

        public IActionResult OnGet(int organizerId)
        {
            OrganizerId = organizerId;
            SportEvent.OrganizerId = organizerId;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var sportEvent = await _service.CreateSportEvent(SportEvent);

            return RedirectToPage("/Organizers/OrganizerDetails", new { id = sportEvent.OrganizerId });
        }
    }
}