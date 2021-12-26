Imports Mono.Cecil
Imports Mono.Cecil.Cil

' By : monstermc
' YouTube Channel : مجهول عرربي

Public Class Form1
    Public serverPath As String

    Private Sub AddServerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddServerToolStripMenuItem.Click
        Dim openFile As New OpenFileDialog()
        If openFile.ShowDialog = DialogResult.OK Then
            serverPath = openFile.FileName
        End If

        If serverPath <> "" Then
            Dim def1 As AssemblyDefinition = AssemblyDefinition.ReadAssembly(serverPath) 'read server file
            Dim def2 As TypeDefinition
            Dim Values As String = ""
            Dim my_Array() As String = {"Host", "Port", "Version", "EXE Name", "Directory", "Registry Name", "BSOD", "Copy To Directory", "Copy To StartUp", "Registry StartUp", "Registry Path"}
            Dim L As ListView = Me.ListView1

            For i = 0 To my_Array.Length - 1
                L.Items.Add(my_Array(i))
            Next

            For Each def2 In def1.MainModule.GetTypes
                Dim def3 As MethodDefinition
                Dim iNum As IEnumerator(Of Instruction) = Nothing

                For Each def3 In def2.Methods
                    If (def3.Name = ".cctor") Then
                        Try
                            iNum = def3.Body.Instructions.GetEnumerator
                            Do While iNum.MoveNext
                                Dim currentOP As Instruction = iNum.Current
                                If (currentOP.OpCode.Code = Code.Ldstr) Then
                                    Dim strValues As String = currentOP.Operand.ToString
                                    Values += strValues + "!"
                                End If
                            Loop
                        Finally
                            iNum.Dispose()
                        End Try
                    End If
                Next

            Next

            Dim SPL() As String = Split(Values, "!") 'Split values
            L.Items(0).SubItems.Add(SPL(5)) 'Host
            L.Items(1).SubItems.Add(SPL(6)) 'Port
            L.Items(2).SubItems.Add(SPL(1)) 'Version
            L.Items(3).SubItems.Add(SPL(2)) 'Exe Name
            L.Items(4).SubItems.Add(SPL(3)) 'Directory
            L.Items(5).SubItems.Add(SPL(4)) 'Registry Name
            L.Items(6).SubItems.Add(SPL(8)) 'BSOD
            L.Items(7).SubItems.Add(SPL(9)) 'Copy To Directory
            L.Items(8).SubItems.Add(SPL(10)) 'Copy To StartUp
            L.Items(9).SubItems.Add(SPL(11)) 'Registry StartUp
            L.Items(10).SubItems.Add(SPL(12)) 'Regsitry Path
        End If
    End Sub

    Private Sub ClearListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearListToolStripMenuItem.Click
        ListView1.Items.Clear()
    End Sub
End Class
