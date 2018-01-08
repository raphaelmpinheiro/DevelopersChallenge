using System;
using Microsoft.AspNetCore.Mvc;
using TournamentManager.Mvc.Domain.Repository;
using TournamentManager.Mvc.Domain.Service;
using TournamentManager.Mvc.Infra;
using TournamentManager.Mvc.Models;

namespace TournamentManager.Mvc.Controllers
{
    public class TournamentController : Controller
    {
        public IAllTournament AllTournamentRepository;
        public IAllTeam AllTeamRepository;

        public TournamentController()
        {
            AllTournamentRepository = new AllTournamentInMemoryImpl();
            AllTeamRepository = new AllTeamInMemory();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpGet]
        public IActionResult Current()
        {
            var ts = new TournamentService(AllTournamentRepository, AllTeamRepository);
            var tournament = ts.GetTournament();
            return View("Tournament", TournamentModel.Build(tournament));
        }

        [HttpGet]
        public IActionResult CreateTournament()
        {
            var ts = new TournamentService(AllTournamentRepository, AllTeamRepository);
            ts.CreateTournament();
            return RedirectToAction(nameof(Current));
        }

        [HttpGet]
        public IActionResult CreateRandomTournament()
        {
            var ts = new TournamentService(AllTournamentRepository, AllTeamRepository);
            ts.CreateTournamentAleatory();
            return RedirectToAction(nameof(Current));
        }

        [HttpGet]
        public IActionResult SetWinner(long teamId, int roundId)
        {
            try
            {
                var team = AllTeamRepository.GetById(teamId);
                var ts = new TournamentService(AllTournamentRepository, AllTeamRepository);
                ts.SetWinner(team, roundId);
                return RedirectToAction(nameof(Current));
            }
            catch (ArgumentException e)
            {
                TempData["MsgError"] = e.Message;
            }
            return RedirectToAction(nameof(Current));
        }
    }
}