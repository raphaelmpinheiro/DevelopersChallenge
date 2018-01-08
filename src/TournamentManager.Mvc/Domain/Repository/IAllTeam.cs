using System.Collections.Generic;
using TournamentManager.Mvc.Domain.Entity;

namespace TournamentManager.Mvc.Domain.Repository
{
    public interface IAllTeam
    {
        void AddOrUpdate(Team team);
        Team GetById(long id);
        IEnumerable<Team> All();
        void Remove(Team team);
    }
}
