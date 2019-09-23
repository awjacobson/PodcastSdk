using System.Xml.Serialization;

namespace PodcastSdk.Models
{
    [XmlType("rss")]
    public class Rss
    {
        [XmlAttribute("version")]
        public string Version { get; set; } = "2.0"; 

        [XmlElement("channel")]
        public Channel Channel { get; set; }
    }
}
