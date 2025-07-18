using RiftReady.Assist;
using RiftReady.Assist.Server;
using System.Diagnostics;
using System.IO.Compression;
using System.Text;

namespace RiftReady.Core.Controller
{
    public class PageController 
    {
        private readonly Stream? stream;

        private readonly ZipArchive? zip;

        private bool isGood = false;
        public PageController()
        {
            try
            {
                stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("RiftReady.Resources.dist.zip");
                zip = new ZipArchive(stream!, ZipArchiveMode.Read, true);
                isGood = true;
            }
            catch {
                Debugger.Break();
            }
        }

        public void Handle(ServerRecv request, ServerSend response)
        {
            if (!isGood)
            {
                return;
            }

            var path = request.Url;

            if (path == null || path == "/")
            {
                path = "/index.html";
            }

            path = path[1..];

            var entry = zip!.GetEntry(path) ?? zip!.GetEntry("index.html");

            if (entry == null)
            {
                return;
            }

            var entryStream = entry.Open();

            if (entryStream == null)
            {
                return;
            }

            var reader = new StreamReader(entryStream);
            var data = reader.ReadToEnd();

            if (Mime.TryGetMimeType(path, out var mimeType))
            {
                response.Text(data, mimeType);
            } else
            {
                response.Text(data, "text/html");
            }

            reader.Close();
            entryStream.Close();
        }
    }
}
