﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HPIT.RentHouse.DTO;

namespace HPIT.RentHouse.lService
{
    public interface IPermissionService : IServiceSupport
    {
        List<PermissionDTO> GetList();
        List<PermissionDTO> GetPageList(int start, int length, string name, ref int count);
    }
}
