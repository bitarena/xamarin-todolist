using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.Repositories
{
    public class TodoItemRepository : ITodoItemRepository
    {
        private readonly ITodoItemRepositoryOptions options;

        public TodoItemRepository(ITodoItemRepositoryOptions options)
        {
            this.options = options ?? throw new ArgumentNullException("options");
        }

        public async Task<IEnumerable<TodoItem>> GetAll()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var response = await httpClient.GetAsync(new Uri(options.GetAllUrl));
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<List<TodoItem>>(content);
                    return result;
                }
            }
            catch(HttpRequestException e)
            {
                throw new Exception("Could not connect");
            }
            finally
            {
                httpClient.Dispose();
            }
            throw new Exception("Could not connect");
        }
    }
}
