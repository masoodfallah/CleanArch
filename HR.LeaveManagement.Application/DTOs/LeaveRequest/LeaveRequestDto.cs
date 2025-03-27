using HR.LeaveManagement.Application.DTOs.Common;
using HR.LeaveManagement.Application.DTOs.LeaveType;

namespace HR.LeaveManagement.Application.DTOs.LeaveRequest;

public class LeaveRequestDto : BaseDto, ILeaveRequestDto
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public LeaveTypeDto LeaveType { get; set; }
    public int LeaveTypeId { get; set; }
    public DateTime RequestedDate { get; set; }
    public string RequestComments { get; set; }
    public DateTime? ActionedDate { get; set; }
    public bool? Approved { get; set; }
    public bool Cancelled { get; set; }
}
