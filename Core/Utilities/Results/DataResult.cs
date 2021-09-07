using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class DataResult<T> :Result, IDataResult<T>
    {
        public DataResult(T _data,bool success,string message):base(success,message)
        {
            Data = _data;
        }
        public DataResult(T data,bool success):base(success)
        {

        }
        public T Data { get; }
    }
}
