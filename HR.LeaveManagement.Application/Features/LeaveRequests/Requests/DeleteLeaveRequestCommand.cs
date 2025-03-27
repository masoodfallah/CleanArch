using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Requests;

public class DeleteLeaveRequestCommand : IRequest
{
    public int Id { get; set; }
}
