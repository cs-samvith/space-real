namespace CarMax.Appraisal.Gateway.Helpers
{
    public class FileSystemHelper
    {
        public static string GetInstanceNameFromLogFiles(string uniqueId)
        {
            var instanceName = string.Empty;
            try
            {
                //var sourcePath = "C:\\per\\prj\\space-devsecops\\quiz-service\\src\\Quiz.Service\\";
                var sourcePath = Directory.GetDirectoryRoot(Directory.GetCurrentDirectory()) + "home/LogFiles";
                var today = DateTime.Now.ToUniversalTime().ToString("yyyy_MM_dd");
                string[] logFiles = System.IO.Directory.GetFiles(sourcePath, $"{today}*_default_docker.log*");

                foreach (string fileName in logFiles)
                {
                    if (ProcessFile(fileName, uniqueId))
                    {
                        var splt = fileName.Split("_");
                        instanceName = splt[3];
                        Console.WriteLine("Found {0} in {1} file.So instance name is {2} ", uniqueId, fileName , instanceName);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("FileSystemHelper-GetInstanceName Failed with error {0}", ex.Message);
            }
            return instanceName;
        }
        public static bool ProcessFile(string path, string uniqueId)
        {
            var contents = File.ReadAllLines(path).TakeLast(100);
            var result = false;
            foreach (string line in contents)
            {
                if (line.Contains(uniqueId))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
    }
}