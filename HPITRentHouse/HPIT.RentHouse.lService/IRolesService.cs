using HPIT.RentHouse.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPIT.RentHouse.lService
{
    public interface IRolesService : IServiceSupport
    {
        List<RolesDTO> GetList();
        List<RolesDTO> GetPageList(int start, int length, string name, ref int count);
    }
}
