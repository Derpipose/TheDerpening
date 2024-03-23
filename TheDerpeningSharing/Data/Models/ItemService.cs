
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using Serilog.Core;

namespace TheDerpening.Data.Models
{
    public partial class ItemService
    {
        private readonly ILogger<ItemService> _logger;
        private ListDbContext _listDbContext;
        public ItemService(ILogger<ItemService> logger, ListDbContext listDbContext)
        {
            _logger = logger;
            _listDbContext = listDbContext;
            LogStartupMessage(logger, "fun");

        }

        [LoggerMessage(Level = LogLevel.Information, Message = "Hello World! Logging is {Description}.")]
        static partial void LogStartupMessage(ILogger logger, string description);



        [LoggerMessage(Level = LogLevel.Information, Message = "1 Item is being {Description}.")]
        static partial void LogFunctionMessage(ILogger logger, string description);



        [LoggerMessage(Level = LogLevel.Warning, Message = "CAUSE FOR CONCERN! {Description}.")]
        static partial void LogWarningMessage(ILogger logger, string description);


        [LoggerMessage(Level = LogLevel.Information, Message = "You found a derp! You are now {Description}.")]
        static partial void DerpingMessage(ILogger logger, string description);


        [LoggerMessage(Level = LogLevel.Warning, Message = ":P! {Description}.")]
        static partial void BlepAlert(ILogger logger, string description);

        // public void inputlog(string descript, )
        public async Task<IEnumerable<TodoListItem>> GetAll()
        {
            using var activity = DerpingMonitor.source.StartActivity("Getting all derp things");
            activity?.SetTag("DerpingAttempt", 1);
            DerpingMonitor.countAdd.Add(1);
            var mylist = await _listDbContext.Todos.ToListAsync();
            List<TodoListItem> list = new List<TodoListItem>();
            list = mylist;
            activity?.Stop();
            LogFunctionMessage(_logger, "gotted");
            var observableUpDownCounter = DerpingMonitor.observableUpDownCounter;
            var stringing = observableUpDownCounter.ToString();
            DerpingMonitor.TaskCounter = Int32.TryParse(stringing, out var parsedValue) ? parsedValue : 0;

            return list;

        }

        public async Task Add(TodoListItem obj)
        {
            if (obj.Title != null)
            {
                using var activity = DerpingMonitor.source.StartActivity("Getting a derp thing");
                activity?.SetTag("DerpAdding", 2);
                _listDbContext.Todos.Add(obj);
                await _listDbContext.SaveChangesAsync();
                activity?.Stop();
                BlepAlert(_logger, "blep :P");
                DerpingMonitor.upDownCounter.Add(1);
            }
            else
            {
                LogWarningMessage(_logger, "Task had no title.");
                //log ERROR
            }
            LogFunctionMessage(_logger, "added");


        }

        public async Task Delete(int id)
        {
            var itemtoberemoved = await _listDbContext.Todos.Where(T => T.Id == id).FirstOrDefaultAsync();
            if (itemtoberemoved != null) { _listDbContext.Todos.Remove(itemtoberemoved); }
            else
            {
                LogWarningMessage(_logger, "Item does not exist");
            }
            LogFunctionMessage(_logger, "deleted");
            await _listDbContext.SaveChangesAsync();
            DerpingMonitor.upDownCounter.Add(-1);
        }

        public async Task<TodoListItem> Get(int id)
        {
            var itemtobefound = await _listDbContext.Todos.Where(T => T.Id == id).FirstOrDefaultAsync();
            if (itemtobefound == null) { itemtobefound = new TodoListItem(); }
            LogFunctionMessage(_logger, "returned");

            return itemtobefound;
        }


        public async Task Update(TodoListItem obj)
        {
            var itemtobeupdated = await _listDbContext.Todos.Where(T => T.Id == obj.Id).FirstOrDefaultAsync();
            if (itemtobeupdated != null)
            {
                itemtobeupdated.IsTaskCompleted = obj.IsTaskCompleted;
                itemtobeupdated.Title = obj.Title;
            }

            await _listDbContext.SaveChangesAsync();
            LogFunctionMessage(_logger, "updated");
            DerpingMessage(_logger, "a bamboozled derpling");
        }
    }
}
