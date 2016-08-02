Imports System

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Decathlon



'''<summary>
'''This is a test class for PointsCalculatorTest and is intended
'''to contain all PointsCalculatorTest Unit Tests
'''</summary>
<TestClass()> _
Public Partial Class PointsCalculatorTest


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
            testContextInstance = Value
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


    <TestMethod()> _
    Public Sub CalculatePoints_DiscusScoreIsBelowBConstantValue_ZeroPoints()
        
        ' Arrange.
        '
        Dim eventType As EventType = EventType.Discus
        Dim score As Decimal = CDec(3.9)
        Dim target As PointsCalculator = New PointsCalculator(eventType, score)
        Dim expected As Long = 0
        
        ' Act.
        '
        target.CalculatePoints()
        Dim actual As Long = target.Points

        ' Assert.
        '
        Assert.AreEqual(expected, actual)

    End Sub


    <TestMethod()> _
    Public Sub CalculatePoints_FifteenHundredMetreSprintScoreIsBelowBConstantValue_ZeroPoints()
        
        ' Arrange.
        '
        Dim eventType As EventType = EventType.FifteenHundredMetreSprint
        Dim score As Decimal = CDec(480.1)
        Dim target As PointsCalculator = New PointsCalculator(eventType, score)
        Dim expected As Long = 0
        
        ' Act.
        '
        target.CalculatePoints()
        Dim actual As Long = target.Points

        ' Assert.
        '
        Assert.AreEqual(expected, actual)

    End Sub


    <TestMethod()> _
    Public Sub CalculatePoints_FourHundredMetreSprintScoreIsBelowBConstantValue_ZeroPoints()
        
        ' Arrange.
        '
        Dim eventType As EventType = EventType.FourHundredMetreSprint
        Dim score As Decimal = CDec(82.1)
        Dim target As PointsCalculator = New PointsCalculator(eventType, score)
        Dim expected As Long = 0
        
        ' Act.
        '
        target.CalculatePoints()
        Dim actual As Long = target.Points

        ' Assert.
        '
        Assert.AreEqual(expected, actual)

    End Sub


    <TestMethod()> _
    Public Sub CalculatePoints_HighJumpScoreIsBelowBConstantValue_ZeroPoints()
        
        ' Arrange.
        '
        Dim eventType As EventType = EventType.HighJump
        Dim score As Decimal = CDec(74.9)
        Dim target As PointsCalculator = New PointsCalculator(eventType, score)
        Dim expected As Long = 0
        
        ' Act.
        '
        target.CalculatePoints()
        Dim actual As Long = target.Points

        ' Assert.
        '
        Assert.AreEqual(expected, actual)

    End Sub


    <TestMethod()> _
    Public Sub CalculatePoints_JavelinScoreIsBelowBConstantValue_ZeroPoints()
        
        ' Arrange.
        '
        Dim eventType As EventType = EventType.Javelin
        Dim score As Decimal = CDec(6.9)
        Dim target As PointsCalculator = New PointsCalculator(eventType, score)
        Dim expected As Long = 0
        
        ' Act.
        '
        target.CalculatePoints()
        Dim actual As Long = target.Points

        ' Assert.
        '
        Assert.AreEqual(expected, actual)

    End Sub


    <TestMethod()> _
    Public Sub CalculatePoints_LongJumpScoreIsBelowBConstantValue_ZeroPoints()
        
        ' Arrange.
        '
        Dim eventType As EventType = EventType.LongJump
        Dim score As Decimal = CDec(219.9)
        Dim target As PointsCalculator = New PointsCalculator(eventType, score)
        Dim expected As Long = 0
        
        ' Act.
        '
        target.CalculatePoints()
        Dim actual As Long = target.Points

        ' Assert.
        '
        Assert.AreEqual(expected, actual)

    End Sub


    <TestMethod()> _
    Public Sub CalculatePoints_OneHundredAndTenMetreHurdlesScoreIsBelowBConstantValue_ZeroPoints()
        
        ' Arrange.
        '
        Dim eventType As EventType = EventType.OneHundredAndTenMetreHurdles
        Dim score As Decimal = CDec(28.6)
        Dim target As PointsCalculator = New PointsCalculator(eventType, score)
        Dim expected As Long = 0
        
        ' Act.
        '
        target.CalculatePoints()
        Dim actual As Long = target.Points

        ' Assert.
        '
        Assert.AreEqual(expected, actual)

    End Sub


    <TestMethod()> _
    Public Sub CalculatePoints_OneHundredMetreSprintScoreIsBelowBConstantValue_ZeroPoints()
        
        ' Arrange.
        '
        Dim eventType As EventType = EventType.OneHundredMetreSprint
        Dim score As Decimal = CDec(18.1)
        Dim target As PointsCalculator = New PointsCalculator(eventType, score)
        Dim expected As Long = 0
        
        ' Act.
        '
        target.CalculatePoints()
        Dim actual As Long = target.Points

        ' Assert.
        '
        Assert.AreEqual(expected, actual)

    End Sub


    <TestMethod()> _
    Public Sub CalculatePoints_PoleVaultScoreIsBelowBConstantValue_ZeroPoints()
        
        ' Arrange.
        '
        Dim eventType As EventType = EventType.PoleVault
        Dim score As Decimal = CDec(99.9)
        Dim target As PointsCalculator = New PointsCalculator(eventType, score)
        Dim expected As Long = 0
        
        ' Act.
        '
        target.CalculatePoints()
        Dim actual As Long = target.Points

        ' Assert.
        '
        Assert.AreEqual(expected, actual)

    End Sub


    <TestMethod()> _
    Public Sub CalculatePoints_ShotPutScoreIsBelowBConstantValue_ZeroPoints()
        
        ' Arrange.
        '
        Dim eventType As EventType = EventType.ShotPut
        Dim score As Decimal = CDec(1.4)
        Dim target As PointsCalculator = New PointsCalculator(eventType, score)
        Dim expected As Long = 0
        
        ' Act.
        '
        target.CalculatePoints()
        Dim actual As Long = target.Points

        ' Assert.
        '
        Assert.AreEqual(expected, actual)

    End Sub

End Class
