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
'*******************************************************************************

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
''' Provides helper methods for working with <see cref="EventType" />s.
''' </summary>
Friend NotInheritable Class EventTypeHelper
    
    #Region "Private Static Fields"

    ''' <summary>
    ''' The map of event type groups to event types.
    ''' </summary>
    Private Shared _eventTypeGroupEventTypeMap _
        As Dictionary(Of EventType, EventTypeGroup)

    #End Region

    #Region "Private Static Methods"
    
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
                String.Format(format, eventType)

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
            "EntrantName: ""{0}"", EventType: {1}, Score: {2}"

        Dim value As String = 
            String.Format(format, Me.EntrantName, Me.EventType, Me.Score)

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

    #Region "Static Private Fields"

    ''' <summary>
    ''' A map of event types to their abbreviations, as used in an input file.
    ''' </summary>
    ''' <remarks>
    ''' The abbreviations, in the key, are in uppercase.
    ''' </remarks>
    Private Shared _eventTypeAbbrMap As Dictionary(Of String, EventType)

    #End Region

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
            If Not line Is Nothing AndAlso line.StartsWith("##") Then
                Exit Sub
            End If

            
            ' If the line starts with "#", this indicates the end of the data
            ' set. Add the completed data set to the InputFile. Start a new data
            ' set. Move to the next line.
            '
            If Not line Is Nothing AndAlso line.StartsWith("#") Then
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
            input.Split(New String() { "\t", " " },
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
            eventAbbr = items(1).ToUpper()
        End If

        Dim eventType As EventType
        If Not _eventTypeAbbrMap.TryGetValue(eventAbbr, eventType) Then
            eventType = EventType.None
        End If


        ' Score.
        '
        Dim score As Decimal
        If items.Length >= 3 Then
            score = Decimal.Parse(items(2))
        End If


        ' Assembly an InputDataItem.
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

        'TODO: Implement InputFileParser.Parse().
        ' 1. Read file.
        ' 2. Iterate over lines of data in the file.
        ' 3. Parse each line in to entrant, event and score.
        ' 4. Start new data set on a line starting with "#".
        ' 5. Stop processing on a line starting with "##".

        Me.InputFile = New InputFile()

        ' Read the file, obtain the contents.
        '
        Me.ReadFile()

        Me.ParseFileContents()

    End Sub

    #End Region

    #Region "Static Constructors"

    ''' <summary>
    ''' Initialises the <see cref="InputFileParser"/> class.
    ''' </summary>
    Shared Sub New()

        ' Initialise the event type / abbreviation map.
        '
        InitialiseEventTypeAbbrMap()

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
''' Represents a single output data item.
''' </summary>
Friend Class OutputDataItem

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

    #Region "Public Methods"
    
    ''' <summary>
    ''' Returns a <see cref="System.String" /> that represents this instance.
    ''' </summary>
    ''' <returns>
    ''' A <see cref="System.String" /> that represents this instance.
    ''' </returns>
    Public Overrides Function ToString() As String
        
        Dim format As String = 
            "EntrantName: ""{0}"", Points: {1}"

        Dim value As String = 
            String.Format(format, Me.EntrantName, Me.Points)

        Return value

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
''' Provides the functionality to calculate the points awarded for a given
''' score and event type combination.
''' </summary>
Friend Class PointsCalculator

    #Region "Nested Types"

    ' TODO: Is a delegate a type?
    
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
                String.Format(format, eventTypeGroup)

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

        Dim pointsRoundedDown As Double = Math.Floor(pointsUnrounded)

        Dim points As Long = Convert.ToInt64(pointsRoundedDown)

        Me._points = points

    End Sub

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

        'TODO: The rest of the event point calculation configurations.

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
    ''' A PointsCalculatorConfiguration could not be found for the event type
    ''' specified in <paramref name="eventType" />.
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
                String.Format(format, eventType)

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
    ''' The input file.
    ''' </summary>
    Private _inputFile As InputFile

    #End Region

    #Region "Private Methods"

    ''' <summary>
    ''' Reads the input file.
    ''' </summary>
    Private Sub ReadInputFile()

        Dim inputFileParser As InputFileParser = New InputFileParser()
        
        inputFileParser.Parse()

        _inputFile = inputFileParser.InputFile

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

        'TODO: Calculate the points for each Decathlon.

        'TODO: Write the output file.

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
