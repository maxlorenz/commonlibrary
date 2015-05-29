using System;
using System.Diagnostics;
using System.Text;

namespace Common_Library.Data.Access.Command
{
    class Execute
    {
        const int ENCODING_GERMAN = 437;

        ProcessStartInfo info;
        Process process;

        public Execute(string Command, string Arguments)
        {
            info = createInfo(Command, Arguments);
            process = createProcess(info);
        }

        public void SetProgressHandler(IProgress<string> Progress)
        {
            process.OutputDataReceived += 
                new DataReceivedEventHandler((s, output) => Progress.Report(output.Data));
        }

        public void Run()
        {
            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
        }

        public void RunBlocking()
        {
            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            process.WaitForExit();
        }

        private Process createProcess(ProcessStartInfo info)
        {
            return new Process()
            {
                StartInfo = info,
                EnableRaisingEvents = true
            };
        }

        private ProcessStartInfo createInfo(string command, string arguments)
        {
            return new ProcessStartInfo(command, arguments)
            {
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true,
                StandardOutputEncoding = Encoding.GetEncoding(ENCODING_GERMAN)
            };
        }
    }
}
