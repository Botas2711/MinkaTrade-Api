using _3._Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._Domain.Premiuns
{
    public interface IPremiunDomain
    {
        public Task<bool> CreateAsync(Premiun premiun);
        public Task<bool> UpdateAsync(Premiun premiun, int id);
        public Task<Premiun> GetByIdAsync(int id);
    }
}
