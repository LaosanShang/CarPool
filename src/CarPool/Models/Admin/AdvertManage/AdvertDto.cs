
using System.ComponentModel.DataAnnotations;

namespace CarPool.Models.Admin.AdvertManage
{
    public class AdvertDto : BaseVModel
    {
        public AdvertDto()
        {
            
        }
        [Display(Name = "标题")]
        [Required(ErrorMessage = "请输入标题")]
        public string Title { get; set; }
        
        [Display(Name = "图片")]
        [Required(ErrorMessage = "请上传图片")]
        public string ImageUrl { get; set; }
        
        [Display(Name = "描述")]
        public string Description { get; set; }
    }
}
