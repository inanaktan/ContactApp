using ContactApp.Contact.Application.Features.Commands.PrepareLocationReport;
using ContactApp.Contact.Domain.Message;
using MassTransit;
using MediatR;

namespace ContactApp.Contact.Application.Consumers;

public class PrepareLocationReportMessageConsumer : IConsumer<PrepareLocationReportMessage>
{
    private readonly IMediator _mediator;

    public PrepareLocationReportMessageConsumer(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task Consume(ConsumeContext<PrepareLocationReportMessage> context)
    {
        var command = new PrepareContactLocationReportCommand() { ReportId = context.Message.ReportId };
        await _mediator.Send(command, context.CancellationToken);
    }
}
