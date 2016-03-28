Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports Intelexion.Nomina
Imports Nomina

Public Class ISN
    Inherits DataDynamics.ActiveReports.ActiveReport3
    Dim sConnection As String = Intelexion.Framework.Model.SQLConnectionProvider.getConnection("default").getConnection.ConnectionString
    'Dim sConnection As String = "Data Source=DCW319V1\MSSQLSERVER8; Initial Catalog=V5McGrawHillNominaTest; User Id=ITXTV5; Password=ITXTV5; Connection Lifetime=60; Max Pool Size=50; Min Pool Size=3"
    Public Sub New()

        'This call is required by the ActiveReports Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    Public Sub New(ByVal reporte As Entities.ReportesProceso)

        'This call is required by the ActiveReports Designer.
        InitializeComponent()

    End Sub


    Public Sub ISN_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.ReportStart
        Me.ShowParameterUI = False


        Me.SetLicense("Hector Ramirez,Intelexion,DD-APN-30-C000260,S4VKSH448MS77HKH9FH9")

        Me.DataSource = New DataDynamics.ActiveReports.DataSources.OleDBDataSource("Provider=SQLOLEDB.1;" & _
                sConnection, "spq_nomISN @IdRazonSocial = " + Me.Parameters("IdRazonSocial").Value + "," & _
                "@Anio = " + Me.Parameters("Anio").Value + "," & _
                "@Mes = " + Me.Parameters("Mes").Value + "," & _
                "@UID = " + Me.Parameters("UID").Value + "," & _
                "@LID = " + Me.Parameters("LID").Value + "," & _
                "@idAccion = " + Me.Parameters("idAccion").Value + "", 90)


        'AQUI

        Dim ParamIdRazonSocial As New Parameter
        ParamIdRazonSocial.Key = "IdRazonSocial"

        Dim ParamAnio As New Parameter
        ParamAnio.Key = "Anio"

        Dim ParamMes As New Parameter
        ParamMes.Key = "Mes"

        Dim ParamUID As New Parameter
        ParamUID.Key = "UID"
        ParamUID.Type = Parameter.DataType.String

        Dim ParamLID As New Parameter
        ParamLID.Key = "LID"
        ParamLID.Type = Parameter.DataType.String

        Dim ParamidAccion As New Parameter
        ParamidAccion.Key = "idAccion"

        ' ''******* SUBREPORTE PERCEPCIONES **************/
        ''                                  nombre del subreporte
        Dim SubReportePercepcionesMensualISN As New PercepcionesMensualISN
        SubReportePercepcionesMensualISN.Parameters.Clear()

        'aqui se agregan
        SubReportePercepcionesMensualISN.Parameters.Add(ParamIdRazonSocial)
        SubReportePercepcionesMensualISN.Parameters.Add(ParamAnio)
        SubReportePercepcionesMensualISN.Parameters.Add(ParamMes)
        SubReportePercepcionesMensualISN.Parameters.Add(ParamUID)
        SubReportePercepcionesMensualISN.Parameters.Add(ParamLID)
        SubReportePercepcionesMensualISN.Parameters.Add(ParamidAccion)


        'aqui se les asigna el valor
        SubReportePercepcionesMensualISN.Parameters("IdRazonSocial").Value = Me.Parameters("IdRazonSocial").Value
        SubReportePercepcionesMensualISN.Parameters("Mes").Value = Me.Parameters("Mes").Value
        SubReportePercepcionesMensualISN.Parameters("LID").Value = Me.Parameters("LID").Value
        SubReportePercepcionesMensualISN.Parameters("idAccion").Value = Me.Parameters("idAccion").Value
        SubReportePercepcionesMensualISN.Parameters("Anio").Value = Me.Parameters("Anio").Value
        SubReportePercepcionesMensualISN.Parameters("UID").Value = Me.Parameters("UID").Value
        Me.SubReport1.Report = SubReportePercepcionesMensualISN


        '*************************************************************************
        ''******* SUBREPORTE DEDUCCIONES **************/
        '                                  nombre del subreporte
        Dim SubReporteDeduccionesMensualISN As New DeduccionesMensualISN
        SubReporteDeduccionesMensualISN.Parameters.Clear()

        'aqui se agregan
        SubReporteDeduccionesMensualISN.Parameters.Add(ParamIdRazonSocial)
        SubReporteDeduccionesMensualISN.Parameters.Add(ParamAnio)
        SubReporteDeduccionesMensualISN.Parameters.Add(ParamMes)
        SubReporteDeduccionesMensualISN.Parameters.Add(ParamUID)
        SubReporteDeduccionesMensualISN.Parameters.Add(ParamLID)
        SubReporteDeduccionesMensualISN.Parameters.Add(ParamidAccion)


        'aqui se les asigna el valor
        SubReporteDeduccionesMensualISN.Parameters("IdRazonSocial").Value = Me.Parameters("IdRazonSocial").Value
        SubReporteDeduccionesMensualISN.Parameters("Anio").Value = Me.Parameters("Anio").Value
        SubReporteDeduccionesMensualISN.Parameters("Mes").Value = Me.Parameters("Mes").Value
        SubReporteDeduccionesMensualISN.Parameters("UID").Value = Me.Parameters("UID").Value
        SubReporteDeduccionesMensualISN.Parameters("LID").Value = Me.Parameters("LID").Value
        SubReporteDeduccionesMensualISN.Parameters("idAccion").Value = Me.Parameters("idAccion").Value
        Me.SubReport2.Report = SubReporteDeduccionesMensualISN



    End Sub
End Class

