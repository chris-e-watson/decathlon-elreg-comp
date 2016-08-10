Imports System

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports System.Globalization
Imports Decathlon



'''<summary>
'''This is a test class for OutputDataItemTest and is intended
'''to contain all OutputDataItemTest Unit Tests
'''</summary>
<TestClass()> _
Public Class OutputDataItemTest


    Private testContextInstance As TestContext

    '''<summary>
    '''Gets or sets the test context which provides
    '''information about and functionality for the current test run.
    '''</summary>
    Public Property TestContext() As TestContext
        Get
            Return testContextInstance
        End Get
        Set(value As TestContext)
            testContextInstance = value
        End Set
    End Property

#Region "Additional test attributes"
    '
    'You can use the following additional attributes as you write your tests:
    '
    'Use ClassInitialize to run code before running the first test in the class
    '<ClassInitialize()>  _
    'Public Shared Sub MyClassInitialize(ByVal testContext As TestContext)
    'End Sub
    '
    'Use ClassCleanup to run code after all tests in a class have run
    '<ClassCleanup()>  _
    'Public Shared Sub MyClassCleanup()
    'End Sub
    '
    'Use TestInitialize to run code before running each test
    '<TestInitialize()>  _
    'Public Sub MyTestInitialize()
    'End Sub
    '
    'Use TestCleanup to run code after each test has run
    '<TestCleanup()>  _
    'Public Sub MyTestCleanup()
    'End Sub
    '
#End Region


    ''' <summary>
    ''' A test to verify the file format is correct.
    ''' </summary>
    <TestMethod()> _
    Public Sub ToString_FileFormat_Formatted()
        
        ' Arrange.
        '
        Dim target As IFormattable = New OutputDataItem("ENTRANT-NAME", 1234)
        Dim format As String = "F4"
        Dim formatProvider As IFormatProvider = CultureInfo.InvariantCulture
        Dim expected As String = "ENTRANT-NAME         1234"
        
        ' Act.
        '
        Dim actual As String
        actual = target.ToString(format, formatProvider)

        ' Assert.
        '
        Assert.AreEqual(expected, actual)

    End Sub


    ''' <summary>
    ''' A test to verify the file format length is correct.
    ''' </summary>
    <TestMethod()> _
    Public Sub ToString_FileFormat_LengthIs25()
        
        ' Arrange.
        '
        Dim target As IFormattable = New OutputDataItem("ENTRANT-NAME", 1234)
        Dim format As String = "F4"
        Dim formatProvider As IFormatProvider = CultureInfo.InvariantCulture
        Dim expected As Integer = 25
        
        ' Act.
        '
        Dim actual As Integer
        actual = target.ToString(format, formatProvider).Length

        ' Assert.
        '
        Assert.AreEqual(expected, actual)

    End Sub


    <TestMethod()> _
    <ExpectedException(GetType(ArgumentException))>
    Public Sub ToString_FileFormatStringHasNonNumericPointsLength_ThrowsArgumentException()
        
        ' Arrange.
        '
        Dim target As IFormattable = New OutputDataItem("ENTRANT-NAME", 1234)
        Dim format As String = "FX" ' Supposed to be "F0", e.g. "F4".
        Dim formatProvider As IFormatProvider = CultureInfo.InvariantCulture
        
        ' Act.
        '
        Dim actual As String
        actual = target.ToString(format, formatProvider)

        ' Assert.
        '
        ' See ExpectedException attribute.

    End Sub


    <TestMethod()> _
    <ExpectedException(GetType(ArgumentException))>
    Public Sub ToString_FileFormatStringIsMissingPointsLength_ThrowsArgumentException()
        
        ' Arrange.
        '
        Dim target As IFormattable = New OutputDataItem("ENTRANT-NAME", 1234)
        Dim format As String = "F" ' Supposed to be "F0", e.g. "F4".
        Dim formatProvider As IFormatProvider = CultureInfo.InvariantCulture
        
        ' Act.
        '
        Dim actual As String
        actual = target.ToString(format, formatProvider)

        ' Assert.
        '
        ' See ExpectedException attribute.

    End Sub


    <TestMethod()> _
    <ExpectedException(GetType(FormatException))>
    Public Sub ToString_UnsupportedFormatString_ThrowsFormatException()
        
        ' Arrange.
        '
        Dim target As IFormattable = New OutputDataItem("ENTRANT-NAME", 1234)
        Dim format As String = "X" ' Supported: G, F0.
        Dim formatProvider As IFormatProvider = CultureInfo.InvariantCulture
        
        ' Act.
        '
        Dim actual As String
        actual = target.ToString(format, formatProvider)

        ' Assert.
        '
        ' See ExpectedException attribute.

    End Sub

End Class
