using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionLibrary.Interface
{
    public interface IConnectionClass
    {
        public DataTable Select(string strQuery);

        public int Insert(string strQuery);

        public bool Update(string strQuery);
    }
}
