using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace CustomersConditions
{
    public class CanJoinQueue : ConditionTask<GoodCustomer>
    {
        protected override string OnInit()
        {
            return null;
        }

        protected override bool OnCheck()
        {
            return agent.CanJoinQueue;
        }
    }
}