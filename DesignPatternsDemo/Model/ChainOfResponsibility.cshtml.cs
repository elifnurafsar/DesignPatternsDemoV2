using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;

namespace DesignPatternsDemo.Model
{
    public class ChainOfResponsibilityModel : PageModel
    {
        public class Creature
        {
            public string Name;
            public int Attack, Defense;

            public Creature(string name, int attack, int defense)
            {
                Name = name ?? throw new ArgumentNullException(paramName: nameof(name));
                Attack = attack;
                Defense = defense;
            }

            public override string ToString()
            {
                return $"{nameof(Name)}: {Name}, {nameof(Attack)}: {Attack}, {nameof(Defense)}: {Defense}";
            }
        }

        public class CreatureModifier
        {
            protected Creature creature;
            protected CreatureModifier next;

            public CreatureModifier(Creature creature)
            {
                this.creature = creature ?? throw new ArgumentNullException(paramName: nameof(creature));
            }

            public void Add(CreatureModifier cm)
            {
                if (next != null) next.Add(cm);
                else next = cm;
            }

            public virtual String Handle() => next?.Handle();
        }

        public class NoBonusesModifier : CreatureModifier
        {
            public NoBonusesModifier(Creature creature) : base(creature)
            {
            }

            public override String Handle()
            {
                // nothing
                return ("No bonuses for you!");
            }
        }

        public class DoubleAttackModifier : CreatureModifier
        {
            public DoubleAttackModifier(Creature creature) : base(creature)
            {
            }

            public override String Handle()
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(($"Doubling {creature.Name}'s attack"));
                creature.Attack *= 2;
                sb.AppendLine(base.Handle());
                return sb.ToString();
            }
        }

        public class IncreaseDefenseModifier : CreatureModifier
        {
            public IncreaseDefenseModifier(Creature creature) : base(creature)
            {
            }

            public override String Handle()
            {
                StringBuilder sb= new StringBuilder();
                sb.AppendLine("Increasing goblin's defense");
                creature.Defense += 3;
                sb.AppendLine(base.Handle());
                return sb.ToString();
            }
        }
    }
}
