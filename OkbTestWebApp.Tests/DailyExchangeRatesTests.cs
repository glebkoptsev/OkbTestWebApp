using Moq;
using OkbTestWebApp.Controllers;
using OkbTestWebApp.Services;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace OkbTestWebApp.Tests
{
    public class DailyExchangeRatesTests
    {

        [Fact]
        public void TestGetTickers()
        {
            var mock = new Mock<IDailyExchangeRatesService>();
            mock.Setup(er => er.GetTickers().Result).Returns(GetTestTickers());

            var controller = new ExchangeRatesController(mock.Object);

            var result = controller.GetTickers().Result;
            Assert.NotNull(result);

            var model = Assert.IsAssignableFrom<IEnumerable<string>>(result);
            Assert.Equal(GetTestTickers(), model);
        }

        private static IEnumerable<string> GetTestTickers()
        {
            return new[]
            {

              "R01010",
              "R01020A",
              "R01035",
              "R01060",
              "R01090B",
              "R01100",
              "R01115",
              "R01135",
              "R01200",
              "R01215",
              "R01235",
              "R01239",
              "R01270",
              "R01335",
              "R01350",
              "R01370",
              "R01375",
              "R01500",
              "R01535",
              "R01565",
              "R01585F",
              "R01589",
              "R01625",
              "R01670",
              "R01700J",
              "R01710A",
              "R01717",
              "R01720",
              "R01760",
              "R01770",
              "R01775",
              "R01810",
              "R01815",
              "R01820"
            };
        }
    }
}