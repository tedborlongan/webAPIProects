using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Primer.Infrastracture
{
    public interface ICustomController
    {
        Task<long> GetPageSize(CancellationToken cToken);
        Task PostUrl(string newUrl, CancellationToken cToken); 
    } 
}
