﻿Public Class Runs

    Public Structure RunsReturn
        Public QueryResult As QATDB.QATResult
        Public StartDate As DateTime
        Public EndDate As DateTime
        Public StartTimeStamp As Integer
        Public EndTimeStamp As Integer
        Public Profile_ID As Integer
        Public RequestType As DisplayTypes
    End Structure

    Public Enum DisplayTypes As Integer
        Weekly = 0
        Monthly = 1
        Anual = 2
        Complete = 3
        Custom = 4
    End Enum

    Public Function AddRun(ByVal profile As Integer, ByVal datetime As Date, ByVal duration As Integer, ByVal track As Integer, ByVal laps As Integer) As Boolean
        QAT.AddParameter(New QATDB.QATCore.QATParameter("profile", profile))
        QAT.AddParameter(New QATDB.QATCore.QATParameter("datetime", Me.ConvertToTimestamp(datetime)))
        QAT.AddParameter(New QATDB.QATCore.QATParameter("duration", duration))
        QAT.AddParameter(New QATDB.QATCore.QATParameter("track", track))
        QAT.AddParameter(New QATDB.QATCore.QATParameter("laps", laps))
        QAT.Execute("ADD runs ID=#?,TRACK_ID=@track@,PROFILE_ID=@profile@,date=@datetime@,duration=@duration@,laps=@laps@,distance=-1")
        Return (True)
    End Function

    Public Function AddRun(ByVal profile As Integer, ByVal datetime As Date, ByVal duration As Integer, ByVal distance As Integer) As Boolean
        QAT.AddParameter(New QATDB.QATCore.QATParameter("profile", profile))
        QAT.AddParameter(New QATDB.QATCore.QATParameter("datetime", Me.ConvertToTimestamp(datetime)))
        QAT.AddParameter(New QATDB.QATCore.QATParameter("duration", duration))
        QAT.AddParameter(New QATDB.QATCore.QATParameter("distance", distance))
        QAT.Execute("ADD runs ID=#?,TRACK_ID=-1,PROFILE_ID=@profile@,date=@datetime@,duration=@duration@,laps=1,distance=@distance@")
        Return (True)
    End Function

    Public Function EditRun(ByVal RunID As Integer, ByVal datetime As Date, ByVal duration As Integer, ByVal track As Integer, ByVal laps As Integer) As Boolean
        If (Not Me.RunExists(RunID)) Then
            Return False
        End If

        QAT.AddParameter(New QATDB.QATCore.QATParameter("id", RunID))
        QAT.AddParameter(New QATDB.QATCore.QATParameter("datetime", Me.ConvertToTimestamp(datetime)))
        QAT.AddParameter(New QATDB.QATCore.QATParameter("duration", duration))
        QAT.AddParameter(New QATDB.QATCore.QATParameter("track", track))
        QAT.AddParameter(New QATDB.QATCore.QATParameter("laps", laps))

        QAT.Execute("CHANGE date=@datetime@,duration=@duration@,TRACK_ID=@track@,laps=@laps@,distance=0 FROM runs WHERE ID=@id@")

        Return True
    End Function

    Public Function EditRun(ByVal RunID As Integer, ByVal datetime As Date, ByVal duration As Integer, ByVal distance As Integer) As Boolean
        If (Not Me.RunExists(RunID)) Then
            Return False
        End If

        QAT.AddParameter(New QATDB.QATCore.QATParameter("id", RunID))
        QAT.AddParameter(New QATDB.QATCore.QATParameter("datetime", Me.ConvertToTimestamp(datetime)))
        QAT.AddParameter(New QATDB.QATCore.QATParameter("duration", duration))
        QAT.AddParameter(New QATDB.QATCore.QATParameter("distance", distance))

        QAT.Execute("CHANGE date=@datetime@,duration=@duration@,TRACK_ID=-1,laps=-1,distance=@distance@ FROM runs WHERE ID=@id@")

        Return True
    End Function

    Public Function RemoveRun(ByVal RunID As Integer) As Boolean
        If (Not Me.RunExists(RunID)) Then
            Return False
        End If

        QAT.AddParameter(New QATDB.QATCore.QATParameter("ID", RunID))
        QAT.Execute("DELETE runs WHERE ID=@ID@")
        Return True
    End Function

    Public Function RunExists(ByVal RunID As Integer) As Boolean
        QAT.AddParameter(New QATDB.QATCore.QATParameter("id", RunID))

        Return Not QAT.Execute("LIST ID FROM runs WHERE ID=@id@").HasNothing
    End Function

    Public Function GetRun(ByVal RunID As Integer) As QATDB.QATResult
        If (Not Me.RunExists(RunID)) Then
            Return Nothing
        End If

        QAT.AddParameter(New QATDB.QATCore.QATParameter("id", RunID))
        Return QAT.Execute("LIST * FROM runs WHERE ID=@id@")
    End Function

    Public Function GetWeeklyRuns(ByVal WeekNumber As Integer, ByVal Year As Integer, ByVal profile As Integer) As RunsReturn
        Dim StartDay As DateTime = Me.GoToWeek(Year, WeekNumber)
        Dim EndDay As DateTime
        If (WeekNumber = 52) Then
            EndDay = New DateTime(Year, 12, 31)
        Else
            EndDay = DateAndTime.DateAdd(DateInterval.Day, -1, Me.GoToWeek(Year, WeekNumber + 1))
        End If

        Dim StartTimeStamp As Integer = Me.ConvertToTimestamp(StartDay)
        Dim EndTimeStamp As Integer = Me.ConvertToTimestamp(EndDay)
        Dim returning As RunsReturn

        'Clipboard.SetText("start_day: " & StartTimeStamp & vbNewLine &
        '                  "end_day: " & EndTimeStamp & vbNewLine &
        '                  "profile_id" & profile)

        QAT.AddParameter(New QATDB.QATCore.QATParameter("start_day", StartTimeStamp))
        QAT.AddParameter(New QATDB.QATCore.QATParameter("end_day", EndTimeStamp))
        QAT.AddParameter(New QATDB.QATCore.QATParameter("profile_id", profile))

        'returning.QueryResult = QAT.Execute("LIST ID, TRACK_ID, PROFILE_ID, date, duration, laps, distance FROM runs WHERE  date > @start_day@ , date < @end_day@ , PROFILE_ID = @profile_id@")
        returning.QueryResult = QAT.Execute("LIST ID, TRACK_ID, PROFILE_ID, date, duration, laps, distance FROM runs WHERE PROFILE_ID = @profile_id@")
        returning.StartDate = StartDay
        returning.EndDate = EndDay
        returning.StartTimeStamp = StartTimeStamp
        returning.EndTimeStamp = EndTimeStamp
        returning.Profile_ID = profile
        returning.RequestType = DisplayTypes.Weekly

        Return returning
    End Function

    Public Function GetMonthlyRuns(ByVal Month As Integer, ByVal Year As Integer, ByVal profile As Integer) As RunsReturn
        Dim StartDay As DateTime = New DateTime(Year, Month, 1)
        Dim EndDay As DateTime
        If (Month = 12) Then
            EndDay = New DateTime(Year, 12, 31)
        Else
            EndDay = DateAndTime.DateAdd(DateInterval.Day, -1, New Date(Year, Month + 1, 1))
        End If

        Dim StartTimeStamp As Integer = Me.ConvertToTimestamp(StartDay)
        Dim EndTimeStamp As Integer = Me.ConvertToTimestamp(EndDay)
        Dim returning As RunsReturn

        QAT.AddParameter(New QATDB.QATCore.QATParameter("start_day", StartTimeStamp))
        QAT.AddParameter(New QATDB.QATCore.QATParameter("end_day", EndTimeStamp))
        QAT.AddParameter(New QATDB.QATCore.QATParameter("profile_id", profile))

        returning.QueryResult = QAT.Execute("LIST ID, TRACK_ID, date, duration, laps FROM runs WHERE date > @start_day@ , date < @end_daye@ , PROFILE_ID = @profile_id@")
        returning.StartDate = StartDay
        returning.EndDate = EndDay
        returning.StartTimeStamp = StartTimeStamp
        returning.EndTimeStamp = EndTimeStamp
        returning.Profile_ID = profile
        returning.RequestType = DisplayTypes.Monthly

        Return returning
    End Function

    Public Function GetAnualRuns(ByVal Year As Integer, ByVal profile As Integer) As RunsReturn
        Dim StartDay As DateTime = New DateTime(Year, 1, 1)
        Dim EndDay As DateTime = New DateTime(Year, 12, 31)

        Dim StartTimeStamp As Integer = Me.ConvertToTimestamp(StartDay)
        Dim EndTimeStamp As Integer = Me.ConvertToTimestamp(EndDay)
        Dim returning As RunsReturn

        QAT.AddParameter(New QATDB.QATCore.QATParameter("start_day", StartTimeStamp))
        QAT.AddParameter(New QATDB.QATCore.QATParameter("end_day", EndTimeStamp))
        QAT.AddParameter(New QATDB.QATCore.QATParameter("profile_id", profile))

        returning.QueryResult = QAT.Execute("LIST ID, TRACK_ID, date, duration, laps FROM runs WHERE date > @start_day@ , date < @end_daye@ , PROFILE_ID = @profile_id@")
        returning.StartDate = StartDay
        returning.EndDate = EndDay
        returning.StartTimeStamp = StartTimeStamp
        returning.EndTimeStamp = EndTimeStamp
        returning.Profile_ID = profile
        returning.RequestType = DisplayTypes.Anual

        Return returning
    End Function

    Public Function GetAllRuns(ByVal profile As Integer) As RunsReturn
        Dim returning As RunsReturn

        QAT.AddParameter(New QATDB.QATCore.QATParameter("profile_id", profile))
        Dim StartTimeStamp As Integer = QAT.ExecuteSingle("LOWEST date FROM runs WHERE PROFILE_ID = @profile_id@")
        QAT.AddParameter(New QATDB.QATCore.QATParameter("profile_id", profile))
        Dim EndTimeStamp As Integer = Me.ConvertToTimestamp("HIGHEST date FROM runs WHERE PROFILE_ID = @profile_id@")

        QAT.AddParameter(New QATDB.QATCore.QATParameter("profile_id", profile))
        returning.QueryResult = QAT.Execute("LIST ID, TRACK_ID, date, duration, laps FROM runs WHERE PROFILE_ID = @profile_id@")
        returning.StartDate = Me.ConvertToDateTime(StartTimeStamp)
        returning.EndDate = Me.ConvertToDateTime(EndTimeStamp)
        returning.StartTimeStamp = StartTimeStamp
        returning.EndTimeStamp = EndTimeStamp
        returning.Profile_ID = profile
        returning.RequestType = DisplayTypes.Complete

        Return returning
    End Function

    Public Function GetRunsIn(ByVal StartDate As DateTime, ByVal EndDate As DateTime, ByVal profile As Integer) As RunsReturn
        Dim returning As RunsReturn

        Dim StartTimeStamp As Integer = Me.ConvertToTimestamp(StartDate)
        Dim EndTimeStamp As Integer = Me.ConvertToTimestamp(EndDate)

        QAT.AddParameter(New QATDB.QATCore.QATParameter("profile_id", profile))
        QAT.AddParameter(New QATDB.QATCore.QATParameter("start_day", StartTimeStamp))
        QAT.AddParameter(New QATDB.QATCore.QATParameter("end_day", EndTimeStamp))

        returning.QueryResult = QAT.Execute("LIST ID, TRACK_ID, date, duration, laps FROM runs WHERE date > @start_day@ , date < @end_day@ , PROFILE_ID = @profile_id@")
        returning.StartDate = Me.ConvertToDateTime(StartTimeStamp)
        returning.EndDate = Me.ConvertToDateTime(EndTimeStamp)
        returning.StartTimeStamp = StartTimeStamp
        returning.EndTimeStamp = EndTimeStamp
        returning.Profile_ID = profile
        returning.RequestType = DisplayTypes.Custom

        Return returning
    End Function

    Public Function GoToWeek(ByVal year As Integer, ByVal week As Integer) As DateTime
        ' use the current culture
        Dim ci As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        ' get first day of week from culture
        Dim fdow As DayOfWeek = ci.DateTimeFormat.FirstDayOfWeek

        ' new empty Date (so starts 01/01/0001)
        Dim d As New DateTime()

        ' year starts at 1, so take away 1 from desired year to prevent going to the next one
        d = d.AddYears(year - 1)

        ' get day January 1st falls on
        Dim startDay As Integer = CInt(d.DayOfWeek)

        ' get the difference between the first day of the week, and the day January 1st starts on
        Dim difference As Integer = CInt(fdow) - startDay
        ' if it is positive (i.e. after first day of week), take away 7
        If difference > 0 Then
            difference = difference - 7
        End If

        ' already on week 1, so add desired number of weeks - 1 * days in week
        If week > 1 Then
            d = d.AddDays((week - 1) * 7 + difference)
        End If

        Return d
    End Function

    Public Function WeekOfYear(ByVal [date] As DateTime) As Integer
        ' use the current culture
        Dim ci As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
        ' use current culture's calendar
        Dim cal As System.Globalization.Calendar = ci.Calendar
        ' get the calendar week rule (i.e. what determines the first week in the year)
        Dim cwr As System.Globalization.CalendarWeekRule = ci.DateTimeFormat.CalendarWeekRule
        ' get the first day of week for the current culture
        Dim fdow As DayOfWeek = ci.DateTimeFormat.FirstDayOfWeek
        ' return the week
        Return cal.GetWeekOfYear([date], cwr, fdow) - 1
    End Function

    Public Function ConvertToDateTime(ByVal value As Integer) As DateTime
        Dim dateTime As New System.DateTime(1970, 1, 1, 0, 0, 0, 0)

        dateTime = dateTime.AddSeconds(value)

        Return dateTime
    End Function

    Public Function ConvertToTimestamp(ByVal value As DateTime) As Double
        'create Timespan by subtracting the value provided from
        'the Unix Epoch
        Dim span As TimeSpan = (value - New DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime())

        'return the total seconds (which is a UNIX timestamp)
        Return CDbl(span.TotalSeconds)
    End Function

End Class
