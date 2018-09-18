'Dim t As New Tree(Of Integer)
't = newTree("(5(6)(7))", type.int)
Public Class Tree(Of T)

    Public value As T
    Public left As Tree(Of T)
    Public right As Tree(Of T)
    Public Sub New()
    End Sub
    Public Sub New(x As T)
        MyBase.New()
        value = x
        left = Nothing
        right = Nothing
    End Sub

End Class
Module _Tree
    Enum type
        int
        str
    End Enum
    Public Function newTree(inputStr As String, t As type)
        If t = type.int Then
            Dim output As New Tree(Of Integer)
            output = bracketsInStringInt(inputStr)
            checkInt(output)
            Return output
        ElseIf t = type.str Then
            Dim output As New Tree(Of String)
            output = bracketsInString(inputStr)
            check(output)
            Return output
        End If

    End Function
    Private Function bracketsInString(ByRef str As String) As Tree(Of String)
        If str(0) <> "(" Then Return Nothing
        str = str.Remove(0, 1)

        Dim output As New Tree(Of String)
        Dim tmp As Tree(Of String) = output
        tmp.value = ""

        Do
            Select Case str(0)
                Case "("
                    If tmp.left Is Nothing Then
                        tmp.left = bracketsInString(str)
                    Else
                        tmp.right = bracketsInString(str)
                    End If

                    str = str.Remove(0, 1)
                Case ")"
                    Return output

                Case Else
                    tmp.value += str(0)
                    str = str.Remove(0, 1)
            End Select
        Loop

    End Function
    Private Function bracketsInStringInt(ByRef str As String) As Tree(Of Integer)
        If str(0) <> "(" Then Return Nothing
        str = str.Remove(0, 1)

        Dim output As New Tree(Of Integer)
        Dim tmp As Tree(Of Integer) = output
        Dim value As String = ""

        Do
            Select Case str(0)
                Case "("
                    If tmp.left Is Nothing Then
                        tmp.left = bracketsInStringInt(str)
                    Else
                        tmp.right = bracketsInStringInt(str)
                    End If

                    str = str.Remove(0, 1)
                Case ")"
                    tmp.value = Val(value)
                    Return output

                Case Else
                    value += str(0)
                    str = str.Remove(0, 1)
            End Select
        Loop

    End Function
    Private Sub check(ByRef inputTree As Tree(Of String))
        If Not inputTree.left Is Nothing Then check(inputTree.left)
        If Not inputTree.right Is Nothing Then check(inputTree.right)
        If inputTree.value = "" AndAlso inputTree.left Is Nothing AndAlso inputTree.right Is Nothing Then inputTree = Nothing
    End Sub
    Private Sub checkInt(ByRef inputTree As Tree(Of Integer))
        If Not inputTree.left Is Nothing Then checkInt(inputTree.left)
        If Not inputTree.right Is Nothing Then checkInt(inputTree.right)
        If inputTree.value = 0 AndAlso inputTree.left Is Nothing AndAlso inputTree.right Is Nothing Then inputTree = Nothing
    End Sub
End Module

