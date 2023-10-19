﻿using AllianzInsuranceBackend.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllianzInsuranceBackend.Application.Interfaces
{
    public interface IPremiumService
    {
        Task<ApiResponse<List<Premium>>> GetAllPremium();
    }
}
