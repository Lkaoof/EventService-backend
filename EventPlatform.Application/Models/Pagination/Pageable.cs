using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlatform.Application.Models.Pagination
{
    public class Pageable
    {
        public int Index { get; set; }

        public int Size { get; set; }
    }
}
