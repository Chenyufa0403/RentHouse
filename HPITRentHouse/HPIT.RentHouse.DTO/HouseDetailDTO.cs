using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPIT.RentHouse.DTO
{
    [Serializable]
    public class HouseDetailDTO
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 区域
        /// </summary>
        public string RegionName { get; set; }

        /// <summary>
        /// 小区名
        /// </summary>
        public string CommunityName { get; set; }

        /// <summary>
        /// 地段
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 租金
        /// </summary>
        public int MonthRent { get; set; }

        /// <summary>
        /// 房间类型
        /// </summary>
        public string RoomTypeName { get; set; }

        /// <summary>
        /// 装修类型
        /// </summary>
        public string DecorateStatusName { get; set; }

        /// <summary>
        /// 面积
        /// </summary>
        public decimal Area { get; set; }

        public string LocationName { get; set; }

        public string TypeName { get; set; }

        public int TotalFloorCount { get; set; }
        public int FloorIndex { get; set; }
        public DateTime LookableDateTime { get; set; }
        public DateTime CheckInDateTime { get; set; }
        public string Direction { get; set; }

        public int CommunityBuiltYear { get; set; }
        public string StatusName { get; set; }

        public string Description { get; set; }

        public string CommunityTraffic { get; set; }

        /// <summary>
        /// 房源图片
        /// </summary>
        public List<HousePicDTO> HousePics { get; set; }

        /// <summary>
        /// 配置设施
        /// </summary>
        public List<AttachmentDTO> Attachments { get; set; }

        /// <summary>
        /// 相似房源
        /// </summary>

        public List<HousesDTO> OtherHouses { get; set; }
    }
}
