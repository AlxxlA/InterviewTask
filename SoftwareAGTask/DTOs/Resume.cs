using System.Xml.Serialization;

namespace SoftwareAGTask.DTOs
{
    [XmlRoot("resume")]
    public class Resume
    {
        public string ResumeId { get; set; }

        [XmlElement("jobInfo")]
        public JobInfo JobInfo { get; set; }

        [XmlElement("personInfo")]
        public PersonInfo PersonInfo { get; set; }
    }
}
