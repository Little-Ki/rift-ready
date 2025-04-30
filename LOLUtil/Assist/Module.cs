using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOLUtil.Assist
{
    public class Module<T> where T : class, new()
    {
        public static T Instance { get; set; } = new();
    }
}
