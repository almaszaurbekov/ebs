using Resources;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTest.Resources
{
    public class PasswordHelperUT
    {
        [Fact]
        public void HashPasswordCheck()
        {
            var password = "123";
            var hashPassword = PasswordHelper.Hash(password);

            Assert.NotEqual(password, hashPassword);
        }

        [Fact]
        public void AuthCheck()
        {
            var password = "123";
            var hashPassword = PasswordHelper.Hash(password);

            Assert.Equal(PasswordHelper.Hash(password), hashPassword);
        }
    }
}
