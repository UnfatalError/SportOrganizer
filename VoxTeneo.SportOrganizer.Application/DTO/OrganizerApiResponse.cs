using VoxTeneo.SportOrganizer.Application.DTO.Metadata;

namespace VoxTeneo.SportOrganizer.Application.DTO
{
    public class OrganizerApiResponse<T>
    {
        public List<T> Data { get; set; }
        public Meta Meta { get; set; }
    }
}
