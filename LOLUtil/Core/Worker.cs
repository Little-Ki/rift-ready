using LOLUtil.Assist;
using LOLUtil.Assist.LOL.LCU;
using LOLUtil.Core.Tasks;
using LOLUtil.Utils;
using System.Diagnostics;

namespace LOLUtil.Core
{

    public class Worker
    {
        private readonly Thread thread;

        private readonly LCUAccess lcu = Module<LCUAccess>.Value;

        private static Config Config { get => Module<Config>.Value; }

        private int processId = -1;

        private bool isContinue = true;

        public Worker()
        {
            thread = new(new ThreadStart(Run));
        }

        public bool FindGame()
        {
            bool exists = ProcessFinder.IsProcess(processId);

            if (exists)
            {
                return true;
            }

            var process = ProcessFinder.GetProcess("LeagueClientUx");

            if (process == null)
            {
                return false;
            }

            var commands = ProcessFinder.ProcessCMD(process);

            if (!commands.TryGetValue("--remoting-auth-token", out string? token) ||
                !commands.TryGetValue("--app-port", out string? port))
            {
                return false;
            }

            processId = process.Id;
            lcu.Update(port, "riot", token);

            return true;
        }

        public void Run()
        {
            while (isContinue)
            {
                var good = FindGame();

                if (!good)
                {
                    Thread.Sleep(500);
                    continue;
                }

                var result = lcu.Send("GET", "lol-gameflow/v1/gameflow-phase").Result;

                if (!result.Success)
                {
                    goto next;
                }

                var status = result.Json.Root?.GetValue<string>() ?? string.Empty;

                if (status.Equals("Lobby"))
                {

                }

                if (status.Equals("Matchmaking"))
                {

                }

                if (status.Equals("ReadyCheck"))
                {
                    if (Config.Feature.AutoAcceptMM)
                    {
                        new AcceptMMTask().Start(true);
                    }
                }

                if (status.Equals("ChampSelect"))
                {

                    if (Config.AutoBan.Enable || Config.AutoPick.Enable)
                    {

                        new BanPickTask().Start(true);
                    }
                }

                Thread.Sleep(15);
                continue;
            next:
                Thread.Sleep(1000);
            }
        }

        public void Start()
        {
            thread.Start();
        }

        public void Stop()
        {
            isContinue = false;
            thread.Join();
        }

    }
}
