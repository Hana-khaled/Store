﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.HandelResponse
{
    public class ValidationErrorResponse : CustomException
    {
        public ValidationErrorResponse() : base(500)
        {

        }

        public IEnumerable<string> Errors { get; set; }

    }
}
