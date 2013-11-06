﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ALCT.Models
{
    public class ALCTContext : DbContext
    {
        public ALCTContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<EstadoModel> Estados { get; set; }
        public DbSet<CidadeModel> Cidades { get; set; }
        public DbSet<ImovelModel> Imoveis { get; set; }
    }
}