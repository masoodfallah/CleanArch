using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveRequest.Validators;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveRequests.Requests;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Handlers.Commands;

public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, Unit>
{
    ILeaveRequestRepository _leaveRequestRepository;
    ILeaveTypeRepository _leaveTypeRepository;
    IMapper _mapper;

    public UpdateLeaveRequestCommandHandler(
        ILeaveRequestRepository leaveRequestRepository,
        ILeaveTypeRepository leaveTypeRepository,
        IMapper mapper)
    {
        _leaveRequestRepository = leaveRequestRepository;
        _leaveTypeRepository = leaveTypeRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateLeaveRequestDtoValidator(_leaveTypeRepository);
        var validationResult = await validator.ValidateAsync(request.LeaveRequestDto);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult);


        var leaveRequest = await _leaveRequestRepository.Get(request.Id);

        if (request.LeaveRequestDto is not null)
        {
            _mapper.Map(request.LeaveRequestDto, leaveRequest);

            await _leaveRequestRepository.Update(leaveRequest);

        }
        else if (request.ChangeLeaveRequestApprovalDto is not null)
        {
            await _leaveRequestRepository.ChangeApprovalStatus(leaveRequest, request.ChangeLeaveRequestApprovalDto.Approved);
        }


        return Unit.Value;
    }
}
