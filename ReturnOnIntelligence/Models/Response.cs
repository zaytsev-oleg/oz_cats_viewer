using System;
using System.Xml.Serialization;

namespace ReturnOnIntelligence.Models
{
    [XmlRoot("response")]
    public class Response<T> where T : IDataModel
    {
        [XmlElement("data")]
        public T Data { get; set; }
    }

    [XmlType("data")]
    public class Categories : IDataModel
    {
        [XmlArray("categories")]
        [XmlArrayItem(typeof(Category))]
        public Category[] Items { get; set; }
    }

    [XmlType("data")]
    public class Images : IDataModel
    {
        [XmlArray("images")]
        [XmlArrayItem(typeof(Image))]
        public Image[] Items { get; set; }
    }
}