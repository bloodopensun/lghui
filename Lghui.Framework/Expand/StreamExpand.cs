using System.IO;

namespace Lghui.Framework.Expand
{
    /// <summary>
    /// Stream扩展
    /// </summary>
    public static class StreamExpand
    {
        /// <summary>
        /// 转换为Bytes
        /// </summary>
        /// <param name="stream">待转换的Stream</param>
        /// <returns>Bytes</returns>
        public static byte[] ToBytes(this Stream stream)
        {
            MemoryStream ms = null;
            try
            {
                ms = new MemoryStream();
                while (true)
                {
                    var data = new byte[512];
                    var count = stream.Read(data, 0, 512);
                    ms.Write(data, 0, count);
                    if (0 == count) break;

                }
                return ms.ToArray();
            }
            finally
            {
                ms?.Close();
                ms?.Dispose();
            }
        }
    }
}
