using System;
using System.Collections.Generic;
using System.Text;

namespace System.Util.JSON.Processer.Interfaces
{
    interface IStringProcesser : IProcesser
    {
        void SetValue(string value);
    }
}
