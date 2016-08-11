Imports System

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Decathlon



'''<summary>
'''This is a test class for PointsCalculatorConfigurationTest and is intended
'''to contain all PointsCalculatorConfigurationTest Unit Tests
'''</summary>
<TestClass()> _
Public Class PointsCalculatorConfigurationTest


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
    Public Sub Equals_CompareOneInstanceToItself_ReturnsTrue()

        ' Arrange.
        '
        Dim eventType As EventType = EventType.Discus
        Dim a As [Decimal] = New Decimal(1)
        Dim b As [Decimal] = New Decimal(2)
        Dim c As [Decimal] = New Decimal(3)
        
        Dim target As IEquatable(Of PointsCalculatorConfiguration) =
            New PointsCalculatorConfiguration(eventType, a, b, c)

        Dim other As PointsCalculatorConfiguration =
            DirectCast(target, PointsCalculatorConfiguration)

        Dim expected As Boolean = True
        
        ' Act.
        '
        Dim actual As Boolean
        actual = target.Equals(other)
        
        ' Assert.
        '
        Assert.AreEqual(expected, actual)

    End Sub


    <TestMethod()> _
    Public Sub Equals_CompareTwoInstancesWithSameValue_ReturnsTrue()

        ' Arrange.
        '
        Dim eventType As EventType = EventType.Discus
        Dim a As [Decimal] = New Decimal(1)
        Dim b As [Decimal] = New Decimal(2)
        Dim c As [Decimal] = New Decimal(3)
        
        Dim target As IEquatable(Of PointsCalculatorConfiguration) =
            New PointsCalculatorConfiguration(eventType, a, b, c)

        Dim other As PointsCalculatorConfiguration =
            New PointsCalculatorConfiguration(eventType, a, b, c)

        Dim expected As Boolean = True
        
        ' Act.
        '
        Dim actual As Boolean
        actual = target.Equals(other)
        
        ' Assert.
        '
        Assert.AreEqual(expected, actual)

    End Sub


    <TestMethod()> _
    Public Sub Equals_CompareTwoInstancesWithDifferentAValues_ReturnsFalse()

        ' Arrange.
        '
        Dim eventType As EventType = EventType.Discus
        Dim a As [Decimal] = New Decimal(1)
        Dim b As [Decimal] = New Decimal(2)
        Dim c As [Decimal] = New Decimal(3)
        
        Dim target As IEquatable(Of PointsCalculatorConfiguration) =
            New PointsCalculatorConfiguration(eventType, a, b, c)

        Dim other As PointsCalculatorConfiguration =
            New PointsCalculatorConfiguration(eventType, a + 1, b, c)

        Dim expected As Boolean = False
        
        ' Act.
        '
        Dim actual As Boolean
        actual = target.Equals(other)
        
        ' Assert.
        '
        Assert.AreEqual(expected, actual)

    End Sub


    <TestMethod()> _
    Public Sub Equals_CompareTwoInstancesWithDifferentBValues_ReturnsFalse()

        ' Arrange.
        '
        Dim eventType As EventType = EventType.Discus
        Dim a As [Decimal] = New Decimal(1)
        Dim b As [Decimal] = New Decimal(2)
        Dim c As [Decimal] = New Decimal(3)
        
        Dim target As IEquatable(Of PointsCalculatorConfiguration) =
            New PointsCalculatorConfiguration(eventType, a, b, c)

        Dim other As PointsCalculatorConfiguration =
            New PointsCalculatorConfiguration(eventType, a, b + 1, c)

        Dim expected As Boolean = False
        
        ' Act.
        '
        Dim actual As Boolean
        actual = target.Equals(other)
        
        ' Assert.
        '
        Assert.AreEqual(expected, actual)

    End Sub


    <TestMethod()> _
    Public Sub Equals_CompareTwoInstancesWithDifferentCValues_ReturnsFalse()

        ' Arrange.
        '
        Dim eventType As EventType = EventType.Discus
        Dim a As [Decimal] = New Decimal(1)
        Dim b As [Decimal] = New Decimal(2)
        Dim c As [Decimal] = New Decimal(3)
        
        Dim target As IEquatable(Of PointsCalculatorConfiguration) =
            New PointsCalculatorConfiguration(eventType, a, b, c)

        Dim other As PointsCalculatorConfiguration =
            New PointsCalculatorConfiguration(eventType, a, b, c + 1)

        Dim expected As Boolean = False
        
        ' Act.
        '
        Dim actual As Boolean
        actual = target.Equals(other)
        
        ' Assert.
        '
        Assert.AreEqual(expected, actual)

    End Sub


    <TestMethod()> _
    Public Sub Equals_CompareAnInstanceWithNull_ReturnsFalse()

        ' Arrange.
        '
        Dim eventType As EventType = EventType.Discus
        Dim a As [Decimal] = New Decimal(1)
        Dim b As [Decimal] = New Decimal(2)
        Dim c As [Decimal] = New Decimal(3)
        
        Dim target As IEquatable(Of PointsCalculatorConfiguration) =
            New PointsCalculatorConfiguration(eventType, a, b, c)

        Dim other As PointsCalculatorConfiguration = Nothing

        Dim expected As Boolean = False
        
        ' Act.
        '
        Dim actual As Boolean
        actual = target.Equals(other)
        
        ' Assert.
        '
        Assert.AreEqual(expected, actual)

    End Sub


    <TestMethod()> _
    Public Sub EqualityOperator_CompareTwoInstancesWithSameValue_ReturnsTrue()
        
        ' Arrange.
        '
        Dim a As PointsCalculatorConfiguration = 
            New PointsCalculatorConfiguration(EventType.Discus, 1, 2, 3)
        
        Dim b As PointsCalculatorConfiguration =
            New PointsCalculatorConfiguration(EventType.Discus, 1, 2, 3)
        
        Dim expected As Boolean = True
        
        ' Act.
        '
        Dim actual As Boolean
        actual = (a = b)

        ' Assert.
        '
        Assert.AreEqual(expected, actual)
        
    End Sub


    <TestMethod()> _
    Public Sub EqualityOperator_CompareTwoInstancesWithDifferentAValues_ReturnsFalse()
        
        ' Arrange.
        '
        Dim a As PointsCalculatorConfiguration = 
            New PointsCalculatorConfiguration(EventType.Discus, 1, 2, 3)
        
        Dim b As PointsCalculatorConfiguration =
            New PointsCalculatorConfiguration(EventType.Discus, 1 + 1, 2, 3)
        
        Dim expected As Boolean = False
        
        ' Act.
        '
        Dim actual As Boolean
        actual = (a = b)

        ' Assert.
        '
        Assert.AreEqual(expected, actual)
        
    End Sub


    <TestMethod()> _
    Public Sub EqualityOperator_CompareTwoInstancesWithDifferentBValues_ReturnsFalse()
        
        ' Arrange.
        '
        Dim a As PointsCalculatorConfiguration = 
            New PointsCalculatorConfiguration(EventType.Discus, 1, 2, 3)
        
        Dim b As PointsCalculatorConfiguration =
            New PointsCalculatorConfiguration(EventType.Discus, 1, 2 + 1, 3)
        
        Dim expected As Boolean = False
        
        ' Act.
        '
        Dim actual As Boolean
        actual = (a = b)

        ' Assert.
        '
        Assert.AreEqual(expected, actual)
        
    End Sub


    <TestMethod()> _
    Public Sub EqualityOperator_CompareTwoInstancesWithDifferentCValues_ReturnsFalse()
        
        ' Arrange.
        '
        Dim a As PointsCalculatorConfiguration = 
            New PointsCalculatorConfiguration(EventType.Discus, 1, 2, 3)
        
        Dim b As PointsCalculatorConfiguration =
            New PointsCalculatorConfiguration(EventType.Discus, 1, 2, 3 + 1)
        
        Dim expected As Boolean = False
        
        ' Act.
        '
        Dim actual As Boolean
        actual = (a = b)

        ' Assert.
        '
        Assert.AreEqual(expected, actual)
        
    End Sub


    <TestMethod()> _
    Public Sub InequalityOperator_CompareTwoInstancesWithSameValue_ReturnsFalse()
        
        ' Arrange.
        '
        Dim a As PointsCalculatorConfiguration = 
            New PointsCalculatorConfiguration(EventType.Discus, 1, 2, 3)
        
        Dim b As PointsCalculatorConfiguration =
            New PointsCalculatorConfiguration(EventType.Discus, 1, 2, 3)
        
        Dim expected As Boolean = False
        
        ' Act.
        '
        Dim actual As Boolean
        actual = (a <> b)

        ' Assert.
        '
        Assert.AreEqual(expected, actual)
        
    End Sub


    <TestMethod()> _
    Public Sub InequalityOperator_CompareTwoInstancesWithDifferentAValues_ReturnsTrue()
        
        ' Arrange.
        '
        Dim a As PointsCalculatorConfiguration = 
            New PointsCalculatorConfiguration(EventType.Discus, 1, 2, 3)
        
        Dim b As PointsCalculatorConfiguration =
            New PointsCalculatorConfiguration(EventType.Discus, 1 + 1, 2, 3)
        
        Dim expected As Boolean = True
        
        ' Act.
        '
        Dim actual As Boolean
        actual = (a <> b)

        ' Assert.
        '
        Assert.AreEqual(expected, actual)
        
    End Sub


    <TestMethod()> _
    Public Sub InequalityOperator_CompareTwoInstancesWithDifferentBValues_ReturnsTrue()
        
        ' Arrange.
        '
        Dim a As PointsCalculatorConfiguration = 
            New PointsCalculatorConfiguration(EventType.Discus, 1, 2, 3)
        
        Dim b As PointsCalculatorConfiguration =
            New PointsCalculatorConfiguration(EventType.Discus, 1, 2 + 1, 3)
        
        Dim expected As Boolean = True
        
        ' Act.
        '
        Dim actual As Boolean
        actual = (a <> b)

        ' Assert.
        '
        Assert.AreEqual(expected, actual)
        
    End Sub


    <TestMethod()> _
    Public Sub InequalityOperator_CompareTwoInstancesWithDifferentCValues_ReturnsTrue()
        
        ' Arrange.
        '
        Dim a As PointsCalculatorConfiguration = 
            New PointsCalculatorConfiguration(EventType.Discus, 1, 2, 3)
        
        Dim b As PointsCalculatorConfiguration =
            New PointsCalculatorConfiguration(EventType.Discus, 1, 2, 3 + 1)
        
        Dim expected As Boolean = True
        
        ' Act.
        '
        Dim actual As Boolean
        actual = (a <> b)

        ' Assert.
        '
        Assert.AreEqual(expected, actual)
        
    End Sub


    <TestMethod()> _
    Public Sub EqualityOperator_CompareAnInstanceWithNull_ReturnsFalse()
        
        ' Arrange.
        '
        Dim a As PointsCalculatorConfiguration = 
            New PointsCalculatorConfiguration(EventType.Discus, 1, 2, 3)
        
        Dim b As PointsCalculatorConfiguration =
            Nothing
        
        Dim expected As Boolean = False
        
        ' Act.
        '
        Dim actual As Boolean
        actual = (a = b)

        ' Assert.
        '
        Assert.AreEqual(expected, actual)
        
    End Sub


    <TestMethod()> _
    Public Sub EqualityOperator_CompareNullWithAnInstance_ReturnsFalse()
        
        ' Arrange.
        '
        Dim a As PointsCalculatorConfiguration = 
            Nothing
        
        Dim b As PointsCalculatorConfiguration =
            New PointsCalculatorConfiguration(EventType.Discus, 1, 2, 3)
        
        Dim expected As Boolean = False
        
        ' Act.
        '
        Dim actual As Boolean
        actual = (a = b)

        ' Assert.
        '
        Assert.AreEqual(expected, actual)
        
    End Sub


    <TestMethod()> _
    Public Sub EqualityOperator_CompareNullWithNull_ReturnsTrue()
        
        ' Arrange.
        '
        Dim a As PointsCalculatorConfiguration = 
            Nothing            
        
        Dim b As PointsCalculatorConfiguration =
            Nothing
        
        Dim expected As Boolean = True
        
        ' Act.
        '
        Dim actual As Boolean
        actual = (a = b)

        ' Assert.
        '
        Assert.AreEqual(expected, actual)
        
    End Sub


    <TestMethod()> _
    Public Sub InequalityOperator_CompareAnInstanceWithNull_ReturnsTrue()
        
        ' Arrange.
        '
        Dim a As PointsCalculatorConfiguration = 
            New PointsCalculatorConfiguration(EventType.Discus, 1, 2, 3)
        
        Dim b As PointsCalculatorConfiguration =
            Nothing
        
        Dim expected As Boolean = True
        
        ' Act.
        '
        Dim actual As Boolean
        actual = (a <> b)

        ' Assert.
        '
        Assert.AreEqual(expected, actual)
        
    End Sub


    <TestMethod()> _
    Public Sub InequalityOperator_CompareNullWithAnInstance_ReturnsTrue()
        
        ' Arrange.
        '
        Dim a As PointsCalculatorConfiguration = 
            Nothing
        
        Dim b As PointsCalculatorConfiguration =
            New PointsCalculatorConfiguration(EventType.Discus, 1, 2, 3)
        
        Dim expected As Boolean = True
        
        ' Act.
        '
        Dim actual As Boolean
        actual = (a <> b)

        ' Assert.
        '
        Assert.AreEqual(expected, actual)
        
    End Sub


    <TestMethod()> _
    Public Sub InequalityOperator_CompareNullWithNull_ReturnsFalse()
        
        ' Arrange.
        '
        Dim a As PointsCalculatorConfiguration = 
            Nothing            
        
        Dim b As PointsCalculatorConfiguration =
            Nothing
        
        Dim expected As Boolean = False
        
        ' Act.
        '
        Dim actual As Boolean
        actual = (a <> b)

        ' Assert.
        '
        Assert.AreEqual(expected, actual)
        
    End Sub

End Class
