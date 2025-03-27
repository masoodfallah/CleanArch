using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Requests;

public class UpdateLeaveRequestCommand : IRequest<Unit>
{
    public int Id { get; set; }

    public UpdateLeaveRequestDto LeaveRequestDto { get; set; }

    public ChangeLeaveRequestApprovalDto ChangeLeaveRequestApprovalDto { get; set; }
}
