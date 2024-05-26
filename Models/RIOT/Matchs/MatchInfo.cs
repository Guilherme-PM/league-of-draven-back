namespace LeagueOfDraven.Models.RIOT.Matchs
{
    public class MatchInfo
    {
        public long MatchId { get; set; }
        public string EndOfGameResult { get; set; }
        public long GameCreation { get; set; }
        public long GameDuration { get; set; }
        public long GameEndTimestamp { get; set; }
        public string GameMode { get; set; }
        public string GameName { get; set; }
        public long GameStartTimestamp { get; set; }
        public string GameType { get; set; }
        public string GameVersion { get; set; }
        public int MapId { get; set; }
        public List<MatchParticipant> Participants { get; set; } = new List<MatchParticipant>();
        public string PlatformId { get; set; }
        public List<MatchTeam> Teams { get; set; }
        public int QueueId { get; set; }
        public string TournamentCode { get; set; }
    }
}
