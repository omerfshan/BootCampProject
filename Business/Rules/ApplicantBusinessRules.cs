using Core.Exceptions;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Rules;

public class ApplicantBusinessRules
{
    private readonly IApplicantRepository _applicantRepository;
    private readonly IBlacklistRepository _blacklistRepository;

    public ApplicantBusinessRules(
        IApplicantRepository applicantRepository,
        IBlacklistRepository blacklistRepository)
    {
        _applicantRepository = applicantRepository;
        _blacklistRepository = blacklistRepository;
    }

    public async Task CheckIfNationalIdentityExists(string nationalIdentity)
    {
        var applicant = await _applicantRepository.GetAsync(a => a.NationalIdentity == nationalIdentity);
        if (applicant != null)
            throw new BusinessException("A user with this national identity number already exists.");
    }

    public async Task CheckIfApplicantIsBlacklisted(int applicantId)
    {
        var blacklist = await _blacklistRepository.GetAsync(b => b.ApplicantId == applicantId);
        if (blacklist != null)
            throw new BusinessException("This applicant is blacklisted and cannot make applications.");
    }

    public async Task CheckIfApplicantExists(int applicantId)
    {
        var applicant = await _applicantRepository.GetAsync(a => a.Id == applicantId);
        if (applicant == null)
            throw new NotFoundException("Applicant not found.");
    }
} 