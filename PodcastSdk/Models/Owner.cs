using System.Xml.Serialization;

namespace PodcastSdk.Models
{
    [XmlType(Namespace = Namespaces.ITunes)]
    public class Owner
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("email")]
        public string Email { get; set; }
    }
}
