using System.Xml;
using System.Xml.Serialization;

namespace SoftwareAGTask.DTOs
{
    public class Person
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlElement("phone")]
        public string Phone { get; set; }

        [XmlElement("email")]
        public string Email { get; set; }

        [XmlElement("address")]
        public Address Address { get; set; }
    }
}
