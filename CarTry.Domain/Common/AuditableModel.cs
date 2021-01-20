using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarTry.Domain.Common
{
    public class AuditableModel
    {
        [XmlIgnore]
        public int CreatedById { get; set; }
        [XmlElement("Date Time")]
        public DateTime CreatedDateTime { get; set; }
        [XmlIgnore]
        public int? ModifiedById { get; set; }
        [XmlIgnore]
        public DateTime? ModifiedDateTime { get; set; }

    }
}
