using Core.DataAccess.EntityFramework;
using Core.Entities;
using DataAccess.Abstract;

namespace DataAccess.Concrete.EntityFramework;

public class EfUserRepository : EfRepositoryBase<User, BootcampProjectContext>, IUserRepository
{
} 