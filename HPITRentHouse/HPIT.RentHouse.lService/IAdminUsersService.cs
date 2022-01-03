using HPIT.RentHouse.Common;
using HPIT.RentHouse.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPIT.RentHouse.lService
{
    public interface IAdminUsersService : IServiceSupport
    {
        /// <summary>
        /// 查询管理员
        /// </summary>
        /// <returns></returns>
        List<AdminUsersDTO> GetList();
        /// <summary>
        /// 查询管理员列表
        /// </summary>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <param name="name"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        List<AdminUsersDTO> GetPageList(int start, int length, string name, ref int count);
        /// <summary>
        /// 添加管理员
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        AjaxResult Add(AdminUsersDTO admin);
        /// <summary>
        /// 查询修改管理员id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        AdminUsersDTO Edit(long id);
        /// <summary>
        /// 修改管理员
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        AjaxResult Edit(AdminUsersDTO admin);
        /// <summary>
        /// 获取城市表字段
        /// </summary>
        /// <returns></returns>
        List<CitiesDTO> CityList();
        /// <summary>
        /// 删除管理员
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
        /// 登录
        /// </summary>
        /// <param name="dtO"></param>
        /// <returns></returns>
        AjaxResult Login(LoginDTO dtO);
    }
}
