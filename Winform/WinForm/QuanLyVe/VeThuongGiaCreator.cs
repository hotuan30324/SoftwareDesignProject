using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL.QuanLyVe
{
    public class VeThuongGiaCreator : VeCreator
    {
        public override Ve createVe()
        {
            return new VeThuongGia();
        }
    }
}
