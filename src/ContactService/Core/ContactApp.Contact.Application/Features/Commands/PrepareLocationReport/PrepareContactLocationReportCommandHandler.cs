using ContactApp.Contact.Application.Abstractions;
using ContactApp.Contact.Domain.Enums;
using ContactApp.Contact.Domain.Events;
using ContactApp.Contact.Domain.Models;
using MediatR;

namespace ContactApp.Contact.Application.Features.Commands.PrepareLocationReport;

public class PrepareContactLocationReportCommandHandler : IRequestHandler<PrepareContactLocationReportCommand>
{
    private readonly IContactRepository _contactRepository;
    private readonly IMediator _mediator;

    public PrepareContactLocationReportCommandHandler(IContactRepository contactRepository, IMediator mediator)
    {
        _contactRepository = contactRepository;
        _mediator = mediator;
    }

    public async Task<Unit> Handle(PrepareContactLocationReportCommand request, CancellationToken cancellationToken)
    {
        var contacts = await _contactRepository.GetListAync();

        PreparedContactLocationReportEvent notification = new()
        {
            ReportId = request.ReportId
        };

        if (contacts != null && contacts.Any())
        {
            var reports = contacts
                        .Where(c => c.InformationType == ContactInformationType.Location)
                        .GroupBy(c => c.Content)
                        .Select(c => new ContactLocationReport
                        {
                            ReportId = request.ReportId,
                            Location = c.Key
                        }).ToList();

            foreach (var report in reports)
            {
                var personIds = contacts.Where(c => c.InformationType == ContactInformationType.Location && c.Content.Equals(report.Location)).Select(c => c.PersonId).Distinct();

                report.RegisteredPersonCount = personIds.Count();
                report.RegisteredPhoneNumberCount = contacts.Count(c => c.InformationType == ContactInformationType.PhoneNumber && personIds.Contains(c.PersonId));
            }

            notification.ContactLocationReports = reports;
        }

        await _mediator.Publish(notification: notification, cancellationToken: cancellationToken);
        return Unit.Value;
    }
}
