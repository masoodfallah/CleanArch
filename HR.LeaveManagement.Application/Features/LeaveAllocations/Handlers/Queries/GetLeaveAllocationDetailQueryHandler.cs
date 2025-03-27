using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveAllocation;
using HR.LeaveManagement.Application.Features.LeaveAllocations.Requests;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Handlers.Queries;

public class GetLeaveAllocationDetailQueryHandler : IRequestHandler<GetLeaveAllocationDetailQuery, LeaveAllocationDto>
{
    ILeaveAllocationRepository _leaveAllocationRepository;
    IMapper _mapper;

    public GetLeaveAllocationDetailQueryHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
    {
        _leaveAllocationRepository = leaveAllocationRepository;
        _mapper = mapper;
    }

    public async Task<LeaveAllocationDto> Handle(GetLeaveAllocationDetailQuery request, CancellationToken cancellationToken)
    {
        var leaveAllocation = await _leaveAllocationRepository.Get(request.Id);
        return _mapper.Map<LeaveAllocationDto>(leaveAllocation);
    }
}
