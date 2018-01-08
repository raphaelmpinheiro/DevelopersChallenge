using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TournamentManager.Mvc.Domain.Repository;
using TournamentManager.Mvc.Domain.Service;
using TournamentManager.Mvc.Infra;
using TournamentManager.Mvc.Models;

namespace TournamentManager.Mvc.Controllers
{
    public class TeamController : Controller
    {
        public IAllTeam AllTeamRepository;

        public TeamController()
        {
            AllTeamRepository = new AllTeamInMemory();
        }

        [HttpGet]
        public ActionResult Index()
        {
            var ts = new TeamService(AllTeamRepository);
            var allTeams = ts.All();
            return View("Index", allTeams.Select(x => TeamModel.Build(x)));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TeamModel model)
        {
            try
            {
                var ts = new TeamService(AllTeamRepository);
                ts.AddOrUpdate(model.GetTeam());
            }
            catch (ArgumentException e)
            {
                TempData["MsgError"] = e.Message;
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var ts = new TeamService(AllTeamRepository);
            var team = ts.Get(id);
            return View("Edit", TeamModel.Build(team));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TeamModel model)
        {
            try
            {
                var ts = new TeamService(AllTeamRepository);
                ts.AddOrUpdate(model.GetTeam());
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Delete(long id)
        {
            var ts = new TeamService(AllTeamRepository);
            ts.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}