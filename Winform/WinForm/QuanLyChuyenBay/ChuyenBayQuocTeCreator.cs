using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL.QuanLyChuyenBay
{
    public class ChuyenBayQuocTeCreator : ChuyenBayCreator
    {
        public override ChuyenBay createChuyenBay()
        {
            return new ChuyenBayQuocTe();
        }
    }
}
