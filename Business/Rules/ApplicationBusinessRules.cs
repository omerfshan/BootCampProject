using Core.Exceptions;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Enums;

namespace Business.Rules;

public class ApplicationBusinessRules
{
    private readonly IApplicationRepository _applicationRepository;
    private readonly IBootcampRepository _bootcampRepository;
    private readonly IBlacklistRepository _blacklistRepository;

    public ApplicationBusinessRules(
        IApplicationRepository applicationRepository,
        IBootcampRepository bootcampRepository,
        IBlacklistRepository blacklistRepository)
    {
        _applicationRepository = applicationRepository;
        _bootcampRepository = bootcampRepository;
        _blacklistRepository = blacklistRepository;
    }

    public async Task CheckIfApplicationExists(int applicantId, int bootcampId)
    {
        var application = await _applicationRepository.GetAsync(
            a => a.ApplicantId == applicantId && a.BootcampId == bootcampId);
        if (application != null)
            throw new BusinessException("This applicant has already applied to this bootcamp.");
    }

    public async Task CheckIfApplicantIsBlacklisted(int applicantId)
    {
        var blacklist = await _blacklistRepository.GetAsync(b => b.ApplicantId == applicantId);
        if (blacklist != null)
            throw new BusinessException("This applicant is blacklisted and cannot make applications.");
    }

    public void ValidateStateTransition(ApplicationState currentState, ApplicationState newState)
    {
        var validTransitions = new Dictionary<ApplicationState, ApplicationState[]>
        {
            { ApplicationState.PENDING, new[] { ApplicationState.APPROVED, ApplicationState.REJECTED, ApplicationState.IN_REVIEW, ApplicationState.CANCELLED } },
            { ApplicationState.IN_REVIEW, new[] { ApplicationState.APPROVED, ApplicationState.REJECTED } },
            { ApplicationState.APPROVED, new[] { ApplicationState.CANCELLED } },
            { ApplicationState.REJECTED, new[] { ApplicationState.PENDING } },
            { ApplicationState.CANCELLED, Array.Empty<ApplicationState>() }
        };

        if (!validTransitions[currentState].Contains(newState))
            throw new BusinessException($"Cannot transition from {currentState} to {newState}.");
    }
} 