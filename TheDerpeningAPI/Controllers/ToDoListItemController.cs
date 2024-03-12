﻿using Microsoft.AspNetCore.Mvc;
using TheDerpening.Data;
using TheDerpening.Data.Models;

namespace TheDerpeningAPI.Controllers
{



    [ApiController]
    [Route("[controller]")]
    public class ToDoListItemController : Controller
    {

        private readonly ILogger<ToDoListItemController> _logger;
        private ItemService _ToDoItems;

        public ToDoListItemController(ILogger<ToDoListItemController> logger, ItemService toDoListItem)
        {

            _logger = logger;
            _ToDoItems = toDoListItem;


        }
        [HttpGet()]
        public async Task<IEnumerable<TodoListItem>> Get()
        {
            return await _ToDoItems.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<TodoListItem> Get(int id)
        {
            return await _ToDoItems.Get(id);
        }

        [HttpPost()]
        public async Task<TodoListItem> Add(TodoListItem listItem)
        {
            await _ToDoItems.Add(listItem);
            return listItem;
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _ToDoItems.Delete(id);
        }

        [HttpPut()]
        public async Task<TodoListItem> Update(TodoListItem listItem)
        {
            await _ToDoItems.Update(listItem);
            return listItem;
        }
    }
}