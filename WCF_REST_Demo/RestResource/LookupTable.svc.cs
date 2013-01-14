using System.Collections.Generic;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace RestResource
{
  [ServiceContract]
  [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
  public class LookupTable
  {

    static readonly Dictionary<string, int> StoredValues = new Dictionary<string, int>();

    [WebInvoke(Method = "POST", UriTemplate = "{name}")]
    [OperationContract]
    public void CreateStoredValue(string name, int value)
    {
      int retval;
      if (!StoredValues.TryGetValue(name, out retval))
      {
        StoredValues[name] = value;
        return;
      }
      var error = string.Format("Value named {0} already exists. Can not create new value with the same name. Did you mean to use POST?", name);
      throw new WebFaultException<string>(error, HttpStatusCode.Conflict);
    }

    [WebGet(UriTemplate = "{name}")]
    [OperationContract]
    public int GetStoredValue(string name)
    {
      int retval;
      if (StoredValues.TryGetValue(name, out retval))
      {
        return retval;
      }

      var error = string.Format("Value named {0} could not be found.", name);
      throw new WebFaultException<string>(error, HttpStatusCode.NotFound);
    }

    [WebInvoke(Method = "PUT", UriTemplate = "{name}")]
    [OperationContract]
    public void UpdateStoredValue(string name, int value)
    {
      int retval;
      if (StoredValues.TryGetValue(name, out retval))
      {
        StoredValues[name] = value;
        return;
      }
      var error = string.Format("Value named {0} could not be found.", name);
      throw new WebFaultException<string>(error, HttpStatusCode.NotFound);
    }

    [WebInvoke(Method = "DELETE", UriTemplate = "{name}")]
    [OperationContract]
    public void DeleteStoredValue(string name)
    {
      int retval;
      if (StoredValues.TryGetValue(name, out retval))
      {
        StoredValues.Remove(name);
      }
    }
  }
}