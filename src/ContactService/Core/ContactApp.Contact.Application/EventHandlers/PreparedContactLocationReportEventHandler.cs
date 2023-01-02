using AutoMapper;
using ContactApp.Contact.Domain.Events;
using ContactApp.Report.Domain.Messages;
using MassTransit;
using MediatR;

namespace ContactApp.Contact.Application.EventHandlers;

public class PreparedContactLocationReportEventHandler : INotificationHandler<PreparedContactLocationReportEvent>
{
    private readonly IBusControl _busControl;
    private readonly IMapper _mapper;

    public PreparedContactLocationReportEventHandler(IBusControl busControl, IMapper mapper)
    {
        _busControl = busControl;
        _mapper = mapper;
    }

    public async Task Handle(PreparedContactLocationReportEvent notification, CancellationToken cancellationToken)
    {
        var message = _mapper.Map<PreparedContactLocationReportMessage>(notification);

        await _busControl.Publish(message: message, cancellationToken: cancellationToken);        
    }
}
