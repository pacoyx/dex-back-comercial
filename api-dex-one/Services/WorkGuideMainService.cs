
public class WorkGuideMainService : IWorkGuideMainService
{
    private readonly IUnitOfWork _unitOfWork;
    public WorkGuideMainService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<WorkGuideMain> AddWorkGuideMain(CreateWorkGuideMainDto workGuideMainDto)
    {
        var WorkGuideMain = workGuideMainDto.AsWorkGuideMain();
        var wgm = await _unitOfWork.WorkGuideMains.AddWorkGuideMain(WorkGuideMain);
        _unitOfWork.Complete();
        return wgm;
    }
    public void DeleteWorkGuideMain(WorkGuideMain workGuideMain)
    {
        _unitOfWork.WorkGuideMains.DeleteWorkGuideMain(workGuideMain);
    }
    public async Task<IEnumerable<WorkGuideMain>> GetWorkGuideByDates(DateTime fechaIni, DateTime fechaFin, int companyId, int branch)
    {
        return await _unitOfWork.WorkGuideMains.GetWorkGuideByDates(fechaIni, fechaFin, companyId, branch);
    }
    public async Task<WorkGuideMain?> GetWorkGuideMain(int id)
    {
        return await _unitOfWork.WorkGuideMains.GetWorkGuideMain(id);
    }
    public async Task<IEnumerable<WorkGuideMain>> GetWorkGuideMains()
    {
        return await _unitOfWork.WorkGuideMains.GetWorkGuideMains();
    }
    public void UpdateWorkGuideMain(WorkGuideMain workGuideMain)
    {
        throw new NotImplementedException();
    }
}