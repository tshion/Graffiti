using System;
using System.Diagnostics;
using NUnit.Framework;

namespace NUnitLibraryStandard
{
    [TestFixture]
    internal class RunCommandTest
    {
        [Test]
        public void RunGitLog()
        {
            Process process = new()
            {
                StartInfo = new ProcessStartInfo("git")
                {
                    Arguments = "log",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                }
            };
            process.Start();
            process.WaitForExit();
            var output = process.StandardOutput.ReadToEnd();
            Assert.IsNotEmpty(output);
        }
    }
}
