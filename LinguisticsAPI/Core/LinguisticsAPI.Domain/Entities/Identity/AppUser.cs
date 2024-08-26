﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinguisticsAPI.Domain.Entities.Identity
{
	public class AppUser : IdentityUser<Guid>
	{
		public string? FullName { get; set; }
	}
}
