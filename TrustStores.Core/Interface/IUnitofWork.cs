﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrustStores.Core.Model;

namespace TrustStores.Core.Interface
{
    public  interface IUnitofWork : IDisposable
    {
        IProduct Products { get; }

        int Save();
    }
}
