using HR.LeaveManagement.Application.DTOs.LeaveType;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Requests;

public class GetLeaveTypeListQuery : IRequest<List<LeaveTypeDto>>
{
}
