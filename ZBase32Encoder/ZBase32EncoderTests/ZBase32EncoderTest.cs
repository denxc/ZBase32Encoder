namespace ZBase32EncoderTests
{
    using System.Text;

    using NUnit.Framework;

    using ZBase32Encoder;

    [TestFixture]
    public class ZBase32EncoderTest
    {        
        [TestCase("BA", "ejyo")]
        [TestCase("a", "cr")]
        [TestCase("", "")]
        public void EncodingTest(string sourceData, string encodedData)
        {
            var bytes = Encoding.ASCII.GetBytes(sourceData);
            var result = ZBase32Encoder.Encode(bytes);

            Assert.AreEqual(encodedData, result);
        }

        [TestCase("Hello, World!")]
        [TestCase("&^%%&*BJKjbjkb&^%%$^&b")]
        [TestCase("  My NaMe Is DeNiS ")]
        [TestCase("--=__--=)(\\//$4")]
        [TestCase("  ")]
        [TestCase("")]
        public void EncodeDecodeTest(string sourceData)
        {
            var bytes = Encoding.ASCII.GetBytes(sourceData);
            var encodedData = ZBase32Encoder.Encode(bytes);
            var decodedData = ZBase32Encoder.Decode(encodedData);

            Assert.AreEqual(sourceData, decodedData);
        }
    }
}
