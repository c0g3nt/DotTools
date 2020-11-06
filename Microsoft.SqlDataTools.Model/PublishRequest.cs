using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Microsoft.SqlDataTools.Model
{
    public static class Preparation
    {

    }
    public struct ExecutionRequest
    {
        public ISqlPackageParameters SqlPackageParameters { get; set; }
        public string DacpacFilePath{ get; set; }
    }
    public class ExecutionResult
    {
        public ExecutionRequest Request { get; set; }

    }
}
