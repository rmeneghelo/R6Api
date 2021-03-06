﻿using R6Api.Domain.Models.Entities;
using System.Threading.Tasks;

namespace R6Api.Domain.Interfaces.Respositories
{
    public interface IAuthenticationRepository
    {
        Task<AuthorizedUser> GetAuthenticatedUserAsync();
    }
}
