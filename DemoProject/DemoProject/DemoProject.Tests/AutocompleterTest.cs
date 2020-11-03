using Bunit;
using DemoProject.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace DemoProject.Tests
{
    [TestClass]
    public class AutocompleterTest
    {
        Autocompleter<Car> sut;
        List<Autocompleter<Car>.AutocompleterItem> dataItems;

        [TestInitialize]
        public void Init()
        {
            var data = new List<Car>()
            {
                new Car() { Id = 4, Make = "Opel", Model = "Astra" },
                new Car() { Id = 8, Make = "Mercedes", Model = "A-klasse" },
                new Car() { Id = 15, Make = "Lamborghini", Model = "Murcilago" },
            };
            dataItems = data.Select(x => new Autocompleter<Car>.AutocompleterItem()
            {
                Item = x,
                Text = $"{x.Make} {x.Model}"
            }).ToList();

            var context = new Bunit.TestContext();
            //context.Services.addtrans
            var sutComponent = context.RenderComponent<Autocompleter<Car>>(("Data", dataItems)); // system under test
            sut = sutComponent.Instance;
        }

        [TestMethod]
        public void AutocompleteWithBasicQueryAndSuggestions()
        {
            sut.Query = "e";
            sut.Autocomplete();

            Assert.AreEqual(2, sut.Suggestions.Count);
            Assert.AreEqual("Opel Astra", sut.Suggestions[0].Text);
            Assert.AreEqual("Mercedes A-klasse", sut.Suggestions[1].Text);
        }

        [TestMethod]
        public void AutocompleteShouldSuggestWithCaseInsensitiveQuery()
        {
            sut.Query = "E";
            sut.Autocomplete();

            Assert.AreEqual(2, sut.Suggestions.Count);
            Assert.AreEqual("Opel Astra", sut.Suggestions[0].Text);
            Assert.AreEqual("Mercedes A-klasse", sut.Suggestions[1].Text);
        }

        [TestMethod]
        public void AutocompleteShouldSuggestWithCaseInsensitiveValues()
        {
            sut.Query = "m";
            sut.Autocomplete();

            CollectionAssert.AreEquivalent(new List<Autocompleter<Car>.AutocompleterItem>()
            {
                dataItems[1],
                dataItems[2]
            }, sut.Suggestions);
        }

        [TestMethod]
        public void AutocompleteShouldHandleNulLDataGracefully()
        {
            sut.Data = null;
            sut.Query = "m";
            sut.Autocomplete();

            Assert.IsNull(sut.Suggestions);
        }

        [TestMethod]
        public void AutocompleteShouldHandleNulLQueryGracefully()
        {
            sut.Query = null;
            sut.Autocomplete();

            Assert.IsNull(sut.Suggestions);
        }

        [TestMethod]
        public void NextShouldHighlightTheFirstItem()
        {
            sut.Query = "m";
            sut.Autocomplete();
            sut.Next();

            Assert.IsTrue(sut.Suggestions[0].IsHighlighted);
            Assert.AreEqual(1, sut.Suggestions.Count(x => x.IsHighlighted));
        }

        [TestMethod]
        public void NextShouldHighlightTheNextItem()
        {
            sut.Query = "m";
            sut.Autocomplete();
            sut.Next();
            sut.Next();

            Assert.IsTrue(sut.Suggestions[1].IsHighlighted);
            Assert.AreEqual(1, sut.Suggestions.Count(x => x.IsHighlighted));
        }

        [TestMethod]
        public void NextShouldHighlightBeyondTheLastItem()
        {
            sut.Query = "m";
            sut.Autocomplete();

            foreach (var item in sut.Suggestions)
            {
                sut.Next();
            }
            sut.Next();

            Assert.IsTrue(sut.Suggestions[0].IsHighlighted);
            Assert.AreEqual(1, sut.Suggestions.Count(x => x.IsHighlighted));
        }
    }
}
