Imports System
Imports DotNetNuke

Namespace Data

 Partial Public MustInherit Class DataProvider

  Public MustOverride Sub ApproveComment(commentId As Int32)
  Public MustOverride Sub DeleteBlogPermissions(blogId As Int32)
  Public MustOverride Function GetBlog(blogId As Int32, userId As Int32) As IDataReader
  Public MustOverride Function GetBlogPermissionsByBlog(blogId As Int32) As IDataReader
  Public MustOverride Function GetBlogsByModule(moduleId As Int32, userId As Int32) As IDataReader
  Public MustOverride Function GetPosts(moduleId As Int32, blogID As Int32, userId As Int32, userIsAdmin As Boolean, published As Int32, locale As String, endDate As Date, authorUserId As Int32, pageIndex As Int32, pageSize As Int32, orderBy As String) As IDataReader
  Public MustOverride Function GetPostsByTerm(moduleId As Int32, blogID As Int32, userId As Int32, userIsAdmin As Boolean, termID As Int32, published As Int32, locale As String, endDate As Date, authorUserId As Int32, pageIndex As Int32, pageSize As Int32, orderBy As String) As IDataReader
  Public MustOverride Function GetTerm(termId As Int32, moduleId As Int32) As IDataReader
  Public MustOverride Function GetTermsByPost(contentItemId As Int32, moduleId As Int32) As IDataReader
  Public MustOverride Function GetTermsByModule(moduleId As Int32) As IDataReader
  Public MustOverride Function GetTermsByVocabulary(moduleId As Int32, vocabularyId As Int32) As IDataReader
  Public MustOverride Function GetUserPermissionsByModule(moduleID As Int32, userId As Int32) As IDataReader
  Public MustOverride Function GetUsersByBlogPermission(portalId As Int32, blogId As Int32, permissionId As Int32) As IDataReader
  Public MustOverride Function SearchPosts(moduleId As Int32, blogID As Int32, userId As Int32, userIsAdmin As Boolean, searchText As String, searchTitle As Boolean, searchContents As Boolean, published As Int32, locale As String, endDate As Date, authorUserId As Int32, pageIndex As Int32, pageSize As Int32, orderBy As String) As IDataReader
  Public MustOverride Function SearchPostsByTerm(moduleId As Int32, blogID As Int32, userId As Int32, userIsAdmin As Boolean, termID As Int32, searchText As String, searchTitle As Boolean, searchContents As Boolean, published As Int32, locale As String, endDate As Date, authorUserId As Int32, pageIndex As Int32, pageSize As Int32, orderBy As String) As IDataReader

 End Class

End Namespace

