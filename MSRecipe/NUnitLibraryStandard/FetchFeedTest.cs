using NUnit.Framework;
using System;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NUnitLibraryStandard
{
    /// <summary>
    /// TODO
    /// * Angular
    /// * Developers I/O
    /// * Hyperion
    /// * Material
    /// * Moshi
    /// * Node.js
    /// * O'Reilly
    /// * OkHttp
    /// * Picasso
    /// * Retrofit
    /// * Robolectric
    /// * Swift
    /// * TypeScript
    /// * Visual Studio
    /// * Visual Studio Code
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
        public async Task Firebase()
        {
            var url = "https://firebase.google.com/support/releases";

            using HttpClient client = new();
            var response = await client.GetStringAsync(url);

            var divider = "\t";
            var intro = @"id=""";
            var limit = 50;
            var blocks = response.Replace(intro, $"{divider}{intro}")
                .Split(divider)[1..]
                .Select(x => x[..limit]);

            var pattern = intro + @"([a-z]+_[0-3]?\d_\d{4}).*""";
            var result = blocks
                .Select(x => Regex.Match(x, pattern))
                .Where(x => x.Success)
                .Select(x =>
                {
                    var culture = CultureInfo.CreateSpecificCulture("en-US");
                    var part = x.Groups[1].Value.Split("_");

                    var date = 2 < part.Length
                        ? DateTime.Parse($"{part[0]} {part[1]}, {part[2]}")
                        : DateTime.Parse($"{part[0]} 1, {part[1]}");
                    var prefix = 2 < part.Length ? "" : "Around";
                    return new
                    {
                        Date = date,
                        Title = $"{prefix} {date.ToString("MMMM dd, yyyy", culture)}",
                        Url = $"{url}#{x.Groups[1].Value}",
                    };
                })
                .ToList();
            Assert.IsNotEmpty(result);
        }

        [Test]
        public async Task GooglePlayServices()
        {
            var url = "https://developers.google.com/android/guides/releases?hl=en";

            using HttpClient client = new();
            var response = await client.GetStringAsync(url);

            var divider = "\t";
            var intro = @"id=""";
            var limit = 50;
            var blocks = response.Replace(intro, $"{divider}{intro}")
                .Split(divider)[1..]
                .Select(x => x[..limit]);

            var pattern = intro + @"([a-z]+_?[0-3]?\d?_\d{4}).*""";
            var result = blocks
                .Select(x => Regex.Match(x, pattern))
                .Where(x => x.Success)
                .Select(x =>
                {
                    var culture = CultureInfo.CreateSpecificCulture("en-US");
                    var part = x.Groups[1].Value.Split("_");

                    var date = 2 < part.Length
                        ? DateTime.Parse($"{part[0]} {part[1]}, {part[2]}")
                        : DateTime.Parse($"{part[0]} 1, {part[1]}");
                    var prefix = 2 < part.Length ? "" : "Around";
                    return new
                    {
                        Date = date,
                        Title = $"{prefix} {date.ToString("MMMM dd, yyyy", culture)}",
                        Url = $"{url}#{x.Groups[1].Value}",
                    };
                })
                .ToList();
            Assert.IsNotEmpty(result);
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
