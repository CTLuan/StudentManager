﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using StudentManager.Application.Features.User.DTOs;

namespace StudentManager.Application.Features.Users.Queries
{
    public class GetUsersQuery : IRequest<List<UserDto>>
    {

    }
}
