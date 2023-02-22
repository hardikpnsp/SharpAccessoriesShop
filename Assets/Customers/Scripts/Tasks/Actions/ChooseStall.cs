using NodeCanvas.Framework;
using UnityEngine;
using ParadoxNotion.Design;

namespace CustomersActions
{
    public class ChooseStall : ActionTask<GoodCustomer>
    {
        [RequiredField] public BBParameter<Transform> Target;

        protected override string OnInit()
        {
            return null;
        }

        protected override void OnExecute()
        {
            Transform target = agent.ChooseStall();
            Target.value = target;
            EndAction(target != null);
        }
    }
}