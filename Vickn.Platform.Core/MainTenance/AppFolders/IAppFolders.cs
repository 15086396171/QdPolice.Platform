namespace Vickn.Platform.MainTenance.AppFolders
{
    public interface IAppFolders
    {
        string TempFileDownloadFolder { get; }

        string SampleProfileImagesFolder { get; }

        string WebLogsFolder { get; set; }

        string ForensiceRecordFolder { get; set; }
    }
}