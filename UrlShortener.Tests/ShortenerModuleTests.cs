using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Nancy.Testing;
using Nancy.Bootstrappers.StructureMap;
using Nancy;
using UrlShortener.Web.Repositories;
using Model = UrlShortener.Web.Model;
using UrlShortener.Web.Helpers;
using System.IO;
using Newtonsoft.Json;
using UrlShortener.Tests.Helpers;

namespace UrlShortener.Tests
{
    [TestFixture]
    public class ShortenerModuleTests
    {
        [Test]
        public void POST_Given_A_Url_Should_Be_Save_A_Short_Url_Associated_With_Original_Url_And_Returns_StatusCode_201_With_Location_Of_The_Resource()
        {
            //Arrange
            var repository = new StubUrlStorage();

            var bootstrapper = new ConfigurableBootstrapper(with =>
            {
                with.Dependency<IUrlStorage>(repository);
            });

            var browser = new Browser(bootstrapper);

            //Act
            var response = browser.Post("/urls/", ctx => {
                ctx.HttpRequest();
                ctx.FormValue("url", "http://www.2dsolucoes.net");
            });

            //Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
            Assert.IsNotNullOrEmpty(response.Headers["Location"]);
        }

        [Test]
        public void POST_Given_A_Form_No_Parameters_When_Try_Save_A_Short_Url_Then_Returns_StatusCode_400()
        {
            //Arrange
            var repository = new StubUrlStorage();

            var bootstrapper = new ConfigurableBootstrapper(with =>
            {
                with.Dependency<IUrlStorage>(repository);
            });

            var browser = new Browser(bootstrapper);

            //Act
            var response = browser.Post("/urls/", ctx =>
            {
                ctx.HttpRequest();
            });

            //Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }

        [Test]
        public void GET_Given_An_Url_Shortened_Should_Return_Data_Of_The_Url()
        {
            //Arrange
            var url = new Model.Url("http://www.2dsolucoes.net");
            var repository = new StubUrlStorage(url);
            var bootstrapper = new ConfigurableBootstrapper(with =>
            {
                with.Dependency<IUrlStorage>(repository);
            });
            var browser = new Browser(bootstrapper);

            //Act
            var urlAPI = string.Format("/urls/{0}", url.Short);
            var response = browser.Get(urlAPI, ctx =>
            {
                ctx.HttpRequest();
            });

            dynamic result = response.Body.ToDynamic();

            //Assert 
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That((string)result.Source, Is.EqualTo(url.Source));
            Assert.That((string)result.Short, Is.EqualTo(url.Short));
        }

        [Test]
        public void GET_When_No_Url_Should_Return_StatsuCode_404()
        {
            //Arrange
            var url = new Model.Url("http://www.2dsolucoes.net");
            var repository = new StubUrlStorage(url);
            var bootstrapper = new ConfigurableBootstrapper(with =>
            {
                with.Dependency<IUrlStorage>(repository);
            });
            var browser = new Browser(bootstrapper);

            //Act
            var urlAPI = "/urls/abCD1";
            var response = browser.Get(urlAPI, ctx =>
            {
                ctx.HttpRequest();
            });

            dynamic result = response.Body.ToDynamic();

            //Assert 
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }
    }
}
