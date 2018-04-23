Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
#Region "#usingresources"
Imports System.Collections
#End Region ' #usingresources

#Region "#customresources"
<Serializable> _
Public Class CustomResource
	Private resourceID_Renamed As Object
	Private name_Renamed As String

	Public Sub New()
	End Sub

	Public Sub New(ByVal ID As Object, ByVal nameValue As String)
		Me.resourceID_Renamed = ID
		Me.name_Renamed = nameValue
	End Sub


	Public Property Name() As String
		Get
			Return name_Renamed
		End Get
		Set(ByVal value As String)
			name_Renamed = value
		End Set
	End Property
	Public Property ResourceID() As Object
		Get
			Return resourceID_Renamed
		End Get
		Set(ByVal value As Object)
			resourceID_Renamed = value
		End Set
	End Property
End Class

<Serializable> _
Public Class CustomResourceList
	Inherits List(Of CustomResource)
End Class

Public Class CustomResourceDataSource
	Private events As CustomResourceList
	Public Sub New(ByVal events As CustomResourceList)
		If events Is Nothing Then
			DevExpress.XtraScheduler.Native.Exceptions.ThrowArgumentNullException("resources")
		End If
		Me.events = events
	End Sub
	Public Sub New()
		Me.New(New CustomResourceList())
	End Sub
	Public Property Resources() As CustomResourceList
		Get
			Return events
		End Get
		Set(ByVal value As CustomResourceList)
			events = value
		End Set
	End Property
	Public ReadOnly Property Count() As Integer
		Get
			Return Resources.Count
		End Get
	End Property

	Public Function SelectMethodHandler() As IEnumerable
		Dim result As New CustomResourceList()
		result.AddRange(Resources)
		Return result
	End Function
End Class
#End Region ' #customresources