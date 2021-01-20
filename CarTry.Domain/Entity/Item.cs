using CarTry.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarTry.Domain.Entity
{
    public class Item : BaseEntity
    {
        [XmlElement("Car brand")]
        public string CarBrand { get; set; }
        [XmlElement("Car model")]
        public string CarModel { get; set; }
        [XmlElement("Car location")]
        public string CarLocation { get; set; }

        public Item()
        {

        }

        public Item(int id, string carModel, string carBrand, DateTime dateTime, string carLocation)
        {
            CarModel = carModel;
            CarBrand = carBrand;
            Id = id;
            CreatedDateTime = dateTime;
            CarLocation = carLocation;

        }
    }
}
