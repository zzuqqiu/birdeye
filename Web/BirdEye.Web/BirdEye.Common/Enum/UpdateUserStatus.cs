using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BirdEye.Common.Enum
{
    public enum UpdateUserStatus
    {
        Success = 0,
        MultipleUserName = 1,
        InvalidEmailFormat = 2,
        InvalidAccountId = 3,
        ServerError = 4,
    }
}
