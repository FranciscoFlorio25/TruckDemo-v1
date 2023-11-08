using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TruckDemo_v1.Application.DTO.Identity.Users;
using TruckDemo_v1.Application.DTO.Result;
using TruckDemo_v1.Domain.Entities.Identity;

namespace TruckDemo_v1.Application.UseCases.Users.GetAllUsers
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersRequest, Result<GetAllUsersResponse>>
    {
        public readonly UserManager<ApplicationUser> _userManager;
        public GetAllUsersHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Result<GetAllUsersResponse>> Handle(GetAllUsersRequest request, CancellationToken cancellationToken)
        {
            var userQuery = _userManager.Users.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(request.Search))
            {
                userQuery = userQuery.Where(x => x.Email!.ToLower().Contains(request.Search.ToLower()));
                
              
            }
            
            var users = await userQuery.Select(async x => new GetAllUserItem
            {
                Id = x.Id,
                Email = x.Email,
                FirstName = (await _userManager.GetClaimsAsync(x)).FirstOrDefault(c => c.Type == "firstname")?.Value,
                LastName = (await _userManager.GetClaimsAsync(x)).FirstOrDefault(c => c.Type == "lastname")?.Value
            });

        }
    }
}
