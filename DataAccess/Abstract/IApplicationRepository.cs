using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract;

public interface IApplicationRepository : IAsyncRepository<Application>, IRepository<Application>
{
} 