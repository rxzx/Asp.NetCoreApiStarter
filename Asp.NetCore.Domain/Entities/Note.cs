using Asp.NetCore.Domain.IRepositories;
using BolForce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.NetCore.Domain.Entities
{
    public class Note : BaseEntity<int>, IBase<int>
    {
        public string Title {get; set;}

        public string Description { get; set; }
    }
}
