﻿using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.Entities;
using Persistence.Models;
using System.Linq.Expressions;

namespace Persistence.Repositories;

public class EventRepository(DataContext context) : BaseRepository<EventEntity>(context), IEventRepository
{
    public override async Task<RepositoryResult<IEnumerable<EventEntity>>> GetAllAsync()
    {
        try
        {
            var entities = await _table.Include(x => x.EventPackages).ToListAsync();
            return new RepositoryResult<IEnumerable<EventEntity>> { Success = true, Result = entities };
        }
        catch (Exception ex)
        {
            return new RepositoryResult<IEnumerable<EventEntity>> { Success = false, Error = ex.Message };
        }
    }

    public override async Task<RepositoryResult<EventEntity?>> GetAsync(Expression<Func<EventEntity, bool>> expression)
    {
        try
        {
            var entity = await _table.Include(x => x.EventPackages).FirstOrDefaultAsync(expression);
            if (entity == null)
            {
                throw new Exception("Entity not found");
            }
            return new RepositoryResult<EventEntity?> { Success = true, Result = entity };
        }
        catch (Exception ex)
        {
            return new RepositoryResult<EventEntity?> { Success = false, Error = ex.Message };
        }
    }
}

