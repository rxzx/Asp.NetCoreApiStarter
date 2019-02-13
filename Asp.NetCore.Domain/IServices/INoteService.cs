using Asp.NetCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.NetCore.Domain.Services
{
    public interface INoteService
    {

        Task<List<Note>> GetAll(CancellationToken ct = default(CancellationToken));
        Task<Note> Get(int Id,CancellationToken ct = default(CancellationToken));
        Task<Note> Create(Note item, CancellationToken ct = default(CancellationToken));
        Task<Note> Delete(int Id, CancellationToken ct = default(CancellationToken));
    }



}
