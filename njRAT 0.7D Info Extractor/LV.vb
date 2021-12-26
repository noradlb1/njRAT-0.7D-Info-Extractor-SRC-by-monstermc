Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Public Class LV
    Inherits ListView

    Public Sub New()

        AddHandler MyBase.ColumnClick, AddressOf ColumnClick1
        LV.ENCAddToList11(Me)
        LV.ENCAddToList11(Me)
        LV.ENCAddToList(Me)
        Me.AllowDrop = False
        Me.Font = New Font("arial", 8.0F, FontStyle.Bold)
        Me.Dock = DockStyle.Fill
        Me.FullRowSelect = True
        Me.View = View.Details
        Me.OwnerDraw = True
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer, True)
        Me.SetStyle(ControlStyles.EnableNotifyMessage, True)
    End Sub

    Public Sub ColumnClick1(sender As Object, e As ColumnClickEventArgs)
        'Dim columnHeader As ColumnHeader = CType(NewLateBinding.LateGet(sender, Nothing, "Columns", New Object() {e.Column}, Nothing, Nothing, Nothing), ColumnHeader)
        'Dim sortOrder As SortOrder
        'If Me.m_SortingColumn Is Nothing Then
        '    sortOrder = sortOrder.Ascending
        'Else
        '    If columnHeader.Equals(Me.m_SortingColumn) Then
        '        If Me.m_SortingColumn.Text.StartsWith(ChrW(9650)) Then
        '            sortOrder = sortOrder.Descending
        '        Else
        '            sortOrder = sortOrder.Ascending
        '        End If
        '    Else
        '        sortOrder = sortOrder.Ascending
        '    End If
        '    Me.m_SortingColumn.Text = Me.m_SortingColumn.Text.Substring(1)
        'End If
        'Me.m_SortingColumn = columnHeader
        'If sortOrder = sortOrder.Ascending Then
        '    Me.m_SortingColumn.Text = ChrW(9650) + Me.m_SortingColumn.Text
        'Else
        '    Me.m_SortingColumn.Text = ChrW(9660) + Me.m_SortingColumn.Text
        'End If
        'If sender IsNot Nothing Then
        '    NewLateBinding.LateSet(sender, Nothing, "ListViewItemSorter", New Object() {New LV.clsListviewSorter(e.Column, sortOrder)}, Nothing, Nothing)
        '    NewLateBinding.LateCall(sender, Nothing, "Sort", New Object(0 - 1) {}, Nothing, Nothing, Nothing, True)
        '    NewLateBinding.LateSet(sender, Nothing, "ListViewItemSorter", New Object()() {Nothing}, Nothing, Nothing)
        'End If
    End Sub

    <DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso Me.icontainer_0 IsNot Nothing Then
                Me.icontainer_0.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    <DebuggerNonUserCode()>
    Private Shared Sub ENCAddToList(object_0 As Object)
        Dim eNCList As List(Of WeakReference) = LV._ENCList
        Dim obj As List(Of WeakReference) = eNCList
        ' The following expression was wrapped in a checked-statement
        SyncLock obj
            If LV._ENCList.Count = LV._ENCList.Capacity Then
                Dim num As Integer = 0
                Dim num2 As Integer = LV._ENCList.Count - 1
                For i As Integer = 0 To num2
                    Dim weakReference As WeakReference = LV._ENCList(i)
                    If weakReference.IsAlive Then
                        If i <> num Then
                            LV._ENCList(num) = LV._ENCList(i)
                        End If
                        num += 1
                    End If
                Next
                LV._ENCList.RemoveRange(num, LV._ENCList.Count - num)
                LV._ENCList.Capacity = LV._ENCList.Count
            End If
            LV._ENCList.Add(New WeakReference(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(object_0)))))
        End SyncLock
    End Sub

    Protected Overrides Sub OnColumnWidthChanged(e As ColumnWidthChangedEventArgs)
        MyBase.OnColumnWidthChanged(e)
    End Sub

    Protected Overrides Sub OnDrawColumnHeader(e As DrawListViewColumnHeaderEventArgs)
        Dim num As Integer = 0
        e.Graphics.Clear(Me.BackColor)
        Dim num2 As Integer = 0
        ' The following expression was wrapped in a checked-statement
        Try
            Dim enumerator As IEnumerator = Me.Columns.GetEnumerator()
            While enumerator.MoveNext()
                Dim columnHeader As ColumnHeader = CType(enumerator.Current, ColumnHeader)
                num2 += columnHeader.Width
            End While
        Finally
            Dim enumerator As IEnumerator
            If TypeOf enumerator Is IDisposable Then
                TryCast(enumerator, IDisposable).Dispose()
            End If
        End Try
        e.Graphics.FillRectangle(New Pen(Me.BackColor).Brush, 0, 0, num2, CInt(Math.Round(Math.Round(Math.Round(CDec(e.Bounds.Height) / 3.0)))))
        e.Graphics.FillRectangle(New Pen(Me.BackColor).Brush, 0, CInt(Math.Round(Math.Round(Math.Round(CDec(e.Bounds.Height) / 3.0)))), num2, CInt(Math.Round(Math.Round(Math.Round(CDec(e.Bounds.Height) / 3.0)))))
        e.Graphics.FillRectangle(New Pen(Me.BackColor).Brush, 0, CInt(Math.Round(Math.Round(Math.Round(CDec(e.Bounds.Height) / 3.0)))) * 2, num2, CInt(Math.Round(Math.Round(Math.Round(CDec(e.Bounds.Height) / 3.0)))))
        Try
            Dim enumerator2 As IEnumerator = Me.Columns.GetEnumerator()
            While enumerator2.MoveNext()
                Dim columnHeader2 As ColumnHeader = CType(enumerator2.Current, ColumnHeader)
                Dim r As Rectangle = New Rectangle(num, e.Bounds.Y, columnHeader2.Width, e.Bounds.Height)
                Dim stringFormat As StringFormat = New StringFormat()
                stringFormat.FormatFlags = StringFormatFlags.LineLimit
                stringFormat.Trimming = StringTrimming.Character
                stringFormat.Alignment = StringAlignment.Center
                e.Graphics.DrawString(columnHeader2.Text, Me.Font, New Pen(Me.ForeColor).Brush, r, stringFormat)
                e.Graphics.DrawLine(New Pen(Me.ForeColor), num + columnHeader2.Width, e.Bounds.Y, num + columnHeader2.Width, e.Bounds.Y + e.Bounds.Height)
                num += columnHeader2.Width
            End While
        Finally
            Dim enumerator2 As IEnumerator
            If TypeOf enumerator2 Is IDisposable Then
                TryCast(enumerator2, IDisposable).Dispose()
            End If
        End Try
        e.DrawDefault = False
        MyBase.OnDrawColumnHeader(e)
    End Sub

    Protected Overrides Sub OnDrawItem(e As DrawListViewItemEventArgs)
        e.DrawDefault = True
        MyBase.OnDrawItem(e)
    End Sub

    Protected Overrides Sub OnDrawSubItem(e As DrawListViewSubItemEventArgs)
        e.DrawDefault = True
        MyBase.OnDrawSubItem(e)
    End Sub

    Protected Overrides Sub OnNotifyMessage(m As Message)
        If m.Msg <> 20 Then
            MyBase.OnNotifyMessage(m)
        End If
    End Sub

    <DebuggerNonUserCode()>
    Public Shared Sub ENCAddToList11(object_0 As Object)
        Dim obj As List(Of WeakReference) = LV._ENCList
        ' The following expression was wrapped in a checked-statement
        SyncLock obj
            If LV._ENCList.Count = LV._ENCList.Capacity Then
                Dim num As Integer = 0
                Dim arg_37_0 As Integer = 0
                Dim num2 As Integer = LV._ENCList.Count - 1
                Dim num3 As Integer = arg_37_0
                While True
                    Dim arg_7D_0 As Integer = num3
                    Dim num4 As Integer = num2
                    If arg_7D_0 > num4 Then
                        Exit While
                    End If
                    Dim weakReference As WeakReference = LV._ENCList(num3)
                    If weakReference.IsAlive Then
                        If num3 <> num Then
                            LV._ENCList(num) = LV._ENCList(num3)
                        End If
                        num += 1
                    End If
                    num3 += 1
                End While
                LV._ENCList.RemoveRange(num, LV._ENCList.Count - num)
                LV._ENCList.Capacity = LV._ENCList.Count
            End If
            LV._ENCList.Add(New WeakReference(RuntimeHelpers.GetObjectValue(object_0)))
        End SyncLock

    End Sub

    Private icontainer_0 As IContainer

    Private m_SortingColumn As ColumnHeader

    Private Shared _ENCList As List(Of WeakReference) = New List(Of WeakReference)()

    Private Shared __ENCList11 As List(Of WeakReference) = New List(Of WeakReference)()

    Public Class clsListviewSorter

        'Dim IComparer As IComparer

        Public Sub New(int_0 As Integer, sortOrder_0 As SortOrder)
            Me.m_ColumnNumber = int_0
            Me.m_SortOrder = sortOrder_0
        End Sub

        Public Function Compare(x As Object, y As Object) As Integer
            On Error Resume Next
            Dim listViewItem As ListViewItem = CType(x, ListViewItem)
            Dim listViewItem2 As ListViewItem = CType(y, ListViewItem)
            Dim text As String
            If listViewItem.SubItems.Count <= Me.m_ColumnNumber Then
                text = ""
            Else
                text = listViewItem.SubItems(Me.m_ColumnNumber).Text
            End If
            Dim text2 As String
            If listViewItem2.SubItems.Count <= Me.m_ColumnNumber Then
                text2 = ""
            Else
                text2 = listViewItem2.SubItems(Me.m_ColumnNumber).Text
            End If
            Dim result As Integer
            If Me.m_SortOrder = SortOrder.Ascending Then
                If Versioned.IsNumeric(text) And Versioned.IsNumeric(text2) Then
                    result = Conversion.Val(text).CompareTo(Conversion.Val(text2))
                Else
                    If Information.IsDate(text) And Information.IsDate(text2) Then
                        result = DateTime.Parse(text).CompareTo(DateTime.Parse(text2))
                    Else
                        result = String.Compare(text, text2)
                    End If
                End If
            Else
                If Versioned.IsNumeric(text) And Versioned.IsNumeric(text2) Then
                    result = Conversion.Val(text2).CompareTo(Conversion.Val(text))
                Else
                    If Information.IsDate(text) And Information.IsDate(text2) Then
                        result = DateTime.Parse(text2).CompareTo(DateTime.Parse(text))
                    Else
                        result = String.Compare(text2, text)
                    End If
                End If
            End If
            Return result
        End Function

        Private m_ColumnNumber As Integer

        Private m_SortOrder As SortOrder
    End Class
End Class
