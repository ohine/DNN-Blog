Imports System
Imports System.Data
Imports System.IO
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Json
Imports System.Text
Imports System.Xml
Imports System.Xml.Schema
Imports System.Xml.Serialization

Imports DotNetNuke.Common.Utilities
Imports DotNetNuke.Entities.Modules
Imports DotNetNuke.Services.Tokens

Imports DotNetNuke.Modules.Blog.Common.Globals

Namespace Entities.Posts

 <Serializable(), XmlRoot("Post"), DataContract()>
 Partial Public Class PostInfo
  Implements IHydratable
  Implements IPropertyAccess
  Implements IXmlSerializable

#Region " IHydratable Implementation "
  ''' -----------------------------------------------------------------------------
  ''' <summary>
  ''' Fill hydrates the object from a Datareader
  ''' </summary>
  ''' <remarks>The Fill method is used by the CBO method to hydrtae the object
  ''' rather than using the more expensive Refection  methods.</remarks>
  ''' <history>
  ''' 	[pdonker]	02/19/2013  Created
  ''' </history>
  ''' -----------------------------------------------------------------------------
  Public Overrides Sub Fill(dr As IDataReader) Implements IHydratable.Fill
   FillInternal(dr)
   BlogID = Convert.ToInt32(Null.SetNull(dr.Item("BlogID"), BlogID))
   Title = Convert.ToString(Null.SetNull(dr.Item("Title"), Title))
   Summary = Convert.ToString(Null.SetNull(dr.Item("Summary"), Summary))
   Image = Convert.ToString(Null.SetNull(dr.Item("Image"), Image))
   Published = Convert.ToBoolean(Null.SetNull(dr.Item("Published"), Published))
   PublishedOnDate = CDate(Null.SetNull(dr.Item("PublishedOnDate"), PublishedOnDate))
   AllowComments = Convert.ToBoolean(Null.SetNull(dr.Item("AllowComments"), AllowComments))
   DisplayCopyright = Convert.ToBoolean(Null.SetNull(dr.Item("DisplayCopyright"), DisplayCopyright))
   Copyright = Convert.ToString(Null.SetNull(dr.Item("Copyright"), Copyright))
   Locale = Convert.ToString(Null.SetNull(dr.Item("Locale"), Locale))
   ViewCount = Convert.ToInt32(Null.SetNull(dr.Item("ViewCount"), ViewCount))
   Username = Convert.ToString(Null.SetNull(dr.Item("Username"), Username))
   Email = Convert.ToString(Null.SetNull(dr.Item("Email"), Email))
   DisplayName = Convert.ToString(Null.SetNull(dr.Item("DisplayName"), DisplayName))
   AltLocale = Convert.ToString(Null.SetNull(dr.Item("AltLocale"), AltLocale))
   AltTitle = Convert.ToString(Null.SetNull(dr.Item("AltTitle"), AltTitle))
   AltSummary = Convert.ToString(Null.SetNull(dr.Item("AltSummary"), AltSummary))
   AltContent = Convert.ToString(Null.SetNull(dr.Item("AltContent"), AltContent))
   NrComments = Convert.ToInt32(Null.SetNull(dr.Item("NrComments"), NrComments))
   PublishedOnDate = Date.SpecifyKind(PublishedOnDate, DateTimeKind.Utc)
  End Sub
  ''' -----------------------------------------------------------------------------
  ''' <summary>
  ''' Gets and sets the Key ID
  ''' </summary>
  ''' <remarks>The KeyID property is part of the IHydratble interface.  It is used
  ''' as the key property when creating a Dictionary</remarks>
  ''' <history>
  ''' 	[pdonker]	02/19/2013  Created
  ''' </history>
  ''' -----------------------------------------------------------------------------
  Public Overrides Property KeyID() As Integer Implements IHydratable.KeyID
   Get
    Return ContentItemId
   End Get
   Set(value As Integer)
    ContentItemId = value
   End Set
  End Property
#End Region

#Region " IPropertyAccess Implementation "
  Public Function GetProperty(strPropertyName As String, strFormat As String, formatProvider As System.Globalization.CultureInfo, AccessingUser As DotNetNuke.Entities.Users.UserInfo, AccessLevel As DotNetNuke.Services.Tokens.Scope, ByRef PropertyNotFound As Boolean) As String Implements DotNetNuke.Services.Tokens.IPropertyAccess.GetProperty
   Dim OutputFormat As String = String.Empty
   Dim portalSettings As DotNetNuke.Entities.Portals.PortalSettings = DotNetNuke.Entities.Portals.PortalController.GetCurrentPortalSettings()
   If strFormat = String.Empty Then
    OutputFormat = "D"
   Else
    OutputFormat = strFormat
   End If
   Select Case strPropertyName.ToLower
    Case "blogid"
     Return (Me.BlogID.ToString(OutputFormat, formatProvider))
    Case "title"
     Return PropertyAccess.FormatString(Me.Title, strFormat)
    Case "summary"
     Return Me.Summary.OutputHtml(strFormat)
    Case "image"
     Return PropertyAccess.FormatString(Me.Image, strFormat)
    Case "published"
     Return Me.Published.ToString
    Case "publishedyesno"
     Return PropertyAccess.Boolean2LocalizedYesNo(Me.Published, formatProvider)
    Case "publishedondate"
     Return UtcToLocalTime(PublishedOnDate).ToString(OutputFormat, formatProvider)
    Case "allowcomments"
     Return Me.AllowComments.ToString
    Case "allowcommentsyesno"
     Return PropertyAccess.Boolean2LocalizedYesNo(Me.AllowComments, formatProvider)
    Case "displaycopyright"
     Return Me.DisplayCopyright.ToString
    Case "displaycopyrightyesno"
     Return PropertyAccess.Boolean2LocalizedYesNo(Me.DisplayCopyright, formatProvider)
    Case "copyright"
     Return PropertyAccess.FormatString(Me.Copyright, strFormat)
    Case "locale"
     Return PropertyAccess.FormatString(Me.Locale, strFormat)
    Case "nrcomments"
     Return (Me.NrComments.ToString(OutputFormat, formatProvider))
    Case "viewcount"
     Return (Me.ViewCount.ToString(OutputFormat, formatProvider))
    Case "username"
     Return PropertyAccess.FormatString(Me.Username, strFormat)
    Case "email"
     Return PropertyAccess.FormatString(Me.Email, strFormat)
    Case "displayname"
     Return PropertyAccess.FormatString(Me.DisplayName, strFormat)
    Case "altlocale"
     Return PropertyAccess.FormatString(Me.AltLocale, strFormat)
    Case "alttitle"
     Return PropertyAccess.FormatString(Me.AltTitle, strFormat)
    Case "altsummary"
     Return PropertyAccess.FormatString(Me.AltSummary, strFormat)
    Case "altcontent"
     Return PropertyAccess.FormatString(Me.AltContent, strFormat)
    Case "localizedtitle"
     Return PropertyAccess.FormatString(Me.LocalizedTitle, strFormat)
    Case "localizedsummary"
     Return Me.LocalizedSummary.OutputHtml(strFormat)
    Case "localizedcontent"
     Return Me.LocalizedContent.OutputHtml(strFormat)
    Case "contentitemid"
     Return (Me.ContentItemId.ToString(OutputFormat, formatProvider))
    Case "createdbyuserid"
     Return (Me.CreatedByUserID.ToString(OutputFormat, formatProvider))
    Case "createdondate"
     Return (Me.CreatedOnDate.ToString(OutputFormat, formatProvider))
    Case "lastmodifiedbyuserid"
     Return (Me.LastModifiedByUserID.ToString(OutputFormat, formatProvider))
    Case "lastmodifiedondate"
     Return (Me.LastModifiedOnDate.ToString(OutputFormat, formatProvider))
    Case "content"
     Return Me.Content.OutputHtml(strFormat)
    Case "hasimage"
     Return CBool(Me.Image <> "").ToString(formatProvider)
    Case "link", "permalink"
     Return PermaLink(DotNetNuke.Entities.Portals.PortalSettings.Current)
    Case Else
     PropertyNotFound = True
   End Select

   Return Null.NullString
  End Function

  Public ReadOnly Property Cacheability() As DotNetNuke.Services.Tokens.CacheLevel Implements DotNetNuke.Services.Tokens.IPropertyAccess.Cacheability
   Get
    Return CacheLevel.fullyCacheable
   End Get
  End Property
#End Region

#Region " IXmlSerializable Implementation "
  ''' -----------------------------------------------------------------------------
  ''' <summary>
  ''' GetSchema returns the XmlSchema for this class
  ''' </summary>
  ''' <remarks>GetSchema is implemented as a stub method as it is not required</remarks>
  ''' <history>
  ''' 	[pdonker]	05/03/2013  Created
  ''' </history>
  ''' -----------------------------------------------------------------------------
  Public Function GetSchema() As XmlSchema Implements IXmlSerializable.GetSchema
   Return Nothing
  End Function

  ''' -----------------------------------------------------------------------------
  ''' <summary>
  ''' ReadXml fills the object (de-serializes it) from the XmlReader passed
  ''' </summary>
  ''' <remarks></remarks>
  ''' <param name="reader">The XmlReader that contains the xml for the object</param>
  ''' <history>
  ''' 	[pdonker]	05/03/2013  Created
  ''' </history>
  ''' -----------------------------------------------------------------------------
  Public Sub ReadXml(reader As XmlReader) Implements IXmlSerializable.ReadXml
   Try

    reader.ReadStartElement("Files") ' advance to files
    ImportedFiles = New List(Of BlogML.Xml.BlogMLAttachment)
    If reader.ReadToDescendant("File") Then ' advance to file
     Do
      Dim f As New BlogML.Xml.BlogMLAttachment
      f.Path = readElement(reader, "Path")
      Dim bufferSize As Integer = 1000
      Dim buffer(bufferSize) As Byte
      Dim readBytes As Integer = 0
      Do
       readBytes = reader.ReadElementContentAsBase64(buffer, 0, bufferSize)
      Loop While bufferSize <= readBytes
      f.Data = buffer
      ImportedFiles.Add(f)
     Loop While reader.ReadToNextSibling("File")
    End If

    ReadMultiLingualText(reader, "Title", Title, TitleLocalizations)
    ReadMultiLingualText(reader, "Summary", Summary, SummaryLocalizations)
    ReadMultiLingualText(reader, "Content", Content, ContentLocalizations)

    Title = readElement(reader, "Title")
    Summary = readElement(reader, "Summary")
    Content = readElement(reader, "Content")
    Image = readElement(reader, "Image")
    Boolean.TryParse(readElement(reader, "Published"), Published)
    Date.TryParse(readElement(reader, "PublishedOnDate"), PublishedOnDate)
    Boolean.TryParse(readElement(reader, "AllowComments"), AllowComments)
    Boolean.TryParse(readElement(reader, "DisplayCopyright"), DisplayCopyright)
    Copyright = readElement(reader, "Copyright")
    Locale = readElement(reader, "Locale")
    Username = readElement(reader, "Username")
    Email = readElement(reader, "Email")

   Catch ex As Exception
    ' log exception as DNN import routine does not do that
    DotNetNuke.Services.Exceptions.LogException(ex)
    ' re-raise exception to make sure import routine displays a visible error to the user
    Throw New Exception("An error occured during import of an Post", ex)
   End Try

  End Sub
  Friend Property ImportedFiles As List(Of BlogML.Xml.BlogMLAttachment)

  ''' -----------------------------------------------------------------------------
  ''' <summary>
  ''' WriteXml converts the object to Xml (serializes it) and writes it using the XmlWriter passed
  ''' </summary>
  ''' <remarks></remarks>
  ''' <param name="writer">The XmlWriter that contains the xml for the object</param>
  ''' <history>
  ''' 	[pdonker]	05/03/2013  Created
  ''' </history>
  ''' -----------------------------------------------------------------------------
  Public Sub WriteXml(writer As XmlWriter) Implements IXmlSerializable.WriteXml
   writer.WriteStartElement("Post")

   writer.WriteStartElement("Files")
   ' pack files
   Dim postDir As String = GetPostDirectoryMapPath(BlogID, ContentItemId)
   Dim newSummary As String = Summary
   Dim newSummaryLocalized As LocalizedText = SummaryLocalizations
   Dim newContent As String = Content
   Dim newContentLocalized As LocalizedText = ContentLocalizations
   If IO.Directory.Exists(postDir) Then
    For Each f As String In IO.Directory.GetFiles(postDir)
     Dim fileName As String = IO.Path.GetFileName(f)
     Dim regexPattern As String = "&quot;([^\s]*)\/" & fileName & "&quot;"
     Dim options As RegexOptions = RegexOptions.Singleline Or RegexOptions.IgnoreCase
     newSummary = Regex.Replace(newSummary, regexPattern, "&quot;" & fileName & "&quot;", options)
     For Each l As String In newSummaryLocalized.Locales
      If Not String.IsNullOrEmpty(newSummaryLocalized(l)) Then
       newSummaryLocalized(l) = Regex.Replace(newSummaryLocalized(l), regexPattern, "&quot;" & fileName & "&quot;", options)
      End If
     Next
     newContent = Regex.Replace(newContent, regexPattern, "&quot;" & fileName & "&quot;", options)
     For Each l As String In newContentLocalized.Locales
      If Not String.IsNullOrEmpty(newContentLocalized(l)) Then
       newContentLocalized(l) = Regex.Replace(newContentLocalized(l), regexPattern, "&quot;" & fileName & "&quot;", options)
      End If
     Next
     Dim att As New BlogML.Xml.BlogMLAttachment With {.Embedded = True, .Path = fileName}
     Using fs As New IO.FileStream(f, IO.FileMode.Open)
      Dim fileData(CInt(fs.Length - 1)) As Byte
      If fs.Length > 0 Then
       fs.Read(fileData, 0, CInt(fs.Length - 1))
       att.Data = fileData
      Else
       'Empty File
      End If
     End Using
     att.WriteAttachmentToXml(writer)
    Next
   End If
   writer.WriteEndElement() ' Files

   WriteMultiLingualText(writer, "Title", Title, TitleLocalizations)
   WriteMultiLingualText(writer, "Summary", newSummary, newSummaryLocalized)
   WriteMultiLingualText(writer, "Content", newContent, newContentLocalized)
   writer.WriteElementString("Image", Image)
   writer.WriteElementString("Published", Published.ToString())
   writer.WriteElementString("PublishedOnDate", PublishedOnDate.ToString())
   writer.WriteElementString("AllowComments", AllowComments.ToString())
   writer.WriteElementString("DisplayCopyright", DisplayCopyright.ToString())
   writer.WriteElementString("Copyright", Copyright)
   writer.WriteElementString("Locale", Locale)
   writer.WriteElementString("Username", Username)
   writer.WriteElementString("Email", Email)
   writer.WriteEndElement() ' Post
  End Sub
#End Region

#Region " ToXml Methods "
  Public Function ToXml() As String
   Return ToXml("Post")
  End Function

  Public Function ToXml(elementName As String) As String
   Dim xml As New StringBuilder
   xml.Append("<")
   xml.Append(elementName)
   AddAttribute(xml, "BlogID", BlogID.ToString())
   AddAttribute(xml, "Title", Title)
   AddAttribute(xml, "Summary", Summary)
   AddAttribute(xml, "Image", Image)
   AddAttribute(xml, "Published", Published.ToString())
   AddAttribute(xml, "PublishedOnDate", PublishedOnDate.ToUniversalTime.ToString("u"))
   AddAttribute(xml, "AllowComments", AllowComments.ToString())
   AddAttribute(xml, "DisplayCopyright", DisplayCopyright.ToString())
   AddAttribute(xml, "Copyright", Copyright)
   AddAttribute(xml, "Locale", Locale)
   AddAttribute(xml, "ViewCount", ViewCount.ToString())
   AddAttribute(xml, "Username", Username)
   AddAttribute(xml, "Email", Email)
   AddAttribute(xml, "DisplayName", DisplayName)
   xml.Append(" />")
   Return xml.ToString
  End Function

  Private Sub AddAttribute(ByRef xml As StringBuilder, attributeName As String, attributeValue As String)
   xml.Append(" " & attributeName)
   xml.Append("=""" & attributeValue & """")
  End Sub
#End Region

#Region " JSON Serialization "
  Public Sub WriteJSON(ByRef s As Stream)
   Dim ser As New DataContractJsonSerializer(GetType(PostInfo))
   ser.WriteObject(s, Me)
  End Sub
#End Region

 End Class
End Namespace


