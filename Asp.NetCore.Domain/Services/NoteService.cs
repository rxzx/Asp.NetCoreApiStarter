using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Asp.NetCore.Domain.Entities;
using Asp.NetCore.Domain.IRepositories;

namespace Asp.NetCore.Domain.Services
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository;


        public NoteService(
            INoteRepository noteRepository
            ) {
            _noteRepository = noteRepository;
        }

        public async Task<Note> Create(Note item, CancellationToken ct = default(CancellationToken))
        {
            var note = new Note();
            if (item.Id > 0)
            {
                var id = await _noteRepository.Insert(item);
                note = await _noteRepository.Get(id);
            }
            else
            {
                var id = await _noteRepository.Update(item);
                note = await _noteRepository.Get(id);
            }
            return note;
        }

        public async Task<Note> Delete(int Id, CancellationToken ct = default(CancellationToken))
        {
            var note = new Note();
            note = await _noteRepository.Get(Id);
            return note;
        }

        public async Task<Note> Get(int Id, CancellationToken ct = default(CancellationToken))
        {
            return await _noteRepository.Get(Id);
        }

        public async Task<List<Note>> GetAll(CancellationToken ct = default(CancellationToken))
        {
            return await _noteRepository.GetAll();
        }
    }
}
