using HR.LeaveManagement.Application.DTOs.LeaveType;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Requests;

public class UpdateLeaveTypeCommand : IRequest<Unit>
{
    public UpdateLeaveTypeDto LeaveTypeDto { get; set; }
}
