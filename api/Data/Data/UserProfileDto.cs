using Dapper;

namespace Data {

    [Table(tableName: "UserProfiles")]
    public class UserProfileDto {
        //Warnings not needed for dto
#nullable disable

        [Column(columnName: "Id")]
        public int? Id { get; set; }

        [Column(columnName: "UserName")]
        public string UserName { get; set; }

        [Column(columnName: "Email")]
        public string Email { get; set; }

        [Column(columnName: "AdditionalData")]
        public string AdditionalData { get; set; }

#nullable enable
        }
    }
