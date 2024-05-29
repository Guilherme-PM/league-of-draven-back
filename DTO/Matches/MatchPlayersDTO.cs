namespace LeagueOfDraven.DTO.Matches
{
    public class MatchPlayersDTO
    {
        public string ChampionName { get; set; }
        public string UserName { get; set; }
        public bool WonMatch { get; set; }
        public int Farm { get; set; }
        public int GoldEarned { get; set; }
        public int GoldSpent { get; set; }
        public int TotalDamageDealt { get; set; }
        public int TotalDamageDealtToChampions {  get; set; }
        public int TotalDamageTaken { get; set; }
        public int TotalHeal { get; set; }
        public int VisionScore { get; set; }
        public int WardsPlaced { get; set; }
        public int WardsKilled { get; set; }
        public int Deaths { get; set; }
        public int Kills { get; set; }
        public string Lane { get; set; }
        public string Role { get; set; }
        public string ChampionImageURL { get; set; }
        public List<MatchItemsDTO> Items { get; set; }
    }
}
