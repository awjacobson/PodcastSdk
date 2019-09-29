using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PodcastSdk.Models;

namespace PodcastSdk.Tests.Models
{
    [TestClass]
    public class ItemShould
    {
        [TestMethod]
        public void ValidateEnclosureIsNull()
        {
            // Arrange
            var item = new Item
            {
                Enclosure = null
            };

            // Act
            var results = new List<ValidationResult>();
            Validator.TryValidateObject(item, new ValidationContext(item, null, null), results);

            // Assert
            Assert.IsTrue(results.Any(r => r.ErrorMessage == Item.EnclosureIsRequired));
        }

        [TestMethod]
        public void ValidateEnclosureIsValidated()
        {
            // Arrange
            var item = new Item
            {
                Enclosure = new Enclosure
                {
                    Length = 0
                }
            };

            // Act
            var results = new List<ValidationResult>();
            Validator.TryValidateObject(item, new ValidationContext(item, null, null), results);

            // Assert
            Assert.IsTrue(results.Any(r => r.ErrorMessage == Enclosure.LengthRequired));
        }

    }
}
