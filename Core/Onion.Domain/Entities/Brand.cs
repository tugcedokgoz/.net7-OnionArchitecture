﻿using Onion.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Domain.Entities
{
	public class Brand : EntityBase
	{
        public Brand(string name)
        {
			Name = name;
		}
        public Brand()
        {
            
        }
        public required string Name { get; set; }
    }
}
