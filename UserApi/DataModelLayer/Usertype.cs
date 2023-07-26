using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserApi.DataModelLayer
{
    [Table("usertype")]
    public class Usertype
    {
        public Usertype()
        {
            this.Appuser = new HashSet<Appuser>();
        }

        [Key]
        public int UserTypeId { get; set; }
        public string UserType { get; set; }
        public string Description { get; set; }
        public int IsActive { get; set; }

        public virtual ICollection<Appuser> Appuser { get; }
    }
}
