using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace SoftwareAGTask.DTOs
{
    [Serializable()]
    [XmlRoot("personInfo", IsNullable = true)]
    public class PersonInfo
    {
        [XmlElement("person")]
        public Person Person { get; set; }

        [XmlElement("job")]
        public List<Job> Jobs { get; set; }

        [XmlElement("education")]
        public List<Education> Educations { get; set; }

        [XmlElement("skill")]
        public List<Skill> Skills { get; set; }
    }
}
