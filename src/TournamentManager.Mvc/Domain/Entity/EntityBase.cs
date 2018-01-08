using System;

namespace TournamentManager.Mvc.Domain.Entity
{
    [Serializable]
    public abstract class EntityBase
    {
        public long Id { get; set; }

        protected EntityBase()
        {
            Id = 0;
        }

        public virtual bool IsNew()
        {
            return Id == 0;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (obj.GetType() != GetType())
                return false;

            if (Id <= 0)
                return this == obj;

            var that = (EntityBase)obj;
            return Id == that.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

    }
}

