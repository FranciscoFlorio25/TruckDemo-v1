using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckDemo_v1.Application.DTO.Result;
using TruckDemo_v1.Domain.Entities.Identity;
using TruckDemo_v1.Domain.Enum;

namespace TruckDemo_v1.Application.UseCases.Users.CreateDefaultUser
{
    public class CreateDefaultUserHandler : IRequestHandler<CreateDefaultUserRequest, Result>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public CreateDefaultUserHandler(UserManager<ApplicationUser> userManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<Result> Handle(CreateDefaultUserRequest request, CancellationToken cancellationToken)
        {
            var existingUser = _userManager.FindByNameAsync("admin@deere.com.ar").Result;

            if (existingUser == null)
            {
                ApplicationUser user = new("admin@deere.com.ar")
                {
                    Email = "admin@deere.com.ar"
                };

                var result = _userManager.CreateAsync(user, "admin1234").Result;

                if (result.Succeeded)
                {

                    _userManager.AddToRoleAsync(user, RoleName.Admin.ToString()).Wait();


                }

                return "Usuario default creado";
            }
            return "usuario default ya existe";
        }
    }
}

