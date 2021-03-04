using DataAccess.Abstract;
using DataAccess.Concrete.EF.Context;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EF.Repositories
{
    public class EFColorRepository : IColorDal
    {
        public void Add(Color entity)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var addedContext = context.Entry(entity);
                addedContext.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Color entity)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var deletedContext = context.Entry(entity);
                deletedContext.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            using (ReCapContext context = new ReCapContext())
            {
                return context.Set<Color>().SingleOrDefault(filter);
            }
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            using (ReCapContext context = new ReCapContext())
            {
                return filter == null
                    ? context.Set<Color>().ToList()
                    : context.Set<Color>().Where(filter).ToList();
            }
        }

        public void Update(Color entity)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var updatedContext = context.Entry(entity);
                updatedContext.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
