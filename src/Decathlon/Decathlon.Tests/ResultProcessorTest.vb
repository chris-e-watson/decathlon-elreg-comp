Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Decathlon
Imports System.IO
Imports System.Reflection



'''<summary>
'''This is a test class for ResultProcessorTest and is intended
'''to contain all ResultProcessorTest Unit Tests
'''</summary>
<TestClass()> _
Public Class ResultProcessorTest


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


#Region "Private Methods"

    ''' <summary>
    ''' Copies the test data.
    ''' </summary>
    ''' <param name="testSetName">
    ''' The name of the test set.
    ''' </param>
    ''' <returns>
    ''' The contents of the expected output file.
    ''' </returns>
    Private Function CopyTestData(ByVal testSetName As String) As String

        ' Change the working directory from SolutionDir\TestResults\Dir\Out.
        '
        Directory.SetCurrentDirectory(TestContext.TestDir)
        Directory.SetCurrentDirectory("..\..\Decathlon.Tests\bin\Debug\")

        ' Create a directory to hold the test data.
        '
        Directory.CreateDirectory("test-data\" + testSetName)

        ' Set working directory to new directory holding test data.
        '
        Directory.SetCurrentDirectory("test-data\" + testSetName)

        ' Delete any input, expected output and output files from test dir.
        '
        File.Delete("Decathlon.dat")
        File.Delete("Decathlon.out.expected")
        File.Delete("Decathlon.out")

        ' Copy input file ("Decathlon.dat") to new directory.
        '
        File.Copy("..\..\..\..\test-data\" + testSetName + "\Decathlon.dat",
                  "Decathlon.dat",
                  True)

        ' Copy output file ("Decathlon.out") to new directory (as
        ' "Decathlon.out.expected").
        '
        File.Copy("..\..\..\..\test-data\" + testSetName + "\Decathlon.out",
                  "Decathlon.out.expected",
                  True)

        ' Read expected output file.
        '
        Dim expectedOutputContents As String =
            File.ReadAllText("Decathlon.out.expected")

        Return expectedOutputContents

    End Function

#End Region


    <TestMethod()> _
    Public Sub Execute_London2012Input_ProducesLondon2012Output()

        ' Arrange.
        '
        Dim target As ResultProcessor = New ResultProcessor()
        Dim expected As String = CopyTestData("london-2012")

        ' Act.
        '
        target.Execute()
        Dim actual As String = File.ReadAllText("Decathlon.out")

        ' Assert.
        '
        Assert.AreEqual(expected, actual)

        ' Comment out above, and uncomment below to narrow down to a particular
        ' line in the output file.
        '
        'Dim expecteds = expected.Split(New String() { Environment.NewLine }, 
        '                               StringSplitOptions.None)
        'Dim actuals   = actual.Split(New String() { Environment.NewLine }, 
        '                             StringSplitOptions.None)

        'For iExpected = 0 To expecteds.Length - 1
        '    Assert.AreEqual(expecteds(iExpected), actuals(iExpected))
        'Next

    End Sub


    <TestMethod()> _
    Public Sub Execute_SampleInput_ProducesSampleOutput()

        ' Arrange.
        '
        Dim target As ResultProcessor = New ResultProcessor()
        Dim expected As String = CopyTestData("sample")

        ' Act.
        '
        target.Execute()
        Dim actual As String = File.ReadAllText("Decathlon.out")

        ' Assert.
        '
        Assert.AreEqual(expected, actual)

    End Sub

End Class
