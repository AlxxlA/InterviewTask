using System;
using System.Xml;
using System.Xml.Serialization;

namespace SoftwareAGTask.DTOs
{
    public class Periond
    {
        [XmlElement("from")]
        public DateTime From { get; set; }

        [XmlElement("to")]
        public DateTime? To { get; set; }
    }
}
