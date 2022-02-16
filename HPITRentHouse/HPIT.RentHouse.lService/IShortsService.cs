using HPIT.RentHouse.Common;
using HPIT.RentHouse.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPIT.RentHouse.lService
{
    public interface IShortsService : IServiceSupport
    {
        /// <summary>
        /// 查询房源
        /// </summary>
        /// <returns></returns>
        List<ShortsDTO> GetList();
        /// <summary>
        /// 查询房源列表
        /// </summary>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <param name="name"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        List<ShortsDTO> GetPageList(int start, int length, string name, ref int count);
        /// <summary>
        /// 添加房源
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        AjaxResult Add(ShortsAddDTO admin);
        /// <summary>
        /// 查询修改房源id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ShortsAddDTO Edit(long id);
        /// <summary>
        /// 修改房源
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        AjaxResult Edit(ShortsAddDTO admin);
        /// <summary>
        /// 删除房源
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
