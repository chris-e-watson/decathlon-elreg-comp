﻿Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Decathlon



'''<summary>
'''This is a test class for EventTypeHelperTest and is intended
'''to contain all EventTypeHelperTest Unit Tests
'''</summary>
<TestClass()> _
Public Class EventTypeHelperTest


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
    Public Sub GetEventTypeFromAbbreviation_100mAbbreviation_ReturnsEvent()
        
        ' Arrange.
        '
        Dim abbreviation As String = "100m"
        Dim expected As EventType = EventType.OneHundredMetreSprint
        
        ' Act.
        '
        Dim actual As EventType
        actual = EventTypeHelper.GetEventTypeFromAbbreviation(abbreviation)
        
        ' Assert.
        '
        Assert.AreEqual(expected, actual)

    End Sub


    <TestMethod()> _
    Public Sub GetEventTypeFromAbbreviation_110mAbbreviation_ReturnsEvent()
        
        ' Arrange.
        '
        Dim abbreviation As String = "110m"
        Dim expected As EventType = EventType.OneHundredAndTenMetreHurdles
        
        ' Act.
        '
        Dim actual As EventType
        actual = EventTypeHelper.GetEventTypeFromAbbreviation(abbreviation)
        
        ' Assert.
        '
        Assert.AreEqual(expected, actual)

    End Sub


    <TestMethod()> _
    Public Sub GetEventTypeFromAbbreviation_400mAbbreviation_ReturnsEvent()
        
        ' Arrange.
        '
        Dim abbreviation As String = "400m"
        Dim expected As EventType = EventType.FourHundredMetreSprint
        
        ' Act.
        '
        Dim actual As EventType
        actual = EventTypeHelper.GetEventTypeFromAbbreviation(abbreviation)
        
        ' Assert.
        '
        Assert.AreEqual(expected, actual)

    End Sub


    <TestMethod()> _
    Public Sub GetEventTypeFromAbbreviation_1500mAbbreviation_ReturnsEvent()
        
        ' Arrange.
        '
        Dim abbreviation As String = "1500m"
        Dim expected As EventType = EventType.FifteenHundredMetreSprint
        
        ' Act.
        '
        Dim actual As EventType
        actual = EventTypeHelper.GetEventTypeFromAbbreviation(abbreviation)
        
        ' Assert.
        '
        Assert.AreEqual(expected, actual)

    End Sub


    <TestMethod()> _
    Public Sub GetEventTypeFromAbbreviation_DiscusAbbreviation_ReturnsEvent()
        
        ' Arrange.
        '
        Dim abbreviation As String = "Discus"
        Dim expected As EventType = EventType.Discus
        
        ' Act.
        '
        Dim actual As EventType
        actual = EventTypeHelper.GetEventTypeFromAbbreviation(abbreviation)
        
        ' Assert.
        '
        Assert.AreEqual(expected, actual)

    End Sub


    <TestMethod()> _
    Public Sub GetEventTypeFromAbbreviation_JavelinAbbreviation_ReturnsEvent()
        
        ' Arrange.
        '
        Dim abbreviation As String = "Javelin"
        Dim expected As EventType = EventType.Javelin
        
        ' Act.
        '
        Dim actual As EventType
        actual = EventTypeHelper.GetEventTypeFromAbbreviation(abbreviation)
        
        ' Assert.
        '
        Assert.AreEqual(expected, actual)

    End Sub


    <TestMethod()> _
    Public Sub GetEventTypeFromAbbreviation_ShotAbbreviation_ReturnsEvent()
        
        ' Arrange.
        '
        Dim abbreviation As String = "Shot"
        Dim expected As EventType = EventType.ShotPut
        
        ' Act.
        '
        Dim actual As EventType
        actual = EventTypeHelper.GetEventTypeFromAbbreviation(abbreviation)
        
        ' Assert.
        '
        Assert.AreEqual(expected, actual)

    End Sub


    <TestMethod()> _
    Public Sub GetEventTypeFromAbbreviation_LongAbbreviation_ReturnsEvent()
        
        ' Arrange.
        '
        Dim abbreviation As String = "Long"
        Dim expected As EventType = EventType.LongJump
        
        ' Act.
        '
        Dim actual As EventType
        actual = EventTypeHelper.GetEventTypeFromAbbreviation(abbreviation)
        
        ' Assert.
        '
        Assert.AreEqual(expected, actual)

    End Sub


    <TestMethod()> _
    Public Sub GetEventTypeFromAbbreviation_HighAbbreviation_ReturnsEvent()
        
        ' Arrange.
        '
        Dim abbreviation As String = "High"
        Dim expected As EventType = EventType.HighJump
        
        ' Act.
        '
        Dim actual As EventType
        actual = EventTypeHelper.GetEventTypeFromAbbreviation(abbreviation)
        
        ' Assert.
        '
        Assert.AreEqual(expected, actual)

    End Sub


    <TestMethod()> _
    Public Sub GetEventTypeFromAbbreviation_PoleAbbreviation_ReturnsEvent()
        
        ' Arrange.
        '
        Dim abbreviation As String = "Pole"
        Dim expected As EventType = EventType.PoleVault
        
        ' Act.
        '
        Dim actual As EventType
        actual = EventTypeHelper.GetEventTypeFromAbbreviation(abbreviation)
        
        ' Assert.
        '
        Assert.AreEqual(expected, actual)

    End Sub


    <TestMethod()> _
    <ExpectedException(GetType(ArgumentNullException))>
    Public Sub GetEventTypeFromAbbreviation_NullAbbreviation_ThrowsException()
        
        ' Arrange.
        '
        Dim abbreviation As String = Nothing
        
        ' Act.
        '
        Dim actual As EventType
        actual = EventTypeHelper.GetEventTypeFromAbbreviation(abbreviation)
        
        ' Assert.
        '
        ' See 'ExpectedException' attribute.

    End Sub


    <TestMethod()> _
    <ExpectedException(GetType(ArgumentException))>
    Public Sub GetEventTypeFromAbbreviation_ZeroLengthAbbreviation_ThrowsException()
        
        ' Arrange.
        '
        Dim abbreviation As String = ""
        
        ' Act.
        '
        Dim actual As EventType
        actual = EventTypeHelper.GetEventTypeFromAbbreviation(abbreviation)
        
        ' Assert.
        '
        ' See 'ExpectedException' attribute.

    End Sub


    <TestMethod()> _
    <ExpectedException(GetType(ArgumentException))>
    Public Sub GetEventTypeFromAbbreviation_WhiteSpaceAbbreviation_ThrowsException()
        
        ' Arrange.
        '
        Dim abbreviation As String = " "
        
        ' Act.
        '
        Dim actual As EventType
        actual = EventTypeHelper.GetEventTypeFromAbbreviation(abbreviation)
        
        ' Assert.
        '
        ' See 'ExpectedException' attribute.

    End Sub


    <TestMethod()> _
    Public Sub GetEventTypeGroupFromEventType_DiscusEvent_ReturnsThrowingEventGroup()
        
        ' Arrange.
        '
        Dim eventType As EventType = EventType.Discus
        Dim expected As EventTypeGroup = EventTypeGroup.Throwing 
        
        ' Act.
        '
        Dim actual As EventTypeGroup
        actual = EventTypeHelper.GetEventTypeGroupFromEventType(eventType)
        
        ' Assert.
        '
        Assert.AreEqual(expected, actual)

    End Sub


    <TestMethod()> _
    Public Sub GetEventTypeGroupFromEventType_FifteenHundredMetreSprintEvent_ReturnsRunningEventGroup()
        
        ' Arrange.
        '
        Dim eventType As EventType = EventType.FifteenHundredMetreSprint
        Dim expected As EventTypeGroup = EventTypeGroup.Running 
        
        ' Act.
        '
        Dim actual As EventTypeGroup
        actual = EventTypeHelper.GetEventTypeGroupFromEventType(eventType)
        
        ' Assert.
        '
        Assert.AreEqual(expected, actual)

    End Sub


    <TestMethod()> _
    Public Sub GetEventTypeGroupFromEventType_FourHundredMetreSprintEvent_ReturnsRunningEventGroup()
        
        ' Arrange.
        '
        Dim eventType As EventType = EventType.FourHundredMetreSprint
        Dim expected As EventTypeGroup = EventTypeGroup.Running 
        
        ' Act.
        '
        Dim actual As EventTypeGroup
        actual = EventTypeHelper.GetEventTypeGroupFromEventType(eventType)
        
        ' Assert.
        '
        Assert.AreEqual(expected, actual)

    End Sub


    <TestMethod()> _
    Public Sub GetEventTypeGroupFromEventType_HighJumpEvent_ReturnsJumpingEventGroup()
        
        ' Arrange.
        '
        Dim eventType As EventType = EventType.HighJump
        Dim expected As EventTypeGroup = EventTypeGroup.Jumping 
        
        ' Act.
        '
        Dim actual As EventTypeGroup
        actual = EventTypeHelper.GetEventTypeGroupFromEventType(eventType)
        
        ' Assert.
        '
        Assert.AreEqual(expected, actual)

    End Sub


    <TestMethod()> _
    Public Sub GetEventTypeGroupFromEventType_JavelinEvent_ReturnsThrowingEventGroup()
        
        ' Arrange.
        '
        Dim eventType As EventType = EventType.Javelin
        Dim expected As EventTypeGroup = EventTypeGroup.Throwing 
        
        ' Act.
        '
        Dim actual As EventTypeGroup
        actual = EventTypeHelper.GetEventTypeGroupFromEventType(eventType)
        
        ' Assert.
        '
        Assert.AreEqual(expected, actual)

    End Sub


    <TestMethod()> _
    Public Sub GetEventTypeGroupFromEventType_LongJumpEvent_ReturnsJumpingEventGroup()
        
        ' Arrange.
        '
        Dim eventType As EventType = EventType.LongJump
        Dim expected As EventTypeGroup = EventTypeGroup.Jumping 
        
        ' Act.
        '
        Dim actual As EventTypeGroup
        actual = EventTypeHelper.GetEventTypeGroupFromEventType(eventType)
        
        ' Assert.
        '
        Assert.AreEqual(expected, actual)

    End Sub


    <TestMethod()> _
    Public Sub GetEventTypeGroupFromEventType_OneHundredAndTenMetreHurdlesEvent_ReturnsRunningEventGroup()
        
        ' Arrange.
        '
        Dim eventType As EventType = EventType.OneHundredAndTenMetreHurdles
        Dim expected As EventTypeGroup = EventTypeGroup.Running
        
        ' Act.
        '
        Dim actual As EventTypeGroup
        actual = EventTypeHelper.GetEventTypeGroupFromEventType(eventType)
        
        ' Assert.
        '
        Assert.AreEqual(expected, actual)

    End Sub


    <TestMethod()> _
    Public Sub GetEventTypeGroupFromEventType_OneHundredMetreSprintEvent_ReturnsRunningEventGroup()
        
        ' Arrange.
        '
        Dim eventType As EventType = EventType.OneHundredMetreSprint
        Dim expected As EventTypeGroup = EventTypeGroup.Running 
        
        ' Act.
        '
        Dim actual As EventTypeGroup
        actual = EventTypeHelper.GetEventTypeGroupFromEventType(eventType)
        
        ' Assert.
        '
        Assert.AreEqual(expected, actual)

    End Sub


    <TestMethod()> _
    Public Sub GetEventTypeGroupFromEventType_PoleVaultEvent_ReturnsJumpingEventGroup()
        
        ' Arrange.
        '
        Dim eventType As EventType = EventType.PoleVault
        Dim expected As EventTypeGroup = EventTypeGroup.Jumping 
        
        ' Act.
        '
        Dim actual As EventTypeGroup
        actual = EventTypeHelper.GetEventTypeGroupFromEventType(eventType)
        
        ' Assert.
        '
        Assert.AreEqual(expected, actual)

    End Sub


    <TestMethod()> _
    Public Sub GetEventTypeGroupFromEventType_ShotPutEvent_ReturnsThrowingEventGroup()
        
        ' Arrange.
        '
        Dim eventType As EventType = EventType.ShotPut
        Dim expected As EventTypeGroup = EventTypeGroup.Throwing 
        
        ' Act.
        '
        Dim actual As EventTypeGroup
        actual = EventTypeHelper.GetEventTypeGroupFromEventType(eventType)
        
        ' Assert.
        '
        Assert.AreEqual(expected, actual)

    End Sub


    <TestMethod()> _
    <ExpectedException(GetType(InvalidOperationException))>
    Public Sub GetEventTypeGroupFromEventType_NoneEventType_ThrowsException()
        
        ' Arrange.
        '
        Dim eventType As EventType = EventType.None
        
        ' Act.
        '
        Dim actual As EventTypeGroup
        actual = EventTypeHelper.GetEventTypeGroupFromEventType(eventType)
        
        ' Assert.
        '
        ' See ExpectedExceptionAttribute above.

    End Sub

End Class
