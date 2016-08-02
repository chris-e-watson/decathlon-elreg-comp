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

End Class
