
namespace ESOC.CLTPull.Core.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IUnitOfWork
    {
        /// <summary>
        ///     Applies all database changes.
        /// </summary>
        /// <returns>Number of affected rows.</returns>
        Task<int> Save();
    }
}
