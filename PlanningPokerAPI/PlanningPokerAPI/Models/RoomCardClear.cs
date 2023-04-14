using System.ComponentModel.DataAnnotations;

namespace PlanningPokerAPI.Models
{
    public class RoomCardClear
    {
        [Key]
        public string ClearRoom { get; set; }
        public bool RoomClear { get; set; }
    }
}
