using Samit_For_Entertainment.Data.Base;
using Samit_For_Entertainment.Models;

namespace Samit_For_Entertainment.Data.Services
{
    public class CINAMASSERVICE : EntityBaseRepository<CINAMA>, ICINAMASSERVICE
    {
        public CINAMASSERVICE(AppDbContext context) : base(context) { }
    
    }
}
