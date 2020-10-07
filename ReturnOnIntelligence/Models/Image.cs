using System;
using System.Xml.Serialization;

namespace ReturnOnIntelligence.Models
{
    [XmlType("image")]
    public class Image
    {
        [XmlElement("id")]
        public string Id { get; set; }

        [XmlElement("url")]
        public string Url { get; set; }

        [XmlElement("source_url")]
        public string SourceUrl { get; set; }
    }
}