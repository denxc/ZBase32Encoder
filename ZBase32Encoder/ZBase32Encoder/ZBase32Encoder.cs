namespace ZBase32Encoder
{
    using System;
    using System.Text;

    public static class ZBase32Encoder
    {
        private const string EncodingTable = "ybndrfg8ejkmcpqxot1uwisza345h769";

        private static readonly byte[] DecodintTable = new byte[128];

        static ZBase32Encoder()
        {
            for (var i = 0; i < DecodintTable.Length; ++i)
            {
                DecodintTable[i] = byte.MaxValue;
            }

            for (var i = 0; i < EncodingTable.Length; ++i)
            {
                DecodintTable[EncodingTable[i]] = (byte)i;
            }
        }

        public static string Encode(byte[] data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }

            var encodedResult = new StringBuilder((int)Math.Ceiling(data.Length * 8.0 / 5.0));

            for (var i = 0; i < data.Length; i += 5)
            {
                var byteCount = Math.Min(5, data.Length - i);
                
                ulong buffer = 0;
                for (var j = 0; j < byteCount; ++j)
                {
                    buffer = (buffer << 8) | data[i + j];
                }

                var bitCount = byteCount * 8;
                while (bitCount > 0)
                {                    
                    var index = bitCount >= 5
                                ? (int)(buffer >> (bitCount - 5)) & 0x1f
                                : (int)(buffer & (ulong)(0x1f >> (5 - bitCount))) << (5 - bitCount);

                    encodedResult.Append(EncodingTable[index]);
                    bitCount -= 5;
                }
            }

            return encodedResult.ToString();
        }

        public static byte[] Decode(string data)
        {
            return null;
        }
    }
}
