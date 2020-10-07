using System;
using System.Xml.Serialization;

namespace ReturnOnIntelligence.Models
{
    [XmlType("category")]
    public class Category
    {
        [XmlElement("id")]
        public string Id { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }
    }
}