using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Contracts.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
}