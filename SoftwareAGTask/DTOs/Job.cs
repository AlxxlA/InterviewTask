using System.Xml;
using System.Xml.Serialization;

namespace SoftwareAGTask.DTOs
{
    public class Job
    {
        [XmlElement("jobTitle")]
        public string JobTitle { get; set; }

        [XmlElement("employer")]
        public string Employer { get; set; }

        [XmlElement("period")]
        public Periond Period { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }
    }
}

