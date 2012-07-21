using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UrlShortener.Web.Helpers;

namespace UrlShortener.Tests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestFixture]
    public class ShortenerTests
    {
        [Test]
        public void Generate_Given_The_Number_Zero_Should_Be_Returns_A_Valid_String()
        {
            //Arrange
            var number = 0;

            //Act
            var urlShortned = Shortener.Generate(number);

            //Assert
            Assert.That(urlShortned, Is.EqualTo("0"));
        }

        [Test]
        public void Generate_Given_The_Number_123_Should_Be_Returns_A_Valid_String()
        {
            //Arrange
            var number = 123;

            //Act
            var urlShortned = Shortener.Generate(number);

            //Assert
            Assert.That(urlShortned, Is.EqualTo("1z"));
        }

        [Test]
        public void Generate_Given_The_Number_123456_Should_Be_Returns_A_Valid_String()
        {
            //Arrange
            var number = 123456;

            //Act
            var urlShortned = Shortener.Generate(number);

            //Assert
            Assert.That(urlShortned, Is.EqualTo("W7E"));
        }

        [Test]
        public void Generate_Given_The_Number_987654321_Should_Be_Returns_A_Valid_String()
        {
            //Arrange
            var number = 987654321;

            //Act
            var urlShortned = Shortener.Generate(number);

            //Assert
            Assert.That(urlShortned, Is.EqualTo("14q60P"));
        }
    }
}
