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
    public class ShortsService : IShortsService
    {
        /// <summary>
        /// 查询房屋
        /// </summary>
        /// <returns></returns>
        public List<ShortsDTO> GetList()
        {
            var db = new RentHouseEntity();
            BaseService<T_Houses> bs = new BaseService<T_Houses>(db);
            var list = bs.GetList(h => true).Select(h => new ShortsDTO
            {
                Address = h.Address,
                Area = h.Area,
                StatusId = h.StatusId.ToString(),
                CommunityId = h.CommunityId.ToString(),
                DecorateStatusId = h.DecorateStatusId.ToString(),
                Id = h.Id,
                MonthRent = h.MonthRent,
                RoomTypeId = h.RoomTypeId.ToString()
            }).ToList();
            return list;
        }
        /// <summary>
        /// 查询房屋列表
        /// </summary>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <param name="name"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<ShortsDTO> GetPageList(int start, int length, string name, ref int count)
        {
            var db = new RentHouseEntity();
            var bs = new BaseService<T_Houses>(db);
            var query = PredicateExtensions.True<T_Houses>();
            var list = bs.GetPagedList(start, length, ref count, query, a => a.Id);
            var result = list.Select(h => new ShortsDTO
            {
                Address = h.Address,
                Area = h.Area,
                StatusId = h.StatusId.ToString(),
                CommunityId = h.CommunityId.ToString(),
                DecorateStatusId = h.DecorateStatusId.ToString(),
                Id = h.Id,
                MonthRent = h.MonthRent,
                RoomTypeId = h.RoomTypeId.ToString()
            }).ToList();
            return result;
        }

        public AjaxResult Add(ShortsAddDTO admin)
        {
            throw new NotImplementedException();
        }

        public ShortsAddDTO Edit(long id)
        {
            throw new NotImplementedException();
        }

        public AjaxResult Edit(ShortsAddDTO admin)
        {
            throw new NotImplementedException();
        }

        public AjaxResult Delete(long id)
        {
            throw new NotImplementedException();
        }

        public AjaxResult DeleteBatch(List<long> ids)
        {
            throw new NotImplementedException();
        }
    }
}
