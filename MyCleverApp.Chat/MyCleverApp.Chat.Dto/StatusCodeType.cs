using System;
using System.Collections.Generic;
using System.Text;

namespace MyCleverApp.Chat.Dto
{
    public enum StatusCodeType
    {
        NotDefined      = 0,
        Success         = 1 << 0,
        Error           = 2 << 1,
    }
}
