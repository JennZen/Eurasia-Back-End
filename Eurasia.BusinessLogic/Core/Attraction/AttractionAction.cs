using Eurasia.Domains.Entities.AttractionData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Eurasia.BusinessLogic.Core.Attraction
{
    public class AttractionAction
    {
        private static List<AttractionData> _mockDb =
        [
            new AttractionData
            {
                Id = 1,
                Name = "Peleș Castle",
                Description = "A Neo-Renaissance castle nestled in the Carpathian Mountains.",
                FullDescription = "Peleș Castle is a stunning Neo-Renaissance castle in the Carpathian Mountains of Romania, near Sinaia. Built between 1873 and 1914, it served as the summer residence of Romanian kings.",
                Price = 39,
                BGUrl = "https://images.unsplash.com/photo-1584646098378-0874589a76a3",
                ImageUrl = "https://images.unsplash.com/photo-1584646098378-0874589a76a3",
                City = "Sinaia",
                Duration = "2-3 hours",
                BestTimeToVisit = "May - September",
                OpeningHours = "9:15 AM - 5:00 PM (Closed Mondays)",
                Rating = 4.6,
                NumberOfReviews = 1250,
                CountryId = 1
            },
            new AttractionData
            {
                Id = 2,
                Name = "Bran Castle",
                Description = "The legendary castle often associated with the Dracula myth.",
                FullDescription = "Bran Castle, situated near Brașov, is a national monument and landmark in Transylvania. Commonly known as 'Dracula's Castle', it is marketed as the home of the title character in Bram Stoker's Dracula.",
                Price = 35,
                BGUrl = "https://images.unsplash.com/photo-1577717903315-1691ae25ab3f",
                ImageUrl = "https://images.unsplash.com/photo-1577717903315-1691ae25ab3f",
                City = "Brașov",
                Duration = "1.5-2 hours",
                BestTimeToVisit = "April - October",
                OpeningHours = "9:00 AM - 6:00 PM",
                Rating = 4.3,
                NumberOfReviews = 980,
                CountryId = 2
            },
            new AttractionData
            {
                Id = 3,
                Name = "Schönbrunn Palace",
                Description = "A magnificent imperial palace and UNESCO World Heritage Site.",
                FullDescription = "Schönbrunn Palace in Vienna is one of Austria's most important architectural, cultural, and historical monuments. The 1,441-room palace is one of the most significant in Europe.",
                Price = 45,
                BGUrl = "https://images.unsplash.com/photo-1609856878074-cf31e21ccb6b",
                ImageUrl = "https://images.unsplash.com/photo-1609856878074-cf31e21ccb6b",
                City = "Vienna",
                Duration = "3-4 hours",
                BestTimeToVisit = "April - October",
                OpeningHours = "8:00 AM - 5:30 PM",
                Rating = 4.7,
                NumberOfReviews = 2100,
                CountryId = 3
            },
            new AttractionData
            {
                Id = 4,
                Name = "Mount Fuji",
                Description = "Japan's iconic and highest mountain, a symbol of natural beauty.",
                FullDescription = "Mount Fuji is Japan's tallest peak at 3,776 meters. This active stratovolcano is an iconic symbol of Japan and has been a sacred site for centuries.",
                Price = 0,
                BGUrl = "https://images.unsplash.com/photo-1490806843957-31f4c9a91c65",
                ImageUrl = "https://images.unsplash.com/photo-1490806843957-31f4c9a91c65",
                City = "Shizuoka",
                Duration = "Full day",
                BestTimeToVisit = "July - August",
                OpeningHours = "Open 24 hours (climbing season: July-September)",
                Rating = 4.8,
                NumberOfReviews = 3500,
                CountryId = 4
            },
            new AttractionData
            {
                Id = 5,
                Name = "Eiffel Tower",
                Description = "The iconic iron lattice tower and symbol of Paris.",
                FullDescription = "The Eiffel Tower is a wrought-iron lattice tower on the Champ de Mars in Paris. Named after engineer Gustave Eiffel, it was constructed from 1887 to 1889 as the centerpiece of the 1889 World's Fair.",
                Price = 28,
                BGUrl = "https://images.unsplash.com/photo-1511739001486-6bfe10ce65f4",
                ImageUrl = "https://images.unsplash.com/photo-1511739001486-6bfe10ce65f4",
                City = "Paris",
                Duration = "2-3 hours",
                BestTimeToVisit = "March - May, September - November",
                OpeningHours = "9:30 AM - 11:45 PM",
                Rating = 4.7,
                NumberOfReviews = 5200,
                CountryId = 3
            }
        ];

        public List<AttractionData> GetAttractions()
        {
            return _mockDb.ToList();
        }

        public AttractionData? GetById(int id)
        {
            return _mockDb.FirstOrDefault(a => a.Id == id);
        }

        public bool Create(AttractionData attraction)
        {
            var existing = _mockDb.FirstOrDefault(a => a.Id == attraction.Id);
            if (existing == null)
            {
                _mockDb.Add(attraction);
                return true;
            }
            return false;
        }

        public bool Update(AttractionData attraction)
        {
            var index = _mockDb.FindIndex(a => a.Id == attraction.Id);
            if (index != -1)
            {
                _mockDb[index] = attraction;
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            var existing = _mockDb.FirstOrDefault(a => a.Id == id);
            if (existing != null)
            {
                _mockDb.Remove(existing);
                return true;
            }
            return false;
        }
    }
}
