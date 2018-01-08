using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TournamentManager.Mvc.Domain.Entity;

namespace TournamentManager.Test
{
    [TestClass]
    public class RoundTest
    {
        [TestMethod]
        public void RoundWithTwoTeamsAndFlamengoWinnerTest()
        {
            var flamengo = new Team("Flamengo");
            var vasco = new Team("Vasco");

            Queue<Team> teams = new Queue<Team>();
            teams.Enqueue(flamengo);
            teams.Enqueue(vasco);

            Round round1 = new Round(teams, 0);

            round1.SetWinner(flamengo);

            var winners = round1.GetWinners();

            Assert.IsTrue(winners.Count == 1);
            Assert.AreEqual(flamengo, winners.First());
        }

        [TestMethod]
        public void RoundWithFourTeamsAndFlamengoWinnerTest()
        {
            var flamengo = new Team("Flamengo");
            var vasco = new Team("Vasco");
            var botafogo = new Team("Botafogo");
            var fluminense = new Team("Fluminense");

            Queue<Team> teams = new Queue<Team>();
            teams.Enqueue(flamengo);
            teams.Enqueue(botafogo);
            teams.Enqueue(vasco);
            teams.Enqueue(fluminense);

            Round round1 = new Round(teams, 0);

            round1.SetWinner(flamengo);
            round1.SetWinner(vasco);

            var winnersRound1 = round1.GetWinners();

            Round round2 = new Round(winnersRound1, 1);
            round2.SetWinner(flamengo);
            var winnersRound2 = round2.GetWinners();

            Assert.IsTrue(winnersRound2.Count == 1);
            Assert.AreEqual(flamengo, winnersRound2.First());
        }
    }
}
