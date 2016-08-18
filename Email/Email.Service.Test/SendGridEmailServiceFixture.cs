using Email.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Email.Service.Test
{
    [TestFixture]
    public class SendGridEmailServiceFixture
    {
        [Test]
        public void ShouldCreateInstance()
        {
            var service = new SendGridEmailService("");

            Assert.IsNotNull(service);
        }
    }
}
