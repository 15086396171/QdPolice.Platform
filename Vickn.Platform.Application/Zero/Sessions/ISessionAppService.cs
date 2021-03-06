﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Vickn.Platform.Sessions.Dto;

namespace Vickn.Platform.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();

        Task SetCurrentCulture(CultureInput input);
    }
}
