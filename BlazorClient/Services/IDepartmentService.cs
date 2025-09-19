using BlazorShared;

namespace BlazorClient.Services
{
    public interface IDepartmentService
    {
        Task<List<DepartmentDTO>> List();
    }
}
