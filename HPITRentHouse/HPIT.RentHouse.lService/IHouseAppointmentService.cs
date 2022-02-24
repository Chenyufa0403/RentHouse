using HPIT.RentHouse.Common;
using HPIT.RentHouse.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPIT.RentHouse.lService
{
    public interface IHouseAppointmentService : IServiceSupport
    {
        List<HouseAppointmentDTO> GetPageList(int start, int length, ref int totalCount);

        /// <summary>
        /// 添加看房预约记录
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        AjaxResult Add(HouseAppointmentAddDTO dto);

        /// <summary>
        /// 业务员接单
        /// </summary>
        /// <param name="houseId">订单id</param>
        /// <param name="adminUserId">管理员用户id</param>
        /// <returns></returns>
        AjaxResult Follow(long id, long adminUserId);
    }
}
