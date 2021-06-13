using System.Web;
using System.Web.Mvc;

namespace LectureWebPrgBackend.Attributes {

    public class AdminAccessNeeded : ActionFilterAttribute {

        public override void OnActionExecuting(ActionExecutingContext filterContext) {
            if (!HttpContext.Current.User.Identity.IsAuthenticated) {
                if (!HttpContext.Current.Response.IsRequestBeingRedirected) {
                    filterContext.HttpContext.Response.Redirect("/Admin/Login");
                }
            }
        }

    }

}