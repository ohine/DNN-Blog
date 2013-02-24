'
' DotNetNuke� - http://www.dotnetnuke.com
' Copyright (c) 2002-2012
' by DotNetNuke Corporation
'
' Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
' documentation files (the "Software"), to deal in the Software without restriction, including without limitation 
' the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and 
' to permit persons to whom the Software is furnished to do so, subject to the following conditions:
'
' The above copyright notice and this permission notice shall be included in all copies or substantial portions 
' of the Software.
'
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
' DEALINGS IN THE SOFTWARE.
'

Imports DotNetNuke.Web.Client.ClientResourceManagement
Imports DotNetNuke.Entities.Modules
Imports DotNetNuke.Framework
Imports DotNetNuke.Modules.Blog.Security
Imports DotNetNuke.Services.Tokens

Namespace Common

 Public Class BlogContextBase
  Inherits PortalModuleBase

#Region " Public Properties "
  Public Property BlogId As Integer = -1
  Public Property ContentItemId As Integer = -1
  Public Property Blog As Entities.Blogs.BlogInfo = Nothing
  Public Property Entry As Entities.Entries.EntryInfo = Nothing
  Public Property BlogMapPath As String = ""
  Public Property EntryMapPath As String = ""
  Public Property OutputAdditionalFiles As Boolean

  Private _uiTimezone As TimeZoneInfo = Nothing
  Public ReadOnly Property UiTimeZone As TimeZoneInfo
   Get
    If _uiTimezone Is Nothing Then
     _uiTimezone = ModuleContext.PortalSettings.TimeZone
     If UserInfo.Profile.PreferredTimeZone IsNot Nothing Then
      _uiTimezone = UserInfo.Profile.PreferredTimeZone
     End If
    End If
    Return _uiTimezone
   End Get
  End Property

  Private _settings As ModuleSettings
  Public Shadows Property Settings() As ModuleSettings
   Get
    If _settings Is Nothing Then _settings = ModuleSettings.GetModuleSettings(ModuleId)
    Return _settings
   End Get
   Set(ByVal value As ModuleSettings)
    _settings = value
   End Set
  End Property

  Private _viewSettings As ViewSettings
  Public Property ViewSettings() As ViewSettings
   Get
    If _viewSettings Is Nothing Then _viewSettings = ViewSettings.GetViewSettings(TabModuleId)
    Return _viewSettings
   End Get
   Set(ByVal value As ViewSettings)
    _viewSettings = value
   End Set
  End Property

  Private _security As ContextSecurity
  Public Property Security() As ContextSecurity
   Get
    If _security Is Nothing Then _security = New ContextSecurity(ModuleId, TabId, Blog, UserInfo)
    Return _security
   End Get
   Set(ByVal value As ContextSecurity)
    _security = value
   End Set
  End Property
#End Region

 End Class

End Namespace