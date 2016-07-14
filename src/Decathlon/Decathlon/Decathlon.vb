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
    HughJump                     = 9
        
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

    #Region "Private Fields"

    ''' <summary>
    ''' The contents of the file being parsed.
    ''' </summary>
    ''' <seealso cref="ReadFile" />
    Private _fileContents As List(Of String)

    #End Region

#Region "Internal Properties"

    ''' <summary>
    ''' Gets or sets the path to the input file to be read and parsed.
    ''' </summary>
    Friend Property FilePath() As String

#End Region

#Region "Private Methods"

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

        ' Read the file, obtain the contents.
        '
        Me.ReadFile()

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
    End Sub
    
#End Region

End Module

#End Region
