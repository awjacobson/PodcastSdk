using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PodcastSdk.Models;
using System.Linq;
using System.Web;

namespace PodcastSdk.Tests.Models
{
    [TestClass]
    public class EnclosureShould
    {
        [TestMethod]
        public void ValidateLengthIsGreaterThanZero()
        {
            // Arrange
            var enclosure = new Enclosure
            {
                Length = 0
            };

            // Act
            var results = new List<ValidationResult>();
            Validator.TryValidateObject(enclosure, new ValidationContext(enclosure, null, null), results);

            // Assert
            Assert.IsTrue(results.Any(r => r.ErrorMessage == Enclosure.LengthRequired));
        }

        [TestMethod]
        public void ValidateUrlIsNull()
        {
            // Arrange
            var enclosure = new Enclosure
            {
                Url = null
            };

            // Act
            var results = new List<ValidationResult>();
            Validator.TryValidateObject(enclosure, new ValidationContext(enclosure, null, null), results);

            // Assert
            Assert.IsTrue(results.Any(r => r.ErrorMessage == Enclosure.UrlIsRequired));
        }

        [TestMethod]
        public void ValidateSpaceInUrl()
        {
            // Arrange
            var enclosure = new Enclosure
            {
                Url = "2019-09-29_AM (file1011).mp3"
            };

            // Act
            var results = new List<ValidationResult>();
            Validator.TryValidateObject(enclosure, new ValidationContext(enclosure, null, null), results);

            // Assert
            Assert.IsTrue(results.Any(r => r.ErrorMessage == Enclosure.UrlContainsSpaces));
        }

        [TestMethod]
        public void ValidateUrlEncodedSpaceInUrl()
        {
            // Arrange
            var enclosure = new Enclosure
            {
                Url = HttpUtility.UrlEncode("2019-09-29_AM (file1011).mp3")
            };

            // Act
            var results = new List<ValidationResult>();
            Validator.TryValidateObject(enclosure, new ValidationContext(enclosure, null, null), results);

            // Assert
            Assert.IsTrue(results.Any(r => r.ErrorMessage == Enclosure.UrlContainsSpaces));
        }
    }
}
