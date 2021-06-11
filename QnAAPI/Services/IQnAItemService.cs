using QnAAPI.Models;
using System.Collections.Generic;

namespace QnAAPI.Services
{
    public interface IQnAItemService
    {
        void AddQnaItem(QnAItem qnaItem);
        void DeleteQnaItem(QnAItem qnaItem);
        List<QnAItem> GetQnAItems();
    }
}