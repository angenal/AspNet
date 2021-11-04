using System;
using System.Collections.Generic;
using System.Text;

namespace System.Util.JSON.Processer.Interfaces
{
    interface IListProcesser : IProcesser
    {
        Type GetChildType();
        bool IsListEmpty();
        void AddChild(object value);
    }
}
