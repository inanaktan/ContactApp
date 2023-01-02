using AutoMapper;
using ContactApp.Report.Application.Features.Commands.CompletePreparedReport;
using ContactApp.Report.Domain.Messages;
using MassTransit;
using MediatR;

namespace ContactApp.Report.Application.Consumers;

public class PreparedContactLocationReportMessageConsumer : IConsumer<PreparedContactLocationReportMessage>
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public PreparedContactLocationReportMessageConsumer(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task Consume(ConsumeContext<PreparedContactLocationReportMessage> context)
    {
        var command = _mapper.Map<CompletePreparedReportCommand>(context.Message);
        await _mediator.Send(request: command, cancellationToken: context.CancellationToken);
    }
}
