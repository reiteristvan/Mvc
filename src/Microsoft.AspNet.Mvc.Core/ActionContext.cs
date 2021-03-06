// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc.ModelBinding;
using Microsoft.AspNet.Routing;

namespace Microsoft.AspNet.Mvc
{
    public class ActionContext
    {
        public ActionContext([NotNull] ActionContext actionContext)
            : this(actionContext.HttpContext, actionContext.Router, actionContext.RouteValues, actionContext.ActionDescriptor)
        {
            ModelState = actionContext.ModelState;
            Controller = actionContext.Controller;
        }

        public ActionContext(HttpContext httpContext, IRouter router, IDictionary<string, object> routeValues, ActionDescriptor actionDescriptor)
        {
            HttpContext = httpContext;
            Router = router;
            RouteValues = routeValues;
            ActionDescriptor = actionDescriptor;
            ModelState = new ModelStateDictionary();
        }

        public HttpContext HttpContext { get; private set; }

        public IRouter Router { get; private set; }

        public IDictionary<string, object> RouteValues { get; private set; }

        public ModelStateDictionary ModelState { get; private set; }

        public ActionDescriptor ActionDescriptor { get; private set; }

        /// <summary>
        /// The controller is available only after the controller factory runs.
        /// </summary>
        public object Controller { get; set; }
    }
}
