using TournamentManager.Mvc.Domain.Entity;

namespace TournamentManager.Mvc.Domain.Repository
{
    public interface IAllTournament
    {
        Tournament GetTournament();
        void Set(Tournament tourmament);        
        void ClearTournament();
    }
}
