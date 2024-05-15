Imports System

Public Class Employee
    Private _id As Integer
    Private _name As String
    Private _designation As String

    Public Sub New(id As Integer, name As String, designation As String)
        _id = id
        _name = name
        _designation = designation
    End Sub

    Public ReadOnly Property ID As Integer
        Get
            Return _id
        End Get
    End Property

    Public Property Name As String
        Get
            Return _name
        End Get
        Set(value As String)
            _name = value
        End Set
    End Property

    Public Property Designation As String
        Get
            Return _designation
        End Get
        Set(value As String)
            _designation = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return $"ID: {_id}, Name: {_name}, Designation: {_designation}"
    End Function
End Class

Module Program
    Dim employees As New List(Of Employee)()

    Sub Main(args As String())
        While True
            Console.WriteLine("Employee Management System")
            Console.WriteLine("1. Add Employee")
            Console.WriteLine("2. Delete Employee")
            Console.WriteLine("3. Display All Employees")
            Console.WriteLine("4. Update Employee Details")
            Console.WriteLine("5. Exit")
            Console.Write("Enter your choice: ")

            Dim choice As Integer = Convert.ToInt32(Console.ReadLine())

            Select Case choice
                Case 1
                    AddEmployee()
                Case 2
                    DeleteEmployee()
                Case 3
                    DisplayEmployees()
                Case 4
                    UpdateEmployee()
                Case 5
                    Exit While
                Case Else
                    Console.WriteLine("Invalid choice. Please enter a valid option.")
            End Select
        End While
    End Sub

    Sub AddEmployee()
        Console.WriteLine("Enter Employee ID:")
        Dim id As Integer = Convert.ToInt32(Console.ReadLine())
        Console.WriteLine("Enter Employee Name:")
        Dim name As String = Console.ReadLine()
        Console.WriteLine("Enter Employee Designation:")
        Dim designation As String = Console.ReadLine()

        Dim emp As New Employee(id, name, designation)
        employees.Add(emp)

        Console.WriteLine("Employee added successfully.")
    End Sub

    Sub DeleteEmployee()
        Console.WriteLine("Enter Employee ID to delete:")
        Dim idToDelete As Integer = Convert.ToInt32(Console.ReadLine())
        Dim empToRemove As Employee = employees.Find(Function(emp) emp.ID = idToDelete)

        If empToRemove IsNot Nothing Then
            employees.Remove(empToRemove)
            Console.WriteLine("Employee deleted successfully.")
        Else
            Console.WriteLine("Employee not found.")
        End If
    End Sub

    Sub DisplayEmployees()
        If employees.Count = 0 Then
            Console.WriteLine("No employees found.")
        Else
            Console.WriteLine("List of Employees:")
            For Each emp As Employee In employees
                Console.WriteLine(emp.ToString())
            Next
        End If
    End Sub

    Sub UpdateEmployee()
        Console.WriteLine("Enter Employee ID to update:")
        Dim idToUpdate As Integer = Convert.ToInt32(Console.ReadLine())
        Dim empToUpdate As Employee = employees.Find(Function(emp) emp.ID = idToUpdate)

        If empToUpdate IsNot Nothing Then
            Console.WriteLine("Enter updated Employee Name:")
            Dim newName As String = Console.ReadLine()
            Console.WriteLine("Enter updated Employee Designation:")
            Dim newDesignation As String = Console.ReadLine()

            empToUpdate.Name = newName
            empToUpdate.Designation = newDesignation

            Console.WriteLine("Employee details updated successfully.")
        Else
            Console.WriteLine("Employee not found.")
        End If
    End Sub
End Module
