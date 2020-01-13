using IronPython.Hosting;
using Resources;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace UnitTest.Resources
{
    public class BookSearch
    {
        [Fact]
        public void PyScriptsTest()
        {
            var engine = Python.CreateEngine();
            var script = Directory.GetCurrentDirectory();
            //var password = "123";
            //var hashPassword = PasswordHelper.Hash(password);

            Assert.Equal("12", script);
        }
    }
}
