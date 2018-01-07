using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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

        public async Task<TodoItem> Create(TodoItem item)
        {
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await httpClient.PostAsync(options.CreateUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<TodoItem>(data);
                    return result;
                }
                return null;
            }
            catch (HttpRequestException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                httpClient.Dispose();
            }
        }

        public async Task Delete(string id)
        {
            var httpClient = new HttpClient();

            try
            {
                var response = await httpClient.DeleteAsync(string.Format(options.DeleteUrl, id));

                if (!response.IsSuccessStatusCode)
                {
                    throw new ArgumentException("Could not delete that item");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                httpClient.Dispose();
            }
        }

        public async Task<IEnumerable<TodoItem>> GetAll()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var response = await httpClient.GetAsync(options.GetAllUrl);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<List<TodoItem>>(content);
                    return result;
                }
            }
            catch (HttpRequestException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                httpClient.Dispose();
            }
            throw new Exception("Could not connect");
        }

        public async Task Update(string id, TodoItem item)
        {
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var endpoint = string.Format(options.PutUrl, id);

            try
            {
                var response = await httpClient.PutAsync(endpoint, content);
                if (!response.IsSuccessStatusCode)
                {
                    throw new ArgumentException("Item does not exist");
                }
            }
            catch (HttpRequestException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                httpClient.Dispose();
            }
        }
    }
}
