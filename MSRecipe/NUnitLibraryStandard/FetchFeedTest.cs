using NUnit.Framework;
using System.Linq;
using System.Xml.Linq;

namespace NUnitLibraryStandard
{
    [TestFixture]
    internal class FetchFeedTest
    {
        [Test]
        public void AndroidDeveloperBlog()
        {
            XNamespace xmlns = "http://www.w3.org/2005/Atom";
            var root = XElement.Load("https://feeds.feedburner.com/blogspot/hsDu");

            var entries = root.Descendants(xmlns + "entry");
            var subtitle = root.Descendants(xmlns + "subtitle").FirstOrDefault();
            var title = root.Descendants(xmlns + "title").FirstOrDefault();
            var updated = root.Descendants(xmlns + "updated").FirstOrDefault();

            var data = new
            {
                items = entries.Select(e => new
                {
                    content = e.Descendants(xmlns + "content").FirstOrDefault().Value,
                    title = e.Descendants(xmlns + "title").FirstOrDefault().Value,
                    updated = root.Descendants(xmlns + "updated").FirstOrDefault().Value,
                }).ToList(),
                subtitle = subtitle.Value,
                title = title.Value,
                updated = updated.Value,
            };


            Assert.IsNotEmpty(data.subtitle);
            Assert.IsNotEmpty(data.title);
            Assert.AreEqual("Android Developers Blog", data.title);
        }
    }
}
