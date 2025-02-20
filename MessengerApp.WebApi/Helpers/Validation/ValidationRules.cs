﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerApp.WebApi.Helpers;

public class ValidationRules
{
    public IEnumerable<String> Numbers { get; set; }
    public IEnumerable<String> Symbols { get; set; }
}