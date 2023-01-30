// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
int argb = 0xFF8A80;
string hex = argb.ToString("X");
// argb & 0xFF0000 >> 16
Console.WriteLine(argb & 0xFF0000 >> 16);
Console.WriteLine(hex);

// 首先将颜色值与十六进制表示的00ff0000进行“与”运算，
// 运算结果除了表示红色的数字值之外，GGBB部分颜色都为0，
// 在将结果向右移位16位，得到的就是红色值。所以这句代码主要用来从一个颜色中抽取其组成色-- - 红色的值。