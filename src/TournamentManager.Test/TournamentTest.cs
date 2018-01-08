using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TournamentManager.Mvc.Domain.Entity;

namespace TournamentManager.Test
{
    [TestClass]
    public class TournamentTest
    {
        [TestMethod]
        public void GenerateNewTournamentEndToEnd()
        {
            var team1 = new Team("Flamengo");
            var team2 = new Team("Vasco");
            var team3 = new Team("Botafogo");
            var team4 = new Team("Corinthians");
            var team5 = new Team("Palmeiras");
            var team6 = new Team("Atlético Mineiro");
            var team7 = new Team("Cruzeiro");
            var team8 = new Team("São Paulo");

            Queue<Team> team = new Queue<Team>();
            team.Enqueue(team1);
            team.Enqueue(team2);
            team.Enqueue(team3);
            team.Enqueue(team4);
            team.Enqueue(team5);
            team.Enqueue(team6);
            team.Enqueue(team7);
            team.Enqueue(team8);

            var tournament = new Tournament(team);
            var round1 = tournament.GetRound(0);

            round1.SetWinner(team1);
            round1.SetWinner(team3);
            round1.SetWinner(team5);
            round1.SetWinner(team7);

            tournament.PutRound(round1);

            var round2 = tournament.GetRound(1);
            round2.SetWinner(team1);
            round2.SetWinner(team5);

            tournament.PutRound(round2);

            var round3 = tournament.GetRound(2);
            round3.SetWinner(team1);

            tournament.PutRound(round3);

            var winner = tournament.GetWinnerTournament();

            Assert.AreEqual(team1, winner);
        }
    }
}
