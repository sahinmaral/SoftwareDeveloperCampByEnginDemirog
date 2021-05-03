
using DataAccess.Abstract;

using Entities.Concrete;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfColourDal : IColourDal
    {
        public void Add(Colour entity)
        {
            using (CarContext context = new CarContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Colour entity)
        {
            using (CarContext context = new CarContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Colour Get(Expression<Func<Colour, bool>> filter)
        {
            using (CarContext context = new CarContext())
            {
                return context.Set<Colour>().SingleOrDefault(filter);
            }
        }

        public List<Colour> GetAll(Expression<Func<Colour, bool>> filter = null)
        {
            using (CarContext context = new CarContext())
            {
                return filter == null ?
                    context.Set<Colour>().ToList() :
                    context.Set<Colour>().Where(filter).ToList();
            }
        }

        public void Update(Colour entity)
        {
            using (CarContext context = new CarContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
