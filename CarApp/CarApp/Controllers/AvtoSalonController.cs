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
    internal class AvtoSalonController
    {
        //avtoSalonServisde olan methodlari cağırmaq üçün istifadə ediləcək
        private AvtoSalonService _avtoSalonService;
        //Consturctor
        public AvtoSalonController()
        {
            _avtoSalonService = new AvtoSalonService(); 
        }

        /// <summary>
        /// AvtoSalon yaratmaq üçün melumatlar daxil edib avtoSalonServise gönderirik
        /// </summary>
        public void CreateAvtoSalon()
        {
            Console.Clear();
            Extention.Print(ConsoleColor.DarkCyan, "Enter to Avto Salon Name: ");
            string name = Extention.TryEmptyMethod();
            Extention.Print(ConsoleColor.DarkCyan, "Enter to Avto Salon Size: ");
            int size = Extention.TryParseMethod();

            AvtoSalon avtoSalon = new AvtoSalon()
            {
                Name = name,
                Size = size
                
            };
            if (_avtoSalonService.GetOne(name) != null)
            {
                Extention.Print(ConsoleColor.Red, "This Avto Salon already exists");
                return;
            }

            _avtoSalonService.Create(avtoSalon);
            Extention.Print(ConsoleColor.Green, $"{avtoSalon.Name} created");

        }
        /// <summary>
        /// AvtoSalonda olan məlumatları yeniləyib avtosalonservisə göndəririk
        /// </summary>
        public void UpdateAvtoSalon()
        {
            Console.Clear();
            if (AvtoSalonService.Counter <= 0)
            {
                Extention.Print(ConsoleColor.Red, "AvtoSalon not available");
                return;
            }

            Extention.Print(ConsoleColor.DarkCyan, "Enter to AvtoSalon ID: ");
            int id = Extention.TryParseMethod();
            if (_avtoSalonService.GetOne(id) == null)
            {
                Extention.Print(ConsoleColor.Red, "Id does not exist");
                return;
            }
            _avtoSalonService.GetOne(id);
            Extention.Print(ConsoleColor.DarkCyan, "Enter to avtosalon Name: ");
            string name = Extention.TryEmptyMethod();


            AvtoSalon avtoSalon = new AvtoSalon()
            {
                Name = name,
            };
            _avtoSalonService.Update(avtoSalon, id);
        }
        /// <summary>
        /// Bütün avtoSalonları göstərmək üçün istifadə edirik
        /// </summary>
        public void GetAllAvtoSalon()
        {
            Console.Clear();
            foreach (var item in _avtoSalonService.GetAll())
            {
                Extention.Print(ConsoleColor.Green, $"Avtosalon Id: {item.Id}\n" +
                    $"Avtosalon name: {item.Name}\n" +
                    $"Avtosalon size: {item.Size}\n" +
                    $"Avtosalon count: {item.CarCount} \n" +
                    $"");
            }
        }
        /// <summary>
        ///  Daxil edilmiş id-yə uyğun avtoSalonu və avtoSalondakı bütün məlumatları consola çıxardırıq
        /// </summary>
        public void GetAvtoSalon()
        {
            Console.Clear();
            if (AvtoSalonService.Counter <= 0)
            {
                Extention.Print(ConsoleColor.Red, "AvtoSalon not available");
                return;
            }

            Extention.Print(ConsoleColor.DarkCyan, "Enter to AvtoSalon ID: ");
            int id = Extention.TryParseMethod();
            if (_avtoSalonService.GetOne(id) == null)
            {
                Extention.Print(ConsoleColor.Red, "Id does not exist");
                return;
            }            
            Extention.Print(ConsoleColor.Green, $"Avtosalon Name: {_avtoSalonService.GetOne(id).Name}\n" +
                $"Avtosalon Size: {_avtoSalonService.GetOne(id).Size}\n" +
                $"Avtosalon carcount: {_avtoSalonService.GetOne(id).CarCount}");
            
            foreach (var item in _avtoSalonService.GetOne(id).Model)
            {
                Extention.Print(ConsoleColor.Green, $"Model name: {item.Name}\n" +
                    $"Model price: {item.Price}$\n" +
                    $"Model production: {item.Production}\n" +
                    $"Model color: {item.Color}\n" +
                    $"Model MPH: {item.Mph}mph\n" +
                    $"");          
            }

        }
        /// <summary>
        /// Daxil edilmiş id-yə uyğun avtoSalonu silirik
        /// </summary>
        public void RemoveAvtoSalon()
        {
            Console.Clear();
            if (AvtoSalonService.Counter <= 0)
            {
                Extention.Print(ConsoleColor.Red, "AvtoSalon not available");
                return;
            }
            Extention.Print(ConsoleColor.DarkCyan, "AvtoSalon Id: ");
            int id = Extention.TryParseMethod();
            if (_avtoSalonService.GetOne(id) == null)
            {
                Extention.Print(ConsoleColor.Red, "Id does not exist");
                return;
            }
            AvtoSalon avtoSalon = _avtoSalonService.Delete(id);
            Extention.Print(ConsoleColor.Green, $"{avtoSalon.Name}");
        }
        /// <summary>
        /// Avtosalonun içinə model daxil edirik
        /// </summary>
        public void ModelAddAvtoSalon()
        {
            Console.Clear();
            if (AvtoSalonService.Counter < 0)
            {
                Extention.Print(ConsoleColor.Red, "AvtoSalon not available");
                return;
            }
            Extention.Print(ConsoleColor.DarkCyan, "Enter to AvtoSalon id: ");
            int id = Extention.TryParseMethod();
            if (_avtoSalonService.GetOne(id) == null)
            {
                Extention.Print(ConsoleColor.Red, "Id does not exist");
                return;
            }            
            Extention.Print(ConsoleColor.DarkCyan, "Enter to Model id: ");
            int id1 = Extention.TryParseMethod();
            ModelController modelController = new ModelController();
            foreach (var item in _avtoSalonService.GetOne(id).Model)
            {
                if (modelController.GetModel(id1).Id ==item.Id)
                {
                    Extention.Print(ConsoleColor.Red, "This Model already exists");
                    return;
                }
            }
            
            _avtoSalonService.CreatModelIntoAvtosalon(modelController.GetModel(id1), id);

        }
    }
}
