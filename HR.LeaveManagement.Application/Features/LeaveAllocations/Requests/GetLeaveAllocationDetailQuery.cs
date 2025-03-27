using HR.LeaveManagement.Application.DTOs.LeaveAllocation;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Requests;

public class GetLeaveAllocationDetailQuery : IRequest<LeaveAllocationDto>
{
    public int Id { get; set; }
}
