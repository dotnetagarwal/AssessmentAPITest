namespace ESOC.CLTPull.Infrastructure.Data
{
    using System;
    using System.Threading.Tasks;
    using ESOC.CLTPull.Core.Contracts;
    public sealed class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly CLTPULLContext _context;
        private bool _disposed;

        public UnitOfWork(CLTPULLContext context) => this._context = context;

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<int> Save()
        {
            int affectedRows = await this._context
                .SaveChangesAsync()
                .ConfigureAwait(false);
            return affectedRows;
        }

        private void Dispose(bool disposing)
        {
            if (!this._disposed && disposing)
            {
                this._context.Dispose();
            }

            this._disposed = true;
        }
    }
}
