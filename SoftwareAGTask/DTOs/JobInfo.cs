using System.Xml.Serialization;

namespace SoftwareAGTask.DTOs
{
    public class JobInfo
    {
        [XmlElement("jobTitle")]
        public string JobTitle { get; set; }

        [XmlElement("department")]
        public string Department { get; set; }
    }
}
