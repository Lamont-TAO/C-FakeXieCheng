using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FakeXieCheng.NET3.Models
{
    public class TouristRoutePicture
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//图片的ID是自增的
        public int Id { get; set; }
        [MaxLength(100)]
        public string  Url { get; set; }
        [ForeignKey("TouristRouteID")]
        public Guid  TouristRouteId { get; set; }
        public TouristRoute TouristRoute { get; set; }


    }
}
