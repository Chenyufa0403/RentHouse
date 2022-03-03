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
    public class HousesService : IHousesService
    {
        public List<HousesDTO> GetHouseList(string communityName, int typeId, int start, int length, ref int totalCount)
        {
            using (var db = new RentHouseEntity())
            {
                var bs = new BaseService<T_Houses>(db);
                var query = PredicateExtensions.True<T_Houses>();
                if (typeId > 0)
                {
                    query = query.And(e => e.TypeId == typeId);
                }
                if (!string.IsNullOrWhiteSpace(communityName))
                {
                    query = query.And(e => e.T_Communities.Name.Contains(communityName));
                }
                totalCount = 0;
                var list = bs.GetPagedList(start, length, ref totalCount, query, e => e.Id, false).Select(e => new HousesDTO
                {
                    Address = e.Address,
                    Area = e.Area,
                    CommunityName = e.T_Communities.Name,
                    DecorateStatusId = e.DecorateStatusId,
                    MonthRent = e.MonthRent,
                    Id = e.Id,
                    RoomTypeId = e.RoomTypeId,
                    RegionName = e.T_Communities.T_Regions.Name
                }).ToList();
                var bsIdNames = new BaseService<T_IdNames>(db);
                var idNamesList = bsIdNames.GetList(e => true).ToList();
                list.ForEach(e =>
                {
                    e.DecorateStatusName = idNamesList.Where(i => i.Id == e.DecorateStatusId).FirstOrDefault().Name;
                    e.RoomTypeName = idNamesList.Where(i => i.Id == e.RoomTypeId).FirstOrDefault().Name;
                });
                return list;
            }
        }
        public List<AttachmentDTO> GetAttachmentList()
        {
            using (var db = new RentHouseEntity())
            {
                var bs = new BaseService<T_Attachments>(db);
                var list = bs.GetList(e => true).Select(e => new AttachmentDTO
                {
                    Id = e.Id,
                    Name = e.Name,
                    IconName = e.IconName
                }).ToList(); ;
                return list;
            }
        }

        /// <summary>
        /// 根据id获取房源信息
        /// </summary>
        /// <param name="id">房源id</param>
        /// <returns></returns>
        public HousesEditDTO GetHouse(long id)
        {
            using (var db = new RentHouseEntity())
            {
                var bs = new BaseService<T_Houses>(db);

                var model = bs.Get(e => e.Id == id);
                if (model != null)
                {
                    var dto = new HousesEditDTO()
                    {
                        Address = model.Address,
                        Area = model.Area,
                        CheckInDateTime = model.CheckInDateTime,
                        CityId = model.T_Communities.T_Regions.CityId,
                        CommunityId = model.CommunityId,
                        DecorateStatusId = model.DecorateStatusId,
                        Description = model.Description,
                        Direction = model.Direction,
                        FloorIndex = model.FloorIndex,
                        Id = model.Id,
                        IsDeleted = model.IsDeleted,
                        LookableDateTime = model.LookableDateTime,
                        MonthRent = model.MonthRent,
                        OwnerName = model.OwnerName,
                        OwnerPhoneNum = model.OwnerPhoneNum,
                        RegionId = model.T_Communities.RegionId,
                        RoomTypeId = model.RoomTypeId,
                        StatusId = model.StatusId,
                        TotalFloorCount = model.TotalFloorCount,
                        TypeId = model.TypeId,

                    };

                    //获取所有配置设置信息
                    var bsAttachment = new BaseService<T_Attachments>(db);

                    var attachmentList = bsAttachment.GetList(e => true).ToList();

                    dto.HouseAttachments = new List<HouseAttachment>();

                    //获取当前房源的配置设置信息
                    var currentAttachment = model.T_Attachments;

                    attachmentList.ForEach(e =>
                    {
                        var houseAttachment = new HouseAttachment()
                        {
                            AttachmentId = e.Id,
                            Name = e.Name,
                            IsUsed = currentAttachment.Any(c => c.Id == e.Id)
                        };

                        dto.HouseAttachments.Add(houseAttachment);
                    });

                    return dto;
                }
                return null;
            }
        }
        public AjaxResult Add(HousesAddDTO dto)
        {
            var db = new RentHouseEntity();
            var bs = new BaseService<T_Houses>(db);
            T_Houses model = new T_Houses();
            model.Address = dto.Address;
            model.Area = dto.Area;
            model.CheckInDateTime = dto.CheckInDateTime;
            model.CommunityId = dto.CommunityId;
            model.DecorateStatusId = dto.DecorateStatusId;
            model.Description = dto.Description;
            model.Direction = dto.Direction;
            model.FloorIndex = dto.FloorIndex;
            model.LookableDateTime = dto.LookableDateTime;
            model.MonthRent = dto.MonthRent;
            model.OwnerName = dto.OwnerName;
            model.OwnerPhoneNum = dto.OwnerPhoneNum;
            model.RoomTypeId = dto.RoomTypeId;
            model.StatusId = dto.StatusId;
            model.TotalFloorCount = dto.TotalFloorCount;
            model.TypeId = dto.TypeId;
            model.IsDeleted = dto.IsDeleted;
            model.CreateDateTime = DateTime.Now;
            long id = bs.Add(model);
            if (id > 0)
            {
                return new AjaxResult(ResultState.Success, "房源添加成功");
            }
            else
            {
                return new AjaxResult(ResultState.Error, "房源添加失败");
            }
        }
        /// <summary>
        /// 更新房源
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public AjaxResult EditHouse(HousesEditDTO dto)
        {
            using (var db = new RentHouseEntity())
            {
                var bs = new BaseService<T_Houses>(db);

                var model = bs.Get(e => e.Id == dto.Id);
                if (model != null)
                {
                    model.Address = dto.Address;
                    model.Area = dto.Area;
                    model.CheckInDateTime = dto.CheckInDateTime;
                    model.CommunityId = dto.CommunityId;
                    model.DecorateStatusId = dto.DecorateStatusId;
                    model.Description = dto.Description;
                    model.Direction = dto.Direction;
                    model.FloorIndex = dto.FloorIndex;
                    model.LookableDateTime = dto.LookableDateTime;
                    model.MonthRent = dto.MonthRent;
                    model.OwnerName = dto.OwnerName;
                    model.OwnerPhoneNum = dto.OwnerPhoneNum;
                    model.RoomTypeId = dto.RoomTypeId;
                    model.StatusId = dto.StatusId;
                    model.TotalFloorCount = dto.TotalFloorCount;
                    model.TypeId = dto.TypeId;

                    //清空当前房源的配置设置信息
                    model.T_Attachments.Clear();

                    //添加新的配置设置信息

                    var bsAttachment = new BaseService<T_Attachments>(db);
                    if (dto.AttachmentIds != null && dto.AttachmentIds.Length > 0)
                    {
                        for (int i = 0; i < dto.AttachmentIds.Length; i++)
                        {
                            var attachmentId = dto.AttachmentIds[i];

                            var attachment = bsAttachment.Get(e => e.Id == attachmentId);
                            if (attachment != null)
                            {
                                model.T_Attachments.Add(attachment);
                            }

                        }
                    }

                    db.SaveChanges();

                    return new AjaxResult(ResultState.Success, "修改成功");

                }
                return new AjaxResult(ResultState.Error, "当前房源信息不存在");
            }
        }
        /// <summary>
        /// 添加房源图片
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public AjaxResult AddHousePic(HousePicDTO dto)
        {
            using (var db = new RentHouseEntity())
            {
                BaseService<T_HousePics> bs = new BaseService<T_HousePics>(db);
                var model = new T_HousePics
                {
                    CreateDateTime = DateTime.Now,
                    HouseId = dto.HouseId,
                    ThumbUrl = dto.ThumbUrl,
                    Url = dto.Url
                };
                long id = bs.Add(model);
                if (id > 0)
                {
                    return new AjaxResult(ResultState.Success, "添加图片成功");
                }
                else
                {
                    return new AjaxResult(ResultState.Error, "添加图片败");
                }

            }
        }
        /// <summary>
        /// 获取房源图片
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<HousePicDTO> GetHousePics(long id)
        {
            using (var db = new RentHouseEntity())
            {
                var bs = new BaseService<T_HousePics>(db);
                var list = bs.GetList(a => a.HouseId == id).Select(e => new HousePicDTO
                {
                    Id = e.Id,
                    HouseId = e.Id,
                    ThumbUrl = e.ThumbUrl,
                    Url = e.Url
                }).ToList();
                return list;
            }
        }

        /// <summary>
        /// 批量删除房源图片
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public AjaxResult DeleteHousePic(List<long> ids)
        {
            try
            {
                var db = new RentHouseEntity();
                BaseService<T_HousePics> bs = new BaseService<T_HousePics>(db);
                foreach (var id in ids)
                {
                    //1、通过id获取ef中的model
                    //2、删除该model
                    var model = bs.Get(e => e.Id == id);
                    bs.Delete(model);
                }
                return new AjaxResult(ResultState.Success, "删除成功");
            }
            catch (Exception)
            {
                return new AjaxResult(ResultState.Error, "删除失败");
            }
        }
        public List<HousesDTO> GetList(int cityId, int pageIndex, int pageSize)
        {
            using (var db = new RentHouseEntity())
            {
                var bs = new BaseService<T_Houses>(db);
                var query = PredicateExtensions.True<T_Houses>();
                if (cityId > 0)
                {
                    query = query.And(e => e.T_Communities.T_Regions.CityId == cityId);
                }
                int totalCount = 0;
                int start = (pageIndex - 1) * pageSize;
                var list = bs.GetPagedList(start, pageSize, ref totalCount, query, e => e.Id, false).Select(e => new HousesDTO
                {
                    Address = e.Address,
                    Area = e.Area,
                    CommunityName = e.T_Communities.Name,
                    DecorateStatusId = e.DecorateStatusId,
                    MonthRent = e.MonthRent,
                    Id = e.Id,
                    RoomTypeId = e.RoomTypeId,
                    RegionName = e.T_Communities.T_Regions.Name,
                    FirstThumbUrl = e.T_HousePics.Where(a => !a.IsDeleted).FirstOrDefault().ThumbUrl
                }).ToList();
                var bsIdNames = new BaseService<T_IdNames>(db);
                var idNamesList = bsIdNames.GetList(e => true).ToList();
                list.ForEach(e =>
                {
                    e.DecorateStatusName = idNamesList.Where(i => i.Id == e.DecorateStatusId).FirstOrDefault().Name;
                    e.RoomTypeName = idNamesList.Where(i => i.Id == e.RoomTypeId).FirstOrDefault().Name;
                });
                return list;
            }
        }
        /// <summary>
        /// 房源检索
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public List<HousesDTO> Search(HouseSearchOptions options)
        {
            using (var db = new RentHouseEntity())
            {
                var bs = new BaseService<T_Houses>(db);

                //默认显示当前城市的房源
                var query = bs.GetList(e => e.T_Communities.T_Regions.CityId == options.CityId);

                //按区域检索
                if (options.RegionId > 0)
                {
                    query = query.Where(e => e.T_Communities.RegionId == options.RegionId);
                }

                //按租金检索
                if (options.StartMonthRent.HasValue)
                {
                    query = query.Where(e => e.MonthRent >= options.StartMonthRent.Value);
                }

                if (options.EndMonthRent.HasValue)
                {
                    query = query.Where(e => e.MonthRent <= options.EndMonthRent.Value);
                }

                //关键字
                if (!string.IsNullOrEmpty(options.Keywords))
                {
                    query = query.Where(e => e.Address.Contains(options.Keywords) || e.Description.Contains(options.Keywords));
                }

                //排序
                switch (options.OrderByType)
                {
                    case "MonthRentAsc":
                        query = query.OrderBy(e => e.MonthRent);
                        break;
                    case "MonthRentDesc":
                        query = query.OrderByDescending(e => e.MonthRent);
                        break;
                    case "AreaAsc":
                        query = query.OrderBy(e => e.Area);
                        break;
                    case "AreaDesc":
                        query = query.OrderByDescending(e => e.Area);
                        break;
                    default:
                        query = query.OrderByDescending(e => e.Id);
                        break;
                }

                var list = query.Select(e => new HousesDTO()
                {
                    Id = e.Id,
                    Area = e.Area,
                    CommunityName = e.T_Communities.Name,
                    MonthRent = e.MonthRent,
                    FirstThumbUrl = e.T_HousePics.Where(a => !a.IsDeleted).FirstOrDefault().ThumbUrl,
                    RoomTypeId = e.RoomTypeId,
                    DecorateStatusId = e.DecorateStatusId
                }).ToList();

                var bs1 = new BaseService<T_IdNames>(db);
                list.ForEach(e =>
                {
                    e.RoomTypeName = bs1.Get(a => a.Id == e.RoomTypeId).Name;
                    e.DecorateStatusName = bs1.Get(a => a.Id == e.RoomTypeId).Name;
                });

                return list;
            }
        }
        /// <summary>
        /// 获取房源详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HouseDetailDTO GetHouseDetail(long id)
        {
            //using (var db = new RentHouseEntity())
            //{
            //    var bs = new BaseService<T_Houses>(db);

            //    //根据id先从redis中查询，如果redis中有数据则直接返回redis中的数据
            //    RedisHelper redis = new RedisHelper();
            //    var dtoRedis = redis.HashGet<HouseDetailDTO>("housedetail", id.ToString());
            //    if (dtoRedis != null)
            //        return dtoRedis;

            //    var bsIdNames = new BaseService<T_IdNames>(db);
            //    //否则再读取数据库中的数据，并且添加到redis中
            //    var model = bs.Get(e => e.Id == id);
            //    if (model != null)
            //    {
            //        var dto = new HouseDetailDTO()
            //        {
            //            Address = model.Address,
            //            Area = model.Area,
            //            CommunityName = model.T_Communities.Name,
            //            Id = model.Id,
            //            MonthRent = model.MonthRent,
            //            RegionName = model.T_Communities.T_Regions.Name,
            //            LocationName = model.T_Communities.Location,
            //            RoomTypeName = bsIdNames.Get(a => a.Id == model.RoomTypeId).Name,
            //            DecorateStatusName = bsIdNames.Get(a => a.Id == model.DecorateStatusId).Name,
            //            TypeName = bsIdNames.Get(a => a.Id == model.TypeId).Name,
            //            CheckInDateTime = model.CheckInDateTime,
            //            CommunityBuiltYear = (int)model.T_Communities.BuiltYear,
            //            Direction = model.Direction,
            //            FloorIndex = model.FloorIndex,
            //            LookableDateTime = model.LookableDateTime,
            //            TotalFloorCount = model.TotalFloorCount,
            //            StatusName = bsIdNames.Get(a => a.Id == model.StatusId).Name,
            //            CommunityTraffic = model.T_Communities.Traffic,
            //            Description = model.Description

            //        };

            //        //配置设施
            //        dto.Attachments = new List<AttachmentDTO>();

            //        foreach (var item in model.T_Attachments)
            //        {
            //            var attachment = new AttachmentDTO()
            //            {
            //                IconName = item.IconName,
            //                Id = item.Id,
            //                Name = item.Name
            //            };

            //            dto.Attachments.Add(attachment);
            //        }

            //        //房源图片
            //        dto.HousePics = new List<HousePicDTO>();

            //        var bsHousePic = new BaseService<T_HousePics>(db);

            //        var picList = bsHousePic.GetList(e => e.HouseId == id && e.IsDeleted == false).ToList();
            //        picList.ForEach(e =>
            //        {
            //            var housePic = new HousePicDTO()
            //            {

            //                HouseId = e.HouseId,
            //                Id = e.Id,
            //                ThumbUrl = e.ThumbUrl,
            //                Url = e.Url
            //            };

            //            dto.HousePics.Add(housePic);
            //        });


            //        //相似房源
            //        //与当前房源在同一个小区的，认为是相似房源
            //        dto.OtherHouses = bs.GetList(e => e.CommunityId == model.CommunityId).Take(3).Select(e => new HousesDTO()
            //        {
            //            Id = e.Id,
            //            Area = e.Area,
            //            CommunityName = e.T_Communities.Name,
            //            MonthRent = e.MonthRent,
            //            FirstThumbUrl = e.T_HousePics.Where(a => !a.IsDeleted).FirstOrDefault().ThumbUrl,
            //            RoomTypeId = e.RoomTypeId,
            //            DecorateStatusId = e.DecorateStatusId
            //        }).ToList();

            //        dto.OtherHouses.ForEach(e =>
            //        {
            //            e.RoomTypeName = bsIdNames.Get(a => a.Id == model.RoomTypeId).Name;
            //            e.DecorateStatusName = bsIdNames.Get(a => a.Id == model.DecorateStatusId).Name;
            //        });

            //        //向redis中写入当前房源信息的数据
            //        redis.HashSet<HouseDetailDTO>("housedetail", id.ToString(), dto);

            //        return dto;

            //    }
                return null;
            //}
        }
    }
}
