using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DataContext
    {
        #region Properties
        public static List<Brand> Brands { get; set; }
        public static List<Model> Models { get; set; }
        public static List<AvtoSalon> AvtoSalons { get; set; }
        #endregion

        #region Constructor
        static DataContext()
        {
            Brands = new List<Brand>();
            Models = new List<Model>();
            AvtoSalons = new List<AvtoSalon>();
        }
        #endregion

    }
}
