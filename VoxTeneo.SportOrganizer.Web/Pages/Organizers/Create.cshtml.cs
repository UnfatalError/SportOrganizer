using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VoxTeneo.SportOrganizer.Application.DTO;
using VoxTeneo.SportOrganizer.Application.Interfaces;

namespace VoxTeneo.SportOrganizer.Web.Pages.Organizers
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Organizer Organizer { get; set; } = new Organizer();
        [BindProperty]
        public string LastPageUrl { get; set; }

        private readonly IOrganizerService _service;

        public CreateModel(IOrganizerService service)
        {
            _service = service;
        }

        public IActionResult OnGet(string lastPageUrl)
        {
            LastPageUrl = lastPageUrl;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var organizer = await _service.CreateOrganizer(Organizer);

            return RedirectToPage("/Organizers/OrganizerDetails", new { id = organizer.Id, lastPageUrl = LastPageUrl });
        }
    }
}

