Module Module333
    Sub main()
        Console.WriteLine("module333 is here")
        Dim input As New ListNode(Of Integer)
        input.value = 1
        Dim tmp As ListNode(Of Integer) = input
        For i As Integer = 2 To 11
            tmp.nxt = New ListNode(Of Integer)
            tmp.nxt.value = i
            tmp = tmp.nxt
        Next
        tmp.value = 11

        reverseNodesInKGroups(input, 3)
    End Sub
    Function reverseNodesInKGroups(l As ListNode(Of Integer), k As Integer) As ListNode(Of Integer)
        Dim current = l
        If l Is Nothing Then Return l
        For i As Integer = 0 To k - 1
            current = current.nxt
            If current Is Nothing Then Return l
        Next
        Dim head = l
        Dim prev = reverseNodesInKGroups(current.nxt, k)
        Dim nxt As ListNode(Of Integer) = Nothing
        For i As Integer = 0 To k - 1
            nxt = head.nxt
            head.nxt = prev
            prev = head
            head = nxt
        Next
        Return current
    End Function


    'Function reverseNodesInKGroups(l As ListNode(Of Integer), k As Integer) As ListNode(Of Integer)
    '    If l Is Nothing Then Return l
    '    If l.nxt Is Nothing Then Return l

    '    Dim test As New List(Of Integer)

    '    Dim tmp As ListNode(Of Integer) = l
    '    Do Until tmp.nxt Is Nothing
    '        test.Add(tmp.value)
    '        tmp = tmp.nxt
    '    Loop
    '    test.Add(tmp.value)

    '    Dim output As New ListNode(Of Integer)

    '    Dim err As Integer
    '    tmp = output
    '    For ii As Integer = 0 To CInt(test.Count / k)
    '        For i As Integer = k - 1 To 0 Step -1

    '            If (ii * k + (k - 1)) > test.Count - 1 Then
    '                If (ii * k + err) > test.Count - 1 Then Exit For
    '                tmp.nxt = New ListNode(Of Integer)
    '                tmp.nxt.value = test(ii * k + err)
    '                err += 1
    '            Else
    '                tmp.nxt = New ListNode(Of Integer)
    '                tmp.nxt.value = test(ii * k + i)
    '            End If

    '            tmp = tmp.nxt
    '        Next
    '    Next

    '    Return output.nxt
    'End Function

End Module
