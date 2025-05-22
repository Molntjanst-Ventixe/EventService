using Application.Models;
using Microsoft.Extensions.Logging;
using Persistence.Entities;
using Persistence.Repositories;

namespace Application.Services;

public class EventService(IEventRepository eventRepository) : IEventService
{
    private readonly IEventRepository _eventRepository = eventRepository;

    public async Task<EventResult> CreateEventAsync(CreateEventRequest request)
    {
        try
        {
            var eventEntity = new EventEntity
            {
                Title = request.Title,
                Date = request.Date,
                Location = request.Location,
                Price = request.Price,
            };

            var result = await _eventRepository.AddAsync(eventEntity);
            return result.Success
                ? new EventResult { Success = true }
                : new EventResult { Success = false, Error = result.Error };
        }
        catch (Exception ex)
        {
            return new EventResult { Success = false, Error = ex.Message };
        }
    }

    public async Task<EventResult<IEnumerable<Event>>> GetAllAsync()
    {
        var result = await _eventRepository.GetAllAsync();
        var events = result.Result?.Select(x => new Event
        {
            Id = x.Id,
            Title = x.Title,
            Date = x.Date,
            Location = x.Location,
            Price = x.Price,
        });

        return new EventResult<IEnumerable<Event>> { Success = true, Result = events };
    }

    public async Task<EventResult<Event?>> GetAsync(string eventId)
    {
        var result = await _eventRepository.GetAsync(x => x.Id == eventId);
        if (result.Success && result.Result != null)
        {
            var currentEvent = new Event
            {
                Id = result.Result.Id,
                Title = result.Result.Title,
                Date = result.Result.Date,
                Location = result.Result.Location,
                Price = result.Result.Price,
            };

            return new EventResult<Event?> { Success = true, Result = currentEvent };
        }

        return new EventResult<Event?> { Success = false, Error = "Event not found" };

    }
}
