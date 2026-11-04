
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Group1Blackboard.Models
{
    public class CoursePlanCookie
    {
        private const string CookieKey = "coursePlan";

        private readonly IRequestCookieCollection requestCookies;
        private readonly IResponseCookies responseCookies;

        public CoursePlanCookie(HttpRequest request, HttpResponse response)
        {
            requestCookies = request.Cookies;
            responseCookies = response.Cookies;
        }

        public CoursePlanCookie(HttpContext context)
            : this(context.Request, context.Response)
        {
        }

        public CoursePlan GetPlan()
        {
            var plan = new CoursePlan();

            if (requestCookies.TryGetValue(CookieKey, out string? value)
                && !string.IsNullOrEmpty(value))
            {
                foreach (string item in value.Split(','))
                {
                    if (int.TryParse(item, out int courseID))
                    {
                        plan.Add(courseID);
                    }
                }
            }

            return plan;
        }

        public void SetPlan(CoursePlan plan)
        {
            string value = string.Join(",", plan.CourseIDs);

            responseCookies.Append(CookieKey, value, new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddDays(14),
                HttpOnly = true,
                IsEssential = true,
                SameSite = SameSiteMode.Lax,
                Secure = true
            });
        }

        public void ClearPlan()
        {
            responseCookies.Delete(CookieKey);
        }
    }
}
