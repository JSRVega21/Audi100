using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Audi100.Server.Migrations
{
    /// <inheritdoc />
    public partial class FaseFinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditFinding",
                columns: table => new
                {
                    AuditFindingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuditReportId = table.Column<int>(type: "int", nullable: false),
                    DataReport = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FindingTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfFindings = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FindLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WeightingClassificationId = table.Column<int>(type: "int", nullable: false),
                    WeightingClassification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FindShortNameId = table.Column<int>(type: "int", nullable: false),
                    FindShortName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PositiveWeighting = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NegativeWeighting = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PositiveRisk = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NegativeRisk = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ReviewedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthorizedForReport = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkExecutedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConditionAudit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CriterionAudit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BasisAudit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CauseAudit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EffectAudit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequirementOfAudit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlanOfActionAudit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DetailFindingAudit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuditStatus = table.Column<int>(type: "int", nullable: true),
                    AuditStatusText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuditFindingCostCenter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuditFindingDepto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuditFindingSeccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuditorFinding = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeFinding = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeFinding2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecordLog_CreatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true, comment: "Usuario que creo el registro"),
                    RecordLog_CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Fecha y hora de creación del registro"),
                    RecordLog_UpdatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true, comment: "Ultimo usuario que modificó el registro"),
                    RecordLog_UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Ultima fecha y hora de actualización del registro"),
                    RecordLog_IsActive = table.Column<bool>(type: "bit", nullable: true, comment: "Registro activo"),
                    RecordLog_IsSystem = table.Column<bool>(type: "bit", nullable: true, comment: "Es un registro del sistema, los registros del sistema no pueden ser eliminados"),
                    RecordLog_SyncStatus = table.Column<int>(type: "int", nullable: true, comment: "Estatus de sincronización del registro"),
                    RecordLog_SyncDate = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Ultima fecha de sincronización"),
                    RecordLog_ObjectKey = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true, comment: "Código identificador del objeto representado en el registro"),
                    RecordLog_RecordKey = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true, comment: "Identificador único del registro, asignado en el momento de creación")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditFinding", x => x.AuditFindingId);
                });

            migrationBuilder.CreateTable(
                name: "AuditPrint",
                columns: table => new
                {
                    AuditPrintId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuditReportId = table.Column<int>(type: "int", nullable: false),
                    SubSeccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CostSeccionPrint = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReportCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Line = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DateI = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PersonalPart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Part1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Part2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Part3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Part4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Others = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuditorId1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuditorId2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuditorId3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeId1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeId2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeId3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherEmployee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherEmployee2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherEmployee3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherEmployee4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Graduate1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TextGraduate1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Graduate2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TextGraduate2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Graduate3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TextGraduate3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direct = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TextDirect = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateGra = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RecordLog_CreatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true, comment: "Usuario que creo el registro"),
                    RecordLog_CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Fecha y hora de creación del registro"),
                    RecordLog_UpdatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true, comment: "Ultimo usuario que modificó el registro"),
                    RecordLog_UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Ultima fecha y hora de actualización del registro"),
                    RecordLog_IsActive = table.Column<bool>(type: "bit", nullable: true, comment: "Registro activo"),
                    RecordLog_IsSystem = table.Column<bool>(type: "bit", nullable: true, comment: "Es un registro del sistema, los registros del sistema no pueden ser eliminados"),
                    RecordLog_SyncStatus = table.Column<int>(type: "int", nullable: true, comment: "Estatus de sincronización del registro"),
                    RecordLog_SyncDate = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Ultima fecha de sincronización"),
                    RecordLog_ObjectKey = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true, comment: "Código identificador del objeto representado en el registro"),
                    RecordLog_RecordKey = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true, comment: "Identificador único del registro, asignado en el momento de creación")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditPrint", x => x.AuditPrintId);
                });

            migrationBuilder.CreateTable(
                name: "AuditReport",
                columns: table => new
                {
                    AuditReportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PeriodString = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nomDepto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nomDivision = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nomSeccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nomCompleto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReviewPriority = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReviewdateOf = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReviewdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpectedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OriginOfTheReview = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassificationId = table.Column<int>(type: "int", nullable: false),
                    BscId = table.Column<int>(type: "int", nullable: false),
                    Classification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bsc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReportDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReportTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReportDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Shortage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CrossShortage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Excess = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CrossExcess = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MissingInQ = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AuditorId1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuditorId2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuditorId3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeId1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeId2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeId3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hours = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    HoursInReviwe = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VariationOfHours = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AuditObservations = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuditStatus = table.Column<int>(type: "int", nullable: true),
                    AuditStatusText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecordLog_CreatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true, comment: "Usuario que creo el registro"),
                    RecordLog_CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Fecha y hora de creación del registro"),
                    RecordLog_UpdatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true, comment: "Ultimo usuario que modificó el registro"),
                    RecordLog_UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Ultima fecha y hora de actualización del registro"),
                    RecordLog_IsActive = table.Column<bool>(type: "bit", nullable: true, comment: "Registro activo"),
                    RecordLog_IsSystem = table.Column<bool>(type: "bit", nullable: true, comment: "Es un registro del sistema, los registros del sistema no pueden ser eliminados"),
                    RecordLog_SyncStatus = table.Column<int>(type: "int", nullable: true, comment: "Estatus de sincronización del registro"),
                    RecordLog_SyncDate = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Ultima fecha de sincronización"),
                    RecordLog_ObjectKey = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true, comment: "Código identificador del objeto representado en el registro"),
                    RecordLog_RecordKey = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true, comment: "Identificador único del registro, asignado en el momento de creación")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditReport", x => x.AuditReportId);
                });

            migrationBuilder.CreateTable(
                name: "AuditTrail",
                columns: table => new
                {
                    AuditTrailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuditFindingId = table.Column<int>(type: "int", nullable: true),
                    AuditReportId = table.Column<int>(type: "int", nullable: true),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Line = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReportCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nomDepto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nomDivision = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nomSeccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfFindings = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DetailFindingAudit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FindLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WeightingClassification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FindShortName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PositiveWeighting = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NegativeWeighting = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PositiveRisk = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NegativeRisk = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AuditTrailPositiveWeighting = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AuditTrailNegativeWeighting = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AuditTrailPositiveRisk = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AuditTrailNegativeRisk = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalPositiveWeighting = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalNegativeWeighting = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalPositiveRisk = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalNegativeRisk = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AuditTrailCostCenter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuditTrailDepto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuditTrailSeccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuditorTrail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeTrail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeTrail2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuditTrailWeighting = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuditTrailFollow = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuditStatus = table.Column<int>(type: "int", nullable: false),
                    AuditStatusText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecordLog_CreatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true, comment: "Usuario que creo el registro"),
                    RecordLog_CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Fecha y hora de creación del registro"),
                    RecordLog_UpdatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true, comment: "Ultimo usuario que modificó el registro"),
                    RecordLog_UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Ultima fecha y hora de actualización del registro"),
                    RecordLog_IsActive = table.Column<bool>(type: "bit", nullable: true, comment: "Registro activo"),
                    RecordLog_IsSystem = table.Column<bool>(type: "bit", nullable: true, comment: "Es un registro del sistema, los registros del sistema no pueden ser eliminados"),
                    RecordLog_SyncStatus = table.Column<int>(type: "int", nullable: true, comment: "Estatus de sincronización del registro"),
                    RecordLog_SyncDate = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Ultima fecha de sincronización"),
                    RecordLog_ObjectKey = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true, comment: "Código identificador del objeto representado en el registro"),
                    RecordLog_RecordKey = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true, comment: "Identificador único del registro, asignado en el momento de creación")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditTrail", x => x.AuditTrailId);
                });

            migrationBuilder.CreateTable(
                name: "Bsc",
                columns: table => new
                {
                    BscId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecordLog_CreatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true, comment: "Usuario que creo el registro"),
                    RecordLog_CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Fecha y hora de creación del registro"),
                    RecordLog_UpdatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true, comment: "Ultimo usuario que modificó el registro"),
                    RecordLog_UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Ultima fecha y hora de actualización del registro"),
                    RecordLog_IsActive = table.Column<bool>(type: "bit", nullable: true, comment: "Registro activo"),
                    RecordLog_IsSystem = table.Column<bool>(type: "bit", nullable: true, comment: "Es un registro del sistema, los registros del sistema no pueden ser eliminados"),
                    RecordLog_SyncStatus = table.Column<int>(type: "int", nullable: true, comment: "Estatus de sincronización del registro"),
                    RecordLog_SyncDate = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Ultima fecha de sincronización"),
                    RecordLog_ObjectKey = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true, comment: "Código identificador del objeto representado en el registro"),
                    RecordLog_RecordKey = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true, comment: "Identificador único del registro, asignado en el momento de creación")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bsc", x => x.BscId);
                });

            migrationBuilder.CreateTable(
                name: "Classification",
                columns: table => new
                {
                    ClassificationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecordLog_CreatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true, comment: "Usuario que creo el registro"),
                    RecordLog_CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Fecha y hora de creación del registro"),
                    RecordLog_UpdatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true, comment: "Ultimo usuario que modificó el registro"),
                    RecordLog_UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Ultima fecha y hora de actualización del registro"),
                    RecordLog_IsActive = table.Column<bool>(type: "bit", nullable: true, comment: "Registro activo"),
                    RecordLog_IsSystem = table.Column<bool>(type: "bit", nullable: true, comment: "Es un registro del sistema, los registros del sistema no pueden ser eliminados"),
                    RecordLog_SyncStatus = table.Column<int>(type: "int", nullable: true, comment: "Estatus de sincronización del registro"),
                    RecordLog_SyncDate = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Ultima fecha de sincronización"),
                    RecordLog_ObjectKey = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true, comment: "Código identificador del objeto representado en el registro"),
                    RecordLog_RecordKey = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true, comment: "Identificador único del registro, asignado en el momento de creación")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classification", x => x.ClassificationId);
                });

            migrationBuilder.CreateTable(
                name: "Photo",
                columns: table => new
                {
                    PhotoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BytePhone = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    BytePdf = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    AuditFindingId = table.Column<int>(type: "int", nullable: false),
                    RecordLog_CreatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true, comment: "Usuario que creo el registro"),
                    RecordLog_CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Fecha y hora de creación del registro"),
                    RecordLog_UpdatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true, comment: "Ultimo usuario que modificó el registro"),
                    RecordLog_UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Ultima fecha y hora de actualización del registro"),
                    RecordLog_IsActive = table.Column<bool>(type: "bit", nullable: true, comment: "Registro activo"),
                    RecordLog_IsSystem = table.Column<bool>(type: "bit", nullable: true, comment: "Es un registro del sistema, los registros del sistema no pueden ser eliminados"),
                    RecordLog_SyncStatus = table.Column<int>(type: "int", nullable: true, comment: "Estatus de sincronización del registro"),
                    RecordLog_SyncDate = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Ultima fecha de sincronización"),
                    RecordLog_ObjectKey = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true, comment: "Código identificador del objeto representado en el registro"),
                    RecordLog_RecordKey = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true, comment: "Identificador único del registro, asignado en el momento de creación")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo", x => x.PhotoId);
                });

            migrationBuilder.CreateTable(
                name: "ShortF",
                columns: table => new
                {
                    ShortFId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecordLog_CreatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true, comment: "Usuario que creo el registro"),
                    RecordLog_CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Fecha y hora de creación del registro"),
                    RecordLog_UpdatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true, comment: "Ultimo usuario que modificó el registro"),
                    RecordLog_UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Ultima fecha y hora de actualización del registro"),
                    RecordLog_IsActive = table.Column<bool>(type: "bit", nullable: true, comment: "Registro activo"),
                    RecordLog_IsSystem = table.Column<bool>(type: "bit", nullable: true, comment: "Es un registro del sistema, los registros del sistema no pueden ser eliminados"),
                    RecordLog_SyncStatus = table.Column<int>(type: "int", nullable: true, comment: "Estatus de sincronización del registro"),
                    RecordLog_SyncDate = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Ultima fecha de sincronización"),
                    RecordLog_ObjectKey = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true, comment: "Código identificador del objeto representado en el registro"),
                    RecordLog_RecordKey = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true, comment: "Identificador único del registro, asignado en el momento de creación")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShortF", x => x.ShortFId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserRoleId = table.Column<int>(type: "int", nullable: false),
                    UserRole = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecordLog_CreatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true, comment: "Usuario que creo el registro"),
                    RecordLog_CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Fecha y hora de creación del registro"),
                    RecordLog_UpdatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true, comment: "Ultimo usuario que modificó el registro"),
                    RecordLog_UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Ultima fecha y hora de actualización del registro"),
                    RecordLog_IsActive = table.Column<bool>(type: "bit", nullable: true, comment: "Registro activo"),
                    RecordLog_IsSystem = table.Column<bool>(type: "bit", nullable: true, comment: "Es un registro del sistema, los registros del sistema no pueden ser eliminados"),
                    RecordLog_SyncStatus = table.Column<int>(type: "int", nullable: true, comment: "Estatus de sincronización del registro"),
                    RecordLog_SyncDate = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Ultima fecha de sincronización"),
                    RecordLog_ObjectKey = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true, comment: "Código identificador del objeto representado en el registro"),
                    RecordLog_RecordKey = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true, comment: "Identificador único del registro, asignado en el momento de creación")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "WeightingClassification",
                columns: table => new
                {
                    WeighingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecordLog_CreatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true, comment: "Usuario que creo el registro"),
                    RecordLog_CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Fecha y hora de creación del registro"),
                    RecordLog_UpdatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true, comment: "Ultimo usuario que modificó el registro"),
                    RecordLog_UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Ultima fecha y hora de actualización del registro"),
                    RecordLog_IsActive = table.Column<bool>(type: "bit", nullable: true, comment: "Registro activo"),
                    RecordLog_IsSystem = table.Column<bool>(type: "bit", nullable: true, comment: "Es un registro del sistema, los registros del sistema no pueden ser eliminados"),
                    RecordLog_SyncStatus = table.Column<int>(type: "int", nullable: true, comment: "Estatus de sincronización del registro"),
                    RecordLog_SyncDate = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Ultima fecha de sincronización"),
                    RecordLog_ObjectKey = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true, comment: "Código identificador del objeto representado en el registro"),
                    RecordLog_RecordKey = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true, comment: "Identificador único del registro, asignado en el momento de creación")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeightingClassification", x => x.WeighingId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditFinding");

            migrationBuilder.DropTable(
                name: "AuditPrint");

            migrationBuilder.DropTable(
                name: "AuditReport");

            migrationBuilder.DropTable(
                name: "AuditTrail");

            migrationBuilder.DropTable(
                name: "Bsc");

            migrationBuilder.DropTable(
                name: "Classification");

            migrationBuilder.DropTable(
                name: "Photo");

            migrationBuilder.DropTable(
                name: "ShortF");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "WeightingClassification");
        }
    }
}
