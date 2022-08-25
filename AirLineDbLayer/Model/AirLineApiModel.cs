using MySql.Data.MySqlClient.X.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirLineDbLayer.Model
{
    public class AirLineApiModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }
        [Required, MaxLength(30)]
        public string? FromCity { get; set; }
        [Required, MaxLength(30)]
        public string? ToCity { get; set; }
        [Required]
        public int Fare { get; set; }

    }
}
