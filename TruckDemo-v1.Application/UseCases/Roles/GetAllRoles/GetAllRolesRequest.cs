﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckDemo_v1.Application.DTO.Result;

namespace TruckDemo_v1.Application.UseCases.Roles.GetAllRoles
{
    public record GetAllRolesRequest() : IRequest<Result<GetAllRolesResponse>>;
}
