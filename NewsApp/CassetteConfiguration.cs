using System.Collections.Generic;
using Cassette;
using Cassette.Scripts;
using Cassette.Stylesheets;

namespace NewsApp
{
    /// <summary>
    /// Configures the Cassette asset bundles for the web application.
    /// </summary>
    public class CassetteBundleConfiguration : IConfiguration<BundleCollection>
    {
        public void Configure(BundleCollection bundles)
        {
            List<string> layoutScripts = new List<string>();
            layoutScripts.Add("scripts/modernizr-2.6.2.js");
            layoutScripts.Add("scripts/jquery/dist/jquery.js");
            layoutScripts.Add("scripts/bootstrap/dist/js/bootstrap.js");
            layoutScripts.Add("bowerscripts_components/angular/angular.js");
            bundles.Add<ScriptBundle>("LayoutScripts", layoutScripts);
            bundles.Add<ScriptBundle>("Scripts/news");
            List<string> angularTools = new List<string>();
            angularTools.Add("scripts/angular-animate/angular-animate.js");
            angularTools.Add("scripts/angular-sanitize/angular-sanitize.js");
            angularTools.Add("scripts/angular-cookies/angular-cookies.js");
            angularTools.Add("scripts/angular-bootstrap/ui-bootstrap-tpls.js");
            bundles.Add<ScriptBundle>("AngularTools", angularTools);
            bundles.Add<StylesheetBundle>("LayoutStyles", new List<string>() { "scripts/bootstrap/dist/css/bootstrap.css", "Content/Site.css"});
            bundles.Add<StylesheetBundle>("IndexStyles", new List<string>() {"Content/index.css"});
        }
    }
}