namespace LeagueOfDraven.Models.RIOT.Champions
{
    public class ChampionData
    {
        public string? Version { get; set; }
        public string? Id { get; set; }
        public string? Key { get; set; }
        public string? Name { get; set; }
        public string? Title { get; set; }
        public string? Blurb { get; set; }
        public ChampionInfo? Info { get; set; }
        public ChampionImage? Image { get; set; }
        public List<string>? Tags { get; set; }
        public string? Partype { get; set; }
        public ChampionStats? Stats { get; set; }
    }
}
