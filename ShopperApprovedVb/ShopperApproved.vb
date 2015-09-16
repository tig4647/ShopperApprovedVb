Imports Newtonsoft.Json
Public Class ShopperApproved
    <JsonProperty("name")>
    Property Name As String
    <JsonProperty("location")>
    Property Location As String
    <JsonProperty("displaydate")>
    Property DisplayDate As String
    <JsonProperty("textcomments")>
    Property TextComments As String
    <JsonProperty("Overall")>
    Property Overall As String
    <JsonProperty("fullurl")>
    Property FullUrl As String
    <JsonProperty("Video")>
    Property Video As String
    <JsonProperty("orderid")>
    Property OrderId As String
    <JsonProperty("cancelled")>
    Property Cancelled As String
    <JsonProperty("Recommend")>
    Property Recommend As String
    <JsonProperty("Rebuy")>
    Property Rebuy As String
    <JsonProperty("Price")>
    Property Price As String
    <JsonProperty("Product")>
    Property Product As String
    <JsonProperty("Delivery")>
    Property Delivery As String
    <JsonProperty("CustomerService")>
    Property CustomerService As String
    <JsonProperty("private")>
    Property IsPrivate As String
    <JsonProperty("public")>
    Property IsPublic As String

End Class
