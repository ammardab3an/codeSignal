Public Class ListNode(Of T)
    Public value As T
    Public nxt As ListNode(Of T)
    Public Sub New()

    End Sub

    Public Sub New(x As T)
        MyBase.New()
        value = x
        nxt = Nothing
    End Sub
End Class

Module Module3
    Dim i As Integer

    Sub main()
        Console.WriteLine("module3 is here")
       
    End Sub

    Function rearrangeLastN(l As ListNode(Of Integer), n As Integer) As ListNode(Of Integer)
        Dim current = l
        If n = 0 Then Return l
        For i As Integer = 0 To n - 1
            If current Is Nothing Then Return l
            current = current.nxt
        Next
        If current Is Nothing Then Return l

        Dim head = l
        While Not current.nxt Is Nothing
            current = current.nxt
            head = head.nxt
        End While
        Dim result = head.nxt
        head.nxt = Nothing
        current.nxt = l
        Return result
    End Function



    Function mergeTwoLinkedLists(l1 As ListNode(Of Integer), l2 As ListNode(Of Integer)) As ListNode(Of Integer)
        If l1 Is Nothing AndAlso l2 Is Nothing Then Return Nothing
        If l1 Is Nothing Then Return l2
        If l2 Is Nothing Then Return l1
        If l1.value < l2.value Then
            l1.nxt = mergeTwoLinkedLists(l1.nxt, l2)
            Return l1
        Else
            l2.nxt = mergeTwoLinkedLists(l2.nxt, l1)
            Return l2
        End If
    End Function

    'Function mergeTwoLinkedLists(l1 As ListNode(Of Integer), l2 As ListNode(Of Integer)) As ListNode(Of Integer)

    '    If l1 Is Nothing AndAlso l2 Is Nothing Then Return Nothing
    '    If l1 Is Nothing Then Return l2
    '    If l2 Is Nothing Then Return l1

    '    Dim test As New List(Of Integer)

    '    Dim tmp As ListNode(Of Integer)

    '    tmp = l1
    '    Do Until tmp.nxt Is Nothing
    '        test.Add(tmp.value)
    '        tmp = tmp.nxt
    '    Loop
    '    test.Add(tmp.value)

    '    tmp = l2
    '    Do Until tmp.nxt Is Nothing
    '        test.Add(tmp.value)
    '        tmp = tmp.nxt
    '    Loop
    '    test.Add(tmp.value)

    '    test.Sort()

    '    Dim output As New ListNode(Of Integer)
    '    output.value = test(0)

    '    tmp = output
    '    For i As Integer = 1 To test.Count - 1
    '        tmp.nxt = New ListNode(Of Integer)
    '        tmp.nxt.value = test(i)
    '        tmp = tmp.nxt
    '    Next
    '    tmp.value = test(test.Count - 1)

    '    Return output
    'End Function


    Function isListPalindrome(l As ListNode(Of Integer)) As Boolean

        If l Is Nothing Then Return True
        If l.nxt Is Nothing Then Return True

        Dim after As New List(Of Integer)

        Dim node As New ListNode(Of Integer)
        node = l
        Do Until node.nxt Is Nothing
            after.Add(node.value)
            node = node.nxt
        Loop
        after.Add(node.value)

        Dim rev As New List(Of Integer)
        rev.AddRange(after)
        rev.Reverse()

        For i As Integer = 0 To after.Count - 1
            If rev(i) <> after(i) Then Return False
        Next

        Return True
    End Function

    'Function _isListPalindrome(l As ListNode(Of Integer)) As Boolean


    '    Dim tmp As ListNode(Of Integer) = l
    '    Dim tmp0 As ListNode(Of Integer) = Reverse(l)
    '    Do Until tmp.nxt Is Nothing
    '        If tmp.value <> tmp0.value Then Return False
    '        tmp = tmp.nxt
    '        tmp0 = tmp0.nxt
    '    Loop
    '    If tmp.value <> tmp0.value Then Return False
    '    Return True
    'End Function

    Sub add(ByRef input As ListNode(Of Char), inputStr As String)
        If i > inputStr.Length - 1 Then Exit Sub
        input.nxt = New ListNode(Of Char)
        input.nxt.value = inputStr(i)
        i += 1

        add(input.nxt, inputStr)
    End Sub
    Sub add(ByRef input As ListNode(Of Integer), inputStr As String)
        If i > inputStr.Length - 1 Then Exit Sub
        input.nxt = New ListNode(Of Integer)
        input.nxt.value = Val(inputStr(i))
        i += 1

        add(input.nxt, inputStr)
    End Sub
    '
    Function removeKFromList(l As ListNode(Of Integer), k As Integer) As ListNode(Of Integer)
        Dim list As New ListNode(Of Integer)
        list.nxt = l
        Dim node As New ListNode(Of Integer)
        node = list
        While Not node.nxt Is Nothing
            If (node.nxt.value = k) Then
                node.nxt = node.nxt.nxt
            Else
                node = node.nxt
            End If
        End While
        Return list.nxt
    End Function

    Sub Reverse(ByRef inputListNode As ListNode(Of Integer))
        Dim head As New ListNode(Of Integer)
        head = inputListNode
        Dim fwd As New ListNode(Of Integer)
        fwd = inputListNode.nxt

        head.nxt = Nothing
        Do While Not fwd Is Nothing
            Dim tmp As New ListNode(Of Integer)
            tmp = fwd.nxt
            fwd.nxt = head
            head = fwd
            fwd = tmp
        Loop

        inputListNode = head

    End Sub

End Module

