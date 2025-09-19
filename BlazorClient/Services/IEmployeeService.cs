using BlazorShared;

namespace BlazorClient.Services
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDTO>> List();
        //Task<Response<List<EmployeeDTO>>> List();
        Task<EmployeeDTO> Search(int id);
        Task<int> Create(EmployeeDTO employee);
        Task<int> Edit(EmployeeDTO employee);
        Task<bool> Delete(int id);
    }
}
