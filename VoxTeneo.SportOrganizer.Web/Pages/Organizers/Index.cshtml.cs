using Microsoft.AspNetCore.Mvc.RazorPages;
using VoxTeneo.SportOrganizer.Application.DTO;
using VoxTeneo.SportOrganizer.Application.Interfaces;

namespace VoxTeneo.SportOrganizer.Web.Pages.Organizers
{
    public class IndexModel : PageModel
    {
        public List<Organizer> Organizers { get; set; }
        public string PreviousPageUrl { get; set; }
        public string NextPageUrl { get; set; }
        public string CurrentPageUrl { get; set; }

        private readonly IOrganizerService _organizerService;

        public IndexModel(IOrganizerService organizerService)
        {
            _organizerService = organizerService;
        }

        public async Task OnGetAsync(string pageUrl)
        {
            CurrentPageUrl = pageUrl;
            var result = await _organizerService.GetOrganizers(pageUrl);
            Organizers = result.Data;
            PreviousPageUrl = result.Meta.Pagination.Links.Previous;
            NextPageUrl = result.Meta.Pagination.Links.Next;
        }
    }
}
