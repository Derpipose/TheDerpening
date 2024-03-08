using Microsoft.AspNetCore.Mvc;

namespace DerpeningAPI.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class ToDoController : ControllerBase {
        

        private readonly ILogger<ToDoController> _logger;

        public ToDoController(ILogger<ToDoController> logger) {
            _logger = logger;
        }

        [HttpGet(Name = "ToDoList")]
        public IEnumerable<ToDoItem> Get() {
            return Enumerable.Range(1, 5).Select(index => new ToDoItem {
                ApiId = index,
                ApiIsTaskCompleted = false,
                ApiTitle = "Gabbagool"
            })
            .ToArray();
        }
    }
}
