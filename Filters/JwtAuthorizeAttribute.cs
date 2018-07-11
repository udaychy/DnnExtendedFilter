using System;
using System.Linq;
using System.Web.Http.Controllers;
using DnnExtendedFilter.Filters.Common;
using DotNetNuke.Common;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Web.Api;

namespace DnnExtendedFilter.Filters
{
    public class JwtAuthorizeAttribute : AuthorizeAttributeBase, IOverrideDefaultAuthLevel
    {
        
        #region Properties

        private string _staticRoles;
        private string[] _staticRolesSplit = new string[0];

        public string StaticRoles
        {
            get { return _staticRoles; }
            set
            {
                _staticRoles = value;
                _staticRolesSplit = SplitString(_staticRoles);
            }
        }


        private string _denyRoles;
        private string[] _denyRolesSplit = new string[0];

        public string DenyRoles
        {
            get { return _denyRoles; }
            set
            {
                _denyRoles = value;
                _denyRolesSplit = SplitString(_denyRoles);
            }
        }

        #endregion

        #region Method Overriding

        public override bool IsAuthorized(AuthFilterContext context)
        {
            Requires.NotNull("context", context);

            if (!JwtAuthHelper.IsAuthenticated())
            {
                return false;
            }

            if (_denyRolesSplit.Any())
            {
                var currentUser = PortalController.Instance.GetCurrentPortalSettings().UserInfo;
                if (!currentUser.IsSuperUser && _denyRolesSplit.Any(currentUser.IsInRole))
                {
                    return false;
                }
            }

            if (_staticRolesSplit.Any())
            {
                var currentUser = PortalController.Instance.GetCurrentPortalSettings().UserInfo;
                if (!_staticRolesSplit.Any(currentUser.IsInRole))
                {
                    return false;
                }
            }

            return true;
        }

        protected override bool SkipAuthorization(HttpActionContext actionContext)
        {
            return !JwtAuthHelper.RequestContainJwtHeader(actionContext) || base.SkipAuthorization(actionContext);
        }

        #endregion

        #region Private Methods

        private static readonly string[] EmptyArray = new string[0];
        private static string[] SplitString(string original)
        {
            if (string.IsNullOrEmpty(original))
            {
                return EmptyArray;
            }

            var split = original.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.Trim()).Where(s => !string.IsNullOrEmpty(s));
            return split.ToArray();
        }

        #endregion
    }

}
