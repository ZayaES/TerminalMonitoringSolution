namespace TerminalMonitoringSolution.IServices
{
    public interface ISerialNumberService
    {
        string GetNextSerialId(string entityType);
    }
}