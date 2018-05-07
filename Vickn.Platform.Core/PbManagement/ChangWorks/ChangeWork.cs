using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanNingSSOMS.DAL.Model
{
    public class ChangeWork
    {

        /// <summary>
        /// id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 换班人
        /// </summary>
        [DisplayName("换班人")]
        [Required(ErrorMessage = "换班人不能为空")]
        public string ShiftPeople { get; set; }

        /// <summary>
        /// 换班人ID
        /// </summary>
        public int ShiftPeopleID { get; set; }

        /// <summary>
        /// 换班前岗位ID
        /// </summary>
        public int? BeforPositionID { get; set; }

        /// <summary>
        /// 换班前岗位
        /// </summary>
        public string BeforPositionName { get; set; }

        /// <summary>
        /// 换班人 值班时间
        /// </summary>
        public DateTime ShiftPeopleOnDytuTime { get; set; }
        /// <summary>
        /// 换班人 值班时间 开始时间
        /// </summary>
        [DisplayName("值班开始时间")]
        [Required(ErrorMessage = "值班开始时间不能为空")]
        public DateTime ShiftDutyTime { get; set; }

        /// <summary>
        /// 换班人  值班时间 结束时间
        /// </summary>
        [DisplayName("值班结束时间")]
        [Required(ErrorMessage = "值班开始时间不能为空")]
        public DateTime ShiftEndTime { get; set; }

        /// <summary>
        /// 换班原因
        /// </summary>
        [DisplayName("换班原因"), Required(ErrorMessage = "换班原因不能为空")]
        public string Reason { get; set; }

        /// <summary>
        /// 被换班人
        /// </summary>
        [DisplayName("被换班人")]
        [Required(ErrorMessage = "被换班人不能为空")]
        public string BeShiftPeople { get; set; }

        /// <summary>
        /// 被换班人ID
        /// </summary>
        public int BeShiftPeopleID { get; set; }

        ///<summary>
        /// 换班后岗位ID
        /// </summary>
        public int AfterPositionID { get; set; }

        /// <summary>
        /// 换班后岗位
        /// </summary>
        public string AfterPositionName { get; set; }

        /// <summary>
        /// 换班前positionPbId
        /// </summary>
        public int BeforPositionPbID { get; set; }

        /// <summary>
        /// 换班后positionPbId
        /// </summary>
        public int AfterPositionPbID { get; set; }

        /// <summary>
        /// 换班状态描述
        /// </summary>
        [DisplayName("换班状态")]
        public string StatusDes { get; set; }

        /// <summary>
        /// 值班时间
        /// </summary>
        [DisplayName("换班时间")]
        [Required(ErrorMessage = "值班时间不能为空")]
        public DateTime BeShiftPeopleOnDudyTime { get; set; }

        /// <summary>
        /// 被换班人 值班时间 开始时间
        /// </summary>
        [DisplayName("换班开始时间")]
        [Required(ErrorMessage = "值班开始时间不能为空")]
        public DateTime BeShiftDutyTime { get; set; }

        /// <summary>
        /// 被换班人  值班时间 结束时间
        /// </summary>
        [DisplayName("换班结束时间")]
        [Required(ErrorMessage = "值班结束时间不能为空")]
        public DateTime BeShiftEndTime { get; set; }

        /// <summary>
        /// 换班时间
        /// </summary>
        [DisplayName("申请时间")]
        [Required(ErrorMessage = "换班时间不能为空")]
        public DateTime ChangeTime { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public ChangeWorkStatus Status { get; set; }

        /// <summary>
        /// 是否值班中换班
        /// </summary>
        public bool IsOnDuty { get; set; }

        /// <summary>
        /// 领导ID
        /// </summary>
        public int? LeaderID { get; set; }

        /// <summary>
        /// 领导
        /// </summary>
        public string Leader { get; set; }


    }
    /// <summary>
    /// 换班状态
    /// </summary>
    public enum ChangeWorkStatus
    {
        /// <summary>
        /// 发起换班
        /// </summary>
        OnStart = 0,

        /// <summary>
        /// 换班人同意，待领导同意
        /// </summary>
        BeAfterShift,

        /// <summary>
        /// 被换班人同意
        /// </summary>
        BeShiftPass,

        /// <summary>
        /// 换班完成
        /// </summary>
        BeSuccess,

        /// <summary>
        /// 被换班人不同意
        /// </summary>
        BeShiftNotPass,

        /// <summary>
        /// 领导同意
        /// </summary>
        BeLeaderPass,

        /// <summary>
        /// 领导不同意
        /// </summary>
        BeLeaderNotPass,
    }

    public static class ChangeWorkStatusHelper
    {
        public static string GetChangeWorkStatusDes(ChangeWorkStatus status)
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

    /// <summary>
    /// 换班时间
    /// </summary>
    public class ShiftPeopleOnDytuTime
    {
        /// <summary>
        /// 初始化换班时间的实例
        /// </summary>
        public ShiftPeopleOnDytuTime()
        {
            BeShiftPeoples = new List<BeShiftPeople>();
        }

        public int PositionPbMapV3Id { get; set; }

        public int PositionPbV3Id { get; set; }

        public int PositionV3Id { get; set; }

        public string PositionV3Name { get; set; }

        public DateTime Time { get; set; }

        /// <summary>
        ///  值班开始时间
        /// </summary>
        public string DutyStartTime { get; set; }

        /// <summary>
        /// 值班结束时间
        /// </summary>
        public string DutyEndTime { get; set; }

        public List<BeShiftPeople> BeShiftPeoples { get; set; }

    }

    /// <summary>
    /// 待换班人列表
    /// </summary>
    public class BeShiftPeople
    {
        /// <summary>
        /// 
        /// </summary>
        public int UserID { get; set; }

        public string UserName { get; set; }

        public string Position { get; set; }

        /// <summary>
        /// 职位ID
        /// </summary>
        public int PositionID { get; set; }

        public int PositionPbID { get; set; }

        /// <summary>
        ///  值班开始时间
        /// </summary>
        public string DutyStartTime { get; set; }

        /// <summary>
        /// 值班结束时间
        /// </summary>
        public string DutyEndTime { get; set; }

        /// <summary>
        /// 值班时间
        /// </summary>
        [NotMapped]
        public DateTime Time { get; set; }
    }
}
