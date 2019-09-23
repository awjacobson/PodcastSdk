using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace PodcastSdk.Models
{
    public class Item : IXmlSerializable
    {
        /// <summary>
        /// The episode type.
        /// </summary>
        public EpisodeTypes EpisodeType { get; set; }

        /// <summary>
        /// An episode number.
        /// </summary>
        /// <remarks>
        /// If all your episodes have numbers and you would like them to be ordered based on them use this tag for each one.
        /// <p>
        /// Episode numbers are optional for <itunes:type> episodic shows, but are mandatory for serial shows.
        /// <p>
        /// Where episode is a non-zero integer (1, 2, 3, etc.) representing your episode number.
        /// </remarks>
        public int? Episode { get; set; }

        /// <summary>
        /// The episode season number.
        /// </summary>
        /// <remarks>
        /// If an episode is within a season use this tag.
        /// <p>
        /// Where season is a non-zero integer(1, 2, 3, etc.) representing your season number.
        /// <p>
        /// To allow the season feature for shows containing a single season, if
        /// only one season exists in the RSS feed, Apple Podcasts doesn’t display
        /// a season number.When you add a second season to the RSS feed, Apple
        /// Podcasts displays the season numbers.
        /// </remarks>
        public int? Season { get; set; }

        /// <summary>
        /// An episode title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// <itunes:subtitle>
        /// </summary>
        public string Subtitle { get; set; }

        /// <summary>
        /// An episode description (plain text).
        /// </summary>
        /// <remarks>
        /// description is text containing one or more sentences describing your episode to potential
        /// listeners. You can specify up to 4000 characters.
        /// </remarks>
        public string Description { get; set; }

        /// <summary>
        /// An episode description (HTML formatted).
        /// </summary>
        /// <remarks>
        /// Same as Description but includes HTML formatting. You can use rich text formatting and
        /// some HTML (<p>, <ol>, <ul>, <li>, <a>).
        /// </remarks>
        public string DescriptionEncoded { get; set; }

        public string Author { get; set; }

        /// <summary>
        /// The episode artwork.
        /// </summary>
        /// <remarks>
        /// Artwork must be a minimum size of 1400 x 1400 pixels and a maximum size of 3000 x 3000
        /// pixels, in JPEG or PNG format, 72 dpi, with appropriate file extensions (.jpg, .png),
        /// and in the RGB colorspace. These requirements are different from the standard RSS
        /// image tag specifications.
        /// <p>
        /// Make sure the file type in the URL matches the actual file type of the image file.
        /// </remarks>
        public Image Image { get; set; }

        /// <summary>
        /// An episode link URL.
        /// </summary>
        /// <remarks>
        /// This is used when an episode has a corresponding webpage.
        /// </remarks>
        public string Link { get; set; }

        /// <summary>
        /// The episode content, file size, and file type information.
        /// </summary>
        public Enclosure Enclosure { get; set; }

        /// <summary>
        /// The episode’s globally unique identifier.
        /// </summary>
        public string Guid { get; set; }

        /// <summary>
        /// The date and time when an episode was released.
        /// </summary>
        /// <remarks>
        /// Format the date using the RFC 2822 specifications.
        /// http://www.faqs.org/rfcs/rfc2822.html
        /// </remarks>
        /// <example>
        /// Wed, 15 Jun 2019 19:00:00 GMT.
        /// </example>
        public DateTime PubDate { get; set; }

        /// <summary>
        /// The duration of an episode.
        /// </summary>
        /// <remarks>
        /// Different duration formats are accepted however it is recommended to convert
        /// the length of the episode into seconds.
        /// </remarks>
        public int Duration { get; set; }

        public bool Explicit { get; set; } = false;

        #region IXmlSerializable

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            throw new System.NotImplementedException();
        }

        public void WriteXml(XmlWriter writer)
        {
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            writer.WriteElementString("episodeType", Namespaces.ITunes, EpisodeType.ToString());

            if (Episode.HasValue)
            {
                writer.WriteElementString("episode", Namespaces.ITunes, Episode.Value.ToString());
            }

            if (Season.HasValue)
            {
                writer.WriteElementString("season", Namespaces.ITunes, Season.Value.ToString());
            }

            writer.WriteElementString("title", Title);

            if (!string.IsNullOrWhiteSpace(Subtitle))
            {
                writer.WriteElementString("subtitle", Namespaces.ITunes, Subtitle);
            }

            /*
             * These nodes will be populated with the Description property
             */
            writer.WriteElementString("description", Description);
            writer.WriteElementString("summary", Namespaces.ITunes, Description);

            if (!string.IsNullOrWhiteSpace(DescriptionEncoded))
            {
                writer.WriteStartElement("encoded", Namespaces.Content);
                writer.WriteCData(DescriptionEncoded);
                writer.WriteEndElement();
            }

            writer.WriteElementString("author", Namespaces.ITunes, Author);

            XmlSerializerNamespaces ns2 = new XmlSerializerNamespaces();
            ns2.Add("itunes", Namespaces.ITunes);
            new XmlSerializer(typeof(Image)).Serialize(writer, Image, ns2);

            writer.WriteElementString("link", Link);
            new XmlSerializer(typeof(Enclosure)).Serialize(writer, Enclosure, ns);
            writer.WriteElementString("guid", Guid);
            writer.WriteElementString("pubDate", PubDate.ToUniversalTime().ToString("ddd, dd MMM yyyy HH:mm:ss +0000"));
            writer.WriteElementString("duration", Namespaces.ITunes, Duration.ToString());
            writer.WriteElementString("explicit", Namespaces.ITunes, Explicit ? "true" : "false");
        }

        #endregion

        //public string ConvertDuration()
        //{
        //    var t = TimeSpan.FromSeconds(Duration);
        //    return t.ToString(@"hh\:mm\:ss");
        //}
    }

    public enum EpisodeTypes
    {
        /// <summary>
        /// Specify full when you are submitting the complete content of your show.
        /// </summary>
        [XmlEnum(Name = "full")]
        Full,

        /// <summary>
        /// Specify trailer when you are submitting a short, promotional piece of
        /// content that represents a preview of your current show.
        /// </summary>
        [XmlEnum(Name = "trailer")]
        Trailer,

        /// <summary>
        /// Specify bonus when you are submitting extra content for your show (for
        /// example, behind the scenes information or interviews with the cast) or
        /// cross-promotional content for another show.
        /// </summary>
        [XmlEnum(Name = "Bonus")]
        bonus
    }
}
