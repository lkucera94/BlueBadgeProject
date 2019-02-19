using MilitaryBaseRater.Data;
using MilitaryBaseRater.Models;
using MilitaryBaseRater.Models.RaterModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryBaseRater.Services
{
    public class RaterService
    {
        private readonly Guid _userID;

        public RaterService(Guid userID)
        {
            _userID = userID;
        }
        public bool CreateRater(RaterCreate model)
        {
            Rater rater = new Rater()
            {
                
                OwnerID = _userID,
                Branch = model.Branch,
                Job = model.Job,
                Rank = model.Rank,
                Age = model.Age,  
                UserName = GetUserName()
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Raters.Add(rater);
                return ctx.SaveChanges() == 1;
            }
        }

        public string GetUserName()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var user = ctx.Users.First(c => c.Id == _userID.ToString());
                var userName = user.UserName;
                return userName;
            }
        }

        public IEnumerable<RaterListItem> GetRater()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Raters.Select(r => new RaterListItem
                {
                    RaterID = r.RaterID,
                    UserName = r.UserName,
                    Branch = r.Branch,
                    Job = r.Job,
                    Rank = r.Rank,
                    Age = r.Age
                }).ToList();

                foreach(var rater in query)
                {
                    rater.DisplayInfo = $"{rater.Branch}, {rater.Job}, {rater.Rank}, {rater.Age}";
                }

                return query.ToArray();
            }
        }

        public RaterDetail GetRaterByUserID(Guid id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Raters.FirstOrDefault(e => e.OwnerID == id);

                var model = new RaterDetail
                {
                    RaterID = entity.RaterID,
                    Branch = entity.Branch,
                    Job = entity.Job,
                    UserName = entity.UserName,
                    Rank = entity.Rank,
                    Age = entity.Age,
                };
                return model;
            }
        }

        public RaterDetail GetRaterByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Raters.FirstOrDefault(e => e.RaterID == id);

                var model = new RaterDetail
                {
                    RaterID = entity.RaterID,
                    Branch = entity.Branch,
                    Job = entity.Job,
                    UserName = entity.UserName,
                    Rank = entity.Rank,
                    Age = entity.Age,
                };
                return model;
            }
        }

        public bool EditRater(RaterEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Raters.FirstOrDefault(r => r.RaterID == model.RaterID);

                entity.Branch = model.Branch;
                entity.Job = model.Job;
                entity.Rank = model.Rank;
                entity.Age = model.Age;

                return ctx.SaveChanges() == 1;

            }
        }

        public bool DeleteRater(int raterId)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Raters.Single(r => r.RaterID == raterId);

                ctx.Raters.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

      
    }
}
