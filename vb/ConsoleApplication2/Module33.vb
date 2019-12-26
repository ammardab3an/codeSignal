Module Module33
    Sub main()
        Console.WriteLine("module33 is here")

        Dim testlist As New ListNode(Of Integer)
        testlist.value = 9999

        Dim tmp As ListNode(Of Integer) = testlist
        For i As Integer = 1 To 5
            tmp.nxt = New ListNode(Of Integer)
            tmp.nxt.value = 9999
            tmp = tmp.nxt
        Next



        Dim testlist0 As New ListNode(Of Integer)
        testlist0.value = 1

        addTwoHugeNumbers(testlist, testlist0)

    End Sub

    Function addTwoHugeNumbers(a As ListNode(Of Integer), b As ListNode(Of Integer)) As ListNode(Of Integer)

        Dim sumInt As String = stupidSum(listSum(a), listSum(b))

        Dim len As Integer = sumInt.Length
        Dim sum As String = sumInt.PadLeft( _
                                            IIf(len Mod 4 <> 0, len + (4 - (len Mod 4)), len) _
                                            , "0")

        Dim output As New ListNode(Of Integer)
        output.value = Val(sum(0) & sum(1) & sum(2) & sum(3))

        Dim tmp As ListNode(Of Integer) = output

        Dim index As Integer = 4
        Do Until index > sum.Length - 1
            tmp.nxt = New ListNode(Of Integer)
            tmp.nxt.value = Val(sum(index) & sum(index + 1) & sum(index + 2) & sum(index + 3))
            tmp = tmp.nxt
            index += 4
        Loop

        Return output
    End Function

    Function listSum(inputList As ListNode(Of Integer))
        Dim str As String = ""

        Dim tmp As New ListNode(Of Integer)
        tmp = inputList
        Do Until tmp.nxt Is Nothing
            str += CStr(tmp.value).PadLeft(4, "0")
            tmp = tmp.nxt
        Loop
        str += CStr(tmp.value).PadLeft(4, "0")

        Return str
    End Function

    Function stupidSum(_a As String, _b As String)
        Dim output As String = ""

        Dim maxLength As Integer = Math.Max(_a.Length, _b.Length)
        Dim a As String = _a.PadLeft(maxLength, "0")
        Dim b As String = _b.PadLeft(maxLength, "0")

        Dim byHand As Integer = 0
        For i As Integer = maxLength - 1 To 0 Step -1
            Dim s As String = Val(a(i)) + Val(b(i)) + byHand
            output = output.Insert(0, s(s.Length - 1))

            If s > 9 Then byHand = 1 Else byHand = 0
        Next
        If byHand <> 0 Then output = output.Insert(0, CStr(byHand))

        Return output
    End Function

    'Sub ShitAdd(ByRef input As ListNode(Of Integer), ByVal inputStr As String)
    '    If ShitInt > inputStr.Length - 1 Then Exit Sub

    '    input.nxt = New ListNode(Of Integer)
    '    input.nxt.value = Val(inputStr(ShitInt) & inputStr(ShitInt + 1) & inputStr(ShitInt + 2) & inputStr(ShitInt + 3))
    '    ShitInt += 4
    '    Console.WriteLine(CStr(input.value))

    '    ShitAdd(input.nxt, inputStr)
    'End Sub

End Module
