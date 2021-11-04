using System;
using System.Collections.Generic;
using System.Text;

namespace System.Util.JSON.Processer.Interfaces
{
    interface IObjectProcesser : IProcesser
    {
        void Set(string name, object value);
        Type GetValueType(string name);
    }
}
