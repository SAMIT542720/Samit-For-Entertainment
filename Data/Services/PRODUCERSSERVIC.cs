using Samit_For_Entertainment.Data.Base;
using Samit_For_Entertainment.Models;

namespace Samit_For_Entertainment.Data.Services
{
    public class PRODUCERSSERVIC : EntityBaseRepository<PRODUCER>, IPRODUCERSSERVIC
    {
        public PRODUCERSSERVIC(AppDbContext context) : base(context)
        {

        }
    }
}
