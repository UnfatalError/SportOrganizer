using VoxTeneo.SportOrganizer.Application.DTO;

namespace VoxTeneo.SportOrganizer.Application.Interfaces
{
    public interface IOrganizerService
    {
        Task<OrganizerApiResponse<Organizer>> GetOrganizers(string url = null);
        Task<Organizer> GetOrganizer(int id);
        Task<Organizer> CreateOrganizer(Organizer organizer);
        Task<SportEvent> GetSportEvent(int id);
        Task<OrganizerApiResponse<SportEvent>> GetSportEventsByOrganizer(int organizerId);
        Task<SportEvent> CreateSportEvent(SportEvent sportEvent);
        Task<SportEvent> UpdateSportEvent(SportEvent sportEvent);
        Task DeleteSportEvent(int sportEventId);
    }
}