﻿using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveAllocation;
using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using HR.LeaveManagement.Application.DTOs.LeaveType;
using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        #region LeaveType
        CreateMap<LeaveType, LeaveTypeDto>().ReverseMap();
        CreateMap<LeaveType, CreateLeaveTypeDto>().ReverseMap();
        CreateMap<LeaveType, UpdateLeaveTypeDto>().ReverseMap();
        #endregion

        #region LeaveRequest
        CreateMap<LeaveRequest, LeaveRequestDto>().ReverseMap();
        CreateMap<LeaveRequest, LeaveRequestListDto>().ReverseMap();
        CreateMap<LeaveRequest, CreateLeaveRequestDto>().ReverseMap();
        CreateMap<LeaveRequest, UpdateLeaveRequestDto>().ReverseMap();
        #endregion

        #region LeaveAllocation
        CreateMap<LeaveAllocation, LeaveAllocationDto>().ReverseMap();
        CreateMap<LeaveAllocation, CreateLeaveAllocationDto>().ReverseMap();
        CreateMap<LeaveAllocation, UpdateLeaveAllocationDto>().ReverseMap();
        #endregion        
    }
}
