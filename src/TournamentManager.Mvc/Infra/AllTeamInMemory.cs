using System.Collections.Generic;
using System.Linq;
using TournamentManager.Mvc.Domain.Entity;
using TournamentManager.Mvc.Domain.Repository;

namespace TournamentManager.Mvc.Infra
{
    public class AllTeamInMemory : IAllTeam
    {
        public static List<Team> Teams;
        private static long _id;
        static AllTeamInMemory()
        {
            Teams = new List<Team>();
            _id = 0;
        }

        public void AddOrUpdate(Team team)
        {
            if (team.IsNew())
            {
                _id++;
                team.Id = _id;
                Teams.Add(team);
            }
            else
            {
                var oldTeam = Teams.FirstOrDefault(x => x.Id == team.Id);
                Teams.Remove(oldTeam);
                Teams.Add(team);
            }
        }

        public Team GetById(long id)
        {
            return Teams.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Team> All()
        {
            return Teams.AsEnumerable();
        }

        public void Remove(Team team)
        {
            Teams.Remove(team);
        }
    }
}
