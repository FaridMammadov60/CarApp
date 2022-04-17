using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class AvtoSalon:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public int CarCount { get; set; }

        public List<Model> Model { get; set; }

        #region MyRegion
        public AvtoSalon()
        {
            Model = new List<Model>();
        }
        #endregion


    }
}
