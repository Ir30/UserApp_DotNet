using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserApi.DataModelLayer
{
    [Table("appuser")]
    public class Appuser
    {
        [Key]
        public int AppUserId { get; set; }

        [ForeignKey("usertype")]
        public int UserTypeId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int IsActive { get; set; }
    }
}
