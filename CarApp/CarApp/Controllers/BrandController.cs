using Business.Services;
using Entities.Models;
using System;
using Utilities.Helper;

namespace CarApp.Controllers
{
    internal class BrandController
    {
        //branServisde olan methodlari cağırmaq üçün istifadə ediləcək
        private BrandService _brandService;
        //Consturctor
        public BrandController()
        {
            _brandService = new BrandService();
        }
        /// <summary>
        /// Var olan modeli var olan Brandin içində olan listə əlavə edirik
        /// Brand id və model id seçilir seçilmiş modeli brandin içinə daxil edilir.
        /// </summary>
        public void ModelAddBrand()
        {
            Console.Clear();
            if (BrandService.Counter <= 0)
            {
                Extention.Print(ConsoleColor.Red, "Brand not available");
                return;
            }
            Extention.Print(ConsoleColor.DarkCyan, "Enter to Brand id: ");
            int id = Extention.TryParseMethod();
            if (_brandService.GetOne(id) == null)
            {
                Extention.Print(ConsoleColor.Red, "Id does not exist");
                return;
            }
            Extention.Print(ConsoleColor.DarkCyan, "Enter to Model id: ");
            int id1 = Extention.TryParseMethod();
            ModelController modelController = new ModelController();

            _brandService.CreatModelIntoBrand(modelController.GetModel(id1), id);

        }

        /// <summary>
        /// Brand İD seçilir və həmin brandin içindən yeni model yaradılır
        /// </summary>
        public void AddModelInBrand()
        {

            if (BrandService.Counter <= 0)
            {
                Extention.Print(ConsoleColor.Red, "Brand not available");
                return;
            }
            Extention.Print(ConsoleColor.DarkCyan, "Enter to Brand id: ");
            int id = Extention.TryParseMethod();
            if (_brandService.GetOne(id) == null)
            {
                Extention.Print(ConsoleColor.Red, "Id does not exist");
                return;
            }
            ModelController modelController = new ModelController();
            Model model = modelController.CreatModelinBrand();

            _brandService.CreatModelIntoBrand(model, id);

        }
        /// <summary>
        /// Brand yaratmaq üçün melumatlar daxil edib brandServise gönderirik
        /// </summary>
        public void CreateBrand()
        {
            Console.Clear();
            Extention.Print(ConsoleColor.DarkCyan, "Enter to Brand Name: ");
            string name = Extention.TryEmptyMethod();            
            Brand brand = new Brand()
            {
                Name = name,
            };
            if (_brandService.GetOne(name)!=null)
            {
                Extention.Print(ConsoleColor.Red, "This brand already exists");
                return;
            }            
            
            _brandService.Create(brand);
            Extention.Print(ConsoleColor.Green, $"{brand.Name} created");

        }
        /// <summary>
        /// Branddə olan məlumatları yeniləyib brand servisə göndəririk
        /// </summary>
        public void UpdateBrand()
        {
            Console.Clear();
            if (BrandService.Counter <= 0)
            {
                Extention.Print(ConsoleColor.Red, "Brand not available");
                return;
            }

            Extention.Print(ConsoleColor.DarkCyan, "Enter to Brand ID: ");
            int id = Extention.TryParseMethod();
            if (_brandService.GetOne(id) == null)
            {
                Extention.Print(ConsoleColor.Red, "Id does not exist");
                return;
            }
            _brandService.GetOne(id);
            Extention.Print(ConsoleColor.DarkCyan, "Enter to Brand Name: ");
            string name = Extention.TryEmptyMethod();


            Brand brand = new Brand()
            {
                Name = name,
            };
            _brandService.Update(brand, id);
        }
        /// <summary>
        /// Bütün brandlari göstərmək üçün istifadə edirik
        /// </summary>
        public void GetAllBrand()
        {
            Console.Clear();
            foreach (var item in _brandService.GetAll())
            {
                Extention.Print(ConsoleColor.Green, $"Brand Id: {item.Id}\n" +
                    $"Brand name: {item.Name}\n" +
                    $"");
            }
        }
        /// <summary>
        ///  Daxil edilmiş id-yə uyğun brandi və branddəki bütün məlumatları consola çıxardırıq
        /// </summary>
        public void GetBrand()
        {
            try
            {
                if (BrandService.Counter <= 0)
                {
                    Extention.Print(ConsoleColor.Red, "Brand not available");
                    return;
                }

                Extention.Print(ConsoleColor.DarkCyan, "Enter to Brand ID: ");
                int id = Extention.TryParseMethod();
                
                if (_brandService.GetOne(id) == null)
                {
                    Extention.Print(ConsoleColor.Red, "Id does not exist");
                    return;
                }
                Console.Clear();
                Extention.Print(ConsoleColor.Green, $"Brand Name: {_brandService.GetOne(id).Name}");


                foreach (var item in _brandService.GetOne(id).Model)
                {
                    Extention.Print(ConsoleColor.Green, $"Model name: {item.Name}\n" +
                        $"Model price: {item.Price}$\n" +
                        $"Model production: {item.Production}\n" +
                        $"Model color: {item.Color}\n" +
                        $"Model MPH: {item.Mph}mph\n" +
                        $"");
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        /// <summary>
        /// Daxil edilmiş id-yə uyğun brandi silirik
        /// </summary>
        public void RemoveBrand()
        {
            Console.Clear();
            if (BrandService.Counter <= 0)
            {
                Extention.Print(ConsoleColor.Red, "Brand not available");
                return;
            }
            Extention.Print(ConsoleColor.DarkCyan, "Brand Id: ");
            int id = Extention.TryParseMethod();
            if (_brandService.GetOne(id) == null)
            {
                Extention.Print(ConsoleColor.Red, "Id does not exist");
                return;
            }
            Brand brand = _brandService.Delete(id);
            Extention.Print(ConsoleColor.Green, $"{brand.Name}");
        }
    }
}
