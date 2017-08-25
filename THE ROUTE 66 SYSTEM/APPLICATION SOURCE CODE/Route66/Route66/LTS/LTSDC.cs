using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using Route66;
using Route66.LTS;

namespace Route66.LTS
{
    public class LTSDC : LTSBase, IDisposable
    {
        public LTSDC() : base(Properties.Settings.Default.itspRouteConnectionString) { }

        public LTSDC(string ConnectionString) : base(ConnectionString) { }

        public static LTSDC Context
        {
            get { return new LTSDC(); }
        }
    }
}
