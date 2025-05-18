using Core.Exceptions;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Rules;

public class BlacklistBusinessRules
{
    private readonly IBlacklistRepository _blacklistRepository;

    public BlacklistBusinessRules(IBlacklistRepository blacklistRepository)
    {
        _blacklistRepository = blacklistRepository;
    }

    public async Task CheckIfApplicantIsAlreadyBlacklisted(int applicantId)
    {
        var blacklist = await _blacklistRepository.GetAsync(b => b.ApplicantId == applicantId);
        if (blacklist != null)
            throw new BusinessException("This applicant is already blacklisted.");
    }

    public void ValidateReason(string reason)
    {
        if (string.IsNullOrWhiteSpace(reason))
            throw new BusinessException("Reason cannot be empty.");
    }
} 