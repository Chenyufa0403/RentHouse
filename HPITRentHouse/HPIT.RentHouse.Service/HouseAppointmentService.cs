using HPIT.RentHouse.Common;
using HPIT.RentHouse.DTO;
using HPIT.RentHouse.lService;
using HPIT.RentHouse.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPIT.RentHouse.Service
{
    public class HouseAppointmentService : IHouseAppointmentService
    {
        /// <summary>
        /// 添加看房预约记录
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public AjaxResult Add(HouseAppointmentAddDTO dto)
        {
            using (var db = new RentHouseEntity())
            {
                var bs = new BaseService<T_HouseAppointments>(db);

                var model = new T_HouseAppointments()
                {
                    CreateDateTime = DateTime.Now,
                    HouseId = dto.HouseId,
                    Name = dto.Name,
                    PhoneNum = dto.PhoneNum,
                    Status = "未处理",
                    VisitDate = dto.VisitDate

                };

                if (bs.Add(model) > 0)
                {
                    return new AjaxResult(ResultState.Success, "您已成功提交看房预约，请等待业务员与您联系");
                }
                else
                {
                    return new AjaxResult(ResultState.Error, "添加失败");
                }
            }
        }
        /// <summary>
        /// 业务员接单
        /// </summary>
        /// <param name="houseId">订单id</param>
        /// <param name="adminUserId">管理员用户id</param>
        /// <returns></returns>
        public AjaxResult Follow(long id, long adminUserId)
        {
            using (var db = new RentHouseEntity())
            {
                BaseService<T_HouseAppointments> bs = new BaseService<T_HouseAppointments>(db);
                var model = bs.Get(e => e.Id == id);
                model.FollowAdminUserId = adminUserId;
                model.Status = "已处理";
                model.FollowDateTime = DateTime.Now;
                if (bs.Update(model))
                {
                    return new AjaxResult(ResultState.Success, "恭喜抢单成功");
                }
                else
                {
                    return new AjaxResult(ResultState.Error, "很遗憾，抢单失败");
                }
            }
        }

        public List<HouseAppointmentDTO> GetPageList(int start, int length, ref int totalCount)
        {
            using (var db = new RentHouseEntity())
            {
                var bs = new BaseService<T_HouseAppointments>(db);
                var list = bs.GetPagedList(start, length, ref totalCount, a => true, a => a.Id);
                var result = list.Select(a => new HouseAppointmentDTO
                {
                    Id = a.Id,
                    UserId = a.UserId,
                    Name = a.Name,
                    PhoneNum = a.PhoneNum,
                    VisitDate = a.VisitDate,
                    HouseId = a.HouseId,
                    Status = a.Status,
                    FollowAdminUserId = a.FollowAdminUserId,
                    FollowAdminUserName = a.T_AdminUsers.Name,
                    FollowDateTime = a.FollowDateTime,
                    RegionName = a.T_Houses.T_Communities.T_Regions.Name,
                    CommunityName = a.T_Houses.T_Communities.Name,
                    HouseAddress = a.T_Houses.Address,
                    CreateDateTime = a.CreateDateTime
                }).ToList();
                return result;
            }
        }
    }
}
