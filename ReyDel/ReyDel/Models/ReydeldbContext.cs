﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 
using System.Data;
using System.Data.Entity;

namespace ReyDel.Models
{
    public class ReydeldbContext :DbContext
    {
        static ReydeldbContext()
        {
            Database.SetInitializer<ReydeldbContext>(null);

        }
        public ReydeldbContext() : base("Name=ReydeldbContext")
        {
        }
        public DbSet<MaterialGradeMaster> MaterialGradeMasters { get; set; }
    }
}