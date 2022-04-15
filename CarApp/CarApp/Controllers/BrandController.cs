using Business.Services;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Helper;

namespace CarApp.Controllers
{
    internal class BrandController
    {
        private BrandService _brandService;

        public BrandController()
        {
            _brandService = new BrandService();
        }
        public void ModelAddBrand()
        {

            if (BrandService.Counter <= 0)
            {
                Extention.Print(ConsoleColor.Red, "Brand not available");
                return;
            }
            Extention.Print(ConsoleColor.DarkCyan, "Brand id: ");
            int id = Extention.TryParseMethod();           
            Extention.Print(ConsoleColor.DarkCyan, "Model id: ");
            int id1 = Extention.TryParseMethod();
            ModelController modelController = new ModelController();

            _brandService.CreatModelIntoBrand(modelController.GetModel(id1), id);

        }


        public void AddModelInBrand()
        {

            if (BrandService.Counter <= 0)
            {
                Extention.Print(ConsoleColor.Red, "Brand not available");
                return;
            }
            Extention.Print(ConsoleColor.DarkCyan, "Brand id: ");
            int id = Extention.TryParseMethod();

            ModelController modelController = new ModelController();
            Model model = modelController.CreatModelinBrand();

            _brandService.CreatModelIntoBrand(model, id);

        }

        public void CreateBrand()
        {

            Extention.Print(ConsoleColor.DarkCyan, "Enter to Brand Name: ");
            string name = Extention.TryEmptyMethod();            

            Brand brand = new Brand()
            {
                Name = name,                
            };
            Console.Clear();
            _brandService.Create(brand);
            Extention.Print(ConsoleColor.Green, $"{brand.Name} created");

        }

        public void UpdateBrand()
        {
            if (BrandService.Counter <= 0)
            {
                Extention.Print(ConsoleColor.Red, "Brand not available");
                return;
            }
            Extention.Print(ConsoleColor.DarkCyan, "Brand ID: ");
            int id = Extention.TryParseMethod();
            _brandService.GetOne(id);
            Extention.Print(ConsoleColor.DarkCyan, "Brand Name: ");
            string name = Extention.TryEmptyMethod();
            

            Brand brand = new Brand()
            {
                Name = name,              
            };
            _brandService.Update(brand, id);
        }
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
        public void GetBrand()
        {
            if (BrandService.Counter <= 0)
            {
                Extention.Print(ConsoleColor.Red, "Brand not available");
                return;
            }
            Extention.Print(ConsoleColor.DarkCyan, "Brand ID: ");
            int id = Extention.TryParseMethod();
            Extention.Print(ConsoleColor.Green, "Brand Name");
            Extention.Print(ConsoleColor.Green, $"{_brandService.GetOne(id).Name}");
           
            foreach (var item in _brandService.GetOne(id).Model)
            {               
                Extention.Print(ConsoleColor.Green, $"Model name: {item.Name}\n" +
                    $"Model price: {item.Price}\n" +
                    $"Model production: {item.Production}\n" +
                    $"Model color: {item.Color}\n" +
                    $"Model MPH: {item.Mph}");
            }

        }

        public void RemoveBrand()
        {
            if (BrandService.Counter <= 0)
            {
                Extention.Print(ConsoleColor.Red, "Brand not available");
                return;
            }
            Extention.Print(ConsoleColor.DarkCyan, "Brand Id: ");
            int id = Extention.TryParseMethod();
            Brand brand = _brandService.Delete(id);
            Extention.Print(ConsoleColor.Green, $"{brand.Name}");
        }
    }
}
