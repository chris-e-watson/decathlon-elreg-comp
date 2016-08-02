Public Class PointsCalculatorTest

    <TestMethod()> _
    Public Sub CalculatePoints_OneHundredMetreSprintWorldRecordScore_Returns1200Points()
        
        ' Arrange.
        '
        Dim eventType As EventType = EventType.OneHundredMetreSprint
        Dim score As Decimal = CDec(9.59)
        Dim target As PointsCalculator = New PointsCalculator(eventType, score)
        Dim expected As Long = 1200
        
        ' Act.
        '
        target.CalculatePoints()
        Dim actual As Long = target.Points

        ' Assert.
        '
        Assert.AreEqual(expected, actual)

    End Sub

End Class
