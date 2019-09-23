using System.Xml.Serialization;

namespace PodcastSdk.Models
{
    [XmlRoot(ElementName = "image", Namespace = Namespaces.ITunes)]
    public class Image
    {
        [XmlAttribute("href")]
        public string Href { get; set; }
    }
}
