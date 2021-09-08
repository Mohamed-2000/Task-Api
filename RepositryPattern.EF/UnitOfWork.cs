using RepositryPattern.Core;
using RepositryPattern.Core.Interfaces;
using RepositryPattern.Core.Models;
using RepositryPattern.EF.Repositries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositryPattern.EF
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly RepoDbContext _context;

        // add property for each interface we have in our application

        public IBaseRepositry<client> clients { get; private set; }
        public IBaseRepositry<Calls> calls { get; private set; }
        public UnitOfWork(RepoDbContext context)
        {
            _context = context;

            calls = new BaseRepositry<Calls>(_context);
            clients = new BaseRepositry<client>(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> Complete()
        {
            return _context.SaveChanges();
        }
    }
}
