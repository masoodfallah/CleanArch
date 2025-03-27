using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveAllocation.Validatros;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveAllocations.Requests;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Handlers.Commands;

public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, int>
{
    ILeaveAllocationRepository _leaveAllocationRepository;
    ILeaveTypeRepository _leaveTypeRepository;
    IMapper _mapper;

    public CreateLeaveAllocationCommandHandler(
        ILeaveAllocationRepository leaveAllocationRepository,
        ILeaveTypeRepository leaveTypeRepository,
        IMapper mapper)
    {
        _leaveAllocationRepository = leaveAllocationRepository;
        _leaveTypeRepository = leaveTypeRepository;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateLeaveAllocationDtoValidator(_leaveTypeRepository);
        var validationResult = await validator.ValidateAsync(request.LeaveAllocationDto);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult);


        var leaveAllocation = _mapper.Map<LeaveAllocation>(request.LeaveAllocationDto);

        leaveAllocation = await _leaveAllocationRepository.Add(leaveAllocation);

        return leaveAllocation.Id;
    }
}
