using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace CustomersActions
{
    public class SetRandomIdleTime : ActionTask
    {
        [RequiredField] public BBParameter<float> MinIdleTime;
        [RequiredField] public BBParameter<float> MaxIdleTime;
        public BBParameter<float> IdleTime;

        protected override string OnInit()
        {
            return null;
        }

        protected override void OnExecute()
        {
            IdleTime.value = Random.Range(MinIdleTime.value, MaxIdleTime.value);
            EndAction(true);
        }
    }
}