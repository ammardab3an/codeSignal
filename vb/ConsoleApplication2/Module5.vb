Module Module5
    Sub main()

    End Sub

    'Dim sum As Integer
    'Function sumInRange(nums As List(Of Integer), queries As List(Of List(Of Integer))) As Integer
    '    sum = 0
    '    For Each query As List(Of Integer) In queries
    '        nums.GetRange(query(0), query(1) - query(0) + 1).ForEach(AddressOf sumSub)
    '    Next

    '    Return (sum + (10 ^ 9 + 7)) Mod (10 ^ 9 + 7)
    'End Function

    'Sub sumSub(i As Integer)
    '    sum += i
    'End Sub

    'Function sumInRange(nums As List(Of Integer), queries As List(Of List(Of Integer))) As Integer

    '    Dim sum As Integer
    '    For Each query As List(Of Integer) In queries
    '        sum += System.Linq.Enumerable.Sum(nums.GetRange(query(0), query(1)))
    '    Next

    '    Return (sum + (10 ^ 9 + 7)) Mod (10 ^ 9 + 7)
    'End Function

    'Function sumInRange(nums As List(Of Integer), queries As List(Of List(Of Integer))) As Integer
    '    Dim sum As Integer
    '    For Each query As List(Of Integer) In queries
    '        For i As Integer = query(0) To query(1)
    '            sum += nums(i)
    '        Next
    '    Next
    '    Return (sum + (10 ^ 9 + 7)) Mod (10 ^ 9 + 7)
    'End Function
    Function sumOfTwo(a As List(Of Integer), b As List(Of Integer), v As Integer) As Boolean

        Dim dict As New Dictionary(Of Integer, Integer)

        For i As Integer = 0 To a.Count - 1
            Try
                dict.Add(a(i), 1)
            Catch ex As Exception
            End Try

        Next i
        For j As Integer = 0 To b.Count - 1
            If dict.ContainsKey(v - b(j)) Then
                Return True
            End If
        Next j

        Return False
    End Function


    'Dim hash As New System.Collections.Generic.HashSet(Of Integer)
    'Dim vv As Integer
    'Function sumOfTwo(a As List(Of Integer), b As List(Of Integer), v As Integer) As Boolean
    '    vv = v
    '    Dim loopArr = a
    '    Dim hashArr = b
    '    If b.Count < a.Count Then
    '        loopArr = b
    '        hashArr = a
    '    End If
    '    hash = New System.Collections.Generic.HashSet(Of Integer)(hashArr)
    '    Return Enumerable.Any(loopArr, AddressOf anyFun)
    'End Function
    'Function anyFun(t As Integer) As Boolean
    '    If hash.Contains(vv - t) Then Return True
    'End Function

    'Function sumOfTwo(a As List(Of Integer), b As List(Of Integer), v As Integer) As Boolean
    '    a.Sort()
    '    b.sort()
    '    Dim sum As Integer
    '    For Each i As Integer In a
    '        For Each ii As Integer In b
    '            sum = i + ii
    '            If sum > v Then Exit For
    '            If sum = v Then Return True
    '        Next
    '    Next
    'End Function

    'Function sumOfTwo(a As List(Of Integer), b As List(Of Integer), v As Integer) As Boolean
    '    For Each i As Integer In a
    '        For Each ii As Integer In b
    '            If i + ii = v Then Return True
    '        Next
    '    Next
    'End Function

    'Function sumOfTwo(a As List(Of Integer), b As List(Of Integer), v As Integer) As Boolean
    '    For i As Integer = 0 To a.count - 1
    '        For ii As Integer = 0 To b.count - 1
    '            If a(i) + b(ii) = v Then Return True
    '        Next
    '    Next
    'End Function

    Function containsDuplicates(a As List(Of Integer)) As Boolean
        If a.Count = 0 Then Return False
        a.Sort()
        Dim prevInt As Integer = a(0)
        For i As Integer = 1 To a.Count - 1
            If a(i) = prevInt Then Return True
            prevInt = a(i)
        Next
    End Function

    'Function containsDuplicates(a As List(Of Integer)) As Boolean
    '    Dim test As New List(Of Integer)
    '    For Each Int As Integer In a
    '        If test.Contains(Int) Then Return True
    '        test.Add(Int)
    '    Next
    'End Function

    'Function containsDuplicates(a As List(Of Integer)) As Boolean
    '    For i As Integer = 0 To a.Count - 2
    '        If a.IndexOf(a(i), i + 1) <> -1 Then Return True
    '    Next
    'End Function

    'Function containsDuplicates(a As List(Of Integer)) As Boolean
    '    For Each int As Integer In a
    '        If a.LastIndexOf(int) <> a.IndexOf(int) Then Return True
    '    Next
    'End Function
End Module
