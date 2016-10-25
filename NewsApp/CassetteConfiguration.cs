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
            layoutScripts.Add("Scripts/modernizr-2.6.2.js");
            layoutScripts.Add("Scripts/jquery-1.10.2.js");
            layoutScripts.Add("Scripts/bootstrap.js");
            layoutScripts.Add("Scripts/angular.min.js");
            bundles.Add<ScriptBundle>("LayoutScripts", layoutScripts);
            bundles.Add<ScriptBundle>("Scripts/news");
            bundles.Add<StylesheetBundle>("LayoutStyles", new List<string>() {"Content/bootstrap.css", "Content/Site.css"});
            bundles.Add<StylesheetBundle>("IndexStyles", new List<string>() {"Content/index.css"});
        }
    }
}