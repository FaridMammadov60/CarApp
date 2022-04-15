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
    public class BrandService : IService<Brand>
    {
        public static int Count { get; set; }   
        public static int Counter { get; set; }

        //BrandRepository-daki methodlari cagirmaq ucun istifade eedilecek
        private BrandRepository _brandRepository;

        //Constructor
        public BrandService()
        {
            _brandRepository = new BrandRepository();
        }
        /// <summary>
        /// Brand Controllerden gelen brandi yaratmaq ucun brandrepositoriye gonderir
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Brand Create(Brand entity)
        {
            try
            {
                entity.Id = Count;
                _brandRepository.Create(entity);
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
        /// Brand Controllerden gelen brandi silmek ucun brandrepositoriye gonderir
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Brand Delete(int id)
        {
            try
            {
                Brand isExist = _brandRepository.GetOne(g => g.Id == id);
                if (isExist == null)
                {
                    Extention.Print(ConsoleColor.Red, "Id does not exist");
                    return null;
                }
                _brandRepository.Delete(isExist);
                Counter--;
                return isExist;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Butun brendleri gormek ucun brand servisi cagirir
        /// </summary>
        /// <returns></returns>
        public List<Brand> GetAll()
        {
            try
            {
                return _brandRepository.GetAll();
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Controllerden gelen id uzre repositoriden brandi tapir
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Brand GetOne(int id)
        {
            try
            {
                return _brandRepository.GetOne(g => g.Id == id);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Contollerden gelen id uzre brandi tapmaq ucun repositorini cagirir
        /// ve controllerden gelen brandi tapilmis brande menimsedir
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public Brand Update(Brand entity, int id)
        {
            try
            {
                Brand isExist =_brandRepository.GetOne(g=>g.Id == id);
                if (isExist == null)
                {
                    Extention.Print(ConsoleColor.Red, "Id does not exist");
                    return null;
                }
                isExist.Name=entity.Name;
                _brandRepository.Update(entity);
                return entity;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Controllerden daxil olan id uzre brandi tapib
        /// modeli brande elave etmek ucun repositoriden method cagiririq
        /// modeldeki brendId = edirik id-ye
        /// </summary>
        /// <param name="model"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public Brand CreatModelIntoBrand(Model model, int id)
        {
            try
            {
                Brand brand = _brandRepository.GetOne(g => g.Id == id);
                if (brand == null)
                {
                    Extention.Print(ConsoleColor.Red, "Id does not exist");
                    return null;
                }
                model.BrandId = id;
                _brandRepository.CreateModelIntoBrand(model);
                return brand;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
