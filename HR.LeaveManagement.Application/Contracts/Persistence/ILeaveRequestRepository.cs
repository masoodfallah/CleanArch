using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Contracts.Persistence;

public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
{
    Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? approvalStatus);
}
