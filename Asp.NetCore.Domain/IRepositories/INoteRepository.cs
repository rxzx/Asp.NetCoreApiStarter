using Asp.NetCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.NetCore.Domain.IRepositories
{
    public interface INoteRepository : IBaseRepository<Note, int>, IDisposable
    {
        //Task<List<Note>> GetAll(CancellationToken ct = default(CancellationToken));
        //Task<Note> Get(int id);
        //Task<Note> Insert(Note entity);
        //Task<Note> Update(Note entity);
        //Task<bool> Delete(int id);
    }
}
