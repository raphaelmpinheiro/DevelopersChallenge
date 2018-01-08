using System.Collections.Generic;
using TournamentManager.Mvc.Domain.Entity;

namespace TournamentManager.Mvc.Models
{
    public class TournamentModel
    {
        public List<RoundModel> Round { get; set; }
        public string Winner { get; set; }

        public TournamentModel()
        {
            Round = new List<RoundModel>();
        }

        public static TournamentModel Build(Tournament tournament)
        {
            var tournamentModel = new TournamentModel();
            if (tournament != null)
            {
                var rounds = tournament.GetRounds();
                foreach (var round in rounds)
                {
                    tournamentModel.Round.Add(RoundModel.Build(round.Fights, round.RoundNumber));
                }

                var teamWinner = tournament.GetWinnerTournament();
                if (teamWinner != null)
                {
                    tournamentModel.Winner = teamWinner.Kingdom;
                }
            }
            return tournamentModel;
        }
    }
}
