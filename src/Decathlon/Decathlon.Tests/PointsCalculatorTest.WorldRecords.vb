'
' These World Record scores are calculated manually and checked with the scoring
' calculator at:
' http://cheshireaa.com/statistics/CEscoring.htm
'

Public Class PointsCalculatorTest

    <TestMethod()> _
    Public Sub CalculatePoints_DiscusWorldRecordScore_Returns1383Points()
        
        ' Arrange.
        '
        Dim eventType As EventType = EventType.Discus
        Dim score As Decimal = CDec(74.08)
        Dim target As PointsCalculator = New PointsCalculator(eventType, score)
        Dim expected As Long = 1383

        ' 12.91 * ((74.08 - 4) ^ 1.1) = 1,383.8205...
        
        ' Act.
        '
        target.CalculatePoints()
        Dim actual As Long = target.Points

        ' Assert.
        '
        Assert.AreEqual(expected, actual)

    End Sub


    <TestMethod()> _
    Public Sub CalculatePoints_FifteenHundredMetreSprintWorldRecordScore_Returns1218Points()
        
        ' Arrange.
        '
        Dim eventType As EventType = EventType.FifteenHundredMetreSprint
        Dim score As Decimal = CDec(206) ' 3:26.00 = 206s
        Dim target As PointsCalculator = New PointsCalculator(eventType, score)
        Dim expected As Long = 1218

        ' 0.03768 * ((480 - 206) ^ 1.85) = 1,218.8477...
        
        ' Act.
        '
        target.CalculatePoints()
        Dim actual As Long = target.Points

        ' Assert.
        '
        Assert.AreEqual(expected, actual)

    End Sub


    <TestMethod()> _
    Public Sub CalculatePoints_OneHundredMetreSprintWorldRecordScore_Returns1200Points()
        
        ' Arrange.
        '
        Dim eventType As EventType = EventType.OneHundredMetreSprint
        Dim score As Decimal = CDec(9.59)
        Dim target As PointsCalculator = New PointsCalculator(eventType, score)
        Dim expected As Long = 1200

        ' 25.4347 * ((18 - 9.59) ^ 1.81) = 1200.3485...
        
        ' Act.
        '
        target.CalculatePoints()
        Dim actual As Long = target.Points

        ' Assert.
        '
        Assert.AreEqual(expected, actual)

    End Sub


    <TestMethod()> _
    Public Sub CalculatePoints_FourHundredMetreSprintWorldRecordScore_Returns1156Points()
        
        ' Arrange.
        '
        Dim eventType As EventType = EventType.FourHundredMetreSprint
        Dim score As Decimal = CDec(43.18)
        Dim target As PointsCalculator = New PointsCalculator(eventType, score)
        Dim expected As Long = 1156

        ' 1.53775 * ((82 - 43.18) ^ 1.81) = 1,156.3152...
        
        ' Act.
        '
        target.CalculatePoints()
        Dim actual As Long = target.Points

        ' Assert.
        '
        Assert.AreEqual(expected, actual)

    End Sub


    <TestMethod()> _
    Public Sub CalculatePoints_JavelinWorldRecordScore_Returns1430Points()
        
        ' Arrange.
        '
        Dim eventType As EventType = EventType.Javelin
        Dim score As Decimal = CDec(104.80) ' 104.80 m
        Dim target As PointsCalculator = New PointsCalculator(eventType, score)
        Dim expected As Long = 1430

        ' 10.14 * ((104.8 - 7) ^ 1.08) = 1,430.8823....
        
        ' Act.
        '
        target.CalculatePoints()
        Dim actual As Long = target.Points

        ' Assert.
        '
        Assert.AreEqual(expected, actual)

    End Sub

End Class
