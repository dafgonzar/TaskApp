using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskApp.Core.Entities
{
    public partial class TbTask
    {
        public int? TaskId { get; set; }
        public string Accion { get; set; }
        public bool FinishStatus { get; set; }

    }
}
