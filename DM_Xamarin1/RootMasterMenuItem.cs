using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM_Xamarin1
{

    public class RootMasterMenuItem
    {
        public RootMasterMenuItem()
        {
            TargetType = typeof(RootMasterMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}