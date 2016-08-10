Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Decathlon
Imports System.IO



'''<summary>
'''This is a test class for DecathlonTest and is intended
'''to contain all DecathlonTest Unit Tests
'''</summary>
<TestClass()> _
Public Class DecathlonTest


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
    ''' A test to verify that the program can be compiled to Decathlon.exe from
    ''' the single source (Decathlon.vb) that must be the only file submitted
    ''' for judging.
    ''' </summary>
    ''' <remarks>
    ''' We will call "vbc.exe Decathlon.vb", and verify that "Decathlon.exe" is
    ''' the output.
    ''' </remarks>
    <TestMethod()>
    Public Sub Decathlon_CompilesFromSingleSourceFile_Compiled()

        '
        ' Arrange.
        '

        ' This could be cleverer, but it'll do.
        '
        Dim compilerFilePath As String =
            "C:\Windows\Microsoft.NET\Framework\v4.0.30319\vbc.exe"

        ' Folder with source file.
        '
        Dim sourceDirPath = "..\..\..\Decathlon"

        ' The name of single source file.
        '
        Dim sourceFileName = "Decathlon.vb"

        ' The name of the compiled program file.
        '
        Dim outputFileName = "Decathlon.exe"

        ' Full path to compiled program file.
        '
        Dim outputFilePath = Path.Combine(sourceDirPath, outputFileName)


        ' Delete Decathlon.exe if present.
        '
        If File.Exists(outputFilePath) Then

            Debug.Print("Deleting file: ""{0}""", outputFilePath)
            File.Delete(outputFilePath)

        End If


        ' Configure the compiler process.
        '
        Dim compileProcessStartInfo = 
            New ProcessStartInfo(compilerFilePath, sourceFileName) With
        {
            .CreateNoWindow   = True,
            .UseShellExecute  = False,
            .WindowStyle      = ProcessWindowStyle.Hidden,
            .WorkingDirectory = sourceDirPath
        }


        '
        ' Act.
        '

        ' Compile!
        '
        Using compileProcess = Process.Start(compileProcessStartInfo)

            While Not compileProcess.HasExited

                compileProcess.WaitForExit(100)

            End While

        End Using


        '
        ' Assert.
        '

        ' Did we get a compiled Decathlon.exe file?
        '
        If Not File.Exists(outputFilePath) Then

            Assert.Fail("Output file not found: ""{0}""", outputFilePath)

        End If

    End Sub
End Class
