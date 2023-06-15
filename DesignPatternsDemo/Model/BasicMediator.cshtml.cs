using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DesignPatternsDemo.Model
{
    /*
    A participant can Say()  a particular value, which is broadcast to all other participants. 
    At this point in time, every other participant is obliged to increase their Value  by the value being broadcast.

    Example:
        Two participants start with values 0 and 0 respectively
        Participant 1 broadcasts the value 3. We now have Participant 1 value = 0, Participant 2 value = 3
        Participant 2 broadcasts the value 2. We now have Participant 1 value = 2, Participant 2 value = 3
     */

    public class BasicMediatorModel : PageModel
    {
        public class Mediator
        {
            public event EventHandler<int> Alert;
            public void Broadcast(object sender, int n)
            {
                Alert?.Invoke(sender, n);
            }

        }

        public class Participant
        {

            public int Value { get; set; }
            private readonly Mediator mediator;

            public Participant(Mediator _mediator)
            {
                this.mediator = _mediator;
                mediator.Alert += MediatorAlert;
            }

            private void MediatorAlert(object sender, int e)
            {
                if (sender != this)
                    Value += e;
            }

            public void Say(int n)
            {
                mediator.Broadcast(this, n);
            }
        }

    }
}
