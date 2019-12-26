Module Module7
    Sub main()
        Dim watch As Stopwatch = Stopwatch.StartNew()

        Dim test = feedingTime({{"Coati", "Ram"}.ToList, _
                                {"Chameleon", "Buffalo", "Coati"}.ToList, _
                                {"Elk", "Coyote", "Jerboa"}.ToList, _
                                {"Coyote", "Elk"}.ToList, _
                                {"Gorilla", "Chameleon"}.ToList, _
                                {"Fawn", "Alpaca", "Coyote"}.ToList}.ToList)
        Console.WriteLine(test)
        Threading.Thread.Sleep(500)
        watch.Stop()
        Console.WriteLine(watch.ElapsedMilliseconds)
    End Sub
    Function feedingTime(classes As List(Of List(Of String))) As Integer

        Dim days As New List(Of List(Of String))
        days.Add(classes(0))

        For cls As Integer = 1 To classes.Count - 1

            Dim done As Boolean = False
            For day As Integer = 0 To days.Count - 1

                Dim itIsPossible As Boolean = True
                For Each animal As String In classes(cls)
                    If days(day).Contains(animal) Then
                        itIsPossible = False
                        Exit For
                    End If
                Next

                If itIsPossible Then
                    days(day).AddRange(classes(cls))
                    done = True
                    Exit For
                End If

            Next

            If Not done Then
                If days.Count = 5 Then Return -1
                days.Add(classes(cls))
            End If

        Next
        Return days.Count
    End Function
    'Function feedingTime(classes As List(Of List(Of String))) As Integer
    '    Dim sum As Integer = 1
    '    Dim test As New List(Of String)
    '    test.AddRange(classes(0))

    '    For i As Integer = 1 To classes.Count - 1
    '        For ii As Integer = 0 To classes(i).Count - 1
    '            If test.Contains(classes(i)(ii)) Then
    '                sum += 1
    '                Exit For
    '            End If
    '        Next
    '        test.AddRange(classes(i))
    '    Next
    '    Return sum
    'End Function

    'Function feedingTime(classes As List(Of List(Of String))) As Integer
    '    Dim test As New List(Of List(Of String))
    '    test.Add(classes(0))


    '    For l As Integer = 1 To classes.Count - 1
    '        For Each Str As String In classes(l)

    '            Dim i As Integer = 0
    '            Do
    '                If Not test(i).Contains(Str) Then
    '                    test(i).Add(Str)
    '                    Exit Do
    '                ElseIf i = test.Count - 1 Then
    '                    If test.Count = 5 Then Return -1
    '                    test.Add(New List(Of String))
    '                    test(test.Count - 1).Add(Str)
    '                    Exit Do
    '                End If
    '                i += 1
    '            Loop

    '        Next
    '    Next

    '    Return test.Count
    'End Function


    'Dim test = singlePointOfFailure({{0, 1, 1, 1, 0, 0}.ToList, _
    '                       {1, 0, 1, 0, 0, 0}.ToList, _
    '                       {1, 1, 0, 0, 0, 0}.ToList, _
    '                       {1, 0, 0, 0, 1, 1}.ToList, _
    '                       {0, 0, 0, 1, 0, 0}.ToList, _
    '                       {0, 0, 0, 1, 0, 0}.ToList}.ToList)
    'the idea is to delete a link between x,y then check if (x) still can reach to (y) if not then it is a bad link
    'and i ceated a matrix: "matrix" so i don't have to check each link twice
    Function singlePointOfFailure(con As List(Of List(Of Integer))) As Integer
        Dim sum As Integer = 0
        Dim len As Integer = con.Count - 1
        Dim matrix(len, len) As Boolean
        For x As Integer = 0 To len
            For y As Integer = 0 To len
                If con(x)(y) = 1 AndAlso Not matrix(x, y) Then
                    con(x)(y) = 0
                    con(y)(x) = 0
                    Dim last(len) As Boolean
                    If Not tryToReach(con, x, y, last) Then sum += 1
                    con(x)(y) = 1
                    con(y)(x) = 1
                    matrix(y, x) = True
                End If
            Next
        Next
        Return sum
    End Function

    Function tryToReach(con As List(Of List(Of Integer)), f As Integer, t As Integer, last() As Boolean) As Boolean
        If con(f)(t) = 1 Then Return True
        last(f) = True
        For i As Integer = 0 To con(f).Count - 1
            If con(f)(i) = 1 AndAlso Not last(i) Then
                If tryToReach(con, i, t, last) Then Return True
            End If
        Next
    End Function

    'Dim a As New List(Of List(Of Integer))
    'a = {{2}.ToList, {0, 2}.ToList, New List(Of Integer), {4, 2}.ToList, {2, 3}.ToList}.ToList
    'Dim b = hasDeadlock(a)
    Function hasDeadlock(c As List(Of List(Of Integer))) As Boolean
        Dim nodeCount As Integer = c.Count
        'refn is a table which should contain informations about all then connections
        'at first all the connections are false
        'then we add each one of them true
        Dim refn(nodeCount - 1, nodeCount - 1) As Boolean

        For i As Integer = 0 To nodeCount - 1
            For k As Integer = 0 To c(i).Count - 1
                Dim j As Integer = c(i)(k)
                'there is link from i to j so if there is a link back from j to i then return true
                If refn(j, i) Then Return True
                refn(i, j) = True
                'and there is where is the magic happens
                For x As Integer = 0 To nodeCount - 1
                    refn(x, j) = refn(x, j) OrElse refn(x, i)
                    If refn(j, x) AndAlso refn(x, i) Then Return True
                Next
                ''''''
            Next
        Next

        Return False
    End Function
    'Function hasDeadlock(connections As List(Of List(Of Integer))) As Boolean

    '    For i As Integer = 0 To connections.Count - 1
    '        For Each con As Integer In connections(i)
    '            If con < i Then
    '                If tryToReach(connections, con, i) Then Return True
    '            End If
    '        Next
    '    Next

    'End Function

    'Function tryToReach(connections As List(Of List(Of Integer)), f As Integer, t As Integer) As Boolean
    '    If connections(f).Contains(t) Then Return True
    '    For Each i As Integer In connections(f)
    '        If tryToReach(connections, i, t) Then Return True
    '    Next
    'End Function
End Module
