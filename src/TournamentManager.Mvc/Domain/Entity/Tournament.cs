using System.Collections.Generic;
using System.Linq;

namespace TournamentManager.Mvc.Domain.Entity
{
    public class Tournament
    {
        private readonly Round[] _rounds;

        public Tournament(Queue<Team> teams)
        {
            _rounds = GenerateRounds(teams);
        }

        public Round GetRound(int index)
        {
            return _rounds.FirstOrDefault(x => x.RoundNumber == index);
        }

        /// <summary>
        /// Return list of rounds
        /// </summary>
        /// <returns></returns>
        public Round[] GetRounds()
        {
            return _rounds;
        }

        /// <summary>
        /// The last round contains the winner
        /// </summary>
        /// <returns>Team winner</returns>
        public Team GetWinnerTournament()
        {
            return _rounds.Last().GetWinners().FirstOrDefault();
        }

        public void PutRound(Round roundEdited)
        {
            RecalculateNextRounds(roundEdited);
        }

        private void RecalculateNextRounds(Round roundEdited)
        {
            Queue<Team> teams;
            var roundTemp = roundEdited;
            do
            {
                var winners = roundTemp.GetWinners();
                if (winners.Count == 1)
                {
                    _rounds[roundEdited.RoundNumber] = roundEdited;
                    break;
                }

                Round round = new Round(winners, roundTemp.RoundNumber + 1);
                _rounds[round.RoundNumber] = round;
                teams = round.GetWinners();
                roundTemp = round;
            }
            while (teams.Count != 1);
        }

        /// <summary>
        /// Generate rounds 
        /// </summary>
        /// <param name="teams"></param>
        /// <returns>Array with rounds</returns>
        private Round[] GenerateRounds(Queue<Team> teams)
        {
            List<Round> rounds = new List<Round>();
            var teamsTemporary = teams;
            int i = 0;
            do
            {
                var round = new Round(teamsTemporary, i);
                rounds.Add(round);
                teamsTemporary = round.GetWinners();
                i++;
            }
            while (teamsTemporary.Count > 1);

            return rounds.ToArray();
        }
    }
}