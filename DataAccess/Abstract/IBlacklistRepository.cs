using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract;

public interface IBlacklistRepository : IAsyncRepository<Blacklist>, IRepository<Blacklist>
{
} 