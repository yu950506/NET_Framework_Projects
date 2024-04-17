using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace BoltViewSystem.Utils
{
    /// <summary>
    /// 文件工具类
    /// </summary>
    public class FileUtils
    {
        /// <summary>
        /// 递归删除指定文件夹下的图片文件
        /// </summary>
        /// <param name="directory"> 例如：@"D:\20240204\Cam1" </param>
        /// <param name="saveNewCount"> 保存最新的图片数量 </param>
        public static void TraverseDirectoryDeletePhotos(string directory, int saveNewCount)
        {
            if (Directory.Exists(directory)) // 目录存在的时候才进行操作
            {
                // 获取文件夹下所有图片文件
                string[] imageFiles = Directory.GetFiles(directory, "*.png");
                // 如果图片文件数量超过50张，则删除多余的图片
                if (imageFiles.Length > saveNewCount)
                {
                    // 根据文件的创建时间降序排序，保留最新的50张图片
                    var sortedFiles = imageFiles.Select(file => new FileInfo(file))
                        .OrderByDescending(fileInfo => fileInfo.CreationTime)
                        .Skip(saveNewCount);

                    // 删除多余的图片
                    foreach (var file in sortedFiles)
                    {
                        File.Delete(file.FullName);
                        Console.WriteLine($"已删除文件: {file.FullName}");
                    }
                }

                // 遍历当前文件夹中的子文件夹
                string[] subdirectories = Directory.GetDirectories(directory);
                foreach (string subdirectory in subdirectories)
                {
                   
                    //
                    // D:\20240202\Cam1\01model1
                    // D:\20240202\Cam2\00 template
                    // D:\20240202\Cam2\01 template
                    // D:\20240202\Cam3\00 template
                    // D:\20240202\Cam3\01model3
                    // D:\20240202\Cam4\00 template

                    // 排除一些模版文件夹,这些文件夹下的东西不需要删除
                    if (   subdirectory.Equals(@"D:\20240202\Cam1\00 template")
                        || subdirectory.Equals(@"D:\20240202\Cam1\01model1")
                        || subdirectory.Equals(@"D:\20240202\Cam2\00 template")
                        || subdirectory.Equals(@"D:\20240202\Cam2\01 template")
                        || subdirectory.Equals(@"D:\20240202\Cam3\00 template")
                        || subdirectory.Equals(@"D:\20240202\Cam3\01model3")
                        || subdirectory.Equals(@"D:\20240202\Cam4\00 template")
                        )
                    {
                        Trace.WriteLine(subdirectory + "目录跳过");
                        continue;
                    }
                    TraverseDirectoryDeletePhotos(subdirectory, saveNewCount);
                }
            }
            else
            {
                Console.WriteLine($"{directory} 目录不存在，无需执行该操作");
            }
        }

        /// <summary>
        ///  遍历拷贝文件夹下的所有文件,将@"D:\20240204\Cam1"下的 拷贝到  @"E:\20240204\Cam1"
        /// </summary>
        /// <param name="directory"> @"D:\20240204\Cam1" 拷贝到  @"E:\20240204\Cam1" </param>
        /// <param name="saveNewCount"></param>
        public static void TraverseDirectoryCopyPhotos(string directory, int copyNewCount)
        {
            // 遍历当前文件夹中的文件
            string[] files = Directory.GetFiles(directory, "*.png");

            // 根据文件的最后写入时间进行排序（你也可以使用CreationTime或LastAccessTime）
            var sortedFiles = files
                .OrderByDescending(f => File.GetLastWriteTime(f)) // 降序排序，最新的文件排在最前面
                .Take(copyNewCount); // 取前3个文件

            foreach (var file in sortedFiles)
            {
                // 源文件
                string sourceFile = file;
                // 目标文件
                string destinationFile = file.Replace(@"D:\", @"E:\");

                //1.先创建目标文件目录
                // 使用GetDirectoryName方法获取不包含文件名的目录路径
                string directoryPath = Path.GetDirectoryName(destinationFile);
                // 确保目录存在，如果不存在则创建它
                Directory.CreateDirectory(directoryPath);
                // 2.再进行文件的复制
                File.Copy(sourceFile, destinationFile, true);
            }

            // 遍历当前文件夹中的子文件夹
            string[] subdirectories = Directory.GetDirectories(directory);
            foreach (string subdirectory in subdirectories)
            {
                TraverseDirectoryCopyPhotos(subdirectory, copyNewCount);
            }
        }

        /// <summary>
        /// 模拟生产照片数据
        /// </summary>
        public static void MockData()
        {
            //   "D:\20230126\Cam1\13\Inspect_Cam1_13_20240127161455902.png"
            for (int i = 1; i <= 3; i++) // 3个相机
            {
                for (int j = 1; j < 400; j++) // 400个吊具
                {
                    for (int k = 0; k < 60; k++) // 60张照片
                    {
                        // 1.定义目录结构
                        string dir = $@"D:\20240204\Cam{i}\{j}";
                        // 2.定义文件名
                        string fileName = $@"Inspect_Cam{i}_{j}_{DateTime.Now.ToString(("yyyyMMddHHmmssfff"))}_{k}.png";
                        // 3.文件完整路径
                        string pngFilePath = Path.Combine(dir, fileName);
                        if (!Directory.Exists(dir))
                        {
                            Directory.CreateDirectory(dir);
                        }

                        if (!File.Exists((pngFilePath)))
                        {
                            File.Create(pngFilePath).Close();
                        }

                        // Console.WriteLine(pngFilePath);
                    }
                }
            }
        }
    }
}