using TheDerpening.Data.Models;

namespace TheDerpening.Services
{
    public class ApiService
    {
        private readonly HttpClient client;

        public ApiService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<List<TodoListItem>?> GetTasks()
        {
            return await client.GetFromJsonAsync<List<TodoListItem>>("ToDoListItem/");
        }

        public async Task<TodoListItem?> GetThisTask(int number)
        {
            return await client.GetFromJsonAsync<TodoListItem>($"ToDoListItem/{number}");
        }

        public async Task AddItem(TodoListItem newitem)
        {
            await client.PostAsJsonAsync("ToDoListItem/", newitem);
        }

        public async Task Update(TodoListItem updated)
        {
            await client.PutAsJsonAsync("ToDoListItem/update", updated);
        }

        public async Task Delete(int id)
        {
            await client.DeleteAsync($"ToDoListItem/delete/{id}");
        }



    }

}
