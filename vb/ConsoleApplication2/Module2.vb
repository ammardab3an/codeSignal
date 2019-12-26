Module Module2

    Sub main()
        Console.WriteLine("module2 is here")
        squareDigitsSequence(103)
    End Sub


    Function squareDigitsSequence(a0 As Integer) As Integer
        Dim t As New List(Of Integer)
        t.Add(a0)

        While True
            Dim tmp = 0
            For Each x As Char In CStr(a0)
                tmp += Val(x) ^ 2
            Next
            a0 = tmp
            If t.Contains(a0) Then Exit While
            t.Add(a0)
        End While

        Return t.Count + 1
    End Function
    'Function squareDigitsSequence(a0 As Integer) As Integer
    '    Dim outputInt As Integer = 1
    '    Dim tmp As Integer = a0
    '    Do
    '        If tmp = a0 And outputInt <> 1 Then Return outputInt
    '        outputInt += 1
    '        Dim sum As Integer = 0
    '        For Each c As Char In CStr(tmp)
    '            sum += Val(c) ^ 2
    '        Next
    '        If tmp = sum Then Return outputInt
    '        tmp = sum
    '    Loop
    'End Function

    'Dim test As New List(Of Integer)
    '    test.AddRange({2, 1, 3, 5, 3, 2})
    '    firstDuplicate(test)
    '2, 1, 3, 5, 3, 2

    Function firstDuplicate(a As List(Of Integer)) As Integer
        Dim dict As New Dictionary(Of Integer, Integer)
        For i As Integer = 0 To a.Count - 1
            If dict.ContainsKey(a(i)) Then
                Return a(dict(a(i)))
            Else
                dict.Add(a(i), i)
            End If
        Next
        Return -1
    End Function


    'Function firstDuplicate(a As List(Of Integer)) As Integer
    '    Dim test As New List(Of Integer)

    '    For Each i As Integer In a
    '        If test.Contains(i) Then Return i
    '        test.Add(i)
    '    Next

    '    Return -1
    'End Function


    'Function firstDuplicate(a As List(Of Integer)) As Integer

    '    For i As Integer = 1 To a.Count - 1

    '        For ii As Integer = 0 To i - 1
    '            If a(ii) = a(i) Then Return a(i)
    '        Next

    '    Next

    '    Return -1
    'End Function


    'Function firstDuplicate(a As List(Of Integer)) As Integer

    '    Dim theReturn As Integer = -1
    '    Dim theReturnIndex As Integer = Integer.MaxValue

    '    Dim iloop As Integer = a.Count - 1

    '    Dim i As Integer = 0
    '    Do Until i > iloop - 1

    '        For ii As Integer = i + 1 To iloop
    '            If a(ii) = a(i) Then
    '                theReturn = a(i)
    '                theReturnIndex = ii
    '                iloop = ii - 1
    '                Exit For
    '            End If
    '        Next

    '        i += 1
    '    Loop

    '    Return theReturn

    'End Function


    '--------------------------------------------------------------------

    'Function firstDuplicate(b As List(Of Integer)) As Integer

    '    Dim lastIndex As Integer = Integer.MaxValue

    '    For i As Integer = 0 To b.Count - 1

    '        For ii As Integer = i + 1 To b.Count - 1
    '            If b(ii) = b(i) Then
    '                lastIndex = Math.Min(lastIndex, ii)

    '            End If
    '        Next

    '    Next


    '    Return lastIndex
    'End Function


End Module
