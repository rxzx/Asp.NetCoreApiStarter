using Asp.NetCore.Domain.Entities;
using Asp.NetCore.Domain.IRepositories;
using BolForce.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Asp.NetCore.Data.Repositories
{

    public class NoteRepository : BaseRepository<Note, int>, INoteRepository
    {
        private readonly StartupDataContext _context;
        private IHttpContextAccessor _httpContextAccessor;
        private IConfiguration _configuration;

        public NoteRepository(StartupDataContext context, IHttpContextAccessor httpContextAccessor, IConfiguration configuration) : base(context, httpContextAccessor, configuration)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
