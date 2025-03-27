﻿using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Requests;

public class CreateLeaveRequestCommand : IRequest<int>
{
    public CreateLeaveRequestDto LeaveRequestDto { get; set; }
}
