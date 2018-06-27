using System.Xml;
using System.Xml.Serialization;

namespace SoftwareAGTask.DTOs
{
    public class Education
    {
        [XmlElement("institution")]
        public string Institution { get; set; }

        [XmlElement("degree")]
        public string Degree { get; set; }

        [XmlElement("period")]
        public Periond Period { get; set; }
    }
}
