using ExpenseRecord.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseRecord.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ExpenseRecordController : Controller
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ExpenseRecordController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        //[HttpGet]
        //public string greet()
        //{
        //    //Console.Out.WriteLine(name);
        //    return "Hello, ";
        //}

        [HttpPost]
        public async Task<IActionResult> CreateItemAsync(RecordItemDto recordItemDto)
        {
        var id = Guid.NewGuid().ToString();
            var recordGetItem = new RecordItemDto
            {
                Id = id,
                Description = recordItemDto.Description,
                Type = recordItemDto.Type,
                Amount = recordItemDto.Amount,
                Date = DateOnly.FromDateTime(DateTime.Now),
            };
        _applicationDbContext.RecordItems.Add(recordGetItem);
        await _applicationDbContext.SaveChangesAsync();
        return Created($"controller/{id}", id);
        }

        //        [HttpGet]
        //        [Route("{Id}")]
        //        public async Task<IActionResult> GetItemByIdAsync(string id)
        //        {
        //            Console.WriteLine("GetItemByIdAsync");
        //            var toDoItem = await GetToDoItemAsync(id);
        //            return new ObjectResult(toDoItem);

        //        }

        //        // Get all items  ?done=true&name=""
        //        [HttpGet]
        //        public async Task<IActionResult> GetItemsAsync(bool? done)
        //        {
        //            var toDoItems = new List<ToDoItemDto>();

        //            if (done == null)
        //            {
        //                toDoItems = await _applicationDbContext.ToDoItems.ToListAsync();
        //            }
        //            else
        //            {
        //                toDoItems = _applicationDbContext.ToDoItems.Where(item => item.Done == done).ToList();
        //            }

        //            return new ObjectResult(toDoItems);
        //        }


        //        [HttpPut]
        //        [Route("{Id}")]
        //        public async Task<IActionResult> UpdateItembyIdAsync(string id, ToDoItemDto toDoItemDto)
        //        {
        //            await GetToDoItemAsync(id);
        //            var toDoItemGetDto = new ToDoItemDto
        //            {
        //                Id = toDoItemDto.Id,
        //                Description = toDoItemDto.Description,
        //                Done = toDoItemDto.Done,
        //                CreateTime = toDoItemDto.CreateTime,
        //            };

        //            _applicationDbContext.ToDoItems.Update(toDoItemGetDto);
        //            await _applicationDbContext.SaveChangesAsync();
        //            return Ok();

        //        }


        //        [HttpDelete]
        //        [Route("{Id}")]
        //        public async Task<IActionResult> DeleteItemAsync(string id)
        //        {
        //            var toDoItem = await GetToDoItemAsync(id);
        //            _applicationDbContext.ToDoItems.Remove(toDoItem);
        //            await _applicationDbContext.SaveChangesAsync();
        //            return NoContent();
        //        }


        //        private async Task<ToDoItemDto> GetToDoItemAsync(string id)
        //        {
        //            var todoItem = await _applicationDbContext.ToDoItems.FindAsync(id);

        //            if (todoItem == null) throw new ToDoListException("ToDoItem not found");
        //            _applicationDbContext.Entry(todoItem).State = EntityState.Detached; //和数据库断开
        //            return todoItem;
        //        }

        //    }
    }
}
