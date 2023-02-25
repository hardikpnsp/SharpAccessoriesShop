using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace CustomersActions
{
    public class ReturnStandPosition : ActionTask<Customer>
    {
        [RequiredField] public BBParameter<Transform> standPosition;

        protected override string OnInit()
        {
            return null;
        }

        protected override void OnExecute()
        {
            agent.ReturnPosition(standPosition.value);
            EndAction(true);
        }
    }
}
