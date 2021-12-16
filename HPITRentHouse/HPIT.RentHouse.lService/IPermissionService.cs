using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HPIT.RentHouse.DTO;

namespace HPIT.RentHouse.lService
{
    public interface IPermissionService:IServiceSupport
    {
        List<PermissionDTO> GetList();
    }
}
