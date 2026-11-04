

using Microsoft.AspNetCore.Http;

namespace Group1Blackboard.Models
{
    public class CoursePlanSession
    {
        private const string PlanKey = "coursePlan";

        private readonly ISession session;
        private readonly CoursePlanCookie cookie;

        public CoursePlanSession(HttpContext context)
        {
            session = context.Session;
            cookie = new CoursePlanCookie(context);
        }

        public CoursePlan GetPlan()
        {
            CoursePlan? plan =
                session.GetObject<CoursePlan>(PlanKey);

            if (plan == null)
            {
                plan = cookie.GetPlan();
                session.SetObject(PlanKey, plan);
            }

            return plan;
        }

        public void SetPlan(CoursePlan plan)
        {
            session.SetObject(PlanKey, plan);
            cookie.SetPlan(plan);
        }

        public void ClearPlan()
        {
            session.Remove(PlanKey);
            cookie.ClearPlan();
        }

        public int GetCount()
        {
            return GetPlan().Count;
        }
    }
}
