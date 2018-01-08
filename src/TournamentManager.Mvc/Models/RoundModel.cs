using System.Collections.Generic;
using TournamentManager.Mvc.Domain.Entity;

namespace TournamentManager.Mvc.Models
{
    public class RoundModel
    {
        public RoundModel()
        {
            Fight = new List<FightModel>();
        }

        public int RoundNumber { get; set; }
        public List<FightModel> Fight { get; set; }

        public static RoundModel Build(IEnumerable<Fight> fights, int roundNumber)
        {
            var roundModel = new RoundModel();
            roundModel.RoundNumber = roundNumber;
            foreach (var fight in fights)
            {
                var fightModel = new FightModel();

                fightModel.Team1 = TeamModel.Build(fight.Teams[0]);
                fightModel.Team2 = TeamModel.Build(fight.Teams[1]);
                roundModel.Fight.Add(fightModel);
            }
            return roundModel;
        }
    }
}
