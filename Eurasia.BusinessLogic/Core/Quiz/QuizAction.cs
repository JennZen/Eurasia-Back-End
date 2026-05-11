using Eurasia.DataAccess.Context;
using Eurasia.Domains.Entities.Relations;

namespace Eurasia.BusinessLogic.Core.Quiz
{
    public class QuizAction
    {
        private readonly QuizContext _db = new QuizContext();

        public EurasiaQuizResult? GetByUserId(int userId)
        {
            return _db.EurasiaQuizResults.FirstOrDefault(r => r.UserId == userId);
        }

        public bool Upsert(EurasiaQuizResult result)
        {
            var existing = _db.EurasiaQuizResults.FirstOrDefault(r => r.UserId == result.UserId);
            if (existing == null)
            {
                _db.EurasiaQuizResults.Add(result);
                _db.SaveChanges();
                return true;
            }

            existing.CountriesGuessed = result.CountriesGuessed;
            existing.TotalCountriesCount = result.TotalCountriesCount;
            existing.TimeSpentSeconds = result.TimeSpentSeconds;
            _db.SaveChanges();
            return true;
        }
    }
}
