using Eurasia.DataAccess.Context;
using Eurasia.Domains.Models.Admin;

namespace Eurasia.BusinessLogic.Core.Admin
{
    public class AdminAction
    {
        protected int CountCountries()
        {
            using var db = new CountryContext();
            return db.Countries.Count();
        }

        protected int CountAttractions()
        {
            using var db = new AttractionContext();
            return db.Attractions.Count();
        }

        protected int CountNews()
        {
            using var db = new NewsContext();
            return db.News.Count();
        }

        protected int CountUsers()
        {
            using var db = new UserContext();
            return db.Users.Count();
        }

        protected List<RecentActionDto> CollectRecentActions(int take)
        {
            var perModel = Math.Max(1, take);
            var bucket = new List<RecentActionDto>();

            using (var db = new CountryContext())
            {
                bucket.AddRange(db.Countries
                    .OrderByDescending(c => c.UpdatedAt)
                    .Take(perModel)
                    .Select(c => new RecentActionDto
                    {
                        Type = c.CreatedAt == c.UpdatedAt ? "add" : "edit",
                        Model = "countries",
                        EntityId = c.Id,
                        Label = c.Name,
                        At = c.UpdatedAt
                    })
                    .ToList());
            }

            using (var db = new NewsContext())
            {
                bucket.AddRange(db.News
                    .OrderByDescending(n => n.UpdatedAt)
                    .Take(perModel)
                    .Select(n => new RecentActionDto
                    {
                        Type = n.CreatedAt == n.UpdatedAt ? "add" : "edit",
                        Model = "news",
                        EntityId = n.Id,
                        Label = n.Title,
                        At = n.UpdatedAt
                    })
                    .ToList());
            }

            using (var db = new UserContext())
            {
                bucket.AddRange(db.Users
                    .OrderByDescending(u => u.UpdatedAt)
                    .Take(perModel)
                    .Select(u => new RecentActionDto
                    {
                        Type = u.CreatedAt == u.UpdatedAt ? "add" : "edit",
                        Model = "users",
                        EntityId = u.Id,
                        Label = u.Name,
                        At = u.UpdatedAt
                    })
                    .ToList());
            }

            return bucket
                .OrderByDescending(x => x.At)
                .ThenByDescending(x => x.EntityId)
                .Take(take)
                .ToList();
        }
    }
}
