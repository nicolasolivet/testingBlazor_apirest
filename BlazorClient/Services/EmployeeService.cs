using BlazorShared;
using System.Net.Http;
using System.Net.Http.Json;

namespace BlazorClient.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient _http;
        public EmployeeService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<EmployeeDTO>> List()
        {
            var result = await _http.GetFromJsonAsync<List<EmployeeDTO>>("api/Employee/List");
            return result!;
            //var result = await _http.GetFromJsonAsync<Response<List<EmployeeDTO>>>("api/Employee/List");
            //if (result!.IsSuccess)
            //    return result.Value!;
            //else
            //    throw new Exception(result.Message);

            // The API is likely returning just a list, not a wrapped Response object.
            //var result = await _httpClient.GetFromJsonAsync<List<EmployeeDTO>>("api/Employee/");
        }

        public async Task<EmployeeDTO> Search(int id)
        {
            var result = await _http.GetFromJsonAsync<Response<EmployeeDTO>>($"api/Employee/Search/{id}");

            if (result!.IsSuccess)
                return result.Value!;
            else
                throw new Exception(result.Message);
        }

        public async Task<int> Create(EmployeeDTO employee)
        {
            var result = await _http.PostAsJsonAsync("api/Employee/Create", employee);
            var response = await result.Content.ReadFromJsonAsync<Response<int>>();

            if (response!.IsSuccess)
                return response.Value!;
            else
                throw new Exception(response.Message);
        }

        public async Task<int> Edit(EmployeeDTO employee)
        {
            var result = await _http.PutAsJsonAsync($"api/Employee/Update/{employee.IdEmployee}", employee);
            var response = await result.Content.ReadFromJsonAsync<Response<int>>();

            if (response!.IsSuccess)
                return response.Value!;
            else
                throw new Exception(response.Message);
        }

        public async Task<bool> Delete(int id)
        {
            var result = await _http.DeleteAsync($"api/Employee/Delete/{id}");
            var response = await result.Content.ReadFromJsonAsync<Response<int>>();

            if (response!.IsSuccess)
                return response.IsSuccess!;
            else
                throw new Exception(response.Message);
        }

        

        

        
    }
}
