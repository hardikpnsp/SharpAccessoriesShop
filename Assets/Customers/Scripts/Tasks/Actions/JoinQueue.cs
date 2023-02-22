using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace CustomersActions
{
    public class JoinQueue : ActionTask<GoodCustomer>
    {
        protected override string OnInit()
        {
            return null;
        }

        protected override void OnExecute()
        {
            agent.JoinQueue();
            EndAction(true);
        }
    }
}