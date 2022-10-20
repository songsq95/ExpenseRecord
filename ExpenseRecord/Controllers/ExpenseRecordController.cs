using ExpenseRecord.Dto;
using ExpenseRecord.ExpenseRecordService;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseRecord.Controllers
{

    [ApiController]
    [Route("api")]
    public class ExpenseRecordController : ControllerBase
    {


        //[HttpGet]
        //public string greet()
        //{
        //    //Console.Out.WriteLine(name);
        //    return "Hello, ";
       // }
        
       
        private readonly IExpenseRecordService _recordService;

        public ExpenseRecordController(IExpenseRecordService recordService)
        {
            _recordService = recordService;
        }

        [HttpPost]
        public List<RecordItemDto> CreateItemAsync(RecordItemDto recordItemDto)
        {

            return _recordService.CreateOne(recordItemDto);
        }




        [HttpGet]
        public List<RecordItemDto> GetItems()
        {

            var todoItems =  _recordService.GetAll();
            return todoItems;
        }

        [HttpDelete]
        [Route(@"{Id}")]
        public List<RecordItemDto> DeleteItem(string id)
        {

            return _recordService.DeleteOne(id);

        }


    }
}
