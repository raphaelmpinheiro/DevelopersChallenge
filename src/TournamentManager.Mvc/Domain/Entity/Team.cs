namespace TournamentManager.Mvc.Domain.Entity
{
    public class Team : EntityBase
    {
        public Team(string kingdom)
        {
            this.Kingdom = kingdom;
        }

        public string Kingdom { get; }

        protected bool Equals(Team other)
        {
            return string.Equals(Kingdom, other.Kingdom);
        }

        public override int GetHashCode()
        {
            return (Kingdom != null ? Kingdom.GetHashCode() : 0);
        }
    }
}
