﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace src.Web.Common
{
    public class UserSession : IUserSession
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserSession(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public bool IsAuthenticated => _httpContextAccessor.HttpContext.User?.Identity?.IsAuthenticated ?? false;

        public int Id => Convert.ToInt32(_httpContextAccessor.HttpContext.User?.FindFirst(ClaimTypes.Sid)?.Value);

        public string FirstName => _httpContextAccessor.HttpContext.User?.FindFirst(ClaimTypes.GivenName)?.Value;

        public string LastName => _httpContextAccessor.HttpContext.User?.FindFirst(ClaimTypes.Surname)?.Value;

        public string UserName => _httpContextAccessor.HttpContext.User?.FindFirst(ClaimTypes.Name)?.Value;

        public string EMRSystem => _httpContextAccessor.HttpContext.User?.FindFirst("EMRSystem")?.Value;

        public string ViewType => _httpContextAccessor.HttpContext.User?.FindFirst("ViewType")?.Value;

        public string FullName => !string.IsNullOrWhiteSpace(FirstName) ? $"{LastName}, {FirstName}" : LastName;

        public bool IsInRole(string roleName)
        {
            return _httpContextAccessor.HttpContext.User.HasClaim(ClaimTypes.Role, roleName);
        }
    }
}
