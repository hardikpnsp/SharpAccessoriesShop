using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace CustomersActions
{
    public class Leave : ActionTask<Customer>
    {
        [RequiredField] public BBParameter<bool> Happy;

        protected override string OnInit()
        {
            return null;
        }

        protected override void OnExecute()
        {
            agent.Leave(Happy.value);
        }
    }
}