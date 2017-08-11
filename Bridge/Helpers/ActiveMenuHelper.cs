using System;
using System.Web.Mvc;

namespace Bridge.Helpers
{
    public static class ActiveMenuHelper
    {
        public static MvcHtmlString MenuLink(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, string areaName)
        {
            var currentAction = htmlHelper.ViewContext.RouteData.GetRequiredString("action");
            var currentController = htmlHelper.ViewContext.RouteData.GetRequiredString("controller");
            var currentArea = htmlHelper.ViewContext.RouteData.DataTokens["area"];

            var builder = new TagBuilder("li")
            {
                InnerHtml = "<a href=\"" + new UrlHelper(htmlHelper.ViewContext.RequestContext).Action(actionName, controllerName, new { area = areaName }).ToString() + "\">" + linkText + "</a>"
            };

            if (String.Equals(controllerName, currentController, StringComparison.CurrentCultureIgnoreCase) && String.Equals(actionName, currentAction, StringComparison.CurrentCultureIgnoreCase))
                builder.AddCssClass("active");
            //builder.AddCssClass("btn");

            return new MvcHtmlString(builder.ToString());
        }
    }
}