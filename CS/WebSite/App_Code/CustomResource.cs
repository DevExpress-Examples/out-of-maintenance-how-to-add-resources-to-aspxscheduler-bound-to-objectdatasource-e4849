using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
#region #usingresources
using System.Collections;
#endregion #usingresources

#region #customresources
[Serializable]
public class CustomResource
{
    object resourceID;
    string name;

    public CustomResource()
    {
    }

    public CustomResource(object ID, string nameValue)
    {
        this.resourceID = ID;
        this.name = nameValue;
    }


    public string Name { get { return name; } set { name = value; } }
    public object ResourceID { get { return resourceID; } set { resourceID = value; } }
}

[Serializable]
public class CustomResourceList : List<CustomResource>
{
}

public class CustomResourceDataSource
{
    CustomResourceList events;
    public CustomResourceDataSource(CustomResourceList events)
    {
        if (events == null)
            DevExpress.XtraScheduler.Native.Exceptions.ThrowArgumentNullException("resources");
        this.events = events;
    }
    public CustomResourceDataSource()
        : this(new CustomResourceList())
    {
    }
    public CustomResourceList Resources { get { return events; } set { events = value; } }
    public int Count { get { return Resources.Count; } }

    public IEnumerable SelectMethodHandler()
    {
        CustomResourceList result = new CustomResourceList();
        result.AddRange(Resources);
        return result;
    }
}
#endregion #customresources