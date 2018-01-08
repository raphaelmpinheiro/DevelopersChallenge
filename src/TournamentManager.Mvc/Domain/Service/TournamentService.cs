using System;
using System.Collections.Generic;
using System.Linq;
using TournamentManager.Mvc.Domain.Entity;
using TournamentManager.Mvc.Domain.Repository;

namespace TournamentManager.Mvc.Domain.Service
{
    public class TournamentService
    {
        private readonly IAllTournament _allTournamentRepository;
        private readonly IAllTeam _allTeamRepository;

        public TournamentService(IAllTournament allTournamentRepository, IAllTeam allTeamRepository)
        {
            _allTournamentRepository = allTournamentRepository;
            _allTeamRepository = allTeamRepository;
        }

        public Tournament GetTournament()
        {
            return _allTournamentRepository.GetTournament();
        }

        public void SetWinner(Team team, int roundId)
        {
            var tournament = _allTournamentRepository.GetTournament();
            var round = tournament.GetRound(roundId);
            round.SetWinner(team);
            tournament.PutRound(round);
            _allTournamentRepository.Set(tournament);
        }

        public void CreateTournament()
        {
            var teams = _allTeamRepository.All();
            var tournament = new Tournament(new Queue<Team>(teams));
            _allTournamentRepository.Set(tournament);
        }

        public void CreateTournamentAleatory()
        {
            var teams = _allTeamRepository.All().OrderBy(x => Guid.NewGuid());
            var tournament = new Tournament(new Queue<Team>(teams));
            _allTournamentRepository.Set(tournament);
        }
    }
}