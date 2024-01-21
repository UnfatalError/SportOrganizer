namespace VoxTeneo.SportOrganizer.Application.DTO
{
    public class SportEvent
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public string EventType { get; set; }
        public int OrganizerId { get; set; }
        public Organizer Organizer { get; set; }
    }
}