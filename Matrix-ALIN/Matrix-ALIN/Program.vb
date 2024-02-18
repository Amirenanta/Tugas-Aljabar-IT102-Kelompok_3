Imports System

Module Module1

    Sub Main()
        Dim MatrixA(2, 2) As Integer
        Dim MatrixB(2, 2) As Integer
        Dim choice As Integer

        Console.WriteLine("Matrix Calculator")
        Console.WriteLine("-----------------")
        Console.WriteLine("1. Addition")
        Console.WriteLine("2. Subtraction")
        Console.WriteLine("3. Determinant")
        Console.WriteLine("4. Cofactor Expansion")
        Console.WriteLine("5. Linear Vector Transformation")
        Console.WriteLine("-----------------")
        Console.Write("Enter your choice: ")
        choice = Convert.ToInt32(Console.ReadLine())

        Console.WriteLine("Enter values for MatrixA:")
        For i As Integer = 0 To 2
            For j As Integer = 0 To 2
                Console.Write($"Enter value for MatrixA [{i},{j}]: ")
                MatrixA(i, j) = Convert.ToInt32(Console.ReadLine())
            Next
        Next

        Select Case choice
            Case 1 ' Addition
                Console.WriteLine("Enter values for MatrixB:")
                For i As Integer = 0 To 2
                    For j As Integer = 0 To 2
                        Console.Write($"Enter value for MatrixB [{i},{j}]: ")
                        MatrixB(i, j) = Convert.ToInt32(Console.ReadLine())
                    Next
                Next
                Dim resultMatrix = MatrixAddition(MatrixA, MatrixB)
                Console.WriteLine("Result:")
                PrintMatrix(resultMatrix)
            Case 2 ' Subtraction
                Console.WriteLine("Enter values for MatrixB:")
                For i As Integer = 0 To 2
                    For j As Integer = 0 To 2
                        Console.Write($"Enter value for MatrixB [{i},{j}]: ")
                        MatrixB(i, j) = Convert.ToInt32(Console.ReadLine())
                    Next
                Next
                Dim resultMatrix = MatrixSubtraction(MatrixA, MatrixB)
                Console.WriteLine("Result:")
                PrintMatrix(resultMatrix)
            Case 3 ' Determinant
                Dim determinant = CalculateDeterminant(MatrixA)
                Console.WriteLine($"Determinant of MatrixA: {determinant}")
            Case 4 ' Cofactor Expansion
                Dim cofactorMatrix = CalculateCofactorMatrix(MatrixA)
                Console.WriteLine("Cofactor Matrix:")
                PrintMatrix(cofactorMatrix)
            Case 5 ' Linear Vector Transformation
               Dim linearVector = LinearVectorTransformation(MatrixA)
                Console.WriteLine("Linear Vector Transformation:")
                PrintMatrix(linearVector)
            Case Else
                Console.WriteLine("Invalid choice!")
        End Select

        Console.ReadLine()
    End Sub

    Function MatrixAddition(matrixA As Integer(,), matrixB As Integer(,)) As Integer(,)
        Dim result(2, 2) As Integer
        For i As Integer = 0 To 2
            For j As Integer = 0 To 2
                result(i, j) = matrixA(i, j) + matrixB(i, j)
            Next
        Next
        Return result
    End Function

    Function MatrixSubtraction(matrixA As Integer(,), matrixB As Integer(,)) As Integer(,)
        Dim result(2, 2) As Integer
        For i As Integer = 0 To 2
            For j As Integer = 0 To 2
                result(i, j) = matrixA(i, j) - matrixB(i, j)
            Next
        Next
        Return result
    End Function

    Function CalculateDeterminant(matrix As Integer(,)) As Integer
        Dim determinant As Integer
        determinant = matrix(0, 0) * (matrix(1, 1) * matrix(2, 2) - matrix(1, 2) * matrix(2, 1)) -
                      matrix(0, 1) * (matrix(1, 0) * matrix(2, 2) - matrix(1, 2) * matrix(2, 0)) +
                      matrix(0, 2) * (matrix(1, 0) * matrix(2, 1) - matrix(1, 1) * matrix(2, 0))
        Return determinant
    End Function

    Function CalculateCofactorMatrix(matrix As Integer(,)) As Integer(,)
        Dim cofactorMatrix(2, 2) As Integer
        For i As Integer = 0 To 2
            For j As Integer = 0 To 2
                cofactorMatrix(i, j) = Math.Pow(-1, i + j) * CalculateMinor(matrix, i, j)
            Next
        Next
        Return cofactorMatrix
    End Function
    Function LinearVectorTransformation(matrix As Double(,), vector As Double()) As Double()
        Dim rows = matrix.GetLength(0)
        Dim cols = matrix.GetLength(1)

        If cols <> vector.Length Then
            Throw New Exception("Matrix and vector dimensions do not match for multiplication.")
        End If

        Dim result(rows - 1) As Double

        For i As Integer = 0 To rows - 1
            For j As Integer = 0 To cols - 1
                result(i) += matrix(i, j) * vector(j)
            Next
        Next

        Return result
    End Function
    Function CalculateMinor(matrix As Integer(,), row As Integer, col As Integer) As Integer
        Dim minorMatrix(1, 1) As Integer
        Dim minorIndexI As Integer = 0
        Dim minorIndexJ As Integer = 0
        For i As Integer = 0 To 2
            If i <> row Then
                For j As Integer = 0 To 2
                    If j <> col Then
                        minorMatrix(minorIndexI, minorIndexJ) = matrix(i, j)
                        minorIndexJ += 1
                    End If
                Next
                minorIndexI += 1
                minorIndexJ = 0
            End If
        Next
        Dim minor As Integer = minorMatrix(0, 0) * minorMatrix(1, 1) - minorMatrix(0, 1) * minorMatrix(1, 0)
        Return minor
    End Function

    Sub PrintMatrix(matrix As Integer(,))
        For i As Integer = 0 To 2
            For j As Integer = 0 To 2
                Console.Write(matrix(i, j) & " ")
            Next
            Console.WriteLine()
        Next
    End Sub

End Module

