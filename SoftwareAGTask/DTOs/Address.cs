using System.Xml;
using System.Xml.Serialization;

namespace SoftwareAGTask.DTOs
{
    public class Address
    {
        [XmlElement("street")]
        public string Street { get; set; }

        [XmlElement("city")]
        public string City { get; set; }

        [XmlElement("country")]
        public string Country { get; set; }
    }
}
