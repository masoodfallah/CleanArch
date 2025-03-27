using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.DTOs.LeaveType;
using HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Queries;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests;
using HR.LeaveManagement.Application.Profiles;
using HR.LeaveManagement.Application.UnitTest.Mocks;
using Moq;
using Shouldly;

namespace HR.LeaveManagement.Application.UnitTest.LeaveTypes.Queries;

public class GetLeaveTypeListHandlerTests
{
    IMapper _mapper;
    Mock<ILeaveTypeRepository> _mockRepo;

    public GetLeaveTypeListHandlerTests()
    {
        _mockRepo = MockLeaveTypeRepository.GetLeaveTypeRepository();

        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
    }

    [Fact]
    public async Task GetLeaveTypeListTest()
    {
        var handler = new GetLeaveTypeListQueryHandler(_mockRepo.Object, _mapper);

        var result = await handler.Handle(new GetLeaveTypeListQuery(), CancellationToken.None);

        result.ShouldBeOfType<List<LeaveTypeDto>>();
        result.Count.ShouldBe(2);
    }


}
