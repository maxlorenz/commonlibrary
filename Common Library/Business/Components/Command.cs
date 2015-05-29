using Common_Library.Data.Access.Command;
using System;

namespace Common_Library.Business.Components
{
    public class Command
    {
        Execute execute;

        public Command(string Executable, string Arguments, IProgress<string> ProgressHandler)
        {
            execute = new Execute(Executable, Arguments);
            execute.SetProgressHandler(ProgressHandler);
        }

        public Command(string Executable, string Arguments)
        {
            execute = new Execute(Executable, Arguments);
        }

        public void Run()
        {
            execute.Run();
        }

        public void RunBlocking()
        {
            execute.RunBlocking();
        }
    }
}
