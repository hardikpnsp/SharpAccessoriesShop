using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
    public class SetQueuePosition : ActionTask<GoodCustomer>
    {
        public BBParameter<Transform> QueuePosition;

        protected override string OnInit()
        {
            return null;
        }

        protected override void OnExecute()
        {
            QueuePosition.value = agent.GetQueuePosition();
            EndAction(true);
        }
    }
}