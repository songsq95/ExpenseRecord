using System.Runtime.Serialization;
using Microsoft.EntityFrameworkCore;
using ExpenseRecord.Dto;

namespace ExpenseRecord.ExpenseRecordService
{
    public class ExpenseRecordService : IExpenseRecordService
    {
        public List<RecordItemDto> RecordList = new List<RecordItemDto>();

        public List<RecordItemDto> GetAll()
        {
           
            return RecordList;
        }

        public string CreateOne(RecordItemDto recordItemCreateDto)
        {
            var id = Guid.NewGuid().ToString();

            var recordGetItem = new RecordItemDto
            {
                Id = id,
                Description = recordItemCreateDto.Description,
                Type = recordItemCreateDto.Type,
                Amount = recordItemCreateDto.Amount,
                Date = recordItemCreateDto.Date,

            };
            RecordList.Add(recordGetItem);
            return id;
        }

        

        public List<RecordItemDto> DeleteOne(string id)
        {
            var recordItem =  GetToDoItem(id);
            RecordList.Remove(recordItem);
            return RecordList;
        }

        private  RecordItemDto GetToDoItem(string id)
        {

            var recordItem = RecordList.Find(x => x.Id == id);
            return recordItem;
        }

       
    }


}