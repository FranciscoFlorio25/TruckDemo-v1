using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckDemo_v1.Application.DTO.Result;
using TruckDemo_v1.Domain.Entities.Identity;
using TruckDemo_v1.Domain.Enum;

namespace TruckDemo_v1.Application.UseCases.Roles
{
    public class GetAllRolesRequestHandler : IRequestHandler<GetAllRolesRequest, Result<GetAllRolesResponse>>
    {
        private readonly RoleManager<Role> _roleManager;

        public GetAllRolesRequestHandler(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<Result<GetAllRolesResponse>> Handle(GetAllRolesRequest request, CancellationToken cancellationToken)
        {
            var rolesNames = Enum.GetNames<RoleName>();


            var roles = await _roleManager.Roles
                .Where(x => rolesNames.Contains(x.Name))
                .Select(x => x.Name)
                .ToArrayAsync(cancellationToken);

            return new GetAllRolesResponse(roles!);

        }
    }
}
