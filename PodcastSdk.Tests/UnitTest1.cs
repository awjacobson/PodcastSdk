using System;
using System.IO;
using System.Xml.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PodcastSdk.Models;

namespace PodcastSdk.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            var channel = new Channel
            {
                Title = "Hiking Treks",
                Link = "https://www.apple.com/itunes/podcasts/",
                Copyright = "&#169; 2019 John Appleseed",
                Author = "The Sunset Explorers",
                Description = "Love to get outdoors and discover nature's treasures? Hiking Treks is the show for you. We review hikes and excursions, review outdoor gear and interview a variety of naturalists and adventurers. Look for new episodes each week.",
                Type = ChannelTypes.Episodic,
                Owner = new Owner { Name = "Sunset Explorers", Email = "mountainscape@icloud.com" },
                Image = new Image { Href = "https://applehosted.podcasts.apple.com/hiking_treks/artwork.png" },
                Category = new Category { Text = "Sports", Subcategory = new Category { Text = "Wilderness" } },
                Items = new Item[]
                {
                    new Item
                    {
                        EpisodeType = EpisodeTypes.Trailer,
                        Title = "Hiking Treks Trailer",
                        Author = "Brian Credille",
                        Description = "The Sunset Explorers share tips, techniques and recommendations for",
                        DescriptionEncoded = "<p>The Sunset Explorers share tips, techniques and recommendations for</p>",
                        Image = new Image { Href = "https://applehosted.podcasts.apple.com/hiking_treks/artwork.png" },
                        Enclosure = new Enclosure
                        {
                            Length = 498537,
                            Type = "audio/mpeg",
                            Url = "http://example.com/podcasts/everything/AllAboutEverythingEpisode4.mp3"
                        },
                        Guid = "aae20190418a",
                        PubDate = DateTime.Parse("2018-08-14T01:15:00"), // "Tue, 14 Aug 2018 01:15:00 +0000",
                        Duration = 1399
                    }
                }
            };

            var rss = new Rss { Channel = channel };

            // Act
            var mySerializer = new XmlSerializer(typeof(Rss));

            var myNamespaces = new XmlSerializerNamespaces();
            myNamespaces.Add("itunes", Namespaces.ITunes);
            myNamespaces.Add("content", Namespaces.Content);

            var myWriter = new StreamWriter("myFileName.xml");
            mySerializer.Serialize(myWriter, rss, myNamespaces);
            myWriter.Close();
        }
    }
}
