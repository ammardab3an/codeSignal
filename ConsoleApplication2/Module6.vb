Module Module6
    Sub main()
        'Dim t As New Tree(Of Integer)
        't = newTree("(5(6)(7))", type.int)

    End Sub

    'Function findNodeInTree(ByRef inputTree As Tree(Of Integer), int As Integer) As Tree(Of Integer)
    '    If inputTree Is Nothing Then Return Nothing
    '    Dim tmp = inputTree
    '    Do
    '        If tmp.value = int Then Return tmp
    '        If int > tmp.value Then
    '            If tmp.right Is Nothing Then Return Nothing
    '            tmp = tmp.right
    '        Else
    '            If tmp.left Is Nothing Then Return Nothing
    '            tmp = tmp.left
    '        End If
    '    Loop
    'End Function

    Function restoreBinaryTree(inorder As List(Of Integer), preorder As List(Of Integer)) As Tree(Of Integer)
        If inorder.Count = 0 Then Return Nothing

        Dim root = preorder(0)
        Dim tree = New Tree(Of Integer)(root)
        Dim left_len = inorder.IndexOf(root)

        tree.left = restoreBinaryTree(inorder.GetRange(0, left_len), _
                                      preorder.GetRange(1, left_len))
        tree.right = restoreBinaryTree(inorder.GetRange(left_len + 1, inorder.Count - left_len - 1), _
                                       preorder.GetRange(left_len + 1, preorder.Count - left_len - 1))
        Return tree
    End Function
    Function isSubtree(t1 As Tree(Of Integer), t2 As Tree(Of Integer)) As Boolean
        If t1 Is Nothing And t2 Is Nothing Then Return True
        If t1 Is Nothing AndAlso Not t2 Is Nothing Then Return False
        If Not t1 Is Nothing AndAlso t2 Is Nothing Then Return True

        If areTheSame(t1, t2) = True Then Return True

        If Not t1.left Is Nothing Then If isSubtree(t1.left, t2) = True Then Return True
        If Not t1.right Is Nothing Then If isSubtree(t1.right, t2) = True Then Return True

    End Function
    Function areTheSame(t1 As Tree(Of Integer), t2 As Tree(Of Integer)) As Boolean
        If t1 Is Nothing And t2 Is Nothing Then Return True
        If t1 Is Nothing Or t2 Is Nothing Then Return False

        Dim bol As Boolean = True
        If Not t1.left Is Nothing Or Not t2.left Is Nothing Then bol = areTheSame(t1.left, t2.left)
        Dim _bol As Boolean = True
        If Not t1.right Is Nothing Or Not t2.right Is Nothing Then _bol = areTheSame(t1.right, t2.right)

        If t1.value = t2.value AndAlso bol = True AndAlso _bol = True Then Return True
    End Function

    Function kthSmallestInBST(t As Tree(Of Integer), k As Integer) As Integer
        Dim test As New List(Of Integer)
        addLiftRight(test, t)
        test.Sort()
        Return test(k - 1)
    End Function
    Sub addLiftRight(ByRef inputList As List(Of Integer), ByVal inputTree As Tree(Of Integer))
        If Not inputTree.left Is Nothing Then addLiftRight(inputList, inputTree.left)
        If Not inputTree.right Is Nothing Then addLiftRight(inputList, inputTree.right)
        inputList.Add(inputTree.value)
    End Sub

    Function findProfession(level As Integer, pos As Integer) As String
        Dim test As String = Convert.ToString(pos - 1, 2)
        Dim num As Integer = test.Length - test.Replace("1", "").Length

        Return IIf(num Mod 2 = 0, "Engineer", "Doctor")

    End Function

    Function hasPathWithGivenSum(t As Tree(Of Integer), s As Integer) As Boolean

        If t Is Nothing AndAlso s = 0 Then Return True
        If t Is Nothing Then Return False

        If Not t.left Is Nothing And Not t.right Is Nothing Then
            Return hasPathWithGivenSum(t.left, s - t.value) OrElse _
                    hasPathWithGivenSum(t.right, s - t.value)

        ElseIf Not t.left Is Nothing Then
            Return hasPathWithGivenSum(t.left, s - t.value)

        Else
            Return hasPathWithGivenSum(t.right, s - t.value)
        End If

    End Function

End Module
