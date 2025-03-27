using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Requests;

public class GetLeaveRequestDetailQuery : IRequest<LeaveRequestDto>
{
    public int Id { get; set; }
}
