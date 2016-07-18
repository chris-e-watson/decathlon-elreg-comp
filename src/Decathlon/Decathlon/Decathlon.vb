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

#End Region

#Region "Classes"

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
    ''' Gets or sets the measurement for the named entrant's performance in the
    ''' specified event.
    ''' </summary>
    Friend Property Measurement As Decimal
    
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
    ''' <param name="measurement">
    ''' The measurement.
    ''' </param>
    Friend Sub New(ByVal entrantName As String, ByVal eventType As EventType,
                   ByVal measurement As Decimal)

        Me.EntrantName = entrantName
        Me.EventType   = eventType
        Me.Measurement = measurement

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

        ' Iterate over each line from the file.
        '
        For Each line As String In Me._fileContents

            ' If the line starts with "##", this indicates the end of the file.
            ' Stop processing.
            '
            If Not line Is Nothing AndAlso line.StartsWith("##") Then
                Exit Sub
            End If

            
            ' If the line starts with "##", this indicates the end of the data
            ' set. Start a new data set.
            '
            If Not line Is Nothing AndAlso line.StartsWith("##") Then
                Me.InputFile.DataSets.Add(New InputDataSet())
            End If


            ' Parse entrant name, event type and score from this line.
            '
            Dim inputDataItem As InputDataItem = ParseFileLine(line)

            ' Append to current data set.
            '
            Me.InputFile.DataSets.Last().Items.Add(inputDataItem)

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

        Dim InputFileParser As New InputFileParser()
        InputFileParser.Parse()
        
        Dim InputFile As InputFile
        InputFile = InputFileParser.InputFile()

    End Sub
    
#End Region

End Module

#End Region
