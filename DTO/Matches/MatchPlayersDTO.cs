namespace LeagueOfDraven.DTO.Matches
{
    public class MatchPlayersDTO
    {
        public string ChampionName { get; set; }
        public string UserName { get; set; }
        public int Farm { get; set; }
        public int GoldEarned { get; set; }
        public int GoldSpent { get; set; }
        public string ChampionImageURL { get; set; }
        public List<MatchItemsDTO> Items { get; set; }
    }
}
