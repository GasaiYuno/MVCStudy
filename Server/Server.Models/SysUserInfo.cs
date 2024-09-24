using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models
{
    [Table("sys_user_info")]
    public class SysUserInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("_id")]
        public int Id { get; set; }
        [Column("user_name")]
        public string UserName { get; set; }
        [Column("passwprd")]
        public string Password { get; set; }

    }
}