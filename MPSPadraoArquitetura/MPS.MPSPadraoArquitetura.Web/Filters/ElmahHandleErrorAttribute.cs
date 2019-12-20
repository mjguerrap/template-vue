using Elmah;
using System;
using System.Web.Mvc;

namespace MPS.MPSPadraoArquitetura.Web.Filters
{
    [AttributeUsage(AttributeTargets.All)]
public class ElmahHandleErrorAttribute : HandleErrorAttribute
{
	public override void OnException(ExceptionContext filterContext)
	{
		if (filterContext != null)
		{
			var exceptionHandled = filterContext.ExceptionHandled;

			base.OnException(filterContext);

			// signal ELMAH to log the exception
			if (!exceptionHandled && filterContext.ExceptionHandled)
			{
				ErrorSignal.FromCurrentContext().Raise(filterContext.Exception);
			}
		}
	}
}
}