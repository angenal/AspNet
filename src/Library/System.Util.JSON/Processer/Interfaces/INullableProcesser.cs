using System;
using System.Collections.Generic;
using System.Text;

namespace System.Util.JSON.Processer.Interfaces
{
    interface INullableProcesser : IProcesser
    {
        void SetNull();
    }
}
