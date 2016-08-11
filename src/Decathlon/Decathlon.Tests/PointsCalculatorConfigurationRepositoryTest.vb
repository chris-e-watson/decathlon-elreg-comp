Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Decathlon



'''<summary>
'''This is a test class for PointsCalculatorConfigurationRepositoryTest and is intended
'''to contain all PointsCalculatorConfigurationRepositoryTest Unit Tests
'''</summary>
<TestClass()> _
Public Class PointsCalculatorConfigurationRepositoryTest


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
    Public Sub GetByEventType_DiscusEventType_ReturnsConfiguration()
        
        ' Arrange.
        '
        Dim target As PointsCalculatorConfigurationRepository =
            PointsCalculatorConfigurationRepository.Default
        Dim eventType As EventType = EventType.Discus
        Dim expected As PointsCalculatorConfiguration =
            New PointsCalculatorConfiguration(
                eventType, CDec(12.91), 4, CDec(1.1))
        
        ' Act.
        '
        Dim actual As PointsCalculatorConfiguration
        actual = target.GetByEventType(eventType)
        
        ' Assert.
        '
        Assert.AreEqual(expected, actual)
        Assert.Inconclusive("Verify the correctness of this test method.")

    End Sub

End Class
