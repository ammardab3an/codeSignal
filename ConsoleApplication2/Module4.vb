Module Module4
    Sub main()
        Dim input As New List(Of List(Of String))
        input.Add({"Salad", "Tomato", "Cucumber", "Salad", "Sauce"}.ToList)
        input.Add({"Pizza", "Tomato", "Sausage", "Sauce", "Dough"}.ToList)
        input.Add({"Quesadilla", "Chicken", "Cheese", "Sauce"}.ToList)
        input.Add({"Sandwich", "Salad", "Bread", "Tomato", "Cheese"}.ToList)
        groupingDishes(input)

    End Sub
   
    Function groupingDishes(dishes As List(Of List(Of String))) As List(Of List(Of String))

        Dim output As New List(Of List(Of String))

        Dim tmp As New List(Of String)
        For Each dish As list(Of String) In dishes
            For i As Integer = 1 To dish.Count - 1
                Dim ingredient As String = dish(i)

                Dim index As Integer = tmp.IndexOf(ingredient)
                If index <> -1 Then
                    output(index).Add(dish(0))
                Else
                    tmp.Add(ingredient)
                    output.Add(New List(Of String))
                    output(output.Count - 1).Add(ingredient)
                    output(output.Count - 1).Add(dish(0))
                End If

            Next
        Next

        Dim int As Integer = 0
        Do
            If int > output.Count - 1 Then Exit Do
            If output(int).Count < 3 Then
                output.RemoveAt(int)
            Else
                int += 1
            End If
        Loop

        output.Sort()
        For i As Integer = 0 To output.Count - 1
            output(i).Sort()
        Next

        Return output
    End Function

End Module
