using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeagueOfDraven.Models
{
    public class MatchesPlayerItems
    {
        [Key]
        public int MatchPlayerItemId { get; set; }
        public string UserMatchId { get; set; }
        public long ParticipantId { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public MatchesPlayerStatistics PlayerStatistics { get; set; }
    }
}
