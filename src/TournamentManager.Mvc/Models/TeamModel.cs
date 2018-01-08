using TournamentManager.Mvc.Domain.Entity;

namespace TournamentManager.Mvc.Models
{
    public class TeamModel
    {
        public string Kingdom { get; set; }
        public long Id { get; set; }

        public static TeamModel Build(Team team)
        {
            var teamModel = new TeamModel();
            if (team != null)
            {
                teamModel.Kingdom = team.Kingdom;
                teamModel.Id = team.Id;
            }

            return teamModel;
        }

        public Team GetTeam()
        {
            return new Team(this.Kingdom)
            {
                Id = Id
            };
        }
    }
}
