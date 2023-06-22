using Application.Contracts.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Persistence.Context;

namespace Persistence.Repositories;

public class OrderRepository : BaseRepository<Order, BaseDbContext>, IOrderRepository
{
    public OrderRepository(BaseDbContext context, IHttpContextAccessor contextAccessor) : base(context,
        contextAccessor)
    {
    }
}