﻿using HR.LeaveManagement.Application.DTOs.LeaveType;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Requests;

public class GetLeaveTypeDetailQuery : IRequest<LeaveTypeDto>
{
    public int Id { get; set; }
}
