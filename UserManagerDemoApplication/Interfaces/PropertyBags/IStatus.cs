﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagerDemoApplication.Interfaces.PropertyBags
{
    public interface IStatus
    {
        int Id { get; set; }
        string Name { get; set; }
    }
}
