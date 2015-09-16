
Module Module1
    'To get your token and siteID, you go to Shopper Approved then advanced tools and sign up for their API.
    ' I am loading this to a json file so I am not hitting the API constantly. I simply have this run as a service(or task) then let my app read the json

    Sub Main()
        'Just grabbing the information and saving to a json file.

        CreateJson()
        Console.ReadKey()


    End Sub
    Private Sub CreateJson()
        ' I chose to go one month back each month.
        Try
            Dim dateStart As Date = DateAdd(DateInterval.Month, -1, Date.Now.Date)
            Dim dateEnd As Date = Date.Now.Date

            Dim dateStartString = dateStart.Year & "-" & dateStart.Month & "-" & dateStart.Day
            Dim dateEndString = dateEnd.Year & "-" & dateEnd.Month & "-" & dateEnd.Day
            Dim siteId As String = "<your site key>"
            Dim token As String = "<your token>"
            Dim shopperApproved As New List(Of ShopperApproved)
            Dim client = New Net.WebClient()

            Using (client)

                Dim json = client.DownloadString("https://www.shopperapproved.com/api/reviews/?siteid=" & siteId & "token=" & token & "&from &=" & dateStartString & "&to=" & dateEndString & "&sort=highest&page=0")

                Dim listofShopperApproved = Newtonsoft.Json.Linq.JObject.Parse(json).Children().OfType(Of Newtonsoft.Json.Linq.JProperty)().Select(Function(s) s.Value.ToObject(Of ShopperApproved)()).ToList()

                'I chose to ignore anything without a comment. The Shopper approved api does not have this option, nor the option to select only full reviews.
                For Each item In listofShopperApproved
                    If Not String.IsNullOrEmpty(item.TextComments) Then

                        shopperApproved.Add(item)
                    End If
                Next

            End Using



            Dim o As Newtonsoft.Json.Linq.JArray = DirectCast(Newtonsoft.Json.Linq.JArray.FromObject(shopperApproved), Newtonsoft.Json.Linq.JArray)

            IO.File.WriteAllText("C:\reviews.json", o.ToString())

        Catch ex As Exception
            Throw New Exception
            Exit Sub

        End Try

    End Sub

End Module
