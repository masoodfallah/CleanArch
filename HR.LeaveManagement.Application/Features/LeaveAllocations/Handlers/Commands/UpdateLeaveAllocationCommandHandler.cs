using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveAllocation.Validatros;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveAllocations.Requests;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Handlers.Commands;

public class UpdateLeaveAllocationCommandHandler : IRequestHandler<UpdateLeaveAllocationCommand, Unit>
{
    ILeaveAllocationRepository _leaveAllocationRepository;
    ILeaveTypeRepository _leaveTypeRepository;
    IMapper _mapper;

    public UpdateLeaveAllocationCommandHandler(
        ILeaveAllocationRepository leaveAllocationRepository,
        ILeaveTypeRepository leaveTypeRepository,
        IMapper mapper)
    {
        _leaveAllocationRepository = leaveAllocationRepository;
        _leaveTypeRepository = leaveTypeRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateLeaveAllocationCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateLeaveAllocationDtoValidator(_leaveTypeRepository);
        var validationResult = await validator.ValidateAsync(request.LeaveAllocationDto);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult);


        var leaveAllocation = await _leaveAllocationRepository.Get(request.LeaveAllocationDto.Id);

        _mapper.Map(request.LeaveAllocationDto, leaveAllocation);

        await _leaveAllocationRepository.Update(leaveAllocation);

        return Unit.Value;
    }
}
