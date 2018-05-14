namespace Vickn.Platform.PbManagement.ChangeWorks
{
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
}