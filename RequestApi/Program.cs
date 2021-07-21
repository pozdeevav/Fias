using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.WindowsServices;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;
using System.IO;

namespace RequestApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // �������� ���� � ����� 
            var pathToExe = Process.GetCurrentProcess().MainModule.FileName;
            // ���� � �������� �������
            var pathToContentRoot = Path.GetDirectoryName(pathToExe);
            // ������� ����
            var host = WebHost.CreateDefaultBuilder(args)
                    .UseContentRoot(pathToContentRoot)
                    .UseStartup<Startup>()
                    .Build();
            // ��������� � ���� ������
            host.RunAsService();
        }
    }
}
