using System;
using System.Collections.Generic;
using System.Linq;

namespace TournamentManager.Mvc.Domain.Entity
{
    public class Round
    {
        public Round(Queue<Team> teams, int roundNumber)
        {
            this.Fights = new Queue<Fight>();
            RoundNumber = roundNumber;
            GenerateFights(teams);
        }

        public Queue<Fight> Fights;
        public int RoundNumber { get; }

        public Queue<Team> GetWinners()
        {
            var winners = new Queue<Team>(Fights.Select(x => x.GetWinner()));
            return winners;
        }

        public void SetWinner(Team team)
        {
            foreach (var fight in Fights)
            {
                if (fight.ContainsTeam(team))
                {
                    fight.SetWinner(team);
                    return;
                }
            }
            throw new ArgumentException("Team is not in the fights.");
        }

        private void GenerateFights(Queue<Team> teams)
        {
            while (teams.Count > 0)
            {
                teams.TryDequeue(out var team1);
                teams.TryDequeue(out var team2);
                var fight = new Fight(team1, team2);
                Fights.Enqueue(fight);
            }
        }
    }
}
