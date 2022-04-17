using DataAccess.Interfaces;
using Entities.Models;
using System;
using System.Collections.Generic;

namespace DataAccess.Repositories
{
    public class BrandRepository : IRepository<Brand>
    {
        /// <summary>
        /// Method çağrılarkən Brand istəyir və DataContext-dəki Brands listində Brand yaradır və ya əlavə edir
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
        /// Method çağrılarkən Brand istəyir və DataContext-dəki Brands listindəki seçilmiş brand-i silir
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
        /// DataContext-dəki Brands listinin hamısın geri qaytarır
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public List<Brand> GetAll(Predicate<Brand> filter = null)
        {
            try
            {
                return filter == null ? DataContext.Brands :
                    DataContext.Brands.FindAll(filter);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// DataContext-dəki Brands listindəki bir brandi geri qaytarır
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public Brand GetOne(Predicate<Brand> filter = null)
        {
            try
            {
                return filter == null ? null :
                    DataContext.Brands.Find(filter);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Method çağrılarkən Brand istəyir və DataContext-dəki Brands listindəki seçilmiş brand-in məlumatların dəyişir
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
        /// Method çağrılarkən Model istəyir və DataContext-dəki Brands listindəki 
        /// Modelin brandİd-si ilə Brands listedki brand id uyğunlaşdırır və  Modeli Brandə əlavə edir
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
        /// <summary>
        /// Method çağrılarkən Brand və Model istəyir və brandin içindəki modeli silir
        /// </summary>
        /// <param name="brand"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool DeleteModel(Brand brand, Model model)
        {
            try
            {
                foreach (var item in DataContext.Brands)
                {
                    if (brand.Id==model.BrandId)
                    {
                        item.Model.Remove(model);
                    }                    
                }
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
