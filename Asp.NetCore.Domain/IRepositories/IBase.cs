using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Asp.NetCore.Domain.IRepositories
{
    public interface IBase<TKey>
    {
        [Key]
        TKey Id { get; set; }
    }


    public interface IUserBase<TKey> : IBase<TKey>
    {
        [Key]
        string UserId { get; set; }
    }
}



