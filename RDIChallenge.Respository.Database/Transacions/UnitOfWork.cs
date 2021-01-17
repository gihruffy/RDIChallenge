using RDIChallenge.Domain.Interfaces.Services;
using RDIChallenge.Respository.Database.Context;
using System;
using System.Threading.Tasks;

namespace RDIChallenge.Respository.Database.Transacions
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RDIChallengeContext _context;

        public UnitOfWork(RDIChallengeContext context)
        {
            _context = context;
        }
        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }


    }

}
