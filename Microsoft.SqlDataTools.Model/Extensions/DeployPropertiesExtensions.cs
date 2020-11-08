using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Microsoft.SqlDataTools.Model
{

    public static class DeployPropertiesExtensions
    {
        public static IEnumerable<XElement> AsXElements(
            this DeploymentProperties deploymentProperties)
        {
            if (deploymentProperties == null)
                return Enumerable.Empty<XElement>();

            return XHelpers.
                PropertiesToProfileXElements(deploymentProperties);
        }

        public static IEnumerable<string> AsSqlCmdArgs(
            this DeploymentProperties deploymentProperties,
            bool preferShortForm = true)
        {
            if(deploymentProperties == null)
                return Enumerable.Empty<string>();

            return CmdHelpers.
                PropertiesToSqlCmdArgs(deploymentProperties);
        }
    }
}
