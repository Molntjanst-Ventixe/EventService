using Application.Models;

namespace Application.Services
{
    public interface IEventService
    {
        Task<EventResult> CreateEventAsync(CreateEventRequest request);
        Task<EventResult<IEnumerable<Event>>> GetAllAsync();
        Task<EventResult<Event?>> GetAsync(string eventId);
    }
}