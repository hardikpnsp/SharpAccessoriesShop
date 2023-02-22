using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace CustomersActions
{
    public class MoveTowardsTarget : ActionTask<Customer>
    {
        [RequiredField] public BBParameter<Transform> Target;

        protected override string OnInit()
        {
            return null;
        }

        protected override void OnExecute()
        {
            agent.MoveTowards(Target.value);
            EndAction(true);
        }
    }
}