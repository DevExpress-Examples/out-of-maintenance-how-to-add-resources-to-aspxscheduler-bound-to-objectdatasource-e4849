using DevExpress.Web.ASPxScheduler;
using DevExpress.XtraScheduler;
using System;
using System.Web.UI.WebControls;

public partial class Default : System.Web.UI.Page
{
    #region #setappointment
    CustomEventDataSource objectEventInstance;
  
// Obtain ID of the last inserted appointment from the object data source and assign it to the appointment in the ASPxScheduler storage
    protected void ASPxScheduler1_AppointmentRowInserted(object sender, DevExpress.Web.ASPxScheduler.ASPxSchedulerDataInsertedEventArgs e) {
        e.KeyFieldValue = this.objectEventInstance.ObtainLastInsertedId();
    }

    protected void appointmentsDataSource_ObjectCreated(object sender, ObjectDataSourceEventArgs e) {
        this.objectEventInstance = new CustomEventDataSource(GetCustomEvents());
        e.ObjectInstance = this.objectEventInstance;
    }

    CustomEventList GetCustomEvents()
    {
        CustomEventList events = Session["CustomEventListData"] as CustomEventList;
        if (events == null)
        {
            events = new CustomEventList();
            Session["CustomEventListData"] = events;
        }
        return events;
    }
    
    #endregion #setappointment

    #region #setresources
    CustomResourceDataSource objectResourceInstance;
    protected void resourceDataSource_ObjectCreated(object sender, ObjectDataSourceEventArgs e)
    {
        this.objectResourceInstance = new CustomResourceDataSource(GetCustomResources());
        e.ObjectInstance = this.objectResourceInstance;

    }

    CustomResourceList GetCustomResources()
    {
        CustomResourceList resources = Session["CustomResourceListData"] as CustomResourceList;
        if (resources == null)
        {
            resources = new CustomResourceList();
            ResourceHelper.FillObjectDataSourceWithResources(resources, 3);
            Session["CustomResourceListData"] = resources;
        }
        return resources;
    }
   #endregion #setresources 
    
}
