using System.Xml.Serialization;

namespace PodcastSdk.Models
{
    /// <summary>
    /// The episode content, file size, and file type information.
    /// </summary>
    [XmlType("enclosure")]
    public class Enclosure
    {
        /// <summary>
        /// The length attribute is the file size in bytes.
        /// </summary>
        /// <remarks>
        /// You can find this information in the properties of your podcast file.
        /// </remarks>
        [XmlAttribute("length")]
        public int Length { get; set; }

        /// <summary>
        /// The type attribute provides the correct category for the type of file you are using.
        /// </summary>
        /// <remarks>
        /// The type values for the supported file formats are:
        /// audio/x-m4a, audio/mpeg, video/quicktime, video/mp4, video/x-m4v, and application/pdf.
        /// </remarks>
        /// <example>
        /// audio/mpeg
        /// audio/x-m4a
        /// </example>
        [XmlAttribute("type")]
        public string Type { get; set; }

        /// <summary>
        /// The URL attribute points to your podcast media file.
        /// </summary>
        /// <remarks>
        /// IMPORTANT: URL CANNOT HAVE SPACES. URL ENCODING BY REPLACING SPACES WITH '+' IS NOT ACCEPTED BY ITUNE EITHER.
        /// <p>
        /// The file extension specified within the URL attribute determines whether or
        /// not content appears in the podcast directory. Supported file formats include
        /// M4A, MP3, MOV, MP4, M4V, and PDF.
        /// </remarks>
        /// <example>
        /// http://example.com/podcasts/everything/AllAboutEverythingEpisode4.mp3
        /// </example>
        [XmlAttribute("url")]
        public string Url { get; set; }
    }
}
