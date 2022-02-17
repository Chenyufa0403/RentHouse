using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HPIT.RentHouse.Common;
using HPIT.RentHouse.DTO;

namespace HPIT.RentHouse.lService
{
    public interface IPermissionsService : IServiceSupport
    {
        /// <summary>
        /// 查询权限
        /// </summary>
        /// <returns></returns>
        List<PermissionsDTO> GetList();
        /// <summary>
        /// 查询权限列表
        /// </summary>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <param name="name"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        List<PermissionsDTO> GetPageList(int start, int length, string name, ref int count);
        /// <summary>
        /// 添加权限节点
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        AjaxResult Add(PermissionsDTO permission);
        /// <summary>
        /// 查询修改权限id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        PermissionsDTO Edit(long id);
        /// <summary>
        /// 修改权限
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        AjaxResult Edit(PermissionsDTO permission);
        /// <summary>
        /// 删除权限
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
        /// <summary>
        /// 获取用户权限
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        List<PermissionsDTO> GetListByUser(long userId);
    }
}
