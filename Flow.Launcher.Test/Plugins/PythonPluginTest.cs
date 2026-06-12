using System.Text.Json;
using Flow.Launcher.Core.Plugin;
using NUnit.Framework;

namespace Flow.Launcher.Test.Plugins
{
    [TestFixture]
    public class PythonPluginTest
    {
        [Test]
        public void PythonStringLiteralShouldSafelyEncodeWindowsPaths()
        {
            const string path = @"C:\Users\o'connor\AppData\Local\Flow Launcher\Plugins\Test\";

            var literal = PythonPlugin.PythonStringLiteral(path);

            Assert.That(literal, Does.StartWith("\""));
            Assert.That(literal, Does.EndWith("\""));
            Assert.That(literal, Does.Not.Contain(@"r'"));
            Assert.That(JsonSerializer.Deserialize<string>(literal), Is.EqualTo(path));
        }
    }
}
