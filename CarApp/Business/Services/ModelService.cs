using Business.Interfaces;
using DataAccess.Repositories;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Helper;

namespace Business.Services
{
    public class ModelService:IService<Model>
    {
        public static int Count { get; set; }
        public static int Counter { get; set; }

        //ModelRepository-daki methodlari cagirmaq ucun istifade eedilecek
        private ModelRepository _modelRepository;

        //Constructor
        public ModelService()
        {
            _modelRepository = new ModelRepository();
        }
        public Model Create(Model entity)
        {
            try
            {
                entity.Id = Count;
                _modelRepository.Create(entity);
                Count++;
                Counter++;
                return entity;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Model Controllerden gelen Modeli silmek ucun Modelrepositoriye gonderir
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model Delete(int id)
        {
            try
            {
                Model isExist = _modelRepository.GetOne(g => g.Id == id);
                if (isExist == null)
                {
                    Extention.Print(ConsoleColor.Red, "Id does not exist");
                    return null;
                }
                _modelRepository.Delete(isExist);
                if (isExist.BrandId==null)
                {
                    //baxilmali
                }
                Counter--;
                return isExist;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Butun brendleri gormek ucun Model servisi cagirir
        /// </summary>
        /// <returns></returns>
        public List<Model> GetAll()
        {
            try
            {
                return _modelRepository.GetAll();
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Controllerden gelen id uzre repositoriden Modeli tapir
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model GetOne(int id)
        {
            try
            {
                return _modelRepository.GetOne(g => g.Id == id);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Contollerden gelen id uzre Modeli tapmaq ucun repositorini cagirir
        /// ve controllerden gelen Modeli tapilmis Modele menimsedir
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model Update(Model entity, int id)
        {
            try
            {
                Model isExist = _modelRepository.GetOne(g => g.Id == id);
                if (isExist == null)
                {
                    Extention.Print(ConsoleColor.Red, "Id does not exist");
                    return null;
                }
                isExist.Name = entity.Name;
                isExist.Price = entity.Price;
                isExist.Mph = entity.Mph;
                isExist.Color=entity.Color;
                isExist.Production=entity.Production;
                _modelRepository.Update(entity);
                return entity;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
