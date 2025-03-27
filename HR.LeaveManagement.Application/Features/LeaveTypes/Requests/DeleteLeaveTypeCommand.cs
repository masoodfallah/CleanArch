using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Requests;

public class DeleteLeaveTypeCommand : IRequest
{
    public int Id { get; set; }
}
