﻿using System.Web.Mvc;

namespace Administrator.Areas.Super
{
    public class SuperAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Super";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            #region Inician las rutas generales

            context.MapRoute(
                "panel_super",
                "super/panel",
                new { Controller = "Panel", action = "Index" },
                namespaces: new[] { "Administrator.Areas.Super.Controllers" }
            );

            context.MapRoute(
                "usuarios_super",
                "super/usuarios",
                new { Controller = "Users", action = "Index" },
                namespaces: new[] { "Administrator.Areas.Super.Controllers" }
            );

            context.MapRoute(
                "crearusuarios_super",
                "super/usuarios/crear",
                new { Controller = "Users", action = "CreateUsers" },
                namespaces: new[] { "Administrator.Areas.Super.Controllers" }
            );

            context.MapRoute(
                "editusuarios_super",
                "super/usuarios/edit/{Id}",
                new { Controller = "Users", action = "UpdateUsers", Id = UrlParameter.Optional },
                namespaces: new[] { "Administrator.Areas.Super.Controllers" }
            );

            context.MapRoute(
                "deleteusuarios_super",
                "super/usuarios/delete/{Id}",
                new { Controller = "Users", action = "DeleteUsers", Id = UrlParameter.Optional },
                namespaces: new[] { "Administrator.Areas.Super.Controllers" }
            );

            #endregion

            #region Inician las ViewPartial

            context.MapRoute(
                "header_super",
                "headersuper",
                new { Controller = "Shared", action = "SharedHeader" },
                namespaces: new[] { "Administrator.Areas.Super.Controllers" }
            );

            #endregion
        }
    }
}