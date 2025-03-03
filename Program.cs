using System;
using System.IO;
using System.Reflection;
using System.Linq;
using System.Windows.Forms;

namespace Extract_PDF_to_TXT
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Đường dẫn thư mục chứa các DLL & file cấu hình
            string libsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Libs");

            // Nếu thư mục "Libs" chưa tồn tại thì tạo
            if (!Directory.Exists(libsPath))
            {
                Directory.CreateDirectory(libsPath);
            }

            // Di chuyển tất cả các file DLL, PDB, DEPS, RUNTIMECONFIG vào thư mục "Libs"
            MoveFilesToLibs(libsPath);

            // Xử lý khi ứng dụng không tìm thấy DLL
            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
            {
                string assemblyFile = Path.Combine(libsPath, new AssemblyName(args.Name).Name + ".dll");
                if (File.Exists(assemblyFile))
                {
                    return Assembly.LoadFrom(assemblyFile);
                }
                return null;
            };

            // Chạy ứng dụng
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }

        /// <summary>
        /// Di chuyển các file DLL, PDB, DEPS, RUNTIMECONFIG vào thư mục "Libs"
        /// </summary>
        static void MoveFilesToLibs(string libsPath)
        {
            string appPath = AppDomain.CurrentDomain.BaseDirectory;

            // Danh sách các phần mở rộng file cần di chuyển
            string[] extensions = { "*.dll", "*.pdb", "*.deps.json", "*.runtimeconfig.json" };

            foreach (string ext in extensions)
            {
                var files = Directory.GetFiles(appPath, ext);
                foreach (var file in files)
                {
                    string destFile = Path.Combine(libsPath, Path.GetFileName(file));
                    if (!File.Exists(destFile)) // Tránh ghi đè nếu đã có
                    {
                        File.Move(file, destFile);
                    }
                }
            }
        }
    }
}
