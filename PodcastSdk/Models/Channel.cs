using System.Xml.Serialization;

namespace PodcastSdk.Models
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// https://developers.google.com/search/reference/podcast/rss-feed
    /// https://help.apple.com/itc/podcasts_connect/#/itcb54353390
    /// </remarks>
    public class Channel
    {
        /// <summary>
        /// The show title.
        /// </summary>
        /// <example>
        /// Hiking Treks
        /// </example>
        [XmlElement("title")]
        public string Title { get; set; }

        /// <summary>
        /// The website associated with a podcast.
        /// </summary>
        /// <remarks>
        /// Typically a home page for a podcast or a dedicated portion of a larger website.
        /// </remarks>
        /// <example>
        /// https://www.apple.com/itunes/podcasts/
        /// </example>
        [XmlElement("link")]
        public string Link { get; set; }

        /// <summary>
        /// The language spoken on the show.
        /// </summary>
        /// <example>
        /// en-us
        /// </example>
        [XmlElement("language")]
        public string Language { get; set; } = "en-us";

        /// <summary>
        /// The show copyright details.
        /// </summary>
        /// <remarks>
        /// If your show is copyrighted you should use this tag.
        /// </remarks>
        /// <example>
        /// Copyright 1995-2019 John John Applesee
        /// </example>
        [XmlElement("copyright")]
        public string Copyright { get; set; }

        /// <summary>
        /// The group responsible for creating the show.
        /// </summary>
        [XmlElement(ElementName = "author", Namespace = Namespaces.ITunes)]
        public string Author { get; set; }

        /// <summary>
        /// The show description.
        /// </summary>
        [XmlElement("description")]
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <example>
        /// serial
        /// </example>
        [XmlElement(ElementName = "type", Namespace = Namespaces.ITunes)]
        public ChannelTypes Type { get; set; }

        [XmlElement(ElementName = "owner", Namespace = Namespaces.ITunes)]
        public Owner Owner { get; set; }

        /// <summary>
        /// The artwork for the show.
        /// </summary>
        /// <remarks>
        /// Artwork must be a minimum size of 1400 x 1400 pixels and a maximum size of 3000 x 3000 pixels,
        /// in JPEG or PNG format, 72 dpi, with appropriate file extensions (.jpg, .png), and in the RGB
        /// colorspace. These requirements are different from the standard RSS image tag specifications.
        /// <p>
        /// Make sure the file type in the URL matches the actual file type of the image file.
        /// </remarks>
        [XmlElement(ElementName = "image", Namespace = Namespaces.ITunes)]
        public Image Image { get; set; }

        [XmlElement(ElementName = "category", Namespace = Namespaces.ITunes)]
        public Category Category { get; set; }

        /// <summary>
        /// The podcast parental advisory information.
        /// </summary>
        [XmlElement(ElementName = "explicit", Namespace = Namespaces.ITunes)]
        public bool Explicit { get; set; } = false;

        [XmlElement("item")]
        public Item[] Items { get; set; }
    }

    public enum ChannelTypes
    {
        /// <summary>
        /// Specify episodic when episodes are intended to be consumed without any
        /// specific order.
        /// </summary>
        /// <remarks>
        /// Apple Podcasts will present newest episodes first and display the
        /// publish date (required) of each episode. If organized into seasons,
        /// the newest season will be presented first - otherwise, episodes will
        /// be grouped by year published, newest first.
        /// <p>
        /// For new subscribers, Apple Podcasts adds the newest, most recent
        /// episode in their Library.
        /// </remarks>
        [XmlEnum(Name = "episodic")]
        Episodic,

        /// <summary>
        /// Specify serial when episodes are intended to be consumed in sequential
        /// order.
        /// </summary>
        /// <remarks>
        /// Apple Podcasts will present the oldest episodes first and display the
        /// episode numbers (required) of each episode. If organized into seasons,
        /// the newest season will be presented first and <itunes:episode> numbers
        /// must be given for each episode.
        /// <p>
        /// For new subscribers, Apple Podcasts adds the first episode to their
        /// Library, or the entire current season if using seasons.
        /// </remarks>
        [XmlEnum(Name = "serial")]
        Serial
    }
}
