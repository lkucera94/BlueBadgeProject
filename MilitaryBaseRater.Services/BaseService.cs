using MilitaryBaseRater.Data;
using MilitaryBaseRater.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryBaseRater.Services
{
    public class BaseService
    {
        public bool CreateBase(BaseCreate model)
        {
            Base militaryBase = new Base()
            {
                BaseName = model.BaseName,
                BaseCity = model.BaseCity,
                BaseState = model.BaseState
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Bases.Add(militaryBase);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<BaseListItem> GetBases()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query = ctx.Bases.Select(b => new BaseListItem
                {
                    BaseID = b.BaseID,
                    BaseName = b.BaseName                   
                });

                return query.ToArray();
            }
        }

        public BaseDetail GetBaseByID(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Bases.FirstOrDefault(b => b.BaseID == id);
                var model = new BaseDetail
                {
                    BaseID = entity.BaseID,
                    BaseName = entity.BaseName,
                    BaseCity = entity.BaseCity,
                    BaseState = entity.BaseState
                };
                return model;
            }
        }

        public bool EditBase(BaseEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Bases.FirstOrDefault(b => b.BaseID == model.BaseID);

                entity.BaseName = model.BaseName;
                entity.BaseCity = model.BaseCity;
                entity.BaseState = model.BaseState;

                return ctx.SaveChanges() == 1;
         
            }
        }

        public bool DeleteBase(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Bases.Single(b => b.BaseID == id);

                ctx.Bases.Remove(entity);
                return ctx.SaveChanges() == 1;              
            }
        }

    }
}
