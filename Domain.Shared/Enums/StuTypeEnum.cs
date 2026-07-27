using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Domain.Shared.Enums
{
    public enum StuTypeEnum
    {
        [Description("待入学")]
        NotIn = 1,

        [Description("正常")]
        OK = 1,

        [Description("请假")]
        QingJia = 2,

        [Description("休学")]
        XiuXue = 3,

        [Description("退学")]
        TuiXue = 4,

    }
}
