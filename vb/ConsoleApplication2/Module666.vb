Module Module666
    Sub main()
        Dim test = findSubstrings({"Aaaaaaaaa", "bcdEFGh"}.ToList, _
                               {"aaaaa", "Aaaa", "E", "z", "Zzzzz"}.ToList)

    End Sub
    'Function findSubstrings(words As List(Of String), parts As List(Of String)) As List(Of String)
    '    Dim trie = New trie
    '    For Each s In parts
    '        trie.addWord(s)
    '    Next
    '    Return words.Select(Function(s) trie.replaceLongestSubstring(s)).ToList
    'End Function

    'Function findSubstrings(words As List(Of String), parts As List(Of String)) As List(Of String)
    '    Dim output As New List(Of String)
    '    For Each word As String In words
    '        Dim test As String = ""
    '        Dim testPart As String = ""
    '        For Each part As String In parts
    '            If word.Contains(part) Then
    '                Dim index As Integer = word.IndexOf(part(0))
    '                Dim add As String = word.Remove(index, part.Length).Insert(index, "[" & part & "]")

    '                If part.Length > testPart.Length Then
    '                    test = add
    '                    testPart = part
    '                ElseIf part.Length = testPart.Length Then
    '                    If add.IndexOf("[") < test.IndexOf("[") Then
    '                        test = add
    '                        testPart = part
    '                    End If
    '                End If
    '            End If
    '        Next
    '        output.Add(IIf(test = "", word, test))
    '    Next
    '    Return output
    'End Function
    Function findSubstrings(words As List(Of String), parts As List(Of String)) As List(Of String)
        Dim output As New List(Of String)
        Dim test As String
        Dim index, partLen, i, len As Integer

        For Each word As String In words
            test = word
            partLen = 0
            i = 0
            For Each part As String In parts
                len = part.Length
                If len > partLen Then
                    If word.Contains(part) Then
                        index = word.IndexOf(part)
                        test = word.Remove(index, part.Length).Insert(index, "[" & part & "]")
                        partLen = len
                        i = index
                    End If
                ElseIf len = partLen Then
                    If word.Contains(part) Then
                        index = word.IndexOf(part)
                        If index < i Then
                            test = word.Remove(index, part.Length).Insert(index, "[" & part & "]")
                            partLen = len
                            i = index
                        End If
                    End If
                End If
            Next
            output.Add(test)
        Next

        Return output
    End Function
    Function order(x As String)
        Return x.Length
    End Function
End Module
Public Class node
    Public c As Char
    Public children As List(Of node) = New List(Of node)
    Public lastNode As Boolean = False
End Class
Public Class trie
    Public head As node = New node
    Public Sub addWord(s As String)
        Dim cur = head
        For Each c As Char In s
            Dim node = cur.children.FirstOrDefault(Function(x) x.c = c)
            If node Is Nothing Then
                node = New node With {.c = c}
                cur.children.Add(node)
            End If
            cur = node
        Next
        'cur.lastNode = True
        If Not cur.children.Any(Function(x) x.c = head.c) Then _
            cur.children.Add(New node With {.c = head.c})
    End Sub

    Public Function replaceLongestSubstring(s As String) As String
        Dim cur = head
        Dim maxStart = 0
        Dim maxEnd = -5

        For _i As Integer = 0 To s.Length - 1
            Dim i As Integer = _i
            Dim node = cur.children.FirstOrDefault(Function(x) x.c = s(i))
            If node Is Nothing Then Continue For
            Dim endIndex = i
            cur = head

            While endIndex < s.Length
                cur = cur.children.FirstOrDefault(Function(x) x.c = s(endIndex))
                If cur Is Nothing Then Exit While
                If cur.children.Any(Function(x) x.c = head.c) _
                    AndAlso (endIndex - 1) > (maxEnd - maxStart) Then
                    maxEnd = endIndex
                    maxStart = i
                End If
                endIndex += 1
            End While
            cur = head
        Next
        If maxEnd = -5 Then Return s
        Return s.Substring(0, maxStart) + _
            "[" + s.Substring(maxStart, maxEnd + 1 - maxStart) + "]" _
         + IIf(maxEnd + 1 >= s.Length, "", s.Substring(maxEnd + 1))
    End Function

End Class

