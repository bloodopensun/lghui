namespace Lghui.SmartQQ
{
    partial class SmartQQClient
    {
        /// <summary>
        /// 获取好友hash算法
        /// </summary>
        /// <returns></returns>
        private string Gethash()
        {
            dynamic a = new int[4];

            for (var i = 0; i < Ptwebqq.Length; i++)
                a[i % 4] ^= Ptwebqq[i];

            dynamic w = new[] { "EC", "OK" };
            dynamic d = new long[4];

            d[0] = Login2Model.Uin >> 24 & 255 ^ w[0][0];
            d[1] = Login2Model.Uin >> 16 & 255 ^ w[0][1];
            d[2] = Login2Model.Uin >> 8 & 255 ^ w[1][0];
            d[3] = Login2Model.Uin & 255 ^ w[1][1];

            w = new long[8];

            for (var i = 0; i < 8; i++)
                w[i] = i % 2 == 0 ? a[i >> 1] : d[i >> 1];

            a = new[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F" };
            d = "";

            foreach (var t in w)
            {
                d += a[t >> 4 & 15];
                d += a[t & 15];
            }

            return d;
        }
    }
}
