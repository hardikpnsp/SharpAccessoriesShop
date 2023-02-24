using NodeCanvas.Framework;
using UnityEngine;
using ParadoxNotion.Design;

namespace CustomersActions
{
    public class ChooseStand : ActionTask<Customer>
    {
        public BBParameter<Transform> Target;

        protected override string OnInit()
        {
            return null;
        }

        protected override void OnExecute()
        {
            Transform target = agent.ChooseStand();
            Target.value = target;
            EndAction(target != null);
        }
    }
}