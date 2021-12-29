using HPIT.RentHouse.Common;
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
        /// <summary>
        /// 查询角色
        /// </summary>
        /// <returns></returns>
        List<RolesDTO> GetList();
        /// <summary>
        /// 查询角色列表
        /// </summary>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <param name="name"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        List<RolesDTO> GetPageList(int start, int length, string name, ref int count);
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        AjaxResult Add(RolesEditDTO roles);
        /// <summary>
        /// 查询角色id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        RolesEditDTO Edit(long id);
        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        AjaxResult Edit(RolesEditDTO roles);
        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        AjaxResult Delete(long id);
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        AjaxResult DeleteBatch(List<long> ids);
    }
}
