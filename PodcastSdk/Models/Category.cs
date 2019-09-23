using System.Xml.Serialization;

namespace PodcastSdk.Models
{
    [XmlType(Namespace = Namespaces.ITunes)]
    public class Category
    {
        [XmlAttribute("text")]
        public string Text { get; set; }

        [XmlElement(ElementName = "category")]
        public Category Subcategory { get; set; }
    }
}
