﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowd.View
{
    public interface IBaseView
    {
        Dictionary<int, String> Status { get; set; }
    }
}
