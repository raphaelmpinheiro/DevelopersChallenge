using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TournamentManager.Mvc.Domain.Entity;

namespace TournamentManager.Test
{
    [TestClass]
    public class FlightTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FightCanNotHaveTwoWinnersTest()
        {
            var flamengo = new Team("Flamengo");
            var vasco = new Team("Vasco");
            var fight = new Fight(flamengo, vasco);
            fight.SetWinner(flamengo);
            fight.SetWinner(flamengo);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetTeamWinnerNullTest()
        {
            var flamengo = new Team("Flamengo");
            var fight = new Fight(flamengo, null);
            fight.SetWinner(null);
        }
    }
}
