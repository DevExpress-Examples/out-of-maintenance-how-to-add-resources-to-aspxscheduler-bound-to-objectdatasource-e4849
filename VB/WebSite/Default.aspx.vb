Imports Microsoft.VisualBasic
Imports DevExpress.Web.ASPxScheduler
Imports DevExpress.XtraScheduler
Imports System
Imports System.Web.UI.WebControls

Partial Public Class [Default]
	Inherits System.Web.UI.Page
	#Region "#setappointment"
	Private objectEventInstance As CustomEventDataSource

' Obtain ID of the last inserted appointment from the object data source and assign it to the appointment in the ASPxScheduler storage
	Protected Sub ASPxScheduler1_AppointmentRowInserted(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxScheduler.ASPxSchedulerDataInsertedEventArgs)
		e.KeyFieldValue = Me.objectEventInstance.ObtainLastInsertedId()
	End Sub

	Protected Sub appointmentsDataSource_ObjectCreated(ByVal sender As Object, ByVal e As ObjectDataSourceEventArgs)
		Me.objectEventInstance = New CustomEventDataSource(GetCustomEvents())
		e.ObjectInstance = Me.objectEventInstance
	End Sub

	Private Function GetCustomEvents() As CustomEventList
		Dim events As CustomEventList = TryCast(Session("CustomEventListData"), CustomEventList)
		If events Is Nothing Then
			events = New CustomEventList()
			Session("CustomEventListData") = events
		End If
		Return events
	End Function

	#End Region ' #setappointment

	#Region "#setresources"
	Private objectResourceInstance As CustomResourceDataSource
	Protected Sub resourceDataSource_ObjectCreated(ByVal sender As Object, ByVal e As ObjectDataSourceEventArgs)
		Me.objectResourceInstance = New CustomResourceDataSource(GetCustomResources())
		e.ObjectInstance = Me.objectResourceInstance

	End Sub

	Private Function GetCustomResources() As CustomResourceList
		Dim resources As CustomResourceList = TryCast(Session("CustomResourceListData"), CustomResourceList)
		If resources Is Nothing Then
			resources = New CustomResourceList()
			ResourceHelper.FillObjectDataSourceWithResources(resources, 3)
			Session("CustomResourceListData") = resources
		End If
		Return resources
	End Function
   #End Region ' #setresources 

End Class
