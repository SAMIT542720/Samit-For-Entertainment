﻿using Samit_For_Entertainment.Data.Base;
using Samit_For_Entertainment.Models;

namespace Samit_For_Entertainment.Data.Services
{
    public class ACTORSSERVICE : EntityBaseRepository<ACTOR>, IACTORSSERVICE
    {
        public ACTORSSERVICE(AppDbContext context) : base(context) { }
    }
}
