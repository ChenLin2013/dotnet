using System;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace RestResource
{
  [ServiceContract(Namespace = "")]
  [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
  public class AjaxEnabled
  {
    [OperationContract]
    public string SayHello(string name)
    {
      return string.Format("Hello, {0}", name);
    }
  }
}
