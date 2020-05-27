/*
* Copyright (c) Akveo 2019. All Rights Reserved.
* Licensed under the Single Application / Multi Application License.
* See LICENSE_SINGLE_APP / LICENSE_MULTI_APP in the ‘docs’ folder for license information on type of purchased license.
*/

using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Linq;

namespace AlDarb.WebApiCore.Setup
{
    public class CentralizedPrefixConvention : IApplicationModelConvention
    {
        private readonly AttributeRouteModel centralizedPrefix;

        public CentralizedPrefixConvention(IRouteTemplateProvider routeTemplateProvider)
        {
            centralizedPrefix = new AttributeRouteModel(routeTemplateProvider);
        }

        public void Apply(ApplicationModel app)
        {
            foreach (var controller in app.Controllers)
            {
                var matchedSelectors = controller.Selectors.Where(x => x.AttributeRouteModel != null).ToList();

                foreach (var selectorModel in matchedSelectors)
                {
                    selectorModel.AttributeRouteModel = AttributeRouteModel.CombineAttributeRouteModel(centralizedPrefix, selectorModel.AttributeRouteModel);
                }

                var unmatchedSelectors = controller.Selectors.Where(x => x.AttributeRouteModel == null).ToList();
                foreach (var selectorModel in unmatchedSelectors)
                {
                    selectorModel.AttributeRouteModel = centralizedPrefix;
                }
            }
        }
    }
}
