'*******************************************************************************
'* What:                                                                       *
'*   Decathlon.vb                                                              *
'* Who:                                                                        *
'*   Chris Watson                                                              *
'* When:                                                                       *
'*   13 July 2016                                                              *
'* Why:                                                                        *
'*   Competition entry for The Register's Decathlon coding competition.        *
'*   http://www.theregister.co.uk/2016/07/13/the_reg_coding_competition_10_tim *
'*   es_as_hard_as_the_last_one/                                               *
'* Remarks:                                                                    *
'*   The rules (http://www.theregister.co.uk/Design/page/hub/ibm2016/#four)    *
'*   stipulate that "You must submit the solution for each question as a       *
'*   single source file called Decathlon.<e>, where <e> must be replaced with  *
'*   the appropriate extension for the language used." hence the one large     *
'*   file.                                                                     *
'*                                                                             *
'*   Written in Visual Basic .NET 2010 (VB 10.0) targeting the .NET 4 (.NET    *
'*   Framework 4.0 Client Profile) using Visual Studio 2010 Professional.      *
'*******************************************************************************

Option Explicit On
Option Compare Binary
Option Strict On
Option Infer On

Imports System
Imports System.Collections.Generic
Imports System.Globalization
Imports System.Linq

#Region "Enumerations"

''' <summary>
''' Enumeration of the different event types.
''' </summary>
Friend Enum EventType
    
    ''' <summary>
    ''' The event type is unknown or not specified.
    ''' </summary>
    None                         = 0
        
    ''' <summary>
    ''' The 100m sprint event.
    ''' </summary>
    OneHundredMetreSprint        = 1
        
    ''' <summary>
    ''' The 110m hurdles event.
    ''' </summary>
    OneHundredAndTenMetreHurdles = 2
        
    ''' <summary>
    ''' The 400m sprint event.
    ''' </summary>
    FourHundredMetreSprint       = 3
        
    ''' <summary>
    ''' The 1500m sprint event.
    ''' </summary>
    FifteenHundredMetreSprint    = 4
        
    ''' <summary>
    ''' The discus event.
    ''' </summary>
    Discus                       = 5
        
    ''' <summary>
    ''' The javelin event.
    ''' </summary>
    Javelin                      = 6
        
    ''' <summary>
    ''' The shot put event.
    ''' </summary>
    ShotPut                      = 7
        
    ''' <summary>
    ''' The long jump event.
    ''' </summary>
    LongJump                     = 8
    
    ''' <summary>
    ''' The high jump event.
    ''' </summary>
    HighJump                     = 9
        
    ''' <summary>
    ''' The pole vault event.
    ''' </summary>
    PoleVault                    = 10
End Enum


''' <summary>
''' Enumeration of the different event type groups.
''' </summary>
Friend Enum EventTypeGroup
        
    ''' <summary>
    ''' The event type group is unknown or not specified.
    ''' </summary>
    None     = 0
        
    ''' <summary>
    ''' The jumping event type group.
    ''' </summary>
    Jumping  = 1
    

    ''' <summary>
    ''' The running event type group.
    ''' </summary>
    Running  = 2
    

    ''' <summary>
    ''' The throwing event type group.
    ''' </summary>
    Throwing = 3

End Enum

#End Region

#Region "Classes"

''' <summary>
''' Represents a single decathlon combined event.
''' </summary>
Friend Class CombinedEvent

    #Region "Private Fields"
    
    ''' <summary>
    ''' The entrants.
    ''' </summary>
    Private _entrants As List(Of CombinedEventEntrant) =
        New List(Of CombinedEventEntrant)

    #End Region

    #Region "Internal Properties"

    ''' <summary>
    ''' Gets the entrants.
    ''' </summary>
    Friend ReadOnly Property Entrants As List(Of CombinedEventEntrant)
        Get
            Return _entrants
        End Get
    End Property

    
    ''' <summary>
    ''' Gets or sets the league table.
    ''' </summary>
    Friend Property LeagueTable As LeagueTable

    #End Region

    #Region "Public Methods"
    
    ''' <summary>
    ''' Returns a <see cref="System.String" /> that represents this instance.
    ''' </summary>
    ''' <returns>
    ''' A <see cref="System.String" /> that represents this instance.
    ''' </returns>
    Public Overrides Function ToString() As String
        
        Dim format As String = 
            "Entrants: {0}, LeagueTable: {1}"

        Dim value As String = 
            String.Format(CultureInfo.InvariantCulture, format, _
                If(Not Me.Entrants Is Nothing,
                   Me.Entrants.Count.ToString(CultureInfo.InvariantCulture) & 
                   If(Me.Entrants.Count = 1, " item", " items"), "null"),
                If(Not Me.LeagueTable Is Nothing,
                   "{" & Me.LeagueTable.ToString() & "}", "null"))

        Return value

    End Function

    #End Region

    #Region "Internal Constructors"

    ''' <summary>
    ''' Initialises a new instance of the <see cref="CombinedEvent"/> class.
    ''' </summary>
    Friend Sub New()
    End Sub

    #End Region

End Class


''' <summary>
''' Represents information about a single entrant and their event score/points
''' for all events in a single decathlon combined event.
''' </summary>
Friend Class CombinedEventEntrant

    #Region "Private Fields"
    
    ''' <summary>
    ''' The event scores.
    ''' </summary>
    Private _eventScores As List(Of EventScore) = New List(Of EventScore)

    #End Region

    #Region "Internal Properties"
    
    ''' <summary>
    ''' Gets or sets the name of the entrant.
    ''' </summary>
    Friend Property EntrantName As String
    

    ''' <summary>
    ''' Gets the event scores.
    ''' </summary>
    Friend ReadOnly Property EventScores As List(Of EventScore)
        Get
            Return _eventScores
        End Get
    End Property

    #End Region

    #Region "Public Methods"
    
    ''' <summary>
    ''' Returns a <see cref="System.String" /> that represents this instance.
    ''' </summary>
    ''' <returns>
    ''' A <see cref="System.String" /> that represents this instance.
    ''' </returns>
    Public Overrides Function ToString() As String
        
        Dim format As String = 
            "EntrantName: {0}, EventScores: {1}"

        Dim value As String = 
            String.Format(CultureInfo.InvariantCulture, format, _
                If(Not Me.EntrantName Is Nothing,
                   """" & Me.EntrantName & """", "null"),
                If(Not Me.EventScores Is Nothing,
                   Me.EventScores.Count.ToString() & 
                   If(Me.EventScores.Count = 1, " item", " items"), "null"))

        Return value

    End Function

    #End Region

    #Region "Internal Constructors"

    ''' <summary>
    ''' Initialises a new instance of the <see cref="CombinedEventEntrant"/>
    ''' class.
    ''' </summary>
    Friend Sub New()
    End Sub

    #End Region

End Class


''' <summary>
''' Provides the functionality to calculate the points for all event scores for
''' all entrants for a combined event.
''' </summary>
Friend Class CombinedEventPointsCalculatorService

    #Region "Internal Properties"
    
    ''' <summary>
    ''' Gets or sets the event score for which to calculation the points.
    ''' </summary>
    Friend Property CombinedEvent As CombinedEvent

    #End Region

    #Region "Private Methods"
    
    ''' <summary>
    ''' Calculates the points.
    ''' </summary>
    ''' <exception cref="InvalidOperationException">
    ''' <see cref="CombinedEvent.Entrants" /> was <c>null</c>.
    ''' </exception>
    Private Sub CalculatePoints()
        
        '
        ' Class state validation.
        '

        If Me.CombinedEvent.Entrants Is Nothing Then

            Throw New InvalidOperationException(
                "CombinedEventPointsCalculatorService.CombinedEvent.Entrants" _
                & " cannot be null.")

        End If


        '
        ' Main work.
        '

        For Each entrant In Me.CombinedEvent.Entrants

            For Each eventScore In entrant.EventScores

                Dim eventScorePointsCalculatorService = 
                    New EventScorePointsCalculatorService(eventScore)

                eventScorePointsCalculatorService.Execute()

            Next

        Next

    End Sub


    ''' <summary>
    ''' Throws a <see cref="InvalidOperationException" /> if 
    ''' <see cref="CombinedEvent" /> is <c>null</c>.
    ''' </summary>
    ''' <exception cref="InvalidOperationException">
    ''' <see cref="CombinedEvent" /> was <c>null</c>.
    ''' </exception>
    Private Sub ThrowIfCombinedEventIsNull()

        If Me.CombinedEvent Is Nothing

            Throw New InvalidOperationException(
                "CombinedEventPointsCalculatorService.CombinedEvent cannot" & _
                " be null.")

        End If

    End Sub

    #End Region

    #Region "Internal Methods"
    
    ''' <summary>
    ''' Calculates the points for all event scores for all entrants for the
    ''' combined event.
    ''' </summary>
    ''' <exception cref="InvalidOperationException">
    ''' <see cref="CombinedEvent" /> was <c>null</c>.
    ''' </exception>
    Friend Sub Execute()

        '
        ' Class state validation.
        '

        ThrowIfCombinedEventIsNull()


        '
        ' Main work.
        '

        CalculatePoints()

    End Sub

    #End Region

    #Region "Public Methods"
    
    ''' <summary>
    ''' Returns a <see cref="System.String" /> that represents this instance.
    ''' </summary>
    ''' <returns>
    ''' A <see cref="System.String" /> that represents this instance.
    ''' </returns>
    Public Overrides Function ToString() As String
        
        Dim format As String = 
            "CombinedEvent: {0}"

        Dim value As String = 
            String.Format(CultureInfo.InvariantCulture, format, _
                If(Not Me.CombinedEvent Is Nothing,
                   "{" & Me.CombinedEvent.ToString() & "}", "null"))

        Return value

    End Function

    #End Region

    #Region "Internal Constructors"
    
    ''' <summary>
    ''' Initialises a new instance of the
    ''' <see cref="CombinedEventPointsCalculatorService"/> class.
    ''' </summary>
    Friend Sub New()
    End Sub

    
    ''' <summary>
    ''' Initialises a new instance of the
    ''' <see cref="CombinedEventPointsCalculatorService"/> class.
    ''' </summary>
    ''' <param name="combinedEvent">
    ''' The event score for which to calculate the points.
    ''' </param>
    Friend Sub New(ByVal combinedEvent As CombinedEvent)

        Me.CombinedEvent = combinedEvent

    End Sub

    #End Region

End Class


''' <summary>
''' Provides helper methods for working with <see cref="EventType" />s.
''' </summary>
Friend NotInheritable Class EventTypeHelper
    
    #Region "Private Static Fields"

    ''' <summary>
    ''' A map of event types to their abbreviations, as used in an input file.
    ''' </summary>
    ''' <remarks>
    ''' The abbreviations, in the key, are in uppercase.
    ''' </remarks>
    Private Shared _eventTypeAbbrMap As Dictionary(Of String, EventType)


    ''' <summary>
    ''' The map of event type groups to event types.
    ''' </summary>
    Private Shared _eventTypeGroupEventTypeMap _
        As Dictionary(Of EventType, EventTypeGroup)

    #End Region

    #Region "Private Static Methods"

    ''' <summary>
    ''' Initialises the event type / abbreviation map.
    ''' </summary>
    ''' <seealso cref="_eventTypeAbbrMap" />
    Private Shared Sub InitialiseEventTypeAbbrMap()

        _eventTypeAbbrMap = New Dictionary(Of String, EventType)

        _eventTypeAbbrMap.Add("100M",    EventType.OneHundredMetreSprint)
        _eventTypeAbbrMap.Add("110M",    EventType.OneHundredAndTenMetreHurdles)
        _eventTypeAbbrMap.Add("400M",    EventType.FourHundredMetreSprint)
        _eventTypeAbbrMap.Add("1500M",   EventType.FifteenHundredMetreSprint)
        _eventTypeAbbrMap.Add("DISCUS",  EventType.Discus)
        _eventTypeAbbrMap.Add("JAVELIN", EventType.Javelin)
        _eventTypeAbbrMap.Add("SHOT",    EventType.ShotPut)
        _eventTypeAbbrMap.Add("LONG",    EventType.LongJump)
        _eventTypeAbbrMap.Add("HIGH",    EventType.HighJump)
        _eventTypeAbbrMap.Add("POLE",    EventType.PoleVault)

    End Sub
    

    ''' <summary>
    ''' Initialises the event type group / event type map.
    ''' </summary>
    ''' <seealso cref="_eventTypeGroupEventTypeMap" />
    Private Shared Sub InitialiseEventTypeGroupEventTypeMap()

        _eventTypeGroupEventTypeMap = _
            New Dictionary(Of EventType, EventTypeGroup)

        _eventTypeGroupEventTypeMap.Add(
            EventType.OneHundredMetreSprint,        EventTypeGroup.Running)
        _eventTypeGroupEventTypeMap.Add(
            EventType.OneHundredAndTenMetreHurdles, EventTypeGroup.Running)
        _eventTypeGroupEventTypeMap.Add(
            EventType.FourHundredMetreSprint,       EventTypeGroup.Running)
        _eventTypeGroupEventTypeMap.Add(
            EventType.FifteenHundredMetreSprint,    EventTypeGroup.Running)
        _eventTypeGroupEventTypeMap.Add(
            EventType.Discus,                       EventTypeGroup.Throwing)
        _eventTypeGroupEventTypeMap.Add(
            EventType.Javelin,                      EventTypeGroup.Throwing)
        _eventTypeGroupEventTypeMap.Add(
            EventType.ShotPut,                      EventTypeGroup.Throwing)
        _eventTypeGroupEventTypeMap.Add(
            EventType.LongJump,                     EventTypeGroup.Jumping)
        _eventTypeGroupEventTypeMap.Add(
            EventType.HighJump,                     EventTypeGroup.Jumping)
        _eventTypeGroupEventTypeMap.Add(
            EventType.PoleVault,                    EventTypeGroup.Jumping)

    End Sub

    #End Region

    #Region "Internal Static Methods"

    ''' <summary>
    ''' Gets an event type from an abbreviation.
    ''' </summary>
    ''' <param name="abbreviation">
    ''' The abbreviation for an event, as used in an input file.
    ''' </param>
    ''' <returns>
    ''' An <see cref="EventType" /> for the specified
    ''' <paramref name="abbreviation" />.
    ''' </returns>
    ''' <exception cref="ArgumentNullException">
    ''' <paramref name="abbreviation" /> was <c>null</c>.
    ''' </exception>
    ''' <exception cref="InvalidOperationException">
    ''' No mapping to an event type was configured for the specified
    ''' abbreviation.
    ''' </exception>
    ''' <seealso cref="_eventTypeAbbrMap" />
    Friend Shared Function GetEventTypeFromAbbreviation(
        ByVal abbreviation As String) As EventType

        '
        ' Parameter validation.
        '

        If abbreviation Is Nothing Then

            Throw New ArgumentNullException("abbreviation")

        Else If String.IsNullOrWhiteSpace(abbreviation) Then
            
            Throw New ArgumentException("Argument cannot be empty or consist" &
                " entirely of white-space.", "abbreviation")

        End If


        '
        ' Main work.
        '

        Dim eventType As EventType
        If Not _eventTypeAbbrMap.TryGetValue(abbreviation.ToUpperInvariant(),
                                             eventType) Then

            Dim format As String = 
                "No event type is mapped to the abbreviation '{0}'."

            Dim message As String =
                String.Format(CultureInfo.CurrentCulture, format, abbreviation)

            Throw New InvalidOperationException(message)

        End If

        Return eventType

    End Function

    
    ''' <summary>
    ''' Gets an event type group from an event type.
    ''' </summary>
    ''' <param name="eventType">
    ''' The type of the event for which to obtain the event type group.
    ''' </param>
    ''' <returns>
    ''' An <see cref="EventTypeGroup" /> for the specified
    ''' <paramref name="eventType" />.
    ''' </returns>
    ''' <exception cref="InvalidOperationException">
    ''' No mapping to an event type group was configured for the specified event
    ''' type.
    ''' </exception>
    ''' <seealso cref="_eventTypeGroupEventTypeMap" />
    Friend Shared Function GetEventTypeGroupFromEventType(
        ByVal eventType As EventType) As EventTypeGroup

        Dim eventTypeGroup As EventTypeGroup
        If Not _eventTypeGroupEventTypeMap.TryGetValue(eventType, 
                                                       eventTypeGroup) Then

            Dim format As String = 
                "No event type group is mapped to the event type '{0}'."

            Dim message As String =
                String.Format(CultureInfo.CurrentCulture, format, eventType)

            Throw New InvalidOperationException(message)

        End If

        Return eventTypeGroup

    End Function

    #End Region

    #Region "Static Constructors"

    ''' <summary>
    ''' Initialises the <see cref="EventTypeHelper"/> class.
    ''' </summary>
    Shared Sub New()

        ' Initialise the event type / abbreviation map.
        '
        InitialiseEventTypeAbbrMap()


        ' Initialise the event type group / event type map.
        '
        InitialiseEventTypeGroupEventTypeMap()

    End Sub

    #End Region

    #Region "Private Constructors"

    ''' <summary>
    ''' Prevents a default instance of the <see cref="EventTypeHelper"/> class
    ''' from being created.
    ''' </summary>
    Private Sub New()
    End Sub

    #End Region

End Class


''' <summary>
''' Represents information about a single score in a event.
''' </summary>
Friend Class EventScore
    
    #Region "Internal Properties"

    ''' <summary>
    ''' Gets or sets the event type.
    ''' </summary>
    Friend Property EventType As EventType
    

    ''' <summary>
    ''' Gets or sets the points achieved in the event. Derived from the score.
    ''' </summary>
    Friend Property Points As Long
    

    ''' <summary>
    ''' Gets or sets the score set in the event.
    ''' </summary>
    Friend Property Score As Decimal

    #End Region

    #Region "Public Methods"
    
    ''' <summary>
    ''' Returns a <see cref="System.String" /> that represents this instance.
    ''' </summary>
    ''' <returns>
    ''' A <see cref="System.String" /> that represents this instance.
    ''' </returns>
    Public Overrides Function ToString() As String
        
        Dim format As String = 
            "EventType: {0}, Points: {1}, Score: {2}"

        Dim value As String = 
            String.Format(CultureInfo.InvariantCulture, format,
                Me.EventType, Me.Points, Me.Score)

        Return value

    End Function

    #End Region

    #Region "Internal Constructors"
    
    ''' <summary>
    ''' Initialises a new instance of the <see cref="EventScore"/> class.
    ''' </summary>
    Friend Sub New()
    End Sub

    #End Region

End Class


''' <summary>
''' Provides the functionality to calculate the points for an
''' <see cref="EventScore" />.
''' </summary>
Friend Class EventScorePointsCalculatorService

    #Region "Internal Properties"
    
    ''' <summary>
    ''' Gets or sets the event score for which to calculation the points.
    ''' </summary>
    Friend Property EventScore As EventScore

    #End Region

    #Region "Private Methods"
    
    ''' <summary>
    ''' Calculates the points.
    ''' </summary>
    Private Sub CalculatePoints()

        Dim pointsCalculator As PointsCalculator = 
            New PointsCalculator(Me.EventScore.EventType, _
                                 Me.EventScore.Score)

        pointsCalculator.CalculatePoints()

        Dim points As Long = pointsCalculator.Points

        Me.EventScore.Points = points

    End Sub


    ''' <summary>
    ''' Throws a <see cref="InvalidOperationException" /> if 
    ''' <see cref="EventScore" /> is <c>null</c>.
    ''' </summary>
    ''' <exception cref="InvalidOperationException">
    ''' <see cref="EventScore" /> was <c>null</c>.
    ''' </exception>
    Private Sub ThrowIfEventScoreIsNull()

        If Me.EventScore Is Nothing

            Throw New InvalidOperationException(
                "EventScorePointsCalculatorService.EventScore cannot be" & _
                " null.")

        End If

    End Sub

    #End Region

    #Region "Internal Methods"
    
    ''' <summary>
    ''' Calculates the points for the event score.
    ''' </summary>
    ''' <exception cref="InvalidOperationException">
    ''' <see cref="EventScore" /> was <c>null</c>.
    ''' </exception>
    Friend Sub Execute()

        '
        ' Class state validation.
        '

        ThrowIfEventScoreIsNull()


        '
        ' Main work.
        '

        CalculatePoints()

    End Sub

    #End Region

    #Region "Public Methods"
    
    ''' <summary>
    ''' Returns a <see cref="System.String" /> that represents this instance.
    ''' </summary>
    ''' <returns>
    ''' A <see cref="System.String" /> that represents this instance.
    ''' </returns>
    Public Overrides Function ToString() As String
        
        Dim format As String = 
            "EventScore: {0}"

        Dim value As String = 
            String.Format(CultureInfo.InvariantCulture, format, _
                If(Not Me.EventScore Is Nothing,
                   "{" & Me.EventScore.ToString() & "}", "null"))

        Return value

    End Function

    #End Region

    #Region "Internal Constructors"
    
    ''' <summary>
    ''' Initialises a new instance of the
    ''' <see cref="EventScorePointsCalculatorService"/> class.
    ''' </summary>
    Friend Sub New()
    End Sub

    
    ''' <summary>
    ''' Initialises a new instance of the
    ''' <see cref="EventScorePointsCalculatorService"/> class.
    ''' </summary>
    ''' <param name="eventScore">
    ''' The event score for which to calculate the points.
    ''' </param>
    Friend Sub New(ByVal eventScore As EventScore)

        Me.EventScore = eventScore

    End Sub

    #End Region

End Class


''' <summary>
''' Represents a single input data item.
''' </summary>
Friend Class InputDataItem

    #Region "Internal Properties"

    ''' <summary>
    ''' Gets or sets the name of the entrant.
    ''' </summary>
    Friend Property EntrantName As String
    

    ''' <summary>
    ''' Gets or sets the type of the event.
    ''' </summary>
    Friend Property EventType As EventType


    ''' <summary>
    ''' Gets or sets the score achieved by the named entrant's in the specified
    ''' event.
    ''' </summary>
    Friend Property Score As Decimal
    
    #End Region

    #Region "Public Methods"
    
    ''' <summary>
    ''' Returns a <see cref="System.String" /> that represents this instance.
    ''' </summary>
    ''' <returns>
    ''' A <see cref="System.String" /> that represents this instance.
    ''' </returns>
    Public Overrides Function ToString() As String
        
        Dim format As String = 
            "EntrantName: {0}, EventType: {1}, Score: {2}"

        Dim value As String = 
            String.Format(CultureInfo.InvariantCulture, format,
                If(Not Me.EntrantName Is Nothing,
                   """" & Me.EntrantName & """", "null"),
                Me.EventType, Me.Score)

        Return value

    End Function

    #End Region

    #Region "Internal Constructors"

    ''' <summary>
    ''' Initialises a new instance of the <see cref="InputDataItem"/> class.
    ''' </summary>
    Friend Sub New()
    End Sub


    ''' <summary>
    ''' Initialises a new instance of the <see cref="InputDataItem"/> class.
    ''' </summary>
    ''' <param name="entrantName">
    ''' The name of the entrant.
    ''' </param>
    ''' <param name="eventType">
    ''' The type of the event.
    ''' </param>
    ''' <param name="score">
    ''' The score.
    ''' </param>
    Friend Sub New(ByVal entrantName As String, ByVal eventType As EventType,
                   ByVal score As Decimal)

        Me.EntrantName = entrantName
        Me.EventType   = eventType
        Me.Score       = score

    End Sub

    #End Region

End Class


''' <summary>
''' Represents a single input data set. An input data set contains information
''' about event measurements for entrants for a single decathlon.
''' </summary>
Friend Class InputDataSet

    #Region "Private Fields"
        
    ''' <summary>
    ''' The collection of input data items.
    ''' </summary>
    Private _items As List(Of InputDataItem) = New List(Of InputDataItem)

    #End Region

    #Region "Internal Properties"
    
    ''' <summary>
    ''' Gets the items.
    ''' </summary>
    ''' <value>
    ''' The items.
    ''' </value>
    Friend ReadOnly Property Items As List(Of InputDataItem)
        Get
            Return _items
        End Get
    End Property

    #End Region

    #Region "Public Methods"
    
    ''' <summary>
    ''' Returns a <see cref="System.String" /> that represents this instance.
    ''' </summary>
    ''' <returns>
    ''' A <see cref="System.String" /> that represents this instance.
    ''' </returns>
    Public Overrides Function ToString() As String
        
        Dim format As String = 
            "Items: {0}"

        Dim value As String = 
            String.Format(CultureInfo.InvariantCulture, format, _
                If(Not Me.Items Is Nothing,
                   Me.Items.Count.ToString(CultureInfo.InvariantCulture) & 
                   If(Me.Items.Count = 1, " item", " items"), "null"))

        Return value

    End Function

    #End Region

    #Region "Internal Constructors"

    ''' <summary>
    ''' Initialises a new instance of the <see cref="InputDataSet"/> class.
    ''' </summary>
    Friend Sub New()
    End Sub

    #End Region

End Class


''' <summary>
''' Represents a single input file. An input file contains multiple data sets,
''' each data set represents information for a single decathlon.
''' </summary>
Friend Class InputFile

    #Region "Private Fields"

    ''' <summary>
    ''' The list of data sets contained by this input file.
    ''' </summary>
    Private _dataSets As List(Of InputDataSet) = New List(Of InputDataSet)

    #End Region

    #Region "Internal Properties"

    ''' <summary>
    ''' Gets the list of data sets contained by this input file.
    ''' </summary>
    Friend ReadOnly Property DataSets As List(Of InputDataSet)
        Get
            Return _dataSets
        End Get
    End Property

    #End Region

    #Region "Public Methods"
    
    ''' <summary>
    ''' Returns a <see cref="System.String" /> that represents this instance.
    ''' </summary>
    ''' <returns>
    ''' A <see cref="System.String" /> that represents this instance.
    ''' </returns>
    Public Overrides Function ToString() As String
        
        Dim format As String = 
            "DataSets: {0}"

        Dim value As String = 
            String.Format(CultureInfo.InvariantCulture, format, _
                If(Not Me.DataSets Is Nothing,
                   Me.DataSets.Count.ToString(CultureInfo.InvariantCulture) & 
                   If(Me.DataSets.Count = 1, " item", " items"), "null"))

        Return value

    End Function

    #End Region

    #Region "Internal Constructors"

    ''' <summary>
    ''' Initialises a new instance of the <see cref="InputFile"/> class.
    ''' </summary>
    Friend Sub New()
    End Sub

    #End Region

End Class


''' <summary>
''' Provides the functionality to read and parse an input file from disk.
''' </summary>
Friend Class InputFileParser

    #Region "Private Fields"
    
    ''' <summary>
    ''' The input file which was parsed.
    ''' </summary>
    Private _inputFile As InputFile


    ''' <summary>
    ''' The contents of the file being parsed.
    ''' </summary>
    ''' <seealso cref="ReadFile" />
    Private _fileContents As List(Of String)

    #End Region

    #Region "Internal Properties"

    ''' <summary>
    ''' Gets the input file which was parsed from the file specified in
    ''' <see cref="FilePath" />.
    ''' </summary>
    Friend Property InputFile As InputFile
        Get
            Return _inputFile
        End Get
        Private Set
            _inputFile = Value
        End Set
    End Property
    

    ''' <summary>
    ''' Gets or sets the path to the input file to be read and parsed.
    ''' </summary>
    Friend Property FilePath() As String

    #End Region

    #Region "Private Methods"

    ''' <summary>
    ''' Parses an <see cref="InputFile" /> from the file contents.
    ''' </summary>
    ''' <seealso cref="_fileContents" />
    ''' <seealso cref="InputFile" />
    Private Sub ParseFileContents()

        ' Create an initial data set in the input file.
        '
        Dim dataSet As InputDataSet = New InputDataSet()


        ' Iterate over each line from the file.
        '
        For Each line As String In Me._fileContents

            ' If the line starts with "##", this indicates the end of the file.
            ' Stop processing.
            '
            If Not line Is Nothing AndAlso 
                line.StartsWith("##", StringComparison.OrdinalIgnoreCase) Then
                
                Exit Sub

            End If

            
            ' If the line starts with "#", this indicates the end of the data
            ' set. Add the completed data set to the InputFile. Start a new data
            ' set. Move to the next line.
            '
            If Not line Is Nothing AndAlso 
                line.StartsWith("#", StringComparison.OrdinalIgnoreCase) Then

                Me.InputFile.DataSets.Add(dataSet)
                dataSet = New InputDataSet()
                Continue For

            End If


            ' Parse entrant name, event type and score from this line.
            '
            Dim inputDataItem As InputDataItem = ParseFileLine(line)

            ' Append to current data set.
            '
            dataSet.Items.Add(inputDataItem)

        Next

    End Sub

    
    ''' <summary>
    ''' Parses a single line from an input file in to a
    ''' <see cref="InputDataItem" />.
    ''' </summary>
    ''' <param name="input">
    ''' A single line from an input file.
    ''' </param>
    ''' <returns>
    ''' <see cref="InputDataItem" />
    ''' <para>
    ''' A single input data item taking its values from the specified
    ''' <paramref name="input" /> line data.
    ''' </para>
    ''' </returns>
    ''' <exception cref="ArgumentNullException">
    ''' <paramref name="input" /> was <c>null</c>.
    ''' </exception>
    Private Function ParseFileLine(ByVal input As String) As InputDataItem

        '
        ' Parameter validation.
        '

        If input Is Nothing Then
            Throw New ArgumentNullException("input")
        End If


        '
        ' Main work.
        '

        ' From the rules:
        ' "The items on each line will be separated by one or more whitespace
        ' characters (tabs and/or spaces) and may have trailing whitespace."
        '

        Dim items() As String = 
            input.Split(
                New String() { Microsoft.VisualBasic.ControlChars.Tab, " " },
                StringSplitOptions.RemoveEmptyEntries)


        ' Entrant name.
        '
        Dim entrantName As String = Nothing
        If items.Length >= 1 Then
            entrantName = items(0).ToUpper()
        End If


        ' Event type.
        '
        Dim eventAbbr As String = Nothing
        If items.Length >= 2 Then
            eventAbbr = items(1)
        End If

        Dim eventType As EventType = 
            EventTypeHelper.GetEventTypeFromAbbreviation(eventAbbr)


        ' Score.
        '
        Dim score As Decimal
        If items.Length >= 3 Then
            score = Decimal.Parse(items(2), CultureInfo.InvariantCulture)
        End If


        ' Assemble an InputDataItem.
        '
        Dim inputDataItem As InputDataItem =
            New InputDataItem(entrantName, eventType, score)

        Return inputDataItem

    End Function


    ''' <summary>
    ''' Reads the file.
    ''' </summary>
    ''' <exception cref="InvalidOperationException">
    ''' <see cref="FilePath" /> was <c>null</c>, empty or consisted entirely of
    ''' white-space.
    ''' </exception>
    ''' <seealso cref="_fileContents" />
    Private Sub ReadFile()

        '
        ' Class state validation.
        '

        If String.IsNullOrWhiteSpace(Me.FilePath) Then

            Throw New InvalidOperationException(
                "InputFileParser.FilePath cannot be null, empty or consist" _
                & " entirely of white-space.")

        End If


        '
        ' Main work.
        '

        Dim contents As String() = System.IO.File.ReadAllLines(Me.FilePath)

        Me._fileContents = contents.ToList()

    End Sub

    #End Region

    #Region "Internal Methods"

    ''' <summary>
    ''' Parses the input file.
    ''' </summary>
    Friend Sub Parse()

        Me.InputFile = New InputFile()

        ' Read the file, obtain the contents.
        '
        Me.ReadFile()

        ' Parse the file contents into an InputFile.
        '
        Me.ParseFileContents()

    End Sub

    #End Region

    #Region "Public Methods"
    
    ''' <summary>
    ''' Returns a <see cref="System.String" /> that represents this instance.
    ''' </summary>
    ''' <returns>
    ''' A <see cref="System.String" /> that represents this instance.
    ''' </returns>
    Public Overrides Function ToString() As String
        
        Dim format As String = 
            "InputFile: {0}, FilePath = {1}"

        Dim value As String = 
            String.Format(CultureInfo.InvariantCulture, format, _
                If(Not Me.InputFile Is Nothing,
                   "{" & Me.InputFile.ToString() & "}", "null"),
                If(Not Me.FilePath Is Nothing,
                   """" & Me.FilePath.ToString() & """", "null"))

        Return value

    End Function

    #End Region

    #Region "Static Constructors"

    ''' <summary>
    ''' Initialises the <see cref="InputFileParser"/> class.
    ''' </summary>
    Shared Sub New()
    End Sub

    #End Region

    #Region "Internal Constructors"

    ''' <summary>
    ''' Initialises a new instance of the <see cref="InputFileParser"/> class.
    ''' </summary>
    Friend Sub New()
        
        ' Set the file path to the default. A file named "Decathlon.dat" in the
        ' application directory.
        '
        Me.FilePath = "Decathlon.dat"

    End Sub


    ''' <summary>
    ''' Initialises a new instance of the <see cref="InputFileParser"/> class.
    ''' </summary>
    ''' <param name="filePath">
    ''' The path to the input file to be read and parsed.
    ''' </param>
    Friend Sub New(ByVal filePath As String)

        Me.FilePath = filePath

    End Sub

    #End Region

End Class


''' <summary>
''' Represents a league table for a single decathlon combined event.
''' </summary>
Friend Class LeagueTable

    #Region "Private Fields"
    
    ''' <summary>
    ''' The entrants.
    ''' </summary>
    Private _entrants As List(Of LeagueTableEntrant) =
        New List(Of LeagueTableEntrant)

    #End Region

    #Region "Internal Properties"

    ''' <summary>
    ''' Gets the entrants.
    ''' </summary>
    Friend ReadOnly Property Entrants As List(Of LeagueTableEntrant)
        Get
            Return _entrants
        End Get
    End Property

    #End Region

    #Region "Public Methods"
    
    ''' <summary>
    ''' Returns a <see cref="System.String" /> that represents this instance.
    ''' </summary>
    ''' <returns>
    ''' A <see cref="System.String" /> that represents this instance.
    ''' </returns>
    Public Overrides Function ToString() As String
        
        Dim format As String = 
            "Entrants: {0}"

        Dim value As String = 
            String.Format(CultureInfo.InvariantCulture, format, _
                If(Not Me.Entrants Is Nothing,
                   Me.Entrants.Count.ToString(CultureInfo.InvariantCulture) & 
                   If(Me.Entrants.Count = 1, " item", " items"), "null"))

        Return value

    End Function

    #End Region

    #Region "Internal Constructors"

    ''' <summary>
    ''' Initialises a new instance of the <see cref="LeagueTable"/> class.
    ''' </summary>
    Friend Sub New()
    End Sub

    #End Region

End Class


''' <summary>
''' Provides the functionality to calculate a league table for a combined event.
''' </summary>
Friend Class LeagueTableCalculatorService

    #Region "Internal Properties"

    ''' <summary>
    ''' Gets or sets the combined event for which to calculate the league table.
    ''' </summary>
    Friend Property CombinedEvent As CombinedEvent

    #End Region

    #Region "Private Methods"
    
    ''' <summary>
    ''' Calculates the league table.
    ''' </summary>
    ''' <exception cref="InvalidOperationException">
    ''' <see cref="CombinedEvent.Entrants" /> was <c>null</c>.
    ''' </exception>
    Private Sub CalculateLeagueTable()
        
        '
        ' Class state validation.
        '

        If Me.CombinedEvent.Entrants Is Nothing Then

            Throw New InvalidOperationException(
                "LeagueTableCalculatorService.CombinedEvent.Entrants" _
                & " cannot be null.")

        End If


        '
        ' Main work.
        '

        ' Produce an ordered list of entrants and a sum of all the points each
        ' individual entrant has achieved for all the events in the decathlon.
        ' The highest scoring entrant should appear as the first item in the
        ' list.
        '
        Dim leagueTableEntrants =
            From entrant In Me.CombinedEvent.Entrants
            Let entrantTotalPoints = entrant.EventScores _
                                            .Sum(Function(score) score.Points)
            Order By entrantTotalPoints Descending
            Select New LeagueTableEntrant() With
            {
                .EntrantName = entrant.EntrantName,
                .TotalPoints = entrantTotalPoints
            }
        

        ' Initialise a new league table with the computed entrants list.
        '
        Dim leagueTable As LeagueTable = New LeagueTable()
        
        leagueTable.Entrants.AddRange(leagueTableEntrants)


        ' Set the league table to the combined event.
        '
        Me.CombinedEvent.LeagueTable = leagueTable

    End Sub


    ''' <summary>
    ''' Throws a <see cref="InvalidOperationException" /> if 
    ''' <see cref="CombinedEvent" /> is <c>null</c>.
    ''' </summary>
    ''' <exception cref="InvalidOperationException">
    ''' <see cref="CombinedEvent" /> was <c>null</c>.
    ''' </exception>
    Private Sub ThrowIfCombinedEventIsNull()

        If Me.CombinedEvent Is Nothing

            Throw New InvalidOperationException(
                "LeagueTableCalculatorService.CombinedEvent cannot be null.")

        End If

    End Sub

    #End Region

    #Region "Internal Methods"
    
    ''' <summary>
    ''' Calculates a league table for the combined event.
    ''' </summary>
    ''' <exception cref="InvalidOperationException">
    ''' <see cref="CombinedEvent" /> was <c>null</c>.
    ''' </exception>
    Friend Sub Execute()

        '
        ' Class state validation.
        '

        ThrowIfCombinedEventIsNull()


        '
        ' Main work.
        '

        CalculateLeagueTable()

    End Sub

    #End Region

    #Region "Public Methods"
    
    ''' <summary>
    ''' Returns a <see cref="System.String" /> that represents this instance.
    ''' </summary>
    ''' <returns>
    ''' A <see cref="System.String" /> that represents this instance.
    ''' </returns>
    Public Overrides Function ToString() As String
        
        Dim format As String = 
            "CombinedEvent: {0}"

        Dim value As String = 
            String.Format(CultureInfo.InvariantCulture, format, _
                If(Not Me.CombinedEvent Is Nothing,
                   "{" & Me.CombinedEvent.ToString() & "}", "null"))

        Return value

    End Function

    #End Region

    #Region "Internal Constructors"
    
    ''' <summary>
    ''' Initialises a new instance of the
    ''' <see cref="LeagueTableCalculatorService"/> class.
    ''' </summary>
    Friend Sub New()
    End Sub

    
    ''' <summary>
    ''' Initialises a new instance of the
    ''' <see cref="LeagueTableCalculatorService"/> class.
    ''' </summary>
    ''' <param name="combinedEvent">
    ''' The combined event for which to calculate the league table.
    ''' </param>
    Friend Sub New(ByVal combinedEvent As CombinedEvent)

        Me.CombinedEvent = combinedEvent

    End Sub

    #End Region

End Class


''' <summary>
''' Represents information about a single entrant and their event score/points
''' for all events in a single decathlon combined event.
''' </summary>
Friend Class LeagueTableEntrant

    #Region "Internal Properties"
    
    ''' <summary>
    ''' Gets or sets the name of the entrant.
    ''' </summary>
    Friend Property EntrantName As String
    

    ''' <summary>
    ''' Gets or sets the total points achieved by this entrant in the decathlon.
    ''' </summary>
    Friend Property TotalPoints As Long

    #End Region

    #Region "Public Methods"
    
    ''' <summary>
    ''' Returns a <see cref="System.String" /> that represents this instance.
    ''' </summary>
    ''' <returns>
    ''' A <see cref="System.String" /> that represents this instance.
    ''' </returns>
    Public Overrides Function ToString() As String
        
        Dim format As String = 
            "EntrantName: {0}, TotalPoints: {1}"

        Dim value As String = 
            String.Format(CultureInfo.InvariantCulture, format, _
                If(Not Me.EntrantName Is Nothing,
                   """" & Me.EntrantName & """", "null"),
                Me.TotalPoints)

        Return value

    End Function

    #End Region

    #Region "Internal Constructors"

    ''' <summary>
    ''' Initialises a new instance of the <see cref="CombinedEventEntrant"/>
    ''' class.
    ''' </summary>
    Friend Sub New()
    End Sub


    ''' <summary>
    ''' Initialises a new instance of the <see cref="LeagueTableEntrant"/>
    ''' class.
    ''' </summary>
    ''' <param name="entrantName">
    ''' The name of the entrant.
    ''' </param>
    ''' <param name="totalPoints">
    ''' The total points achieved by this entrant in the decathlon.
    ''' </param>
    Friend Sub New(ByVal entrantName As String, ByVal totalPoints As Long)

        Me.EntrantName = entrantName
        Me.TotalPoints = totalPoints

    End Sub

    #End Region

End Class


''' <summary>
''' Represents a single output data item.
''' </summary>
Friend Class OutputDataItem
    Implements IFormattable

    #Region "Internal Properties"

    ''' <summary>
    ''' Gets or sets the name of the entrant.
    ''' </summary>
    Friend Property EntrantName As String


    ''' <summary>
    ''' Gets or sets the total points achieved by the named entrant across all
    ''' events in a decathlon.
    ''' </summary>
    Friend Property Points As Long
    
    #End Region

    #Region "Private Methods"
    
    ''' <summary>
    ''' Returns a <see cref="System.String" /> that contains the information in
    ''' this instance in a format suitable for a single line in an output file.
    ''' </summary>
    ''' <param name="format">
    ''' The format. A string in the format "F0" where "0" is the width of the
    ''' string used to display the points.
    ''' </param>
    ''' <returns>
    ''' <see cref="System.String" />
    ''' <para>
    ''' A 25 character long string containing the entrant's name left aligned
    ''' to the first column, an appropriate number of spaces, then the points
    ''' right aligned to the 25th column.
    ''' </para>
    ''' </returns>
    ''' <exception cref="System.ArgumentNullException">
    ''' <paramref name="format" /> was <c>null</c>.
    ''' </exception>
    ''' <exception cref="System.ArgumentException">
    ''' <paramref name="format" /> was an empty string or consisted entirely of
    ''' white-space.
    ''' <para>
    ''' -or-
    ''' </para>
    ''' <para>
    ''' <paramref name="format" /> did not start with 'F'.
    ''' </para>
    ''' <para>
    ''' -or-
    ''' </para>
    ''' <para>
    ''' <paramref name="format" /> was not in format 'F0', where 0 is an
    ''' integer.
    ''' </para>
    ''' </exception>
    ''' <remarks>
    ''' The <paramref name="format" /> parameter should be F0 where F means
    ''' "file format" and 0 is the width of the string used to display the 
    ''' points. If the specified width is omitted or less than the width
    ''' required to display the entire points value, the actual width will be
    ''' used.
    ''' E.g.
    ''' Points | Format | Result
    ''' -------+--------+-------
    ''' 123    | F4     | " 123"
    ''' 123    | F3     | "123"
    ''' 123    | F2     | "123"
    ''' 123    | F      | "123"
    ''' </remarks>
    Private Function ToFileFormatString(ByVal format As String) As String

        '
        ' Parameter validation.
        '

        If format Is Nothing Then
            Throw New ArgumentNullException("format")
        Else If String.IsNullOrWhiteSpace(format) Then
            Throw New ArgumentException("Argument cannot be an empty string" &
                " or consist entirely of white-space.", "format")
        End If

        If Not format.ToUpperInvariant().StartsWith("F") Then
            Throw New ArgumentException("Argument should start with 'F'.",
                "format")
        End If

        ' Parse the "0" value from "F0". If the "0" value is not a valid integer
        ' throw an ArgumentException (or should/could I throw a
        ' FormatException)? This is the requested points width (we may override
        ' later).
        '
        Dim pointsWidthInFormat = format.Substring(1)
        Dim pointsWidth As Integer
        If Not Int32.TryParse(pointsWidthInFormat, pointsWidth) Then
            Throw New ArgumentException("Argument should be in the format" &
                " 'F0', where 0 is an integer.", "format")
        End If


        '
        ' Main work.
        '

        ' Put a space between the entrant name and the points, even in the case
        ' of a long name and a long points string.
        '
        Const space      As String  = " "
        
        ' The length of the returned string. This is the length of each line in
        ' the output file format.
        '
        Const lineLength As Integer = 25


        ' If the specified points width is less than the actual points width,
        ' use the actual points width.
        '
        Dim pointsAsString = Me.Points.ToString(CultureInfo.InvariantCulture)

        pointsWidth = Math.Max(pointsWidth, pointsAsString.Length)


        ' If the points does not fill the space available, then points must be
        ' left padded.
        '
        pointsAsString = pointsAsString.PadLeft(pointsWidth)


        ' Calculate the space available for the entrant name; which is the line
        ' length minus the points width minus the length of the space between
        ' the entrant name and the points.
        '
        Dim maxEntrantNameLength = lineLength - pointsWidth - space.Length
        

        ' If the entrant name exceeds the space available, then the entrant name
        ' must be truncated.
        '
        Dim entrantName = If(Me.EntrantName, String.Empty)

        entrantName = If(entrantName.Length <= maxEntrantNameLength,
                         entrantName,
                         entrantName.Substring(0, maxEntrantNameLength))


        ' If the entrant name does not fill the space available, then the
        ' entrant name must be right padded.
        '
        entrantName = entrantName.PadRight(maxEntrantNameLength)


        ' Combine the entrant name, the space and the points to create the final
        ' line for this OutputDataItem in the file format.
        '
        Dim line = String.Format(CultureInfo.InvariantCulture, "{0}{1}{2}",
            entrantName, space, pointsAsString)

        Return line

    End Function

    #End Region

    #Region "Public Methods"
    
    ''' <summary>
    ''' Returns a <see cref="System.String" /> that represents this instance.
    ''' </summary>
    ''' <returns>
    ''' A <see cref="System.String" /> that represents this instance.
    ''' </returns>
    Public Overrides Function ToString() As String
        
        Dim format As String = 
            "EntrantName: {0}, Points: {1}"

        Dim value As String = 
            String.Format(CultureInfo.InvariantCulture, format, 
                If(Not Me.EntrantName Is Nothing,
                   """" & Me.EntrantName & """", "null"),
                Me.Points)

        Return value

    End Function

    
    ''' <summary>
    ''' Returns a <see cref="System.String" /> that represents this instance.
    ''' </summary>
    ''' <param name="format">
    ''' The format.
    ''' </param>
    ''' <returns>
    ''' A <see cref="System.String" /> that represents this instance.
    ''' </returns>
    Public Overloads Function ToString(ByVal format As String) As String

        Return Me.ToString(format, Nothing)

    End Function

 
    ''' <summary>
    ''' Returns a <see cref="System.String" /> that represents this instance.
    ''' </summary>
    ''' <param name="format">
    ''' The format.
    ''' </param>
    ''' <param name="formatProvider">
    ''' The format provider.
    ''' </param>
    ''' <returns>
    ''' A <see cref="System.String" /> that represents this instance.
    ''' </returns>
    ''' <exception cref="System.FormatException">
    ''' The specified <paramref name="format" /> is not supported.
    ''' </exception>
    Public Overloads Function ToString(format As String,
        formatProvider As IFormatProvider) As String _
        Implements IFormattable.ToString

        
        '
        ' Parameter validation.
        '

        ' If format is not specified, default to "G", general format.
        ' General format MUST be supported and should be equivalent to calling
        ' the parameterless ToString(), i.e. Object.ToString().
        '
        If String.IsNullOrWhiteSpace(format) Then
            format = "G"
        End If

        ' If the format provider is not specified, default to the current
        ' culture.
        '
        If formatProvider Is Nothing Then
            formatProvider = CultureInfo.CurrentCulture
        End If


        '
        ' Main work.
        '

        Select Case format.Trim().ToUpperInvariant().Substring(0, 1)
            
            Case "G"
                Return Me.ToString()

            Case "F"
                Return Me.ToFileFormatString(format)
            
            Case Else
                Throw New FormatException(
                    String.Format(CultureInfo.InvariantCulture,
                        "The '{0}' format string is not supported.", format))

        End Select

    End Function

    #End Region

    #Region "Internal Constructors"

    ''' <summary>
    ''' Initialises a new instance of the <see cref="OutputDataItem"/> class.
    ''' </summary>
    Friend Sub New()
    End Sub


    ''' <summary>
    ''' Initialises a new instance of the <see cref="OutputDataItem"/> class.
    ''' </summary>
    ''' <param name="entrantName">
    ''' The name of the entrant.
    ''' </param>
    ''' <param name="points">
    ''' The total points achieved by the entrant across all the events in a
    ''' decathlon.
    ''' </param>
    Friend Sub New(ByVal entrantName As String, ByVal points As Long)

        Me.EntrantName = entrantName
        Me.Points      = points

    End Sub

    #End Region

End Class


''' <summary>
''' Represents a single output data set. An output data set contains an ordered
''' league table for a single decathlon.
''' </summary>
Friend Class OutputDataSet

    #Region "Private Fields"
        
    ''' <summary>
    ''' The collection of output data items.
    ''' </summary>
    Private _items As List(Of OutputDataItem) = New List(Of OutputDataItem)

    #End Region

    #Region "Internal Properties"
    
    ''' <summary>
    ''' Gets the items.
    ''' </summary>
    Friend ReadOnly Property Items As List(Of OutputDataItem)
        Get
            Return _items
        End Get
    End Property

    #End Region

    #Region "Public Methods"
    
    ''' <summary>
    ''' Returns a <see cref="System.String" /> that represents this instance.
    ''' </summary>
    ''' <returns>
    ''' A <see cref="System.String" /> that represents this instance.
    ''' </returns>
    Public Overrides Function ToString() As String
        
        Dim format As String = 
            "Items: {0}"

        Dim value As String = 
            String.Format(CultureInfo.InvariantCulture, format, _
                If(Not Me.Items Is Nothing,
                   Me.Items.Count.ToString(CultureInfo.InvariantCulture) & 
                   If(Me.Items.Count = 1, " item", " items"), "null"))

        Return value

    End Function

    #End Region

    #Region "Internal Constructors"

    ''' <summary>
    ''' Initialises a new instance of the <see cref="OutputDataSet"/> class.
    ''' </summary>
    Friend Sub New()
    End Sub

    #End Region

End Class


''' <summary>
''' Represents a single output file. An output file contains multiple data sets,
''' each data set represents information for a single decathlon.
''' </summary>
Friend Class OutputFile

    #Region "Private Fields"

    ''' <summary>
    ''' The list of data sets contained by this output file.
    ''' </summary>
    Private _dataSets As List(Of OutputDataSet) = New List(Of OutputDataSet)

    #End Region

    #Region "Internal Properties"

    ''' <summary>
    ''' Gets the list of data sets contained by this output file.
    ''' </summary>
    Friend ReadOnly Property DataSets As List(Of OutputDataSet)
        Get
            Return _dataSets
        End Get
    End Property

    #End Region

    #Region "Public Methods"
    
    ''' <summary>
    ''' Returns a <see cref="System.String" /> that represents this instance.
    ''' </summary>
    ''' <returns>
    ''' A <see cref="System.String" /> that represents this instance.
    ''' </returns>
    Public Overrides Function ToString() As String
        
        Dim format As String = 
            "DataSets: {0}"

        Dim value As String = 
            String.Format(CultureInfo.InvariantCulture, format, _
                If(Not Me.DataSets Is Nothing,
                   Me.DataSets.Count.ToString(CultureInfo.InvariantCulture) & 
                   If(Me.DataSets.Count = 1, " item", " items"), "null"))

        Return value

    End Function

    #End Region

    #Region "Internal Constructors"

    ''' <summary>
    ''' Initialises a new instance of the <see cref="OutputFile"/> class.
    ''' </summary>
    Friend Sub New()
    End Sub

    #End Region

End Class


''' <summary>
''' Provides the functionality to write an output file to disk.
''' </summary>
Friend Class OutputFileWriter

    #Region "Private Fields"
    
    ''' <summary>
    ''' The contents of the file to be written.
    ''' </summary>
    ''' <seealso cref="WriteFile" />
    Private _fileContents As List(Of String)    


    ''' <summary>
    ''' The output file to write to disk.
    ''' </summary>
    Private _outputFile As OutputFile

    #End Region

    #Region "Internal Properties"

    ''' <summary>
    ''' Gets or sets the path to which the output file is to be written.
    ''' </summary>
    Friend Property FilePath() As String


    ''' <summary>
    ''' Gets the output file to be written to disk.
    ''' </summary>
    Friend Property OutputFile As OutputFile
        Get
            Return _outputFile
        End Get
        Private Set
            _outputFile = Value
        End Set
    End Property

    #End Region

    #Region "Private Methods"
    
    ''' <summary>
    ''' Builds the file contents.
    ''' </summary>
    ''' <seealso cref="OutputFile" />
    ''' <seealso cref="_fileContents" />
    ''' <exception cref="InvalidOperationException">
    ''' <see cref="OutputFile" /> was <c>null</c>.
    ''' <para>
    ''' -or-
    ''' </para>
    ''' <para>
    ''' <see cref="OutputFile.DataSets" /> was <c>null</c>.
    ''' </para>
    ''' </exception>
    Private Sub BuildFileContents()

        '
        ' Class state validation.
        '

        ThrowIfOutputFileIsNull()
        ThrowIfOutputFileDataSetsIsNull()


        '
        ' Main work.
        '

        Me._fileContents = New List(Of String)

        ' Obtain the string length of the highest points. All points should be
        ' the same width in the file (or maybe per league data set?) to make the
        ' output pretty, i.e. don't overlap the entrant name on one line with
        ' the points on another line (in the case of very long entrant names).
        '
        Dim maxPointsLength = Me.OutputFile.DataSets _
            .SelectMany(Function (f) f.Items) _
            .Select(Function (f) f.Points) _
            .Select(Function (f) f.ToString(CultureInfo.InvariantCulture)) _
            .Select(Function (f) f.Length) _
            .DefaultIfEmpty() _
            .Max()

        ' The file format for each line is "F0" where 0 is the points length.
        '
        Dim fileLineFormat = 
            String.Format(CultureInfo.InvariantCulture, "F{0}", maxPointsLength)


        For Each dataSet In Me.OutputFile.DataSets

            For Each dataItem In dataSet.Items

                Dim dataItemLine = dataItem.ToString(fileLineFormat, 
                                       CultureInfo.InvariantCulture)

                _fileContents.Add(dataItemLine)

            Next


            ' If this isn't the last data set, then we need to add a blank
            ' between this and the next data set. We do NOT want a blank line
            ' after the last data set - this is an automatic fail.
            '
            If Not Object.ReferenceEquals(dataSet, 
                Me.OutputFile.DataSets.Last()) Then
                
                _fileContents.Add("")

            End If

        Next

    End Sub

    
    ''' <summary>
    ''' Throws <see cref="InvalidOperationException" /> if
    ''' <see cref="_fileContents" /> is <c>null</c>.
    ''' </summary>
    ''' <exception cref="InvalidOperationException">
    ''' <see cref="_fileContents" /> was <c>null</c>.
    ''' </exception>
    Private Sub ThrowIfFileContentsIsNull()

        If Me._fileContents Is Nothing Then

            Throw New InvalidOperationException(
                "OutputFileWriter._fileContents cannot be null.")

        End If

    End Sub
    

    ''' <summary>
    ''' Throws an <see cref="InvalidOperationException" /> if
    ''' <see cref="FilePath" /> is <c>null</c>, empty or consists entirely of
    ''' white-space.
    ''' </summary>
    ''' <exception cref="InvalidOperationException">
    ''' <see cref="FilePath" /> was <c>null</c>, empty or consisted entirely of
    ''' white-space.
    ''' </exception>
    Private Sub ThrowIfFilePathIsEmpty()

        If String.IsNullOrWhiteSpace(Me.FilePath) Then

            Throw New InvalidOperationException(
                "OutputFileWriter.FilePath cannot be null, empty or consist" _
                & " entirely of white-space.")

        End If

    End Sub


    ''' <summary>
    ''' Throws an <see cref="InvalidOperationException" /> if
    ''' <see cref="OutputFile.DataSets" /> is <c>null</c>.
    ''' </summary>
    ''' <exception cref="InvalidOperationException">
    ''' <see cref="OutputFile.DataSets" /> was <c>null</c>.
    ''' </exception>
    Private Sub ThrowIfOutputFileDataSetsIsNull()

        If Me.OutputFile Is Nothing OrElse _
           Me.OutputFile.DataSets Is Nothing Then

            Throw New InvalidOperationException(
                "OutputFileWriter.OutputFile.DataSets cannot be null.")

        End If

    End Sub


    ''' <summary>
    ''' Throws an <see cref="InvalidOperationException" /> if
    ''' <see cref="OutputFile" /> is <c>null</c>.
    ''' </summary>
    ''' <exception cref="InvalidOperationException">
    ''' <see cref="OutputFile" /> was <c>null</c>.
    ''' </exception>
    Private Sub ThrowIfOutputFileIsNull()

        If Me.OutputFile Is Nothing Then

            Throw New InvalidOperationException(
                "OutputFileWriter.OutputFile cannot be null.")

        End If

    End Sub


    ''' <summary>
    ''' Writes the file.
    ''' </summary>
    ''' <exception cref="InvalidOperationException">
    ''' <see cref="FilePath" /> was <c>null</c>, empty or consisted entirely of
    ''' white-space.
    ''' </exception>
    ''' <para>
    ''' -or-
    ''' </para>
    ''' <para>
    ''' <see cref="_fileContents" /> was <c>null</c>.
    ''' </para>
    ''' <seealso cref="FilePath" />
    ''' <seealso cref="_fileContents" />
    Private Sub WriteFile()

        '
        ' Class state validation.
        '

        ThrowIfFilePathIsEmpty()        
        ThrowIfFileContentsIsNull()


        '
        ' Main work.
        '

        Using streamWriter = New System.IO.StreamWriter(Me.FilePath)

            Dim lastLineIndex = Me._fileContents.Count - 1

            For lineIndex = 0 To lastLineIndex

                Dim line = Me._fileContents(lineIndex)

                streamWriter.Write(line)

                ' Unless this is the last line to be written to the file, write
                ' a new line character after each line. Why? Well, the rules
                ' state that a blank line should be written between datasets but
                ' not after the last dataset. The HTML mark-up for the sample
                ' output shows there ^is^ a new line character after the last
                ' line but this doesn't render in the browser. If the output
                ' file is displayed at the command line (i.e. "type
                ' Decathlon.out"), then subjectively this causes the file to
                ' appear as though it has a blank line after the last data set.
                ' Thus, after much soul searching, I have decided to *not*
                ' append a new line character after the last line in the file.
                '
                If lineIndex < lastLineIndex Then
                    streamWriter.WriteLine()
                End If

            Next
        
        End Using

    End Sub

    #End Region

    #Region "Internal Methods"

    ''' <summary>
    ''' Writes the output file to disk.
    ''' </summary>
    Friend Sub Write()

        '
        ' Class state validation.
        '

        ThrowIfOutputFileIsNull()
        ThrowIfFilePathIsEmpty()


        '
        ' Main work.
        '

        ' Prepare properly formatted file contents from the output file.
        '
        BuildFileContents()
        
        ' Write the file contents to disk.
        '
        WriteFile()

    End Sub

    #End Region

    #Region "Public Methods"
    
    ''' <summary>
    ''' Returns a <see cref="System.String" /> that represents this instance.
    ''' </summary>
    ''' <returns>
    ''' A <see cref="System.String" /> that represents this instance.
    ''' </returns>
    Public Overrides Function ToString() As String
        
        Dim format As String = 
            "OutputFile: {0}, FilePath: {1}"

        Dim value As String = 
            String.Format(CultureInfo.InvariantCulture, format, _
                If(Not Me.OutputFile Is Nothing,
                   "{" & Me.OutputFile.ToString() & "}", "null"),
                If(Not Me.FilePath Is Nothing,
                   """" & Me.FilePath.ToString() & """", "null"))

        Return value

    End Function

    #End Region

    #Region "Internal Constructors"

    ''' <summary>
    ''' Initialises a new instance of the <see cref="OutputFileWriter"/> class.
    ''' </summary>
    Friend Sub New()
        
        ' Set the file path to the default. A file named "Decathlon.out" in the
        ' application directory.
        '
        Me.FilePath = "Decathlon.out"

    End Sub

    
    ''' <summary>
    ''' Initialises a new instance of the <see cref="OutputFileWriter"/> class.
    ''' </summary>
    ''' <param name="outputFile">
    ''' The output file to be written to disk.
    ''' </param>
    Friend Sub New(ByVal outputFile As OutputFile)

        Me.New()

        Me._outputFile = outputFile

    End Sub


    ''' <summary>
    ''' Initialises a new instance of the <see cref="OutputFileWriter"/> class.
    ''' </summary>
    ''' <param name="filePath">
    ''' The path to which the output file is to be written.
    ''' </param>
    Friend Sub New(ByVal filePath As String)

        Me.FilePath = filePath

    End Sub

    
    ''' <summary>
    ''' Initialises a new instance of the <see cref="OutputFileWriter"/> class.
    ''' </summary>
    ''' <param name="filePath">
    ''' The path to which the output file is to be written.    
    ''' </param>
    ''' <param name="outputFile">
    ''' The output file to be written to disk.
    ''' </param>
    Friend Sub New(ByVal filePath As String, ByVal outputFile As OutputFile)

        Me.FilePath   = filePath
        Me.OutputFile = outputFile

    End Sub

    #End Region

End Class


''' <summary>
''' Provides the functionality to calculate the points awarded for a given
''' score and event type combination.
''' </summary>
Friend Class PointsCalculator

    #Region "Nested Types"
    
    ''' <summary>
    ''' Represents a method which can calculate the (unrounded) points for a
    ''' event, given the A, B and C configuration variables and the score.
    ''' </summary>
    ''' <param name="a">
    ''' The 'A' variable value.
    ''' </param>
    ''' <param name="b">
    ''' The 'B' variable value.
    ''' </param>
    ''' <param name="c">
    ''' The 'C' variable value.
    ''' </param>
    ''' <param name="score">
    ''' The score.
    ''' </param>
    ''' <returns>
    ''' Decimal
    ''' <para>
    ''' The unrounded points for the given inputs. The caller is responsible for
    ''' appropriate rounding. The points should be rounded ^down^ to the nearest
    ''' integer.
    ''' </para>
    ''' </returns>
    Private Delegate Function PointsCalculationEquation(
        ByVal a As Decimal, ByVal b As Decimal, ByVal c As Decimal, 
        ByVal score As Decimal) As Double

    #End Region

    #Region "Private Static Fields"
    
    ''' <summary>
    ''' A map of <see cref="PointsCalculationEquation" />s to
    ''' <see cref="EventTypeGroup" />s.
    ''' </summary>
    Private Shared _pointsCalculationEquationEventTypeGroupMap _
        As Dictionary(Of EventTypeGroup, PointsCalculationEquation)

    #End Region

    #Region "Private Fields"
    
    ''' <summary>
    ''' The type of the event for which to calculate the points.
    ''' </summary>
    Private ReadOnly _eventType As EventType
        

    ''' <summary>
    ''' The calculated points.
    ''' </summary>
    Private _points As Long

    
    ''' <summary>
    ''' The points calculation configuration for the specified event type.
    ''' </summary>
    Private _pointsCalculationConfiguration As PointsCalculatorConfiguration


    ''' <summary>
    ''' A points calculation equation appropriate for the specified event type.
    ''' </summary>
    ''' <seealso cref="_eventType" />
    Private _pointsCalculationEquation As PointsCalculationEquation
    
    
    ''' <summary>
    ''' The score from which to calculate the points.
    ''' </summary>
    Private ReadOnly _score As Decimal

    #End Region

    #Region "Internal Properties"
    
    ''' <summary>
    ''' Gets the type of the event for which to calculate the points.
    ''' </summary>
    Friend ReadOnly Property EventType As EventType
        Get
            Return _eventType
        End Get
    End Property

    
    ''' <summary>
    ''' Gets the calculated points.
    ''' </summary>
    Friend ReadOnly Property Points As Long
        Get
            Return _points
        End Get
    End Property

    
    ''' <summary>
    ''' Gets score from which to calculate the points.
    ''' </summary>
    Friend ReadOnly Property Score As Decimal
        Get
            Return _score
        End Get
    End Property

    #End Region

    #Region "Private Static Methods"

    ''' <summary>
    ''' Calculates the (unrounded) points for a jumping event, given the A, B
    ''' and C configuration variables and the score.
    ''' </summary>
    ''' <param name="a">
    ''' The 'A' variable value.
    ''' </param>
    ''' <param name="b">
    ''' The 'B' variable value.
    ''' </param>
    ''' <param name="c">
    ''' The 'C' variable value.
    ''' </param>
    ''' <param name="score">
    ''' The score.
    ''' </param>
    ''' <returns>
    ''' Decimal
    ''' <para>
    ''' The unrounded points for the given inputs. The caller is responsible for
    ''' appropriate rounding. The points should be rounded ^down^ to the nearest
    ''' integer.
    ''' </para>
    ''' </returns>
    ''' <remarks>
    ''' The competition rules specify the following equation for jumping events:
    '''
    '''           C
    ''' P = A(M-B)
    ''' 
    ''' Note: C is a power.
    '''       M is the measurement in centimetres for jumps.
    ''' </remarks>
    Private Shared Function CalculateJumpingEventsPoints(
        ByVal a As Decimal, ByVal b As Decimal, ByVal c As Decimal,
        ByVal score As Decimal) As Double


        Dim points As Double
        points = a * ((score - b) ^ c)

        Return points

    End Function

    
    ''' <summary>
    ''' Calculates the (unrounded) points for a running event, given the A, B
    ''' and C configuration variables and the score.
    ''' </summary>
    ''' <param name="a">
    ''' The 'A' variable value.
    ''' </param>
    ''' <param name="b">
    ''' The 'B' variable value.
    ''' </param>
    ''' <param name="c">
    ''' The 'C' variable value.
    ''' </param>
    ''' <param name="score">
    ''' The score.
    ''' </param>
    ''' <returns>
    ''' Decimal
    ''' <para>
    ''' The unrounded points for the given inputs. The caller is responsible for
    ''' appropriate rounding. The points should be rounded ^down^ to the nearest
    ''' integer.
    ''' </para>
    ''' </returns>
    ''' <remarks>
    ''' The competition rules specify the following equation for running events:
    '''
    '''           C
    ''' P = A(B-T)
    ''' 
    ''' Note: C is a power.
    '''       T is the time in seconds for running events. 
    ''' </remarks>
    Private Shared Function CalculateRunningEventsPoints(
        ByVal a As Decimal, ByVal b As Decimal, ByVal c As Decimal,
        ByVal score As Decimal) As Double


        Dim points As Double
        points = a * ((b - score) ^ c)

        Return points

    End Function


    ''' <summary>
    ''' Calculates the (unrounded) points for a throwing event, given the A, B
    ''' and C configuration variables and the score.
    ''' </summary>
    ''' <param name="a">
    ''' The 'A' variable value.
    ''' </param>
    ''' <param name="b">
    ''' The 'B' variable value.
    ''' </param>
    ''' <param name="c">
    ''' The 'C' variable value.
    ''' </param>
    ''' <param name="score">
    ''' The score.
    ''' </param>
    ''' <returns>
    ''' Decimal
    ''' <para>
    ''' The unrounded points for the given inputs. The caller is responsible for
    ''' appropriate rounding. The points should be rounded ^down^ to the nearest
    ''' integer.
    ''' </para>
    ''' </returns>
    ''' <remarks>
    ''' The competition rules specify the following equation for throwing
    ''' events:
    '''
    '''           C
    ''' P = A(D-B)
    ''' 
    ''' Note: C is a power.
    '''       D is the distance in metres achieved in a throwing event. 
    ''' </remarks>
    Private Shared Function CalculateThrowingEventsPoints(
        ByVal a As Decimal, ByVal b As Decimal, ByVal c As Decimal,
        ByVal score As Decimal) As Double


        Dim points As Double
        points = a * ((score - b) ^ c)

        Return points

    End Function


    ''' <summary>
    ''' Initialises the points calculation equation / event type group map.
    ''' </summary>
    Private Shared Sub InitialisePointsCalculationEquationEventTypeGroupMap()

        _pointsCalculationEquationEventTypeGroupMap = 
            New Dictionary(Of EventTypeGroup, PointsCalculationEquation)

        _pointsCalculationEquationEventTypeGroupMap.Add(
            EventTypeGroup.Jumping,  AddressOf CalculateJumpingEventsPoints)
        _pointsCalculationEquationEventTypeGroupMap.Add(
            EventTypeGroup.Running,  AddressOf CalculateRunningEventsPoints)
        _pointsCalculationEquationEventTypeGroupMap.Add(
            EventTypeGroup.Throwing, AddressOf CalculateThrowingEventsPoints)

    End Sub

    #End Region

    #Region "Private Methods"
    
    ''' <summary>
    ''' Sets the points calculation configuration.
    ''' </summary>
    ''' <seealso cref="_pointsCalculationConfiguration" />
    ''' <seealso cref="_eventType" />
    Private Sub SetPointsCalculationConfiguration()

        Dim config As PointsCalculatorConfiguration = 
            PointsCalculatorConfigurationRepository _
                .Default.GetByEventType(Me._eventType)

        Me._pointsCalculationConfiguration = config

    End Sub


    ''' <summary>
    ''' Sets the points calculation equation.
    ''' </summary>
    ''' <exception cref="InvalidOperationException">
    ''' A points calculation equation could not be determined for the current
    ''' event type. The map did not contain a value.
    ''' </exception>
    ''' <seealso cref="_pointsCalculationEquation" />
    ''' <seealso cref="_pointsCalculationEquationEventTypeGroupMap" />
    ''' <seealso cref="_eventType" />
    Private Sub SetPointsCalculationEquation()

        Dim eventTypeGroup As EventTypeGroup =
            EventTypeHelper.GetEventTypeGroupFromEventType(Me._eventType)

        Dim pointsCalculationEquation As PointsCalculationEquation
        If Not _pointsCalculationEquationEventTypeGroupMap.TryGetValue(
            eventTypeGroup, pointsCalculationEquation) Then

            Dim format As String = 
                "Couldn't determine a 'PointsCalculationEquation'. The map" _
                & " did not contain the a value for the '{0}' event type group."

            Dim message As String =
                String.Format(CultureInfo.CurrentCulture, format, 
                    eventTypeGroup)

            Throw New InvalidOperationException(message)

        End If

        Me._pointsCalculationEquation = pointsCalculationEquation

    End Sub


    ''' <summary>
    ''' Throws a <see cref="InvalidOperationException" /> if 
    ''' <see cref="_pointsCalculationConfiguration" /> is <c>null</c>.
    ''' </summary>
    ''' <exception cref="InvalidOperationException">
    ''' <see cref="_pointsCalculationConfiguration" /> was <c>null</c>.
    ''' </exception>
    Private Sub ThrowIfPointsCalculationConfigurationIsNull()

        If Me._pointsCalculationConfiguration Is Nothing

            Throw New InvalidOperationException(
                "PointsCalculator._pointsCalculationConfiguration cannot be" & _
                " null.")

        End If

    End Sub


    ''' <summary>
    ''' Throws a <see cref="InvalidOperationException" /> if 
    ''' <see cref="_pointsCalculationEquation" /> is <c>null</c>.
    ''' </summary>
    ''' <exception cref="InvalidOperationException">
    ''' <see cref="_pointsCalculationEquation" /> was <c>null</c>.
    ''' </exception>
    Private Sub ThrowIfPointsCalculationEquationIsNull()

        If Me._pointsCalculationEquation Is Nothing

            Throw New InvalidOperationException(
                "PointsCalculator._pointsCalculationEquation cannot be null.")

        End If

    End Sub

    #End Region

    #Region "Internal Methods"
    
    ''' <summary>
    ''' Calculates the points.
    ''' </summary>
    Friend Sub CalculatePoints()

        '
        ' Class state validation.
        '

        ThrowIfPointsCalculationConfigurationIsNull()
        ThrowIfPointsCalculationEquationIsNull()
        

        '
        ' Main work.
        '

        Dim pointsUnrounded As Double =
            Me._pointsCalculationEquation(Me._pointsCalculationConfiguration.A,
                                          Me._pointsCalculationConfiguration.B,
                                          Me._pointsCalculationConfiguration.C,
                                          Me._score)

        '
        ' If the entrant's score is less than the B constant (the B constant
        ' appears to be baseline performance for each event), this results in a
        ' negative value being raised to a fractional power in the
        ' CalculateXEventPoints() methods. This results in an overflow
        ' (pointsUnrounded is -1.#IND at this point), which will cause an
        ' OverflowException when we call Convert.ToInt64() later.
        '
        ' E.g.
        ' For 100m, the B value is 18 (18 seconds).
        ' A score of 18.1 seconds results in the overflow.
        '
        ' So, we check for this -1.#IND value, and if we have encountered it, we
        ' set the points to zero. I have found some explanation for the thinking
        ' behind the decathlon scoring tables that a score of zero should be
        ' that of "an untrained schoolboy", there is no mention of a negative
        ' points value, so zero seems appropriate.
        ' Note: I have found no mention of an upper limit for an event score.
        '
        ' This check could be also be achieved by comparing the score to the B
        ' constant before attempting the calculation.
        '

        If Double.IsNaN(pointsUnrounded) Then
            pointsUnrounded = 0
        End If

        Dim pointsRoundedDown As Double = Math.Floor(pointsUnrounded)

        Dim points As Long = Convert.ToInt64(pointsRoundedDown)

        Me._points = points

    End Sub

    #End Region

    #Region "Public Methods"
    
    ''' <summary>
    ''' Returns a <see cref="System.String" /> that represents this instance.
    ''' </summary>
    ''' <returns>
    ''' A <see cref="System.String" /> that represents this instance.
    ''' </returns>
    Public Overrides Function ToString() As String
        
        Dim format As String = 
            "EventType: {0}, Points: {1}, Score: {2}"

        Dim value As String = 
            String.Format(CultureInfo.InvariantCulture, format,
                Me.EventType, Me.Points, Me.Score)

        Return value

    End Function

    #End Region

    #Region "Static Constructors"

    ''' <summary>
    ''' Initialises the <see cref="PointsCalculator"/> class.
    ''' </summary>
    Shared Sub New()

        ' Initialise the points calculation equation / event type map.
        '
        InitialisePointsCalculationEquationEventTypeGroupMap()

    End Sub

    #End Region

    #Region "Internal Constructors"
    
    ''' <summary>
    ''' Initialises a new instance of the <see cref="PointsCalculator"/> class.
    ''' </summary>
    ''' <param name="eventType">
    ''' The type of the event for which to calculate the points.
    ''' </param>
    ''' <param name="score">
    ''' The score from which to calculate the points.
    ''' </param>
    Friend Sub New(ByVal eventType As EventType, ByVal score As Decimal)

        Me._eventType = eventType
        Me._score     = score
        
        SetPointsCalculationConfiguration()
        SetPointsCalculationEquation()

    End Sub

    #End Region

End Class


''' <summary>
''' Represents configuration information for a points calculator for a specific
''' event type.
''' </summary>
Friend Class PointsCalculatorConfiguration 
    Implements IEquatable(Of PointsCalculatorConfiguration)

    #Region "Private Fields"
    
    ''' <summary>
    ''' The 'A' variable value for the points calculation algorithm.
    ''' </summary>
    Private ReadOnly _a As Decimal
    

    ''' <summary>
    ''' The 'B' variable value for the points calculation algorithm.
    ''' </summary>
    Private ReadOnly _b As Decimal
    

    ''' <summary>
    ''' The 'C' variable value for the points calculation algorithm.
    ''' </summary>
    Private ReadOnly _c As Decimal
    

    ''' <summary>
    ''' The type of the event for which this configuration class contains
    ''' calculation algorithm variable values.
    ''' </summary>
    Private ReadOnly _eventType As EventType 

    #End Region

    #Region "Internal Properties"
    
    ''' <summary>
    ''' Gets the 'A' variable value for the points calculation algorithm.
    ''' </summary>
    Friend ReadOnly Property A As Decimal
        Get
            Return _a
        End Get
    End Property


    ''' <summary>
    ''' Gets the 'B' variable value for the points calculation algorithm.
    ''' </summary>
    Friend ReadOnly Property B As Decimal
        Get
            Return _b
        End Get
    End Property


    ''' <summary>
    ''' Gets the 'C' variable value for the points calculation algorithm.
    ''' </summary>
    Friend ReadOnly Property C As Decimal
        Get
            Return _c
        End Get
    End Property

    
    ''' <summary>
    ''' Gets the type of the event for which this configuration class contains
    ''' calculation algorithm variable values.
    ''' </summary>
    Friend ReadOnly Property EventType As EventType
        Get
            Return _eventType 
        End Get
    End Property

    #End Region

    #Region "Public Methods"

    ''' <summary>
    ''' Determines whether the specified
    ''' <see cref="PointsCalculatorConfiguration" />, is equal to this instance.
    ''' </summary>
    ''' <param name="other">
    ''' The <see cref="PointsCalculatorConfiguration" /> to compare with this
    ''' instance.
    ''' </param>
    ''' <returns>
    ''' <c>true</c> if the specified
    ''' <see cref="PointsCalculatorConfiguration" /> is equal to this instance;
    ''' otherwise, <c>false</c>.
    ''' </returns>
    Public Overloads Function Equals(other As PointsCalculatorConfiguration) _
        As Boolean Implements _
        System.IEquatable(Of PointsCalculatorConfiguration).Equals


        If other Is Nothing Then
            Return False
        End If

        Dim isEqual As Boolean =
            Me.A = other.A And 
            Me.B = other.B And 
            Me.C = other.C And 
            Me.EventType = other.EventType

        Return isEqual

    End Function


    ''' <summary>
    ''' Determines whether the specified <see cref="System.Object" />, is equal
    ''' to this instance.
    ''' </summary>
    ''' <param name="obj">
    ''' The <see cref="System.Object" /> to compare with this instance.
    ''' </param>
    ''' <returns>
    ''' <c>true</c> if the specified <see cref="System.Object" /> is equal to
    ''' this instance; otherwise, <c>false</c>.
    ''' </returns>
    Public Overrides Function Equals(obj As Object) As Boolean
        
        If obj Is Nothing Then
            Return False
        End If

        Dim otherPointsCalculatorConfiguration = 
            TryCast(obj, PointsCalculatorConfiguration)
        
        If Not otherPointsCalculatorConfiguration Is Nothing Then
            Return Me.Equals(otherPointsCalculatorConfiguration)
        End If

        Return False

    End Function


    ''' <summary>
    ''' Returns a hash code for this instance.
    ''' </summary>
    ''' <returns>
    ''' A hash code for this instance, suitable for use in hashing algorithms
    ''' and data structures like a hash table. 
    ''' </returns>
    Public Overrides Function GetHashCode() As Integer

        Return Me.A.GetHashCode()

    End Function
    

    ''' <summary>
    ''' Returns a <see cref="System.String" /> that represents this instance.
    ''' </summary>
    ''' <returns>
    ''' A <see cref="System.String" /> that represents this instance.
    ''' </returns>
    Public Overrides Function ToString() As String
        
        Dim format As String = 
            "A: {0}, B: {1}, C: {2}, EventType: {3}"

        Dim value As String = 
            String.Format(CultureInfo.InvariantCulture, format,
                Me.A, Me.B, Me.C, Me.EventType)

        Return value

    End Function

    #End Region

    #Region "Public Static Operators"

    ''' <summary>
    ''' Determines whether two <see cref="PointsCalculatorConfiguration" />
    ''' instances are not equal.
    ''' </summary>
    ''' <param name="a">
    ''' The first <see cref="PointsCalculatorConfiguration" /> instance to
    ''' compare.
    ''' </param>
    ''' <param name="b">
    ''' The second <see cref="PointsCalculatorConfiguration" /> instance to
    ''' compare.
    ''' </param>
    ''' <returns>
    ''' <c>true</c> if the specified
    ''' <see cref="PointsCalculatorConfiguration" />, <paramref name="a" />, is
    ''' not equal to the specified
    ''' <see cref="PointsCalculatorConfiguration" />, <paramref name="b" />;
    ''' otherwise, <c>false</c>.
    ''' </returns>
    Public Shared Operator <> (ByVal a As PointsCalculatorConfiguration, _
                               ByVal b As PointsCalculatorConfiguration) _
        As Boolean


        Return Not (a = b)

    End Operator


    ''' <summary>
    ''' Determines whether two <see cref="PointsCalculatorConfiguration" />
    ''' instances are equal.
    ''' </summary>
    ''' <param name="a">
    ''' The first <see cref="PointsCalculatorConfiguration" /> instance to
    ''' compare.
    ''' </param>
    ''' <param name="b">
    ''' The second <see cref="PointsCalculatorConfiguration" /> instance to
    ''' compare.
    ''' </param>
    ''' <returns>
    ''' <c>true</c> if the specified
    ''' <see cref="PointsCalculatorConfiguration" />, <paramref name="a" />, is
    ''' equal to the specified
    ''' <see cref="PointsCalculatorConfiguration" />, <paramref name="b" />;
    ''' otherwise, <c>false</c>.
    ''' </returns>
    Public Shared Operator = (ByVal a As PointsCalculatorConfiguration, _
                              ByVal b As PointsCalculatorConfiguration) _
        As Boolean

        
        ' If both are null, or both are same instance, return true.
        '
        If Object.ReferenceEquals(a, b) Then

            Return True

        End If


        ' If one is null, but not both, return false.
        '
        If DirectCast(a, Object) Is Nothing Or _
           DirectCast(b, Object) Is Nothing Then

            Return False

        End If


        ' Compare a and b via Object.Equals(Object).
        '
        Return a.Equals(b)

    End Operator

    #End Region

    #Region "Internal Constructors"

    ''' <summary>
    ''' Initialises a new instance of the
    ''' <see cref="PointsCalculatorConfiguration"/> class.
    ''' </summary>
    ''' <param name="eventType">
    ''' The type of the event for which this configuration class contains
    ''' calculation algorithm variable values.
    ''' </param>
    ''' <param name="a">
    ''' The 'A' variable value for the points calculation algorithm.
    ''' </param>
    ''' <param name="b">
    ''' The 'B' variable value for the points calculation algorithm.
    ''' </param>
    ''' <param name="c">
    ''' The 'C' variable value for the points calculation algorithm.
    ''' </param>
    Friend Sub New(ByVal eventType As EventType, ByVal a As Decimal, 
                   ByVal b As Decimal, ByVal c As Decimal)

        Me._eventType = eventType
        Me._a         = a
        Me._b         = b
        Me._c         = c

    End Sub

    #End Region

End Class


''' <summary>
''' Provides a repository of <see cref="PointsCalculatorConfiguration" />s.
''' </summary>
Friend Class PointsCalculatorConfigurationRepository

    #Region "Private Static Fields"

    ''' <summary>
    ''' The default instance of the
    ''' <see cref="PointsCalculatorConfigurationRepository" /> class.
    ''' </summary>
    Private Shared _defaultInstance As PointsCalculatorConfigurationRepository =
        New PointsCalculatorConfigurationRepository()

    #End Region

    #Region "Private Fields"

    ''' <summary>
    ''' The collection of points calculator configurations.
    ''' </summary>
    Private _items As List(Of PointsCalculatorConfiguration) =
        New List(Of PointsCalculatorConfiguration)
    
    #End Region

    #Region "Internal Static Properties"

    ''' <summary>
    ''' Gets the default instance of the
    ''' <see cref="PointsCalculatorConfigurationRepository" /> class.
    ''' </summary>
    Friend Shared ReadOnly Property [Default] _
        As PointsCalculatorConfigurationRepository
        Get
            Return _defaultInstance
        End Get
    End Property

    #End Region

    #Region "Private Methods"
    
    ''' <summary>
    ''' Initialises the items.
    ''' </summary>
    Private Sub InitialiseItems()

        ' 100m
        '
        _items.Add(New PointsCalculatorConfiguration(
                       EventType.OneHundredMetreSprint,
                       CDec(25.4347),
                       CDec(18),
                       CDec(1.81)))

        ' 110m hurdles
        '
        _items.Add(New PointsCalculatorConfiguration(
                       EventType.OneHundredAndTenMetreHurdles,
                       CDec(5.74352),
                       CDec(28.5),
                       CDec(1.92)))

        ' 400m sprint
        '
        _items.Add(New PointsCalculatorConfiguration(
                       EventType.FourHundredMetreSprint,
                       CDec(1.53775),
                       CDec(82),
                       CDec(1.81)))

        ' 1500m sprint
        '
        _items.Add(New PointsCalculatorConfiguration(
                       EventType.FifteenHundredMetreSprint,
                       CDec(0.03768),
                       CDec(480),
                       CDec(1.85)))

        ' Discus
        '
        _items.Add(New PointsCalculatorConfiguration(
                       EventType.Discus,
                       CDec(12.91),
                       CDec(4),
                       CDec(1.1)))

        ' Javelin
        '
        _items.Add(New PointsCalculatorConfiguration(
                       EventType.Javelin,
                       CDec(10.14),
                       CDec(7),
                       CDec(1.08)))

        ' Shot put
        '
        _items.Add(New PointsCalculatorConfiguration(
                       EventType.ShotPut,
                       CDec(51.39),
                       CDec(1.5),
                       CDec(1.05)))

        ' Long jump
        '
        _items.Add(New PointsCalculatorConfiguration(
                       EventType.LongJump,
                       CDec(0.14354),
                       CDec(220),
                       CDec(1.4)))

        ' High jump
        '
        _items.Add(New PointsCalculatorConfiguration(
                       EventType.HighJump,
                       CDec(0.8465),
                       CDec(75),
                       CDec(1.42)))

        ' Pole vault
        '
        _items.Add(New PointsCalculatorConfiguration(
                       EventType.PoleVault,
                       CDec(0.2797),
                       CDec(100),
                       CDec(1.35)))
        
        ' TODO: Validate that each event has only one configuration?
        '       Validate that each event has a configuration?
        '       Would a dictionary help here?

    End Sub
    
    #End Region

    #Region "Internal Methods"
    
    ''' <summary>
    ''' Gets the points calculation configuration for the specified event type.
    ''' </summary>
    ''' <param name="eventType">
    ''' The event type.
    ''' </param>
    ''' <returns>
    ''' A <see cref="PointsCalculatorConfiguration" /> for the event type
    ''' specified in <paramref name="eventType" />.
    ''' </returns>
    ''' <exception cref="KeyNotFoundException">
    ''' A <see cref="PointsCalculatorConfiguration" /> could not be found for
    ''' the event type specified in <paramref name="eventType" />.
    ''' </exception>
    Friend Function GetByEventType(ByVal eventType As EventType) _
        As PointsCalculatorConfiguration 

        Dim config as PointsCalculatorConfiguration = 
            _items.FirstOrDefault(Function(c) c.EventType = eventType)

        If config Is Nothing Then

            Dim format As String =
                "A PointsCalculatorConfiguration could not be found for the" & _
                " requested event type ({0})."

            Dim message As String = 
                String.Format(CultureInfo.CurrentCulture, format, eventType)

            Throw New KeyNotFoundException(message)

        End If

        Return config

    End Function
    
    #End Region

    #Region "Static Constructors"

    ''' <summary>
    ''' Initialises the <see cref="PointsCalculatorConfigurationRepository"/>
    ''' class.
    ''' </summary>
    Shared Sub New()
    End Sub

    #End Region

    #Region "Internal Constructors"

    ''' <summary>
    ''' Initialises a new instance of the
    ''' <see cref="PointsCalculatorConfigurationRepository"/> class.
    ''' </summary>
    Friend Sub New()

        InitialiseItems()

    End Sub
    
    #End Region

End Class


''' <summary>
''' Provides the functionality to process the results of a set of Decathlons.
''' Data is sourced from an input file and the results are written to an output
''' file.
''' </summary>
Friend Class ResultProcessor

    #Region "Private Fields"
    
    ''' <summary>
    ''' The list of combined events.
    ''' </summary>
    Private _combinedEvents As List(Of CombinedEvent) =
        New List(Of CombinedEvent)


    ''' <summary>
    ''' The input file.
    ''' </summary>
    Private _inputFile As InputFile

    
    ''' <summary>
    ''' The output file.
    ''' </summary>
    Private _outputFile As OutputFile

    #End Region

    #Region "Private Methods"

    ''' <summary>
    ''' Builds the combined events from the data in the input file.
    ''' </summary>
    ''' <exception cref="InvalidOperationException">
    ''' <see cref="_inputFile" /> was <c>null</c>.
    ''' </exception>
    ''' <seealso cref="_inputFile" />
    Private Sub BuildCombinedEvents()

        '
        ' Class state validation.
        '

        ThrowIfInputFileIsNull()


        '
        ' Main work.
        '
        
        For Each dataSet As InputDataSet In Me._inputFile.DataSets
            
            Dim combinedEvent As CombinedEvent = New CombinedEvent()

            Dim dataItemsByEntrant =
                From dataItem In dataSet.Items
                Group dataItem By dataItem.EntrantName Into grouping = Group
                Select New With
                {
                    .EntrantName = EntrantName,
                    .Items       = grouping
                }

            For Each dataItemGroup In dataItemsByEntrant

                Dim combinedEventEntrant As CombinedEventEntrant = 
                    New CombinedEventEntrant() With
                {
                    .EntrantName = dataItemGroup.EntrantName
                }

                For Each dataItem As InputDataItem In dataItemGroup.Items
                    
                    Dim eventScore As EventScore = New EventScore() With
                    {
                        .EventType = dataItem.EventType,
                        .Score     = dataItem.Score
                    }

                    combinedEventEntrant.EventScores.Add(eventScore)

                Next

                combinedEvent.Entrants.Add(combinedEventEntrant)

            Next

            _combinedEvents.Add(combinedEvent)

        Next        

    End Sub

    
    ''' <summary>
    ''' Builds the output file from the combined events.
    ''' </summary>
    ''' <exception cref="InvalidOperationException">
    ''' <see cref="_combinedEvents" /> was <c>null</c>.
    ''' </exception>
    ''' <seealso cref="_combinedEvents" />
    ''' <seealso cref="_outputFile" />
    Private Sub BuildOutputFile()

        '
        ' Class state validation.
        '

        ThrowIfCombinedEventsIsNull()


        '
        ' Main work.
        '

        Me._outputFile = New OutputFile()
        
        For Each combinedEvent In Me._combinedEvents
            
            Dim dataSet As New OutputDataSet()

            For Each entrant In combinedEvent.LeagueTable.Entrants

                Dim outputDataItem = 
                    New OutputDataItem(entrant.EntrantName, entrant.TotalPoints)

                dataSet.Items.Add(outputDataItem)

            Next

            _outputFile.DataSets.Add(dataSet)

        Next

        ' TODO: Could this be refactored and extracted into an
        '       OutputFileBuilderService class?

    End Sub

    
    ''' <summary>
    ''' Calculates the points for each event score for each entrant in each
    ''' combined event.
    ''' </summary>
    ''' <exception cref="InvalidOperationException">
    ''' <see cref="_combinedEvents" /> was <c>null</c>.
    ''' </exception>
    ''' <seealso cref="_combinedEvents" />
    Private Sub CalculateCombinedEventsPoints()

        '
        ' Class state validation.
        '

        ThrowIfCombinedEventsIsNull()


        '
        ' Main work.
        '
        
        For Each combinedEvent In Me._combinedEvents

            Dim combinedEventPointsCalculatorService = 
                New CombinedEventPointsCalculatorService(combinedEvent)

            combinedEventPointsCalculatorService.Execute()

        Next

    End Sub


    ''' <summary>
    ''' Calculates a league table for each combined event.
    ''' </summary>
    ''' <exception cref="InvalidOperationException">
    ''' <see cref="_combinedEvents" /> was <c>null</c>.
    ''' </exception>
    ''' <seealso cref="_combinedEvents" />
    Private Sub CalculateLeagueTables()
        
        '
        ' Class state validation.
        '

        ThrowIfCombinedEventsIsNull()


        '
        ' Main work.
        '
        
        For Each combinedEvent In Me._combinedEvents

            Dim leagueTableCalculatorService = 
                New LeagueTableCalculatorService(combinedEvent)

            leagueTableCalculatorService.Execute()

        Next

    End Sub


    ''' <summary>
    ''' Reads the input file.
    ''' </summary>
    Private Sub ReadInputFile()

        Dim inputFileParser As InputFileParser = New InputFileParser()
        
        inputFileParser.Parse()

        _inputFile = inputFileParser.InputFile

    End Sub


    ''' <summary>
    ''' Throws a <see cref="InvalidOperationException" /> if 
    ''' <see cref="_combinedEvents" /> is <c>null</c>.
    ''' </summary>
    ''' <exception cref="InvalidOperationException">
    ''' <see cref="_combinedEvents" /> was <c>null</c>.
    ''' </exception>
    Private Sub ThrowIfCombinedEventsIsNull()

        If Me._combinedEvents Is Nothing Then

            Throw New InvalidOperationException(
                "Me._combinedEvents cannot be null.")

        End If

    End Sub

        
    ''' <summary>
    ''' Throws a <see cref="InvalidOperationException" /> if 
    ''' <see cref="_inputFile" /> is <c>null</c>.
    ''' </summary>
    ''' <exception cref="InvalidOperationException">
    ''' <see cref="_inputFile" /> was <c>null</c>.
    ''' </exception>
    Private Sub ThrowIfInputFileIsNull()

        If Me._inputFile Is Nothing Then

            Throw New InvalidOperationException(
                "ResultProcessor._inputFile cannot be null.")

        End If

    End Sub


    ''' <summary>
    ''' Throws a <see cref="InvalidOperationException" /> if 
    ''' <see cref="_outputFile" /> is <c>null</c>.
    ''' </summary>
    ''' <exception cref="InvalidOperationException">
    ''' <see cref="_outputFile" /> was <c>null</c>.
    ''' </exception>
    Private Sub ThrowIfOutputFileIsNull()

        If Me._outputFile Is Nothing Then

            Throw New InvalidOperationException(
                "ResultProcessor._outputFile cannot be null.")

        End If

    End Sub

    
    ''' <summary>
    ''' Writes the output file.
    ''' </summary>
    ''' <exception cref="InvalidOperationException">
    ''' <see cref="outputFile" /> was <c>null</c>.
    ''' </exception>
    Private Sub WriteOutputFile()

        '
        ' Class state validation.
        '

        ThrowIfOutputFileIsNull()


        '
        ' Main work.
        '

        Dim outputFileWriter = New OutputFileWriter(Me._outputFile)

        outputFileWriter.Write()

    End Sub

    #End Region

    #Region "Internal Methods"
    
    ''' <summary>
    ''' Executes this result processor.
    ''' </summary>
    Friend Sub Execute()

        ' Read the input file.
        '
        ReadInputFile()

        ' Build the combined events (one decathlon for each data set in the
        ' input file).
        '
        BuildCombinedEvents()
        
        ' Calculate the points for all the scores in all the combined events.
        '
        CalculateCombinedEventsPoints()

        ' Calculate a league table for all the combined events.
        '
        CalculateLeagueTables()

        ' Build the output file.
        '
        BuildOutputFile()

        ' Write the output file.
        '
        WriteOutputFile()

    End Sub

    #End Region

    #Region "Internal Constructors"

    ''' <summary>
    ''' Initialises a new instance of the <see cref="ResultProcessor"/> class.
    ''' </summary>
    Friend Sub New()
    End Sub

    #End Region

End Class

#End Region

#Region "Modules"

''' <summary>
''' The main application class.
''' </summary>
Module Decathlon

    #Region "Internal Methods"

    ''' <summary>
    ''' Defines the entry point of the application.
    ''' </summary>
    Sub Main()

        Dim resultProcessor As ResultProcessor = New ResultProcessor()

        resultProcessor.Execute()

    End Sub
    
    #End Region

End Module

#End Region
