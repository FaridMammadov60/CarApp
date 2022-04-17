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
        //Brand yaranan zaman fərqli id-də olması üçün Create methodunda count++ qeyd edilib
        public static int Count { get; set; }   
        //yaradılmış brand-lərin sayın tapmaq və brand sıfırdısa remove update kimi methodların istifadəsinin
        //qarşısın almaq üçün create methodunda counter ++ remove methodunda isə counter-- qeyd edilib
        public static int Counter { get; set; }

        //BrandRepository-dəki methodları çagırmaq üçün istifade edilecək
        private BrandRepository _brandRepository;

        //Constructor
        public BrandService()
        {
            _brandRepository = new BrandRepository();
        }
        /// <summary>
        /// Method çağrılarkın Brand isteyir və brand.id counta bərabər edir
        /// Brand yaratmaq üçün brandrepositoriyə gonderir və
        /// Count və counteri ++ edir
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
        /// Method çağrılarkın id isteyir və id-yə uyğun brand tapır əgər id-yə uyğun brand yoxdursa null qaytarır
        /// Tapılmış Brandi silmək üçün brandrepositoriyə gonderir
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
        /// Butun brendleri geri qaytarmaq üçün brandRepositorinin getAll methodun çağırır
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
        /// Method çağrılarkən id istəyir və həmin id üzrə brandi geri qaytarmaq üçün brandRepository çağırır
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
        /// Method çağrılarkən stringden name istəyir və həmin name üzrə brandi geri qaytarmaq üçün brandRepository çağırır
        /// </summary>
        /// <param name="string"></param>
        /// <returns></returns>
        public Brand GetOne(string name)
        {
            try
            {
                return _brandRepository.GetOne(g => g.Name == name);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Methodu çağırarkən Brand və id istəyir və id üzrə brandRepositor.getOne methodun çağırır
        /// əgər id-yə uyğun brand yoxdursa null qaytarır
        /// Tapılmış brandə yeni məlumatlar mənimsədilir və update üçün branrepositoryə göndərilir        
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
        /// Method çağrılarkənModel və id istəyir
        /// daxil olan id uzre brandi tapir əgər brand yoxdursa geriyə null qaytarır
        /// modeldeki brendId = edir id-ye
        /// modeli brandə əlavə etmək üçün brandaRepositoriyə gondəriri
        /// /// </summary>
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
        /// <summary>
        /// Brandin içindəki modeli silir
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        public Brand RemoveModelInBrand(Model model)
        {
            try
            {
                Brand isExist = _brandRepository.GetOne(g => g.Id == model.BrandId);
                if (isExist == null)
                {
                    Extention.Print(ConsoleColor.Red, "Id does not exist");
                    return null;
                }
                _brandRepository.DeleteModel(isExist, model);
                return isExist;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
