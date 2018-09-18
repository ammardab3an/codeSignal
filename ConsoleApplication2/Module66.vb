Module Module66
    Sub main()
        Dim input As New Tree(Of Integer)
        input.value = 99

        input.left = New Tree(Of Integer)
        input.left.value = 100
        input.right = New Tree(Of Integer)
        input.right.value = 99

        Console.WriteLine(CStr(isTreeSymmetric(input)))
        Console.ReadKey()
    End Sub
    'i had to do it the hard way to improve my skills, and to use the functions in another solution.
    Function isTreeSymmetric(t As Tree(Of Integer)) As Boolean
        If t Is Nothing Then Return True

        ' i had to check the first tree first
        If t.left Is Nothing And t.right Is Nothing Then Return True
        If t.left Is Nothing Or t.right Is Nothing Then Return False
        If t.left.value <> t.right.value Then Return False
        'i split each row to a level and each level has (2 ^ level) trees 
        'and we have to check each tree in the first half if it "symmetric" to the opposite tree in the second half
        Dim level As Integer = -1
        Dim trees As Integer = 0

        Dim t1 As New Tree(Of Integer)
        Dim t2 As New Tree(Of Integer)
        Dim index As String
        Dim _index As String
        'the index for the t2 should be the opposite of t1's index 
        'ex: t1.index = "00101" t2.index = "11010"
        Dim bol As Boolean = False
        Do
            bol = False
            level += 1
            trees = 2 ^ level
            For i As Integer = 0 To trees - 1
                index = Convert.ToString(i, 2).PadLeft(level, "0")
                'if you know smarter way to convert the index let me know
                _index = index.Replace("0", "*").Replace("1", "0").Replace("*", "1")

                t1 = getTree(t, index)
                t2 = getTree(t, _index)

                If Not t1 Is Nothing Or Not t2 Is Nothing Then bol = True

                If Not isSymmetric(t1, t2) Then Return False


            Next
            If bol = False Then Exit Do
        Loop

        Return True
    End Function

    'this function is to check two tree if they are symmetric
    Function isSymmetric(t As Tree(Of Integer), _t As Tree(Of Integer)) As Boolean
        If t Is Nothing AndAlso _t Is Nothing Then Return True
        If t Is Nothing OrElse _t Is Nothing Then Return False

        Dim bol As Boolean = False
        If t.left Is Nothing AndAlso _t.right Is Nothing Then
            bol = True
        ElseIf t.left Is Nothing Or _t.right Is Nothing Then
            bol = False
        Else
            If t.left.value = _t.right.value Then bol = True
        End If

        Dim _bol As Boolean = False
        If _t.left Is Nothing AndAlso t.right Is Nothing Then
            _bol = True
        ElseIf _t.left Is Nothing Or t.right Is Nothing Then
            _bol = False
        Else
            If _t.left.value = t.right.value Then _bol = True
        End If

        If bol = True AndAlso _bol = True Then Return True
    End Function

    'to get specific tree from a larger tree        
    'the index should be like "0010", "0" for the left, "1" for the right           
    Function getTree(t As Tree(Of Integer), index As String) As Tree(Of Integer)
        Dim tmp As New Tree(Of Integer)
        tmp = t
        For Each c As Char In index
            If c = "0" Then
                If tmp.left Is Nothing Then Return Nothing
                tmp = tmp.left
            Else
                If tmp.right Is Nothing Then Return Nothing
                tmp = tmp.right
            End If
        Next
        Return tmp
    End Function
    'Function isTreeSymmetric(t As Tree(Of Integer)) As Boolean
    '    Dim Com As String = "0"

    '    Dim len As Integer = 1
    '    Dim int As Integer = 0
    '    Do
    '        Dim output As List(Of Integer) = TreeIndex(t, Com)
    '        Dim _output As List(Of Integer) = TreeIndex(t, Com.Replace("0", "*").Replace("1", "0").Replace("*", "1"))
    '        If output Is Nothing AndAlso _output Is Nothing Then
    '            If TreeIndex(t, _
    '                         IIf(Com(Com.Length - 1) = "0", _
    '                             Strings.StrReverse(Strings.StrReverse(Com).Remove(0, 1).Insert(0, "1")), _
    '                             Strings.StrReverse(Strings.StrReverse(Com).Remove(0, 1).Insert(0, "0")))) Is Nothing Then Exit Do

    '            Continue Do
    '        End If

    '        If (output Is Nothing AndAlso Not _output Is Nothing) Or (_output Is Nothing AndAlso Not output Is Nothing) Then Return False
    '        If Not Enumerable.SequenceEqual(output, _output) Then Return False

    '        If Convert.ToString(int + 1, 2).Length > len Then
    '            len += 1
    '            int = 0
    '            Com = Strings.StrDup(len, "0")
    '        Else
    '            int += 1
    '            Com = Convert.ToString(int, 2).PadLeft(len, "0")
    '        End If

    '    Loop
    '    Return True
    'End Function
    Function TreeIndex(ByVal t As Tree(Of Integer), ByVal com As String) As List(Of Integer)
        Dim output As New List(Of Integer)
        output.Add(t.value)
        Dim tmp As New Tree(Of Integer)
        tmp = t
        For Each c As Char In com
            If c = "0" Then
                If tmp.left Is Nothing Then Return Nothing
                tmp = tmp.left
            Else
                If tmp.right Is Nothing Then Return Nothing
                tmp = tmp.right
            End If
            output.Add(tmp.value)
        Next
        Return output
    End Function
End Module
