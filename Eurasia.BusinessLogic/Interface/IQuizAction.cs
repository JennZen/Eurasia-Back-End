using Eurasia.Domains.Models.Quiz;

namespace Eurasia.BusinessLogic.Interface
{
    public interface IQuizAction
    {
        public UserQuizRecordDto? GetUserBestRecord(int userId);
        public bool UpdateQuizResult(int userId, UpdateQuizResultDto resultDto);
    }
}
