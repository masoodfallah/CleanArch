using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Infrastructure;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.DTOs.LeaveRequest.Validators;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveRequests.Requests;
using HR.LeaveManagement.Application.Models;
using HR.LeaveManagement.Domain;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Handlers.Commands;

public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, int>
{
    ILeaveRequestRepository _leaveRequestRepository;
    ILeaveTypeRepository _leaveTypeRepository;
    IEmailSender _emailSender;
    IMapper _mapper;

    public CreateLeaveRequestCommandHandler(
        ILeaveRequestRepository leaveRequestRepository,
        ILeaveTypeRepository leaveTypeRepository,
        IEmailSender emailSender,
        IMapper mapper)
    {
        _leaveRequestRepository = leaveRequestRepository;
        _leaveTypeRepository = leaveTypeRepository;
        _emailSender = emailSender;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateLeaveRequestDtoValidator(_leaveTypeRepository);
        var validationResult = await validator.ValidateAsync(request.LeaveRequestDto);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult);


        var leaveRequest = _mapper.Map<LeaveRequest>(request.LeaveRequestDto);

        leaveRequest = await _leaveRequestRepository.Add(leaveRequest);


        var email = new Email
        {
            To = "masoodfallah68@gmail.com",
            Body = $"Your leave request for {request.LeaveRequestDto.StartDate:D} to {request.LeaveRequestDto.EndDate:D} " +
            $"has been submitted successfully.",
            Subject = "Leave Request Submitted"
        };

        try
        {
            await _emailSender.SendEmail(email);
        }
        catch (Exception ex)
        {
            //log or handle error, but don't throw...
        }

        return leaveRequest.Id;
    }
}
