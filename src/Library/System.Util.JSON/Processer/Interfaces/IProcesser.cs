using System;
using System.Collections.Generic;
using System.Text;

namespace System.Util.JSON.Processer.Interfaces
{
    interface IProcesser
    {
        void SetValue(object value);
        object GetResult();
    }
}
