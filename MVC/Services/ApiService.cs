using Azure;
using MVC.Models;
using PaymentSystem.MVC.DTO;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text.Json;

namespace MVC.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public ApiService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _baseUrl = configuration["WebAPI:BaseUrl"];
        }

        public async Task<StudentDTO> PostStudentDTO(StudentDTO student)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/api/student", student);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<StudentDTO>();
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Failed to add student. Error: {error}");
            }
        }

        public async Task<List<StudentDTO>> GetStudentDTOAsync()
        {


            //contact API to get students
            var response = await _httpClient.GetAsync(_baseUrl);
            await _httpClient.GetAsync(_baseUrl);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var students = JsonSerializer.Deserialize<List<StudentDTO>>(responseBody, options);


            return students;
        }

        public async Task<TransactionDTO> PostTransactionDTO(TransactionDTO transaction)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/api/transaction", transaction);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<TransactionDTO>();
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Failed to add transaction. Error: {error}");
            }
        }



        public async Task<List<TransactionDTO>> GetTransactionDTOs(string username)
        {
            // Get the students
            var students = await GetStudentDTOAsync();

            // Find the student whose username matches the provided one
            var student = students.FirstOrDefault(s => s.Username == username);

            if (student != null)
            {
                // Get the student's transactions using their student ID
                var response = await _httpClient.GetAsync($"{_baseUrl}/api/transaction/{student.StudentId}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<TransactionDTO>>();
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Failed to get transactions. Error: {error}");
                }
            }
            else
            {
                throw new Exception($"Student with username '{username}' not found.");
            }
        }

    }



}
