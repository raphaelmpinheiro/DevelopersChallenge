using System;
using System.Collections.Generic;

namespace TournamentManager.Mvc.Domain.Entity
{
    public class Fight
    {
        private Team _winner;
        public List<Team> Teams { get; }

        public Fight(Team teamA, Team teamB)
        {
            Teams = new List<Team>(2);
            Teams.Add(teamA);
            Teams.Add(teamB);
        }

        public bool ContainsTeam(Team team)
        {
            return Teams.Contains(team);
        }

        public void SetWinner(Team team)
        {
            if (team == null)
            {
                throw new ArgumentException("Winning team can not be null");
            }

            if (_winner == null)
            {
                _winner = team;
            }
            else
            {
                throw new ArgumentException("A fight can not have two winners!");
            }
        }

        public Team GetWinner()
        {
            return _winner;
        }
    }
}
