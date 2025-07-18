﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Application.Models;

namespace Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventsController(IEventService eventService) : ControllerBase
{
    private readonly IEventService _eventService = eventService;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var events = await _eventService.GetAllAsync();
        return Ok(events);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var currentEvent = await _eventService.GetAsync(id);
        return currentEvent != null ? Ok(currentEvent) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateEventRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _eventService.CreateEventAsync(request);
        return result.Success ? Ok(result) : StatusCode(500, result.Error);
    }
}
