using DataAccess.Interfaces;
using Entities.Models;
using System;
using System.Collections.Generic;

namespace DataAccess.Repositories
{
    public class ModelRepository : IRepository<Model>
    {
        /// <summary>
        /// Method çağrılarkən Model istəyir və DataContext-dəki Models listində Model yaradır və ya əlavə edir
        /// </summary>
        /// <param name="entity">Servisden gelen model</param>
        /// <returns></returns>
        public bool Create(Model entity)
        {
            try
            {
                DataContext.Models.Add(entity);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Method çağrılarkən Model istəyir və DataContext-dəki Models listindəki seçilmiş modeli-i silir
        /// </summary>
        /// <param name="entity">Servisden gelen model</param>
        /// <returns></returns>
        public bool Delete(Model entity)
        {
            try
            {
                DataContext.Models.Remove(entity);
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// DataContext-dəki Models listinin hamısın geri qaytarır
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public List<Model> GetAll(Predicate<Model> filter = null)
        {
            try
            {
                return filter == null ? DataContext.Models :
                    DataContext.Models.FindAll(filter);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// DataContext-dəki Models listindəki bir modeli geri qaytarır
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public Model GetOne(Predicate<Model> filter = null)
        {
            try
            {
                return filter == null ? null :
                DataContext.Models.Find(filter);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Method çağrılarkən Model istəyir və DataContext-dəki Models listindəki seçilmiş model-in məlumatların dəyişir
        /// </summary>
        /// <param name="entity">Servisden gelen model</param>
        /// <returns></returns>
        public bool Update(Model entity)
        {
            try
            {
                Model isExist = GetOne(s => s.Id == entity.Id);
                isExist = entity;
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
