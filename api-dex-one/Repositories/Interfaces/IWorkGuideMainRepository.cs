public interface IWorkGuideMainRepository
{
    Task<IEnumerable<WorkGuideMain>> GetWorkGuideMains();
    Task<WorkGuideMain?> GetWorkGuideMain(int id);
    Task<WorkGuideMain> AddWorkGuideMain(WorkGuideMain workGuideMain);
    void UpdateWorkGuideMain(WorkGuideMain workGuideMain);
    void DeleteWorkGuideMain(WorkGuideMain workGuideMain);
    Task<IEnumerable<WorkGuideMain>> GetWorkGuideByDates(DateTime fechaIni, DateTime fechaFin, int companyId, int branch);
}