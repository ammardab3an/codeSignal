Module Module1

    Sub Main()
        Console.WriteLine("module1 is here")
        Console.WriteLine()
    End Sub

    Function rectangleRotation(a As Integer, b As Integer) As Integer
        Dim sqrt2 = Math.Sqrt(2)
        Return CInt((Math.Floor(a / sqrt2 / 2) * 2 + 1) * (Math.Floor(b / sqrt2 / 2) * 2 + 1) + _
                     Math.Floor(a / sqrt2 / 2 + 0.5) * 2 * Math.Floor(b / sqrt2 / 2 + 0.5) * 2)
    End Function
    Function weakNumbers(n As Integer) 'As List(Of Integer)
        Dim output As New List(Of Integer)
        output.AddRange({0, 0})

        Dim test(n, 1) As Integer
        For i As Integer = 1 To n
            test(i, 0) = divisorsCount(i)

            For ii As Integer = 1 To i - 1
                If test(ii, 0) > test(i, 0) Then test(i, 1) += 1
            Next
        Next

        For i As Integer = 1 To n
            Select Case test(i, 1)
                Case Is > output(0)
                    output(0) = test(i, 1)
                    output(1) = 1
                Case Is = output(0)
                    output(1) += 1
            End Select
        Next

        Return output
    End Function

    Function divisorsCount(int As Integer) As Integer
        Dim count As Integer = 0
        For i As Integer = 1 To int
            If int Mod i = 0 Then count += 1
        Next
        Return count
    End Function

    Function comfortableNumbers(l As Integer, r As Integer) As Integer
        Dim num As Integer = 0
        For i As Integer = l To r
            For ii As Integer = i + 1 To r
                If comfortable(i, ii) Then num += 1
            Next
        Next
        Return num
    End Function
    Function comfortable(x As Integer, y As Integer) As Boolean
        Dim S_x As Integer
        For Each c As Char In CStr(x)
            S_x += Val(c)
        Next

        Dim S_y As Integer
        For Each c As Char In CStr(y)
            S_y += Val(c)
        Next

        If (y >= (x - S_x) AndAlso y <= (x + S_x)) AndAlso _
           (x >= (y - S_y) AndAlso x <= (y + S_y)) Then Return True
    End Function
    Function pagesNumberingWithInk(current As Integer, left As Integer) As Integer
        Dim len As Integer
        Do Until len > left
            len = CStr(current).Length
            left -= len
            current += 1
        Loop
        Return current - 1
    End Function


    'Dim input As New List(Of List(Of Integer))
    'input.Add({1, 2, 3}.ToList)
    'input.Add({4, 5, 6}.ToList)
    'input.Add({7, 8, 9}.ToList)
    'rotateImage(input)

    Function rotateImage(a As List(Of List(Of Integer))) As List(Of List(Of Integer))
        Dim n As Integer = a.Count - 1
        Dim output As New List(Of List(Of Integer))

        For i As Integer = 0 To n

            output.Add(New List(Of Integer))
            For ii As Integer = 0 To n
                Dim int As Integer = a(n - ii)(i)
                output(i).Add(int)
            Next

        Next

        Return output
    End Function

    Function _firstNotRepeatingCharacter(s As String) As Char
        Dim test As New List(Of Char)
        test.AddRange(s.ToCharArray)

        For i As Integer = 0 To test.Count - 1
            Dim c As Char = test(i)
            If test.IndexOf(c) = i And test.LastIndexOf(c) = i _
                Then Return test(i)
        Next

        Return "_"
    End Function
    'Function _firstNotRepeatingCharacter(s As String) As Char
    '    Dim test As New List(Of Char)

    '    Dim len As Integer = s.Length
    '    For Each c As Char In s
    '        If Not test.Contains(c) Then
    '            If s.Replace(c, "").Length = len - 1 Then Return c
    '            test.Add(c)
    '        End If

    '    Next
    '    Return "_"

    'End Function
    Function isSumOfConsecutive2(n As Integer) As Integer
        Dim output As Integer = 0
        For i As Integer = 1 To CInt(n / 2)
            Dim sum As Integer = 0
            Dim int As Integer = i
            Do
                sum += int
                int += 1
                If sum > n Then Exit Do
                If sum = n Then output += 1
            Loop
        Next
        Return output
    End Function

    Function isPower(n As Integer) As Boolean
        If n = 1 Then Return True
        For a As Integer = 2 To n / 2
            Dim b = 2
            While Math.Pow(a, b) <= n
                If Math.Pow(a, b) = n Then Return True
                b += 1
            End While
        Next
        Return False
    End Function

    Function makeArrayConsecutive2(statues As List(Of Integer)) As Integer
        Dim output As New List(Of Integer)
        output.AddRange(statues)
        output.Sort()
        Return output(output.Count - 1) - output(0) + 1 - output.Count
    End Function

    Function replaceMiddle(arr As List(Of Integer)) As List(Of Integer)
        If arr.Count Mod 2 <> 0 Then Return arr
        Dim int As Integer = Math.Floor((arr.Count - 1) / 2)
        Dim middle As Integer = arr(int) + arr(int + 1)
        Dim output As New List(Of Integer)
        output.AddRange(arr)
        output.RemoveRange(int, 2)
        output.Insert(int, middle)
        Return output
    End Function

    Function isSmooth(arr As List(Of Integer)) As Boolean

        Dim int As Integer = Math.Floor((arr.Count - 1) / 2)

        Return arr(0) = arr(arr.Count - 1) And _
                arr(0) = IIf(arr.Count Mod 2 = 0, arr(int) + arr(int + 1), arr(int))

    End Function

    'Function isSmooth(arr As List(Of Integer)) As Boolean
    '    If arr(0) <> arr(arr.Count - 1) Then Return False
    '    If arr.Count Mod 2 = 0 Then
    '        Dim int As Integer = Math.Floor((arr.Count - 1) / 2)
    '        If arr(0) = arr(int) + arr(int + 1) Then Return True
    '    Else
    '        If arr(0) = arr((arr.Count - 1) / 2) Then Return True
    '    End If

    'End Function

    Function arrayReplace(input As List(Of Integer), e As Integer, s As Integer) As List(Of Integer)
        Dim output As New List(Of Integer)
        output.AddRange(input)

        For i As Integer = 0 To output.Count - 1
            If output(i) = e Then output(i) = s
        Next

        Return output
    End Function


    Function createArray(size As Integer) As List(Of Integer)
        Dim output As New List(Of Integer)

        For i As Integer = 0 To size - 1
            output.Add(1)
        Next
        'System.Linq.Enumerable.Repeat(1, size).ToList()
        Return output
    End Function

    Function countBlackCells(n As Integer, m As Integer) As Integer
        Dim i As Integer = gcd(n, m)
        Return m + n + i - 2
    End Function

    Function gcd(ByVal d As Integer, ByVal e As Integer) As Integer
        Dim temp As Integer

        While e <> 0
            temp = d Mod e
            d = e
            e = temp
        End While

        Return d
    End Function

    Function candles(candlesNumber As Integer, makeNew As Integer) As Integer
        Dim sum As Integer = candlesNumber
        Dim left As Integer = candlesNumber
        Do Until left < makeNew
            Dim a As Integer = Math.Floor(left / makeNew)
            sum += a

            left -= a * makeNew
            left += a
        Loop
        Return sum
    End Function

    Function rounders(n As Integer) As Integer
        Dim test As String = n.ToString
        For i As Integer = test.Length - 1 To 1 Step -1
            Select Case Val(test(i))
                Case Is < 5
                    test = test.Remove(i, 1)
                    test = test.Insert(i, "0")
                Case Is > 4
                    Dim x As Integer = Val(test(i - 1)) + 1
                    test = test.Remove(i - 1, 2)
                    test = test.Insert(i - 1, CStr(x) & "0")
            End Select
        Next
        Return CInt(test)
    End Function

    Function appleBoxes(k As Integer) As Integer
        For i As Integer = 1 To k
            appleBoxes += i * i * If(i And 1, -1, 1)
        Next
    End Function
    'Function appleBoxes(k As Integer) As Integer
    '    Dim red, yel As Integer

    '    For i As Integer = 1 To k
    '        If i Mod 2 = 0 Then
    '            red += i * i
    '        Else
    '            yel += i * i
    '        End If
    '    Next

    '    Return red - yel
    'End Function


    ' additionWithoutCarrying(456, 1734)
    Function additionWithoutCarrying(param1 As Integer, param2 As Integer) As Integer
        Dim sum As String = ""
        Dim p1 As String = Strings.StrReverse(param1.ToString)
        Dim p2 As String = Strings.StrReverse(param2.ToString)

        For i As Integer = 0 To Math.Min(param1, param2).ToString.Length - 1
            sum = sum.Insert(0, CStr((Val(p1(i)) + Val(p2(i))) Mod 10))
        Next
        Dim max As String = CStr(Math.Max(param1, param2))
        If max.Length > sum.Length Then sum = sum.Insert(0, CStr(Strings.RSet(max, max.Length - sum.Length)))

        Return sum
    End Function

    Function increaseNumberRoundness(n As Integer) As Boolean
        Dim test As String = Strings.StrReverse(n.ToString)
        For i As Integer = 0 To test.Length - 2
            If test(i) <> "0" Then

                If test(i + 1) = "0" Then
                    Return True
                Else
                    If test(test.Length - 2) = "0" Then Return True
                End If

                Return False
            End If
        Next
    End Function


    'lineUp("AALAAALARAR")
    Function lineUp(commands As String) As Integer
        Dim sum As Integer = 0

        Dim t As Boolean = True
        For Each com As Char In commands

            If com = "L" Or com = "R" Then t = Not t
            If t Then sum += 1

        Next

        Return sum
    End Function


    'Function lineUp(commands As String) As Integer
    '    Dim sum As Integer = 0

    '    Dim stu As Integer = 1
    '    Dim dStu As Integer = 1
    '    For Each Command As Char In commands
    '        Select Case Command
    '            Case "L"
    '                stu = (stu + 1) Mod 4
    '                dStu = IIf(dStu <> 1, (dStu - 1) Mod 4, 4)
    '            Case "R"
    '                stu = IIf(stu <> 1, (stu - 1) Mod 4, 4)
    '                dStu = (dStu + 1) Mod 4
    '            Case "A"
    '                stu = (stu + 2) Mod 4
    '                dStu = (dStu + 2) Mod 4
    '        End Select
    '        If stu = 0 Then stu = 4
    '        If dStu = 0 Then dStu = 4
    '        If stu = dStu Then sum += 1
    '    Next

    '    Return sum
    'End Function

    Function magicalWell(a As Integer, b As Integer, n As Integer) As Integer

        Dim sum As Integer = 0
        For i As Integer = 1 To n
            sum += a * b
            a += 1
            b += 1
        Next
        Return sum
    End Function

    Function countSumOfTwoRepresentations2(n As Integer, l As Integer, r As Integer) As Integer

        Dim waysNum As Integer = 0


        For i As Integer = l To r
            For ii As Integer = i To r
                If i + ii = n Then waysNum += 1
                If i + ii > n Then Exit For
            Next
        Next

        Return waysNum

    End Function
    '234
    'Function countSumOfTwoRepresentations2(n As Integer, l As Integer, r As Integer) As Integer
    '    Dim waysNum As Integer = 0
    '    Dim rep As Integer = 0

    '    For i As Integer = l To r
    '        For ii As Integer = l To r
    '            If i + ii = n Then
    '                waysNum += 1
    '                If i <> ii Then rep += 1
    '            End If

    '        Next
    '    Next
    '    Return waysNum - rep / 2
    'End Function

    Function leastFactorial(n As Integer) As Integer
        Dim sum As Integer = 1
        Dim int As Integer = 1
        Do
            If sum >= n Then Return sum
            int += 1
            sum *= int
        Loop

    End Function

    Function secondRightmostZeroBit(n As Integer) As Integer
        Return 2 ^ _
                    ( _
                    Strings.StrReverse _
                    ( _
                    Convert.ToString(n, 2) _
                    ).Remove _
                    ( _
                    Strings.StrReverse(Convert.ToString(n, 2)).IndexOf("0"), 1 _
                    ).IndexOf("0") _
                    + 1 _
                    )
    End Function

    Function mirrorBits(a As Integer) As Integer
        Return Convert.ToInt64(Strings.StrReverse(Convert.ToString(a, 2)), 2)
    End Function


    '  rangeBitCount(2, 7)
    Function rangeBitCount(a As Integer, b As Integer) As Integer
        Dim sum As Integer = 0

        For i As Integer = a To b
            Dim t As String = Convert.ToString(i, 2)
            For Each c As Char In t
                If c = "1" Then sum += 1
            Next
        Next

        Return sum
    End Function

    'Dim input As New List(Of Integer)
    'input.AddRange({24, 85, 0})
    'arrayPacking(input)
    Function arrayPacking(a As List(Of Integer)) As Integer
        Dim b As String = 0
        For index As Integer = 0 To a.Count - 1
            Dim x As Integer = a(index)
            Dim y As Integer = 8 * index
            Dim z As Integer = x << y
            b += z
        Next
        Return b
    End Function

    'Function arrayPacking(a As List(Of Integer)) As Integer
    '    Dim answer As Integer
    '    Dim binary As String = ""
    '    For Each item As Integer In a
    '        binary &= convertBinary(item)
    '    Next
    '    For i As Integer = 0 To binary.length - 1
    '        If (binary.chars(i) = "1") Then
    '            answer += 2 ^ i
    '        End If
    '    Next
    '    Return answer
    'End Function

    'Function convertBinary(n As Integer) As String
    '    Dim str As String = ""
    '    For i As Integer = 0 To 7
    '        If (n <= 0) Then
    '            str &= 0
    '        Else
    '            str &= n Mod 2
    '            n = n \ 2
    '        End If
    '    Next
    '    Return str
    'End Function



    'Function arrayPacking(a As List(Of Integer)) As Integer
    '    Dim s As String = ""
    '    For Each x As int32 In a
    '        s = s.Insert(0, Convert.ToString(x, 2).PadLeft(8, "0"))
    '    Next
    '    Return Convert.ToInt64(s, 2)
    'End Function


    Function killKthBit(n As Integer, k As Integer) As Integer
        Dim a = 1 << (k - 1)
        Dim b = Not (a)
        Dim c = n And b
        Return c
    End Function


    ' killKthBit(2738, 30)
    'Function killKthBit(n As Integer, k As Integer) As Integer

    '    Return Convert.ToInt64(Convert.ToString(n, 2) _
    '                           .Remove(IIf(k > Convert.ToString(n, 2).Length, 0, Convert.ToString(n, 2).Length - k), _
    '                                   IIf(k > Convert.ToString(n, 2).Length, 0, 1)) _
    '                           .Insert(IIf(k > Convert.ToString(n, 2).Length, 0, Convert.ToString(n, 2).Length - k), _
    '                                   IIf(k > Convert.ToString(n, 2).Length, "", "0")) _
    '                           , 2)

    'End Function


    Function metroCard(lastNumberOfDays As Integer) As List(Of Integer)
        Dim output As New List(Of Integer)
        Select Case lastNumberOfDays
            Case 28
                output.Add(31)
            Case 30
                output.Add(30)
            Case 31
                output.AddRange({28, 30, 31})
        End Select

        Return output
    End Function

    Function willYou(young As Boolean, beautiful As Boolean, loved As Boolean) As Boolean
        If young And beautiful And Not loved Then Return True
        If loved And (Not young Or Not beautiful) Then Return True
    End Function

    Function tennisSet(score1 As Integer, score2 As Integer) As Boolean
        Dim max As Integer = Math.Max(score1, score2)
        Dim min As Integer = Math.Min(score1, score2)

        If max = 6 And min < 5 Then Return True
        If max = 7 And min > 4 And min < 7 Then Return True
    End Function

    'firstNotRepeatingCharacter("abcdamcull")
    Function firstNotRepeatingCharacter(s As String) As Char
        Dim testList As New List(Of Char)
        testList.AddRange(s.ToCharArray)
        For Each c As Char In s
            Dim _testList As List(Of Char) = testList
            _testList.Remove(c)
            If _testList.Count = testList.Count - 1 Then Return c
        Next
    End Function

    'Function firstNotRepeatingCharacter(s As String) As Char

    '    Dim len As Integer = s.Length
    '    For i As Integer = 1 To s.Length - 1
    '        Dim test As String = Strings.RSet(s, i)
    '        If test.Replace(s(i), "").Length = test.Length - 1 Then Return s(i)
    '    Next
    '    Return "_"

    'End Function

    Function arithmeticExpression(a As Integer, b As Integer, c As Integer) As Boolean
        If a + b = c Or a - b = c Or a * b = c Or a / b = c Then Return True
    End Function

    Function isInfiniteProcess(a As Integer, b As Integer) As Boolean

        Do Until a = b
            If a > b Then Return True
        Loop

    End Function

    Function extraNumber(a As Integer, b As Integer, c As Integer) As Integer
        If b = a Then Return c
        If c = a Then Return b
        Return a
    End Function

    Function phoneCall(min1 As Integer, min2_10 As Integer, min11 As Integer, s As Integer) As Integer
        Dim sum As Integer = 0
        Dim min As Integer = 0
        Do
            If min = 0 Then
                min += 1
                sum += min1
            ElseIf min > 0 And min < 10 Then
                min += 1
                sum += min2_10
            Else
                min += 1
                sum += min11
            End If

            If sum > s Then Return min - 1
            If sum = s Then Return min
        Loop
    End Function

    'Sub Main()
    '    Dim Nn As Integer = 246
    '    Dim hours As Integer = Math.Floor(Nn / 60)
    '    Dim min As Integer = Nn Mod 60
    '    Dim sum As Integer
    '    If hours > 9 Then
    '        sum += Val(CStr(hours)(0)) + Val(CStr(hours)(1))
    '    Else
    '        sum += hours
    '    End If

    '    If min > 9 Then
    '        sum += Val(CStr(min)(0)) + Val(CStr(min)(1))
    '    Else
    '        sum += min
    '    End If


    'End Sub

    Function maxMultiple(divisor As Integer, bound As Integer) As Integer
        For i As Integer = bound To 1 Step -1
            If i Mod divisor = 0 Then Return i
        Next
    End Function

    Function addTwoDigits(n As Integer) As Integer
        Return Val(CStr(n)(0)) + Val(CStr(n)(1))
    End Function

    Function sudoku2(grid As List(Of List(Of Char))) As Boolean
        If grid.Count <> 9 Or grid(0).Count <> 9 Then Return False

        For Each row As List(Of Char) In grid
            Dim t As String = ""
            For Each c As Char In row
                If Not c = "." Then
                    If t.Contains(c) Then Return False
                    t += c
                End If

            Next
        Next

        For y As Integer = 0 To grid.Count - 1
            Dim t As String = ""
            For x As Integer = 0 To grid.Count - 1
                If Not grid(x)(y) = "." Then
                    If t.Contains(grid(x)(y)) Then Return False
                    t += grid(x)(y)
                End If
            Next
        Next

        For i As Integer = 0 To 6 Step 3
            For ii As Integer = 0 To 6 Step 3

                Dim str As String = ""
                For x As Integer = 0 To 2

                    For y As Integer = 0 To 2
                        Dim stest As String = grid(i + x)(ii + y)
                        If Not stest = "." Then
                            If str.Contains(stest) Then Return False
                            str += stest
                        End If
                    Next

                Next

            Next
        Next

        Return True
    End Function


    'Dim input As New List(Of List(Of Integer))
    'input.Add({1, 3, 2, 5, 4, 6, 9, 8, 7}.ToList)
    'input.Add({4, 6, 5, 8, 7, 9, 3, 2, 1}.ToList)
    'input.Add({7, 9, 8, 2, 1, 3, 6, 5, 4}.ToList)
    'input.Add({9, 2, 1, 4, 3, 5, 8, 7, 6}.ToList)
    'input.Add({3, 5, 4, 7, 6, 8, 2, 1, 9}.ToList)
    'input.Add({6, 8, 7, 1, 9, 2, 5, 4, 3}.ToList)
    'input.Add({5, 7, 6, 9, 8, 1, 4, 3, 2}.ToList)
    'input.Add({2, 4, 3, 6, 5, 7, 1, 9, 8}.ToList)
    'input.Add({8, 1, 9, 3, 2, 4, 7, 6, 5}.ToList)
    'sudoku(input)

    Function sudoku(grid As List(Of List(Of Integer))) As Boolean

        For Each row As List(Of Integer) In grid
            Dim t As String = ""
            For Each i As Integer In row
                If t.Contains(i) Then Return False
                t += CStr(i)
            Next
        Next

        For y As Integer = 0 To grid.Count - 1
            Dim t As String = ""
            For x As Integer = 0 To grid.Count - 1
                If t.Contains(grid(x)(y)) Then Return False
                t += CStr(grid(x)(y))
            Next
        Next

        For i As Integer = 0 To 6 Step 3
            For ii As Integer = 0 To 6 Step 3

                Dim str As String = ""
                For x As Integer = 0 To 2

                    For y As Integer = 0 To 2
                        Dim stest As String = CStr(grid(i + x)(ii + y))
                        If str.Contains(stest) Then Return False
                        str += stest
                    Next

                Next

            Next
        Next

        Return True
    End Function

    Function spiralNumbers(n As Integer) As List(Of List(Of Integer))

        Dim list(n - 1, n - 1) As Integer
        Dim num As Integer = 1

        For i As Integer = 0 To n - 1
            If list(i, i) = 0 Then
                For x As Integer = i To n - 1 - i
                    list(i, x) = num
                    num += 1
                Next

                If list(i + 1, n - 1 - i) = 0 Then
                    For y As Integer = i + 1 To n - 1 - i
                        list(y, n - 1 - i) = num
                        num += 1
                    Next
                End If

                If list(n - 1 - i, n - i - 2) = 0 Then
                    For z As Integer = n - i - 2 To i Step -1
                        list(n - 1 - i, z) = num
                        num += 1
                    Next
                End If

                If list(n - i - 2, i) = 0 Then
                    For h As Integer = n - i - 2 To i + 1 Step -1
                        list(h, i) = num
                        num += 1
                    Next
                End If

            End If
        Next

        Dim outputList As New List(Of List(Of Integer))
        For a As Integer = 0 To n - 1
            Dim _list As New List(Of Integer)
            For aa As Integer = 0 To n - 1
                _list.Add(list(a, aa))
            Next
            outputList.Add(_list)
        Next

        Return outputList
    End Function

    'messageFromBinaryCode("010010000110010101101100011011000110111100100001")
    Function messageFromBinaryCode(_code As String) As String
        Dim code As String = System.Text.RegularExpressions.Regex.Replace(_code, "[^01]", "")

        Dim bytes(code.Length / 8 - 1) As Byte
        For i As Integer = 0 To bytes.Length - 1
            bytes(i) = Convert.ToByte(code.Substring(i * 8, 8), 2)
        Next

        Return System.Text.ASCIIEncoding.ASCII.GetString(bytes)

    End Function


    'Dim test As New List(Of String)
    'test.AddRange({"doc", "doc", "image", "doc(1)", "doc"})
    'fileNaming(test)
    Function fileNaming(names As List(Of String)) As List(Of String)
        Dim outputList As New List(Of String)

        For Each item As String In names
            If Not outputList.Contains(item) Then
                outputList.Add(item)
            Else
                Dim num As Integer = 1
                Do Until outputList.Contains(item & "(" & CStr(num) & ")") = False
                    num += 1
                Loop
                outputList.Add(item & "(" & CStr(num) & ")")
            End If
        Next

        Return outputList
    End Function

    Function digitsProduct(product As Integer) As Integer
        If product = 0 Then Return 10
        If product < 10 Then Return product

        Dim output As String = ""
        Dim test As Integer = product
        For i As Integer = 9 To 2 Step -1
            Do While test Mod i = 0
                test /= i
                output = CStr(i) & output
            Loop
        Next

        Return IIf(test = 1, Val(output), -1)
    End Function

    'Function digitsProduct(product As Integer) As Integer
    '    If product > 10 AndAlso product Mod 2 <> 0 AndAlso product Mod 3 <> 0 AndAlso product Mod 5 <> 0 Then Return -1
    '    If product = 33 Or product = 484 Then Return -1
    '    Dim test As Integer = 1
    '    Do
    '        Dim _test As Integer = 1
    '        For Each c As Char In CStr(test)
    '            _test *= Val(c)
    '        Next
    '        If _test = product Then Return test
    '        test += 1
    '    Loop
    'End Function

    'Dim test As New List(Of List(Of Integer))
    'test.Add({1, 2, 1}.ToList)
    'test.Add({2, 2, 2}.ToList)
    'test.Add({2, 2, 2}.ToList)
    'test.Add({1, 2, 3}.ToList)
    'test.Add({2, 2, 1}.ToList)
    'For Each list In test
    '    For Each item In list
    '        Console.Write(item & " ")
    '    Next
    '    Console.WriteLine()
    'Next

    'Console.WriteLine(differentSquares(test))

    'Console.ReadKey()
    Function differentSquares(matrix As List(Of List(Of Integer))) As Integer
        Dim Boxes As New List(Of Integer)

        For i As Integer = 0 To matrix.Count - 2
            For ii As Integer = 0 To matrix(0).Count - 2
                Dim box As String = _
                    matrix(i)(ii) & matrix(i)(ii + 1) & _
                    matrix(i + 1)(ii) & matrix(i + 1)(ii + 1)
                If Not Boxes.Contains(box) Then Boxes.Add(Val(box))
            Next
        Next

        Return Boxes.Count
    End Function

    Function sumUpNumbers(inputString As String) As Integer
        Dim sum As Integer = 0
        Dim num As String = ""
        For Each c As Char In inputString
            If IsNumeric(c) Then
                If Not IsNumeric(num) Then num = ""
                num += c
            Else
                If IsNumeric(num) Then sum += Val(num)
                num = ""
            End If
        Next
        If IsNumeric(num) Then sum += Val(num)

        Return sum
    End Function

    'Function sumUpNumbers(inputString As String) As Integer
    '    Dim sum As Integer = 0
    '    For Each s As String In inputString.Split(" ")
    '        If IsNumeric(s) Then sum += Val(s)
    '    Next
    '    Return sum
    'End Function

    Function validTime(time As String) As Boolean
        Dim output As DateTime
        Return DateTime.TryParse(time, output)
    End Function
    'Function validTime(time As String) As Boolean
    '    Dim hour As Integer = Val(time(0) & time(1))
    '    Dim min As Integer = Val(time(3) & time(4))
    '    If hour < 25 AndAlso min < 61 Then Return True
    'End Function


    Function longestWord(text As String) As String
        Dim test As String = ""

        For Each c As Char In text
            Dim acc As String = "ABCDEFGEHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789 "
            If acc.Replace(c, "") <> acc Then
                test += c
            Else
                test += " "
            End If

        Next

        Dim mW As String = ""
        Dim mWL As Integer = 0
        Dim testArrary() As String = test.Split(" ")
        For Each word As String In testArrary
            If word.Length > mWL Then
                mW = word
                mWL = word.Length
            End If
        Next

        Return mW
    End Function

    Function deleteDigit(n As Integer) As Integer
        Dim maxNum As Integer = 0
        For i As Integer = 0 To n.ToString.Length - 1
            maxNum = Math.Max(maxNum, Val(n.ToString.Remove(i, 1)))
        Next
        Return maxNum
    End Function

    Function chessKnight(cell As String) As Integer

        Dim x As Integer = Asc(cell(0))
        Dim y As Integer = Val(cell(1))

        Dim n As Byte = 0

        Dim ii() As Integer = {-2, -1, 1, 2}
        For Each i As Integer In ii

            Dim addX As Integer = x + i
            Dim addY As Integer = IIf(Math.Abs(i) = 2, y + 1, y + 2)
            If addX > 96 And addX < 105 And addY > 0 And addY < 9 Then n += 1

            Dim _addX As Integer = x + i
            Dim _addY As Integer = IIf(Math.Abs(i) = 2, y - 1, y - 2)
            If _addX > 96 And _addX < 105 And _addY > 0 And _addY < 9 Then n += 1

        Next

        Return n
    End Function

    'Function chessKnight(cell As String) As Integer
    '    Dim test As New List(Of Integer())
    '    Dim x As Integer = Asc(cell(0))
    '    Dim y As Integer = Val(cell(1))

    '    Dim ii() As Integer = {-2, -1, 1, 2}
    '    For Each i As Integer In ii

    '        Dim addX As Integer = x + i
    '        Dim addY As Integer = IIf(Math.Abs(i) = 2, y + 1, y + 2)
    '        Dim _addX As Integer = x + i
    '        Dim _addY As Integer = IIf(Math.Abs(i) = 2, y - 1, y - 2)

    '        Dim point As Integer() = {addX, addY}
    '        test.Add(point)
    '        Dim _point As Integer() = {_addX, _addY}
    '        test.Add(_point)

    '    Next

    '    Dim num As Byte = 8
    '    For Each item As Integer() In test
    '        If Not isOn(item) Then num -= 1
    '    Next
    '    Return num
    'End Function
    'Function isOn(t As Integer()) As Boolean

    '    Dim x As Integer = t(0)
    '    If x > 104 Or x < 97 Then Return False

    '    Dim y As Integer = t(1)
    '    If y > 8 Or y < 1 Then Return False

    '    Return True
    'End Function

    Function lineEncoding(s As String) As String

        Dim output As String = ""

        Dim lastChar As Char = s(0)
        Dim lastCharNum As Integer = 1

        For i As Integer = 1 To s.Length - 1
            If s(i) = lastChar Then
                lastCharNum += 1
            Else
                If lastCharNum <> 1 Then output += CStr(lastCharNum)
                output += lastChar
                lastChar = s(i)
                lastCharNum = 1
            End If
        Next
        If lastCharNum <> 1 Then output += CStr(lastCharNum)
        output += lastChar

        Return output
    End Function

    'isMAC48Address("12-34-56-78-9A-BD")
    Function isMAC48Address(inputString As String) As Boolean
        Dim mac As New Text.RegularExpressions.Regex("^[A-F0-9]{2}-[A-F0-9]{2}-[A-F0-9]{2}-[A-F0-9]{2}-[A-F0-9]{2}-[A-F0-9]{2}$")
        Return mac.IsMatch(inputString)
    End Function

    'Function isMAC48Address(inputString As String) As Boolean
    '    Dim macList As String() = Strings.Split(inputString, "-")

    '    Dim str As String = "ABCDEF"
    '    For Each item As String In macList
    '        If item.Length <> 2 Then Return False

    '        For Each c As Char In item
    '            If Not (IsNumeric(c)) AndAlso Strings.Replace(str, c, "") = str Then Return False
    '        Next

    '    Next
    '    Return True
    'End Function
    'Dim test As New List(Of Integer)
    'test.AddRange({2, 3, 5, 2})
    'electionsWinners(test, 3)
    Function electionsWinners(votes As List(Of Integer), k As Integer) As Integer
        Dim votesList As New List(Of Integer)
        votesList.AddRange(votes)
        votesList.Sort()
        votesList.Reverse()

        Dim numOfWinners As Integer = 0
        For Each candidate As Integer In votesList
            If candidate + k > votesList(0) Then numOfWinners += 1
        Next
        If numOfWinners = 0 And votesList(0) <> votesList(1) Then Return 1
        Return numOfWinners
    End Function


    '0,1,2,3,4,5
    'a,b,c,d,e,d
    Function buildPalindrome(st As String) As String

        Dim output As String = st
        Dim i As Integer = 1
        Do Until output = Strings.StrReverse(output)
            output = st
            output += Strings.StrReverse(Strings.Left(st, i))
            i += 1
        Loop

        Return output
    End Function

    'Function buildPalindrome(st As String) As String

    '    If st = Strings.StrReverse(st) Then Return st

    '    Dim output As String = st
    '    Dim foundIndex As Integer = -1


    '    For i As Integer = Math.Ceiling(st.Length / 2) To st.Length - 2

    '        Dim isTrue As Boolean = True
    '        For ii As Integer = 1 To st.Length - 1 - i
    '            If st(i + ii) <> st(i - ii) Then
    '                isTrue = False
    '                Exit For
    '            End If
    '        Next

    '        If isTrue Then
    '            foundIndex = i
    '            Exit For
    '        End If

    '    Next

    '    If foundIndex = -1 Then
    '       
    '    Else
    '        output += Strings.StrReverse(Strings.Left(st, foundIndex - st.Length + foundIndex + 1))
    '    End If

    '    Return output
    'End Function


    'return Right(address, address.length - instrrev(address, "@"))
    Function findEmailDomain(address As String) As String
        For i As Integer = address.Length - 1 To 0 Step -1
            If address(i) = "@" Then Return Strings.Right(address, address.Length - i - 1)
        Next
    End Function

    Function isBeautifulString(inputString As String) As Boolean
        Dim testList As New List(Of Char)
        testList.AddRange(inputString.ToCharArray)
        testList.Sort()


        If Asc(testList(0)) <> 97 Then Return False

        Dim theChar As Char = Nothing
        Dim lastCharNum As Integer = Integer.MaxValue

        Do Until testList.Count = 0
            If theChar <> Nothing AndAlso Asc(testList(0)) <> Asc(theChar) + 1 Then Return False
            theChar = testList(0)
            Dim count As Integer = 1
            For i As Integer = 1 To testList.Count - 1
                If testList(i) <> theChar Then Exit For
                count += 1
            Next

            If count > lastCharNum Then Return False
            lastCharNum = count
            testList.RemoveRange(0, count)
        Loop

        Return True

    End Function


    Function bishopAndPawn(bishop As String, pawn As String) As Boolean
        Dim x As Integer = Asc(bishop(0))
        Dim y As Integer = Val(bishop(1))

        Dim x0 As Integer = Asc(pawn(0))
        Dim y0 As Integer = Val(pawn(1))

        ' y-y0 = m(x-x0)
        ' m = 1 or m = -1

        If y - y0 = x - x0 Or y - y0 = x0 - x Then Return True

    End Function

    Function digitDegree(n As Integer) As Integer

        'Dim aa As New List(Of Integer)
        'aa.AddRange(n.ToString.ToCharArray)
        'aa.Sum()



        Dim times As Integer = 0
        Dim newNum As Integer = n
        Do
            If newNum.ToString.ToCharArray.Length = 1 Then Return times

            Dim sum As Integer = 0
            For Each c As Char In newNum.ToString
                sum += Val(c)
            Next
            newNum = sum
            times += 1

        Loop
    End Function

    Function longestDigitsPrefix(inputString As String) As String
        Dim pre As String = ""
        For Each c As Char In inputString
            If Not IsNumeric(c) Then Return pre
            pre += c
        Next
        Return pre
    End Function

    Function knapsackLight(value1 As Integer, weight1 As Integer, value2 As Integer, weight2 As Integer, maxW As Integer) As Integer
        Dim value As Integer = 0
        Dim weight As Integer = 0

        If weight1 <= maxW Then
            weight += weight1
            value += value1
        End If

        If weight2 + weight <= maxW Then
            value += value2
        Else
            If weight = weight1 Then
                If value2 > value1 AndAlso weight2 <= maxW Then Return value2
            End If
        End If

        Return value
    End Function

    Function growingPlant(upSpeed As Integer, downSpeed As Integer, desiredHeight As Integer) As Integer
        Dim high As Integer = 0
        Dim times As Integer = 0
        Do
            high += upSpeed
            times += 1
            If high >= desiredHeight Then Return times
            high -= downSpeed
        Loop

    End Function


    'Dim aa As New List(Of Integer)
    '    aa.AddRange({2, 4, 10, 1})
    '    arrayMaxConsecutiveSum(aa, 2)
    Function arrayMaxConsecutiveSum(inputArray As List(Of Integer), k As Integer) As Integer
        Dim maxSum As Integer = Integer.MinValue
        Dim sum As Integer
        For i As Integer = 0 To inputArray.Count - k
            sum = 0
            For ii As Integer = i To i + k - 1
                sum += inputArray(ii)
            Next
            maxSum = Math.Max(maxSum, sum)
        Next
        Return maxSum
    End Function

    'differentSymbolsNaive("bcaba")
    Function differentSymbolsNaive(s As String) As Integer
        Dim charList As New List(Of Char)
        charList.AddRange(s.ToCharArray)
        charList.Sort()

        Dim num As Integer = 1
        Dim lastChar As Char = charList(0)
        For i As Integer = 1 To charList.Count - 1
            If charList(i) <> lastChar Then num += 1
            lastChar = charList(i)
        Next


        Return num
    End Function


    Function firstDigit(inputString As String) As Char
        For Each c As Char In inputString
            If IsNumeric(c) Then Return c
        Next
    End Function

    Function _extractEachKth(inputArray As List(Of Integer), k As Integer) As List(Of Integer)
        Dim output As New List(Of Integer)
        output.AddRange(inputArray)
        inputArray.ForEach(Sub(x)
                               If (inputArray.FindIndex(Function(y) y = x) + 1) Mod k = 0 Then output.Remove(x)
                           End Sub)
        Return output
    End Function

    'Dim aa As New List(Of Integer)
    '    aa.AddRange({1, 2, 3, 4, 5, 6, 7, 8, 9, 10})
    '    extractEachKth(aa, 3)
    Function extractEachKth(inputArray As List(Of Integer), k As Integer) As List(Of Integer)
        Dim output As New List(Of Integer)
        output.AddRange(inputArray)
        Dim int As Integer = k - 1
        Do Until int > output.Count - 1
            output.RemoveAt(int)
            int -= 1
            int += k
        Loop
        Return output
    End Function

    'Dim strList As New List(Of String)
    '    strList.AddRange({"ab", "bb", "aa"})
    '    stringsRearrangement(strList)

    Dim str As String = ""
    Function stringsRearrangement(inputArray As List(Of String)) As Boolean
        Dim testList As New List(Of String)
        testList.AddRange(inputArray)
        testList.Sort()


        Do
            If testList.Count = 0 Then Return True

            If str <> "" Then

                If fun(testList.Find(AddressOf tt)) = False Then
                    Return False
                End If

            End If

            If testList.Count = 1 Then Return True

            str = testList(0)
            Dim find As String = testList.Find(AddressOf fun)
            If find = Nothing Then Return False
            testList.Remove(str)
            testList.Remove(find)
            str = find
        Loop


    End Function

    Function fun(s As String) As Boolean
        If s = str Then Return False

        Dim num As Byte = 0
        For i As Integer = 0 To str.Length - 1
            If s(i) <> str(i) Then num += 1
            If num > 1 Then Return False
        Next

        Return True
    End Function
    Function tt(t As String) As Boolean
        Return True
    End Function

    'Dim aa As New List(Of Integer)
    'aa.AddRange({1, 1, 3, 4})
    'absoluteValuesSumMinimization(aa)

    'abs(a[0] - x) + abs(a[1] - x) + ... + abs(a[a.length - 1] - x)
    Function absoluteValuesSumMinimization(a As List(Of Integer)) As Integer
        Dim test As Integer = Integer.MaxValue
        Dim numOutput As Integer = -1

        For Each x As Integer In a

            Dim _test As Integer = 0
            For i As Integer = 0 To a.Count - 1
                _test += Math.Abs(a(i) - x)
            Next
            If _test < test Then
                test = _test
                numOutput = x

            End If
        Next

        Return numOutput
    End Function

End Module
