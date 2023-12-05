using Domain.account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.repository
{
    public interface AccountRepository
    {
        public CurrentAccount Get(string accountNumber);
        public void Save(CurrentAccount account);
        public void Update(CurrentAccount account);
        public void Delete(string accountNumber);
    }
}
