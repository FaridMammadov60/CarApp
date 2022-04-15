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
        /// <summary>
        /// Servisden gelen Brand yaratmaq ucun
        /// </summary>
        /// <param name="entity">servisden gelen brand</param>
        /// <returns></returns>
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
        /// <summary>
        /// Servisden gelen Brandslardan birin silmek ucun
        /// </summary>
        /// <param name="entity">servisden gelen brand</param>
        /// <returns></returns>
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
        /// <summary>
        /// Servisden gelen brandlarin hamisin tapmaq ucun
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Servisden gelen brandin birin tapmaq ucun
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Servisden gelen brandin melumatlarin deyishmek ucun
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Servisden gelen Modeli secilmis brande elave etmek ucun
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
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
