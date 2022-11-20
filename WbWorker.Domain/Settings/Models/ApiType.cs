namespace WbWorker.Domain.Settings.Models;

public class ApiType
{
    public byte Id { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }
    public byte Order { get; set; }
    public ApiTypeSchedule[] ApiTypeSchedules { get; set; }
    public ApiTypeParam[] ApiTypeParams { get; set; }
}