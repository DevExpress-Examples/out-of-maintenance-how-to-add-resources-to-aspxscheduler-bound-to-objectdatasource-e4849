#region #usinghelper
using DevExpress.Web.ASPxScheduler;
using DevExpress.XtraScheduler;
#endregion #usinghelper
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

#region #fillresources
public class ResourceHelper
{
    public static string[] Users = new string[] { "Sarah Brighton", "Ryan Fischer", "Andrew Miller" };
    public static string[] Usernames = new string[] { "sbrighton", "rfischer", "amiller" };

    public static void FillObjectDataSourceWithResources(CustomResourceList list, int count)
    {
            for (int i = 1; i <= count; i++)
            {
                list.Add(new CustomResource(Usernames[i-1], Users[i - 1]));
            }
    }
}
#endregion #fillresources