Module intro
    Sub main()
        Console.WriteLine("please type the num of your module")

        Do
            Dim input = Console.ReadLine
            Console.WriteLine()
            If IsNumeric(input) Then
                Select Case Val(input)
                    Case 1
                        Module1.Main()
                    Case 2
                        Module2.main()
                    Case 3
                        Module3.main()
                    Case 33
                        Module33.main()
                    Case 333
                        Module333.main()
                    Case 4
                        Module4.main()
                    Case 5
                        Module5.main()
                    Case 6
                        Module6.main()
                    Case 66
                        Module66.main()
                    Case 666
                        Module666.main()
                    Case 7
                        Module7.main()
                    Case Else
                        Console.WriteLine("please type then num of your module")
                End Select
            Else

                Console.WriteLine("please type then num of your module")
            End If
        Loop



    End Sub
End Module
