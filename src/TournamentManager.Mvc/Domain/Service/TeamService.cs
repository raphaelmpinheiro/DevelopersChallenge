using System.Collections.Generic;
using TournamentManager.Mvc.Domain.Entity;
using TournamentManager.Mvc.Domain.Repository;

namespace TournamentManager.Mvc.Domain.Service
{
    public class TeamService
    {
        private readonly IAllTeam _allTeam;

        public TeamService(IAllTeam allTeam)
        {
            _allTeam = allTeam;
        }

        public Team Get(long id)
        {
            return _allTeam.GetById(id);
        }

        public void Remove(long id)
        {
            var team = _allTeam.GetById(id);
            _allTeam.Remove(team);
        }

        public IEnumerable<Team> All()
        {
            return _allTeam.All();
        }

        public void AddOrUpdate(Team team)
        {
            _allTeam.AddOrUpdate(team);
        }
    }
}
