using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Requests;

public class DeleteLeaveAllocationCommand : IRequest
{
    public int Id { get; set; }
}
