using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract;

public interface IInstructorRepository : IAsyncRepository<Instructor>, IRepository<Instructor>
{
} 