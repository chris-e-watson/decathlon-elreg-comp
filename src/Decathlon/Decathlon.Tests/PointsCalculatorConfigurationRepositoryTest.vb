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

    End Sub


    <TestMethod()> _
    Public Sub GetByEventType_FifteenHundredMetreSprintEventType_ReturnsConfiguration()
        
        ' Arrange.
        '
        Dim target As PointsCalculatorConfigurationRepository =
            PointsCalculatorConfigurationRepository.Default
        
        Dim eventType As EventType = EventType.FifteenHundredMetreSprint

        Dim expected As PointsCalculatorConfiguration =
            New PointsCalculatorConfiguration(
                eventType, CDec(0.03768), 480, CDec(1.85))
        
        ' Act.
        '
        Dim actual As PointsCalculatorConfiguration
        actual = target.GetByEventType(eventType)
        
        ' Assert.
        '
        Assert.AreEqual(expected, actual)

    End Sub


    <TestMethod()> _
    Public Sub GetByEventType_FourHundredMetreSprintEventType_ReturnsConfiguration()
        
        ' Arrange.
        '
        Dim target As PointsCalculatorConfigurationRepository =
            PointsCalculatorConfigurationRepository.Default
        
        Dim eventType As EventType = EventType.FourHundredMetreSprint

        Dim expected As PointsCalculatorConfiguration =
            New PointsCalculatorConfiguration(
                eventType, CDec(1.53775), 82, CDec(1.81))
        
        ' Act.
        '
        Dim actual As PointsCalculatorConfiguration
        actual = target.GetByEventType(eventType)
        
        ' Assert.
        '
        Assert.AreEqual(expected, actual)

    End Sub


    <TestMethod()> _
    Public Sub GetByEventType_HighJumpEventType_ReturnsConfiguration()
        
        ' Arrange.
        '
        Dim target As PointsCalculatorConfigurationRepository =
            PointsCalculatorConfigurationRepository.Default
        
        Dim eventType As EventType = EventType.HighJump

        Dim expected As PointsCalculatorConfiguration =
            New PointsCalculatorConfiguration(
                eventType, CDec(0.8465), 75, CDec(1.42))
        
        ' Act.
        '
        Dim actual As PointsCalculatorConfiguration
        actual = target.GetByEventType(eventType)
        
        ' Assert.
        '
        Assert.AreEqual(expected, actual)

    End Sub


    <TestMethod()> _
    Public Sub GetByEventType_JavelinEventType_ReturnsConfiguration()
        
        ' Arrange.
        '
        Dim target As PointsCalculatorConfigurationRepository =
            PointsCalculatorConfigurationRepository.Default
        
        Dim eventType As EventType = EventType.Javelin

        Dim expected As PointsCalculatorConfiguration =
            New PointsCalculatorConfiguration(
                eventType, CDec(10.14), 7, CDec(1.08))
        
        ' Act.
        '
        Dim actual As PointsCalculatorConfiguration
        actual = target.GetByEventType(eventType)
        
        ' Assert.
        '
        Assert.AreEqual(expected, actual)

    End Sub


    <TestMethod()> _
    Public Sub GetByEventType_LongJumpEventType_ReturnsConfiguration()
        
        ' Arrange.
        '
        Dim target As PointsCalculatorConfigurationRepository =
            PointsCalculatorConfigurationRepository.Default
        
        Dim eventType As EventType = EventType.LongJump

        Dim expected As PointsCalculatorConfiguration =
            New PointsCalculatorConfiguration(
                eventType, CDec(0.14354), 220, CDec(1.4))
        
        ' Act.
        '
        Dim actual As PointsCalculatorConfiguration
        actual = target.GetByEventType(eventType)
        
        ' Assert.
        '
        Assert.AreEqual(expected, actual)

    End Sub


    <TestMethod()> _
    <ExpectedException(GetType(KeyNotFoundException))>
    Public Sub GetByEventType_NoneEventType_ThrowsKeyNotFoundException()
        
        ' Arrange.
        '
        Dim target As PointsCalculatorConfigurationRepository =
            PointsCalculatorConfigurationRepository.Default
        
        Dim eventType As EventType = EventType.None
        
        ' Act.
        '
        Dim actual As PointsCalculatorConfiguration
        actual = target.GetByEventType(eventType)
        
        ' Assert.
        '
        ' See ExpectedException attribute above.

    End Sub


    <TestMethod()> _
    Public Sub GetByEventType_OneHundredAndTenMetreHurdlesEventType_ReturnsConfiguration()
        
        ' Arrange.
        '
        Dim target As PointsCalculatorConfigurationRepository =
            PointsCalculatorConfigurationRepository.Default
        
        Dim eventType As EventType = EventType.OneHundredAndTenMetreHurdles

        Dim expected As PointsCalculatorConfiguration =
            New PointsCalculatorConfiguration(
                eventType, CDec(5.74352), CDec(28.5), CDec(1.92))
        
        ' Act.
        '
        Dim actual As PointsCalculatorConfiguration
        actual = target.GetByEventType(eventType)
        
        ' Assert.
        '
        Assert.AreEqual(expected, actual)

    End Sub


    <TestMethod()> _
    Public Sub GetByEventType_OneHundredMetreSprintEventType_ReturnsConfiguration()
        
        ' Arrange.
        '
        Dim target As PointsCalculatorConfigurationRepository =
            PointsCalculatorConfigurationRepository.Default
        
        Dim eventType As EventType = EventType.OneHundredMetreSprint

        Dim expected As PointsCalculatorConfiguration =
            New PointsCalculatorConfiguration(
                eventType, CDec(25.4347), 18, CDec(1.81))
        
        ' Act.
        '
        Dim actual As PointsCalculatorConfiguration
        actual = target.GetByEventType(eventType)
        
        ' Assert.
        '
        Assert.AreEqual(expected, actual)

    End Sub


    <TestMethod()> _
    Public Sub GetByEventType_PoleVaultEventType_ReturnsConfiguration()
        
        ' Arrange.
        '
        Dim target As PointsCalculatorConfigurationRepository =
            PointsCalculatorConfigurationRepository.Default
        
        Dim eventType As EventType = EventType.PoleVault

        Dim expected As PointsCalculatorConfiguration =
            New PointsCalculatorConfiguration(
                eventType, CDec(0.2797), 100, CDec(1.35))
        
        ' Act.
        '
        Dim actual As PointsCalculatorConfiguration
        actual = target.GetByEventType(eventType)
        
        ' Assert.
        '
        Assert.AreEqual(expected, actual)

    End Sub


    <TestMethod()> _
    Public Sub GetByEventType_ShotPutEventType_ReturnsConfiguration()
        
        ' Arrange.
        '
        Dim target As PointsCalculatorConfigurationRepository =
            PointsCalculatorConfigurationRepository.Default
        
        Dim eventType As EventType = EventType.ShotPut

        Dim expected As PointsCalculatorConfiguration =
            New PointsCalculatorConfiguration(
                eventType, CDec(51.39), CDec(1.5), CDec(1.05))
        
        ' Act.
        '
        Dim actual As PointsCalculatorConfiguration
        actual = target.GetByEventType(eventType)
        
        ' Assert.
        '
        Assert.AreEqual(expected, actual)

    End Sub


    <TestMethod()>
    Public Sub InitialiseItems_Configurations_NotEmpty()

        ' Arrange.
        '
        Dim target As PointsCalculatorConfigurationRepository =
            PointsCalculatorConfigurationRepository.Default

        ' Wrap an already existing instance.
        '
        Dim accessor As PrivateObject = New PrivateObject(target)

        ' Retrieve a private field.
        '
        Dim _items As List(Of PointsCalculatorConfiguration) =
            DirectCast(accessor.GetField("_items"), 
                List(Of PointsCalculatorConfiguration))

        ' Act.
        '
        ' Umm...

        ' Assert.
        '
        ' _items collection cannot be empty.
        '
        Assert.IsTrue(_items.Any(),
            "PointsCalculatorConfigurationRepository._items is empty.")

    End Sub


    <TestMethod()>
    Public Sub InitialiseItems_Configurations_NotNull()

        ' Arrange.
        '
        Dim target As PointsCalculatorConfigurationRepository =
            PointsCalculatorConfigurationRepository.Default

        ' Wrap an already existing instance.
        '
        Dim accessor As PrivateObject = New PrivateObject(target)

        ' Retrieve a private field.
        '
        Dim _items As List(Of PointsCalculatorConfiguration) =
            DirectCast(accessor.GetField("_items"), 
                List(Of PointsCalculatorConfiguration))

        ' Act.
        '
        ' Umm...

        ' Assert.
        '
        Assert.IsNotNull(_items,
            "PointsCalculatorConfigurationRepository._items is null.")

    End Sub


    <TestMethod()>
    Public Sub InitialiseItems_Configurations_OneForEachEventType()

        ' Arrange.
        '
        Dim target As PointsCalculatorConfigurationRepository =
            PointsCalculatorConfigurationRepository.Default

        ' Wrap an already existing instance.
        '
        Dim accessor As PrivateObject = New PrivateObject(target)

        ' Retrieve a private field.
        '
        Dim _items As List(Of PointsCalculatorConfiguration) =
            DirectCast(accessor.GetField("_items"), 
                List(Of PointsCalculatorConfiguration))

        ' List of all event types from enum (apart from None).
        '
        Dim eventTypes0 = [Enum].GetValues(GetType(EventType))
        Dim eventTypes = New List(Of EventType)(
            DirectCast(eventTypes0, IEnumerable(Of EventType))) _
            .Where(Function(f) f <> EventType.None)

        ' Act.
        '
        ' Um...

        ' Assert.
        '

        For Each eventType As EventType In eventTypes

            Dim eType = eventType

            Dim eventTypeConfigurationCount =
                _items.AsEnumerable().Count(Function(f) f.EventType = eType)

            If eventTypeConfigurationCount <> 1 Then

                Dim format As String =
                    "EventType '{0}' has an invalid amount of configurations." &
                    " Expected: <1>. Found: <{1}>."
                Dim message As String =
                    String.Format(CultureInfo.CurrentCulture, format,
                                  eType, eventTypeConfigurationCount)

                Assert.Fail(message)

            End If

        Next

    End Sub


End Class
