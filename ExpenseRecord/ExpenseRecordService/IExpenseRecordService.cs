﻿
using ExpenseRecord.Dto;

namespace ExpenseRecord.ExpenseRecordService
{
    public interface IExpenseRecordService
    {
        string CreateOne(RecordItemDto recordItemDto);
        List<RecordItemDto> DeleteOne(string id);
        List<RecordItemDto> GetAll( );
    }
}