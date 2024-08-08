using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    // interfeys interfeysden miras ala biler
    public interface IDataResult<T> : IResult
    {
        T Data { get; }
    }
}
