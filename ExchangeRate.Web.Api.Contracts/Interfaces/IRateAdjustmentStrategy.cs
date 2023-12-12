﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRateAPI.Web.Api.Contracts
{
    public interface IRateAdjustmentStrategy
    {
        public T GetAdjustedRate<T>(PartnerRate partnerRate, Country country) where T : IComparable<T>;
    }
}
