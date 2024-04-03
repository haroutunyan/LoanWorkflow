using AutoMapper;
using LoanWorkflow.DAL.Core.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace LoanWorkflow.Api.Abstractions
{
    public class ApiContext(
        ILogger<ApiContext> logger,
        IMapper mapper,
        IDbContextAccessor dbContextAccessor)
    {
        public ILogger Logger { get; } = logger;
        public IMapper Mapper { get; } = mapper;
        public IDbContextAccessor DbContextAccessor { get; } = dbContextAccessor;
    }

    public class UserContext(
        ControllerBase controller)
    {
        public long UserId => long.Parse(controller.User.Claims.Single(x => x.Type == "userId").Value);
    }
}
