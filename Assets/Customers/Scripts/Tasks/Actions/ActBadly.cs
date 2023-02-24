using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.Actions
{
    public class ActBadly : ActionTask<BadCustomer>
    {
        protected override string OnInit()
        {
            return null;
        }

        protected override void OnExecute()
        {
            agent.ActBadly();
            EndAction(true);
        }
    }
}