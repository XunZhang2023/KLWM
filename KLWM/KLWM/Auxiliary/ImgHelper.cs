using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLWM.Auxiliary
{
    public class ImgHelper
    {
        public static byte[] BitmapToByte(Bitmap bitmap)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            ms.Seek(0, System.IO.SeekOrigin.Begin);
            byte[] bytes = new byte[ms.Length];
            ms.Read(bytes, 0, bytes.Length);
            ms.Dispose();
            return bytes;
        }
        //将Image转换成流数据，并保存为byte[]   
        public static byte[] PhotoImageInsert(Image imgPhoto)
        {
            MemoryStream mstream = new MemoryStream();
            imgPhoto.Save(mstream, System.Drawing.Imaging.ImageFormat.Bmp);
            byte[] byData = new Byte[mstream.Length];
            mstream.Position = 0;
            mstream.Read(byData, 0, byData.Length); mstream.Close();
            return byData;
        }
        public static Byte[] GetImageByteFromPath(string _path)
        {
            FileStream fs = new FileStream(_path, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);
            Byte[] byData = br.ReadBytes((int)fs.Length);
            fs.Close();
            return byData;
        }
        public static Image CreateThumbnail(byte[] imageData, int width, int height)
        {
            using (MemoryStream ms = new MemoryStream(imageData))
            {
                Image originalImage = Image.FromStream(ms);

                // 计算缩略图大小，保持宽高比
                float ratio = Math.Min((float)width / originalImage.Width, (float)height / originalImage.Height);
                int newWidth = (int)(originalImage.Width * ratio);
                int newHeight = (int)(originalImage.Height * ratio);

                // 创建缩略图
                Image thumbnail = originalImage.GetThumbnailImage(newWidth, newHeight, () => false, IntPtr.Zero);

                // 如果需要，可以在这里释放originalImage
                originalImage.Dispose();

                return thumbnail;
            }
        }
    }
}
