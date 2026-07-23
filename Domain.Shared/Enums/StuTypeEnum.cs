using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Domain.Shared.Enums
{
    public enum StuTypeEnum
    {
        [Description("正常")]
        OK = 1,

        [Description("请假")]
        QingJia = 2,

        [Description("休学")]
        XiuXue = 3,

    }
}
