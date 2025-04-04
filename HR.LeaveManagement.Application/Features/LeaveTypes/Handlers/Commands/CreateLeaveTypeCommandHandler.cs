﻿using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveType.Validators;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Responses;
using HR.LeaveManagement.Domain;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands;

public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, BaseCommandResponse>
{
    ILeaveTypeRepository _leaveTypeRepository;
    IMapper _mapper;

    public CreateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
    {
        _leaveTypeRepository = leaveTypeRepository;
        _mapper = mapper;
    }

    public async Task<BaseCommandResponse> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse();
        var validator = new CreateLeaveTypeDtoValidator();
        var validationResult = await validator.ValidateAsync(request.LeaveTypeDto);

        if (!validationResult.IsValid)
        {
            response.Success = false;
            response.Message = "Creation Failed";
            response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
        }

        var leaveType = _mapper.Map<LeaveType>(request.LeaveTypeDto);

        leaveType = await _leaveTypeRepository.Add(leaveType);

        response.Success = true;
        response.Message = "Creation Successful";
        response.Id = leaveType.Id;

        return response;
    }
}
