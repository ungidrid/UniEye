using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniEye.Shared.Domain.Domain
{
    public interface ISharedIdentity
    {
        Guid IdentityGuid { get; set; }
    }
}
