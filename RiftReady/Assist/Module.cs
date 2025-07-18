using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiftReady.Assist
{
    public class Module<T> where T : class, new()
    {
        private static T Instance = new();
        public static T Value { get => Instance; set { Instance = value; } }
    }

}
