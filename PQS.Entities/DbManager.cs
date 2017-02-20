using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PQS.Entities
{
    public sealed class DbManager
    {
        private static volatile pqsEntities instance;
        private static object syncRoot = new Object();

        private DbManager() { }

        public static pqsEntities Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new pqsEntities();
                    }
                }

                return instance;
            }
        }
    }
}

