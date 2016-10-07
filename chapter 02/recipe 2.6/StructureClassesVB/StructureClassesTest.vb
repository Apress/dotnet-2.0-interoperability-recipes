Imports System
Imports System.Runtime.InteropServices

Module StructureClassesTest

    <StructLayout(LayoutKind.Sequential)> _
    Public Class ManagedItem
        Private m_ItemId As Integer
        Private m_ItemDesc As String = String.Empty
        Private m_CategoryCode As Long
        Private m_UnitPrice As Double
        Private m_TaxCategoryId As Integer

        Public Property ItemId()
            Get
                Return m_ItemId
            End Get
            Set(ByVal value)
                m_ItemId = value
            End Set
        End Property

        Public Property ItemDesc()
            Get
                Return m_ItemDesc
            End Get
            Set(ByVal value)
                m_ItemDesc = value
            End Set
        End Property

        Public Property CategoryCode()
            Get
                Return m_CategoryCode
            End Get
            Set(ByVal value)
                m_CategoryCode = value
            End Set
        End Property

        Public Property UnitPrice()
            Get
                Return m_UnitPrice
            End Get
            Set(ByVal value)
                m_UnitPrice = value
            End Set
        End Property

        Public Property TaxCategoryId()
            Get
                Return m_TaxCategoryId
            End Get
            Set(ByVal value)
                m_TaxCategoryId = value
            End Set
        End Property

    End Class

    <DllImport("FlatAPIStructLib.DLL")> _
    Public Function LookupItemDetail( _
        <[In](), Out()> ByVal item As ManagedItem) _
        As Boolean
    End Function

    Sub Main()
        'pass a class object as an [In,Out]
        Dim item As ManagedItem = New ManagedItem()
        item.ItemId = 111

        'call the unmanaged function using [In,Out]
        Dim result As Boolean = LookupItemDetail(item)

        'show the results
        Console.WriteLine( _
            "LookupItemDetail results: {0},{1},{2},{3},{4}", _
            item.ItemId, item.ItemDesc, item.TaxCategoryId, _
            item.CategoryCode, item.UnitPrice)

        'wait for input
        Console.WriteLine("Press any key to exit")
        Console.Read()
    End Sub

End Module
