using DataAccess.Interfaces;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class BrandRepository : IRepository<Brand>
    {
        public bool Create(Brand entity)
        {
            try
            {
                DataContext.Brands.Add(entity);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(Brand entity)
        {
            try
            {
                DataContext.Brands.Remove(entity);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Brand> GetAll(Predicate<Brand> filter = null)
        {
            try
            {
                return filter == null ? null :
                    DataContext.Brands.FindAll(filter);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Brand GetOne(Predicate<Brand> filter = null)
        {
            try
            {
                return filter == null? null:
                    DataContext.Brands.Find(filter);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Update(Brand entity)
        {
            try
            {
                Brand isExsist = GetOne(g => g.Id == entity.Id);
                isExsist = entity;
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool CreateModelIntoBrand(Model entity)
        {
            try
            {
                List<Brand> isExist = DataContext.Brands.FindAll(s => s.Id == entity.BrandId);
                Brand brand = DataContext.Brands.Find(f => f.Id == entity.BrandId);
                brand.Model.Add(entity);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
