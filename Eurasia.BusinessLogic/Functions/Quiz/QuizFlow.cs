using Eurasia.BusinessLogic.Core.Quiz;
using Eurasia.BusinessLogic.Interface;
using Eurasia.Domains.Entities.Relations;
using Eurasia.Domains.Models.Quiz;

namespace Eurasia.BusinessLogic.Functions.Quiz
{
    public class QuizFlow : QuizAction, IQuizAction
    {
        public UserQuizRecordDto? GetUserBestRecord(int userId)
        {
            var record = base.GetByUserId(userId);

            if (record == null) return null;

            return new UserQuizRecordDto
            {
                MaxCountriesGuessed = record.CountriesGuessed,
                BestTimeSeconds = record.TimeSpentSeconds
            };
        }

        public bool UpdateQuizResult(int userId, UpdateQuizResultDto resultDto)
        {
            var result = new EurasiaQuizResult
            {
                UserId = userId,
                CountriesGuessed = resultDto.CountriesGuessed,
                TotalCountriesCount = resultDto.TotalCountries,
                TimeSpentSeconds = resultDto.TimeSpentSeconds
            };

            return base.Upsert(result);
        }
    }
}
