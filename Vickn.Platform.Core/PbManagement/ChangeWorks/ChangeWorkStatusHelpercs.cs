using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vickn.Platform.PbManagement.ChangeWorks
{
   public class ChangeWorkStatusHelpercs
    {
        public static string GetNewChangeWorkStatusDes(ChangeWorkStatus status)
        {
            switch (status)
            {
                case ChangeWorkStatus.OnStart:
                    return "开始换班";
                case ChangeWorkStatus.BeAfterShift:
                    return "待领导审核";
                case ChangeWorkStatus.BeShiftPass:
                    return "被换班人同意";
                case ChangeWorkStatus.BeSuccess:
                    return "换班成功";
                case ChangeWorkStatus.BeShiftNotPass:
                    return "换班人不同意";
                case ChangeWorkStatus.BeLeaderPass:
                    return "领导同意";
                case ChangeWorkStatus.BeLeaderNotPass:
                    return "领导不同意";
                default:
                    return String.Empty;
            }
        }
    }
}
