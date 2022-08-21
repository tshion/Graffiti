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

        [Test]
        public void AndroidJetpack()
        {
            XNamespace xmlns = "http://www.w3.org/2005/Atom";
            var root = XElement.Load("https://developer.android.com/feeds/androidx-release-notes.xml");

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
                subtitle = subtitle?.Value ?? "",
                title = title.Value,
                updated = updated.Value,
            };


            Assert.IsEmpty(data.subtitle);
            Assert.IsNotEmpty(data.title);
            Assert.AreEqual("AndroidX - Release Notes", data.title);
        }

        [Test]
        public void AppleDeveloper()
        {
            var root = XElement.Load("https://developer.apple.com/news/rss/news.rss");

            var channels = root.Descendants("channel");

            var link = channels.Descendants("link").FirstOrDefault();
            Assert.AreEqual("https://developer.apple.com/news/", link.Value);
            var title = channels.Descendants("title").FirstOrDefault();
            Assert.AreEqual("Latest News - Apple Developer", title.Value);

            var items = channels.Descendants("item");
            var data = items.Select(item => new
            {
                description = item.Descendants("description").FirstOrDefault().Value,
                guid = item.Descendants("guid").FirstOrDefault().Value,
                link = item.Descendants("link").FirstOrDefault().Value,
                //pubDate = DateTime.Parse(item.Descendants("pubDate").FirstOrDefault().Value),
                title = item.Descendants("title").FirstOrDefault().Value,
            }).ToList();
            Assert.IsNotEmpty(data);
        }

        [Test]
        public void YahooJapanTechBlog()
        {
            var root = XElement.Load("https://techblog.yahoo.co.jp/index.xml");

            var channels = root.Descendants("channel");

            var link = channels.Descendants("link").FirstOrDefault();
            Assert.AreEqual("https://techblog.yahoo.co.jp/", link.Value);
            var title = channels.Descendants("title").FirstOrDefault();
            Assert.AreEqual("Yahoo! JAPAN Tech Blog", title.Value);

            var items = channels.Descendants("item");
            var data = items.Select(item => new
            {
                description = item.Descendants("description").FirstOrDefault().Value,
                guid = item.Descendants("guid").FirstOrDefault().Value,
                link = item.Descendants("link").FirstOrDefault().Value,
                //pubDate = DateTime.Parse(item.Descendants("pubDate").FirstOrDefault().Value),
                title = item.Descendants("title").FirstOrDefault().Value,
            }).ToList();
            Assert.IsNotEmpty(data);
        }
    }
}
