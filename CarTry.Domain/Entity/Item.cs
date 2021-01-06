using CarTry.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarTry.Domain.Entity
{
    public class Item : BaseEntity
    {
        public string CarBrand { get; set; }
        public string CarModel { get; set; }

        public Item(int id,string carModel, string carBrand)
        {
            CarModel = carModel;
            CarBrand = carBrand;
            Id = id;
        }    
    }
}
