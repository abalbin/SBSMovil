using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SbsMobile.SharedPcl;

namespace SbsMobile.Tests
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            var client = new TipoCambioClient();
            var lista = await client.GetTipoCambio(new TipoCambio { Fecha = new DateTime(2010, 12, 01) });
        }
    }
}
