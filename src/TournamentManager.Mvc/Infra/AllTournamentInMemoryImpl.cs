using System;
using TournamentManager.Mvc.Domain.Entity;
using TournamentManager.Mvc.Domain.Repository;

namespace TournamentManager.Mvc.Infra
{
    public class AllTournamentInMemoryImpl : IAllTournament
    {
        public static Tournament TournamentInMemory;

        public Tournament GetTournament()
        {
            return TournamentInMemory;
        }

        public void Set(Tournament tourmament)
        {
            TournamentInMemory = tourmament;
        }        

        public void ClearTournament()
        {
            TournamentInMemory = null;
        }
    }
}
