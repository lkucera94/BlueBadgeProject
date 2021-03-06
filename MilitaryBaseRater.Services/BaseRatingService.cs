﻿using MilitaryBaseRater.Data;
using MilitaryBaseRater.Models.RatingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryBaseRater.Services
{
    public class BaseRatingService
    {
        private readonly Guid _userId;
        public BaseRatingService(Guid userId)
        {
            _userId = userId;
        }
        public BaseRatingService() { }

        public bool CreateRating(RatingCreate model)
        {
            var rating = new BaseRating
            {
                OwnerID = _userId,
                BaseID = model.BaseID,
                RaterID = model.RaterID,
                OverallRating = model.OverallRating,
                HousingRating = model.HousingRating,
                FoodRating = model.FoodRating,
                ActivitiesRating = model.ActivitiesRating,
                TrainingSitesRating = model.TrainingSitesRating,
                Comments = model.Comments
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Ratings.Add(rating);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<RatingListItem> GetRatingsByUserID(Guid userId) 
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Ratings.Where(b => b.OwnerID == userId).Select(b => new RatingListItem
                { 
                    BaseID = b.BaseID,
                    RatingID = b.RatingID,
                    BaseName = b.Base.BaseName,
                    OverallRating = b.OverallRating
                });

                return query.ToArray();
            }
        }

        public IEnumerable<RatingListItem> GetRatings()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Ratings.Select(r => new RatingListItem
                {
                    BaseID = r.BaseID,
                    RatingID = r.RatingID,
                    UserName = r.Rater.UserName,
                    Branch = r.Rater.Branch,
                    Job = r.Rater.Job,
                    Rank = r.Rater.Rank,
                    Age = r.Rater.Age,
                    BaseName = r.Base.BaseName,
                    OverallRating = r.OverallRating

                });

                return query.ToArray();
            }
        }

        public RatingDetail GetRatingsByRatingID(int ratingId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Ratings.FirstOrDefault(r => r.RatingID == ratingId);
                var model = new RatingDetail()
                {
                    RatingID = entity.RatingID,
                    UserName = entity.Rater.UserName,
                    BaseName = entity.Base.BaseName,
                    OverallRating = entity.OverallRating,
                    HousingRating = entity.HousingRating,
                    FoodRating = entity.FoodRating,
                    ActivitiesRating = entity.ActivitiesRating,
                    TrainingSitesRating = entity.TrainingSitesRating,
                    Comments = entity.Comments

                };
                return model;

            }
        }

        public bool EditBaseRating(RatingEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Ratings.Single(r => r.RatingID == model.RatingID);

                entity.BaseID = model.BaseID;
                entity.OverallRating = model.OverallRating;
                entity.HousingRating = model.HousingRating;
                entity.FoodRating = model.FoodRating;
                entity.ActivitiesRating = model.ActivitiesRating;
                entity.TrainingSitesRating = model.TrainingSitesRating;
                entity.Comments = model.Comments;

                return ctx.SaveChanges() == 1;
            }


        }

        public bool DeleteRating(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Ratings.Single(r => r.RatingID == id);

                ctx.Ratings.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}
