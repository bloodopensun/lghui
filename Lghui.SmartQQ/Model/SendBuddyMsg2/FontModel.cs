using Lghui.SmartQQ.Enum.SendBuddyMsg2;

namespace Lghui.SmartQQ.Model.SendBuddyMsg2
{
    public class FontModel
    {
        /// <summary>
        /// 字体
        /// </summary>
        public string Name { get; set; } = "宋体";

        /// <summary>
        /// 字体大小
        /// </summary>
        public FontSizeEnum Size { get; set; } = FontSizeEnum._10;

        /// <summary>
        /// 加粗 倾斜 下划线 [0,0,0] 1表示开启
        /// </summary>
        public int[] Style { get; set; } = { 0, 0, 0 };

        /// <summary>
        /// 颜色 例如 000000 白色
        /// </summary>
        public string Color { get; set; } = "000000";
    }
}
