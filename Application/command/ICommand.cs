using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.command
{
    public interface ICommand<T>
    {
        public string Operation {  get; set; }
        public T Execute();

    }
}
