using NUnit.Framework;
using System;
using System.Linq;
using System.Xml.Linq;

namespace NUnitLibraryStandard
{
    /// <summary>
    /// TODO
    /// * Developers I/O
    /// * Firebase
    /// * Google Play Services
    /// * Hyperion
    /// * Material
    /// * Moshi
    /// * O'Reilly
    /// * OkHttp
    /// * Picasso
    /// * Retrofit
    /// * Robolectric
    /// * Zxing
    /// * 技術評論社
    /// </summary>
    [TestFixture]
    internal class FetchFeedTest
    {
        [Test]
        public void AndroidDeveloperBlog()
        {
            XNamespace xmlns = "http://www.w3.org/2005/Atom";
            var root = XElement.Load("https://feeds.feedburner.com/blogspot/hsDu");
            var source = root.Descendants(xmlns + "title").First().Value;
            var sample = root.Descendants(xmlns + "entry").Select(entry =>
            {
                try
                {
                    var link = entry.Descendants(xmlns + "link")
                        .Single(x => x.Attribute("rel")?.Value == "alternate")
                        .Attribute("href");
                    return new
                    {
                        Link = new Uri(link!.Value),
                        Source = source,
                        Summary = "",
                        Title = entry.Descendants(xmlns + "title").Single().Value,
                        Updated = DateTime.Parse(entry.Descendants(xmlns + "updated").First().Value)
                    };
                }
                catch (Exception)
                {
                    return null;
                }
            }).Where(item => item != null).Select(item => item!)
            .ToList();
            Assert.IsNotEmpty(sample);
        }

        [Test]
        public void AndroidJetpack()
        {
            XNamespace xmlns = "http://www.w3.org/2005/Atom";
            var root = XElement.Load("https://developer.android.com/feeds/androidx-release-notes.xml");
            var source = root.Descendants(xmlns + "title").First().Value;
            var sample = root.Descendants(xmlns + "entry").Select(entry =>
            {
                try
                {
                    return new
                    {
                        Link = new Uri(entry.Descendants(xmlns + "link").First().Attribute("href").Value),
                        Source = source,
                        Summary = "",
                        Title = entry.Descendants(xmlns + "title").First().Value,
                        Updated = DateTime.Parse(entry.Descendants(xmlns + "updated").First().Value)
                    };
                }
                catch (Exception)
                {
                    return null;
                }
            }).Where(item => item != null).Select(item => item!)
            .ToList();
            Assert.IsNotEmpty(sample);
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
