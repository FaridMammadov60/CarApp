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
    internal class ModelController
    {
        //branServisde olan methodlari cağırmaq üçün istifadə ediləcək
        public ModelService _modelService;
        //Consturctor
        public ModelController()
        {
            _modelService = new ModelService();
        }
        /// <summary>
        /// Bu method ilə brandin içində yeni model yaradılır
        /// </summary>
        /// <returns></returns>
        public Model CreatModelinBrand()
        {
            Console.Clear();
            Extention.Print(ConsoleColor.DarkCyan, "Enter to Model Name: ");
            string name = Extention.TryEmptyMethod();
            Extention.Print(ConsoleColor.DarkCyan, "Enter to Model Color: ");
            string color = Extention.TryEmptyMethod();
            Extention.Print(ConsoleColor.DarkCyan, "Enter to Model Production: ");
            int production = Extention.TryParseMethod();
            Extention.Print(ConsoleColor.DarkCyan, "Enter to Model Mph: ");
            int mph = Extention.TryParseMethod();            
            Extention.Print(ConsoleColor.DarkCyan, "Enter to Model Price: ");
            int price = Extention.TryParseMethod();

            Model model = new Model()
            {
                Name = name,
                Color = color,
                Production = production,
                Mph = mph,
                Price = price
            };

            _modelService.Create(model);
            Extention.Print(ConsoleColor.Green, $"{model.Name} created");
            return model;
        }
        /// <summary>
        /// Model yaratmaq üçün melumatlar daxil edib modelServise gönderirik
        /// </summary>
        public void ModelCreat()
        {
            Console.Clear();
            Extention.Print(ConsoleColor.DarkCyan, "Enter to Model Name: ");
            string name = Extention.TryEmptyMethod();
            Extention.Print(ConsoleColor.DarkCyan, "Enter to Model Color: ");
            string color = Extention.TryEmptyMethod();
            Extention.Print(ConsoleColor.DarkCyan, "Enter to Model Production: ");
            int production = Extention.TryParseMethod();
            Extention.Print(ConsoleColor.DarkCyan, "Enter to Model Mph: ");
            int mph = Extention.TryParseMethod();            
            Extention.Print(ConsoleColor.DarkCyan, "Enter to Model Price: ");
            int price = Extention.TryParseMethod();

            Model model = new Model()
            {
                Name = name,
                Color = color,
                Production = production,
                Mph = mph,
                Price = price
            };

            _modelService.Create(model);
            Extention.Print(ConsoleColor.Green, $"{model.Name} created");
        }
        /// <summary>
        /// Bütün modelleri consola çıxarırıq
        /// </summary>
        public void GetAllModel()
        {
            foreach (var item in _modelService.GetAll())
            {
                Extention.Print(ConsoleColor.Green, $"Model name: {item.Name}\n" +
                    $"Model price: {item.Price}$\n" +
                    $"Model production: {item.Production}\n" +
                    $"Model color: {item.Color}\n" +
                    $"Model MPH: {item.Mph}mph");
            }
        }
        /// <summary>
        /// Modeldə olan məlumatları yeniləyib modelservisə göndəririk
        /// </summary>
        public void UpdateModel()
        {
            if (ModelService.Counter <= 0)
            {
                Extention.Print(ConsoleColor.Red, "Model not available");
                return;
            }
            Extention.Print(ConsoleColor.DarkCyan, "Enter to Model Id: ");
            int id = Extention.TryParseMethod();
            if (_modelService.GetOne(id) == null)
            {
                Extention.Print(ConsoleColor.Red, "Id does not exist");
                return;
            }
            Extention.Print(ConsoleColor.DarkCyan, "Enter to Model Name: ");
            string name = Extention.TryEmptyMethod();
            Extention.Print(ConsoleColor.DarkCyan, "Enter to Model Color: ");
            string color = Extention.TryEmptyMethod();
            Extention.Print(ConsoleColor.DarkCyan, "Enter to Model Production: ");
            int production = Extention.TryParseMethod();
            Extention.Print(ConsoleColor.DarkCyan, "Enter to Model Mph: ");
            int mph = Extention.TryParseMethod();            
            Extention.Print(ConsoleColor.DarkCyan, "Enter to Model Price: ");
            int price = Extention.TryParseMethod();

            Model model = new Model()
            {
                Name = name,
                Color = color,
                Production = production,
                Mph = mph,
                Price = price
            };
            model.BrandId = _modelService.GetOne(id).BrandId;
            _modelService.Update(model, id);
        }
        /// <summary>
        /// Daxil edilmiş id-yə uyğun modeli silirik
        /// </summary>
        public void RemoveModel()
        {
            Console.Clear();
            if (ModelService.Counter <= 0)
            {
                Extention.Print(ConsoleColor.Red, "Model not available");
                return;
            }
            Extention.Print(ConsoleColor.DarkCyan, "Enter to Model Id: ");
            int id = Extention.TryParseMethod();
            if (_modelService.GetOne(id) == null)
            {
                Extention.Print(ConsoleColor.Red, "Id does not exist");
                return;
            }
            Model Model = _modelService.Delete(id);
            Extention.Print(ConsoleColor.Green, $"{Model.Name}");
        }
        /// <summary>
        /// Daxil edilmiş id-yə uyğun modeli və modeldəki bütün məlumatları consola çıxardırıq
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model GetModel(int id)
        {
            Console.Clear();
            if (ModelService.Counter <= 0)
            {
                Extention.Print(ConsoleColor.Red, "Model not available");
                return null;
            }
            if (_modelService.GetOne(id) == null)
            {
                Extention.Print(ConsoleColor.Red, "Id does not exist");
                return null;
            }
            return _modelService.GetOne(id);

        }
    }
}
