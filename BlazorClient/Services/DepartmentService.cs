using BlazorShared;
using System.Net.Http.Json;

namespace BlazorClient.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly HttpClient _http;

        public DepartmentService(HttpClient http)
        {
            _http = http; 
        }

        public async Task<List<DepartmentDTO>> List()
        {
            // obetner la respuesta en formato json
            //var result = await _http.GetFromJsonAsync<Response<List<DepartmentDTO>>>("api/departament/List");
            //if (result!.IsSuccess)
            //    return result.Value!;
            //else
            //    throw new Exception(result.Message);
            
            var result = await _http.GetFromJsonAsync<List<DepartmentDTO>>("api/department/List");
                return result!;
            
        }
    }
}
