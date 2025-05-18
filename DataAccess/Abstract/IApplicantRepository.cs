using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract;

public interface IApplicantRepository : IAsyncRepository<Applicant>, IRepository<Applicant>
{
} 