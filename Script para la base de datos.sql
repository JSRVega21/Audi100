USE [Auditoria]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 29/10/2024 18:50:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AuditFinding]    Script Date: 29/10/2024 18:50:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuditFinding](
	[AuditFindingId] [int] IDENTITY(1,1) NOT NULL,
	[AuditReportId] [int] NOT NULL,
	[DataReport] [nvarchar](max) NULL,
	[FindingTitle] [nvarchar](max) NOT NULL,
	[NumberOfFindings] [decimal](18, 2) NOT NULL,
	[DateCreate] [datetime2](7) NOT NULL,
	[FindLevel] [nvarchar](max) NOT NULL,
	[WeightingClassificationId] [int] NOT NULL,
	[WeightingClassification] [nvarchar](max) NULL,
	[FindShortNameId] [int] NOT NULL,
	[FindShortName] [nvarchar](max) NULL,
	[PositiveWeighting] [decimal](18, 2) NULL,
	[NegativeWeighting] [decimal](18, 2) NULL,
	[PositiveRisk] [decimal](18, 2) NULL,
	[NegativeRisk] [decimal](18, 2) NULL,
	[ReviewedBy] [nvarchar](max) NULL,
	[AuthorizedForReport] [nvarchar](max) NULL,
	[WorkExecutedBy] [nvarchar](max) NULL,
	[ConditionAudit] [nvarchar](max) NULL,
	[CriterionAudit] [nvarchar](max) NULL,
	[BasisAudit] [nvarchar](max) NULL,
	[CauseAudit] [nvarchar](max) NULL,
	[EffectAudit] [nvarchar](max) NULL,
	[RequirementOfAudit] [nvarchar](max) NULL,
	[PlanOfActionAudit] [nvarchar](max) NULL,
	[DetailFindingAudit] [nvarchar](max) NOT NULL,
	[RecordLog_CreatedBy] [nvarchar](256) NULL,
	[RecordLog_CreatedDate] [datetime2](7) NULL,
	[RecordLog_UpdatedBy] [nvarchar](256) NULL,
	[RecordLog_UpdatedDate] [datetime2](7) NULL,
	[RecordLog_IsActive] [bit] NULL,
	[RecordLog_IsSystem] [bit] NULL,
	[RecordLog_SyncStatus] [int] NULL,
	[RecordLog_SyncDate] [datetime2](7) NULL,
	[RecordLog_ObjectKey] [nvarchar](64) NULL,
	[RecordLog_RecordKey] [nvarchar](36) NULL,
 CONSTRAINT [PK_AuditFinding] PRIMARY KEY CLUSTERED 
(
	[AuditFindingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AuditPrint]    Script Date: 29/10/2024 18:50:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuditPrint](
	[AuditPrintId] [int] IDENTITY(1,1) NOT NULL,
	[AuditReportId] [int] NOT NULL,
	[CostSeccionPrint] [nvarchar](max) NOT NULL,
	[ReportCode] [nvarchar](max) NULL,
	[DisplayName] [nvarchar](max) NULL,
	[Line] [decimal](18, 2) NULL,
	[DateI] [datetime2](7) NOT NULL,
	[DateE] [datetime2](7) NULL,
	[PersonalPart] [nvarchar](max) NULL,
	[Part1] [nvarchar](max) NULL,
	[Part2] [nvarchar](max) NULL,
	[Part3] [nvarchar](max) NULL,
	[Part4] [nvarchar](max) NULL,
	[AuditorId1] [nvarchar](max) NOT NULL,
	[AuditorId2] [nvarchar](max) NULL,
	[AuditorId3] [nvarchar](max) NULL,
	[EmployeeId1] [nvarchar](max) NOT NULL,
	[EmployeeId2] [nvarchar](max) NULL,
	[EmployeeId3] [nvarchar](max) NULL,
	[OtherEmployee] [nvarchar](max) NULL,
	[OtherEmployee2] [nvarchar](max) NULL,
	[OtherEmployee3] [nvarchar](max) NULL,
	[OtherEmployee4] [nvarchar](max) NULL,
	[RecordLog_CreatedBy] [nvarchar](256) NULL,
	[RecordLog_CreatedDate] [datetime2](7) NULL,
	[RecordLog_UpdatedBy] [nvarchar](256) NULL,
	[RecordLog_UpdatedDate] [datetime2](7) NULL,
	[RecordLog_IsActive] [bit] NULL,
	[RecordLog_IsSystem] [bit] NULL,
	[RecordLog_SyncStatus] [int] NULL,
	[RecordLog_SyncDate] [datetime2](7) NULL,
	[RecordLog_ObjectKey] [nvarchar](64) NULL,
	[RecordLog_RecordKey] [nvarchar](36) NULL,
 CONSTRAINT [PK_AuditPrint] PRIMARY KEY CLUSTERED 
(
	[AuditPrintId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AuditReport]    Script Date: 29/10/2024 18:50:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuditReport](
	[AuditReportId] [int] IDENTITY(1,1) NOT NULL,
	[ReportCode] [nvarchar](max) NULL,
	[PeriodString] [nvarchar](max) NOT NULL,
	[nomDepto] [nvarchar](max) NULL,
	[nomDivision] [nvarchar](max) NULL,
	[nomSeccion] [nvarchar](max) NULL,
	[nomCompleto] [nvarchar](max) NULL,
	[ReviewPriority] [nvarchar](max) NULL,
	[ReviewdateOf] [datetime2](7) NULL,
	[ReviewdateAt] [datetime2](7) NULL,
	[CreationDate] [datetime2](7) NOT NULL,
	[ModificationDate] [datetime2](7) NULL,
	[ExpectedDate] [datetime2](7) NULL,
	[OriginOfTheReview] [nvarchar](max) NOT NULL,
	[ClassificationId] [int] NOT NULL,
	[BscId] [int] NOT NULL,
	[Classification] [nvarchar](max) NULL,
	[Bsc] [nvarchar](max) NULL,
	[ReportDescription] [nvarchar](max) NOT NULL,
	[ReportTitle] [nvarchar](max) NOT NULL,
	[ReportDate] [datetime2](7) NOT NULL,
	[Shortage] [decimal](18, 2) NULL,
	[CrossShortage] [decimal](18, 2) NULL,
	[Excess] [decimal](18, 2) NULL,
	[CrossExcess] [decimal](18, 2) NULL,
	[MissingInQ] [decimal](18, 2) NULL,
	[AuditorId1] [nvarchar](max) NULL,
	[AuditorId2] [nvarchar](max) NULL,
	[AuditorId3] [nvarchar](max) NULL,
	[EmployeeId1] [nvarchar](max) NULL,
	[EmployeeId2] [nvarchar](max) NULL,
	[EmployeeId3] [nvarchar](max) NULL,
	[Hours] [decimal](18, 2) NULL,
	[HoursInReviwe] [decimal](18, 2) NULL,
	[VariationOfHours] [decimal](18, 2) NULL,
	[AuditObservations] [nvarchar](max) NULL,
	[RecordLog_CreatedBy] [nvarchar](256) NULL,
	[RecordLog_CreatedDate] [datetime2](7) NULL,
	[RecordLog_UpdatedBy] [nvarchar](256) NULL,
	[RecordLog_UpdatedDate] [datetime2](7) NULL,
	[RecordLog_IsActive] [bit] NULL,
	[RecordLog_IsSystem] [bit] NULL,
	[RecordLog_SyncStatus] [int] NULL,
	[RecordLog_SyncDate] [datetime2](7) NULL,
	[RecordLog_ObjectKey] [nvarchar](64) NULL,
	[RecordLog_RecordKey] [nvarchar](36) NULL,
 CONSTRAINT [PK_AuditReport] PRIMARY KEY CLUSTERED 
(
	[AuditReportId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AuditTrail]    Script Date: 29/10/2024 18:50:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuditTrail](
	[AuditTrailId] [int] IDENTITY(1,1) NOT NULL,
	[AuditFindingId] [int] NULL,
	[AuditReportId] [int] NULL,
	[DateCreate] [datetime2](7) NOT NULL,
	[Line] [decimal](18, 2) NULL,
	[DisplayName] [nvarchar](max) NULL,
	[ReportCode] [nvarchar](max) NULL,
	[nomDepto] [nvarchar](max) NULL,
	[nomDivision] [nvarchar](max) NULL,
	[nomSeccion] [nvarchar](max) NULL,
	[NumberOfFindings] [decimal](18, 2) NULL,
	[DetailFindingAudit] [nvarchar](max) NULL,
	[FindLevel] [nvarchar](max) NULL,
	[WeightingClassification] [nvarchar](max) NULL,
	[FindShortName] [nvarchar](max) NULL,
	[PositiveWeighting] [decimal](18, 2) NULL,
	[NegativeWeighting] [decimal](18, 2) NULL,
	[PositiveRisk] [decimal](18, 2) NULL,
	[NegativeRisk] [decimal](18, 2) NULL,
	[AuditTrailDepto] [nvarchar](max) NOT NULL,
	[AuditTrailSeccion] [nvarchar](max) NOT NULL,
	[AuditTrailWeighting] [nvarchar](max) NULL,
	[AuditTrailFollow] [nvarchar](max) NOT NULL,
	[AuditTrailStatus] [int] NOT NULL,
	[RecordLog_CreatedBy] [nvarchar](256) NULL,
	[RecordLog_CreatedDate] [datetime2](7) NULL,
	[RecordLog_UpdatedBy] [nvarchar](256) NULL,
	[RecordLog_UpdatedDate] [datetime2](7) NULL,
	[RecordLog_IsActive] [bit] NULL,
	[RecordLog_IsSystem] [bit] NULL,
	[RecordLog_SyncStatus] [int] NULL,
	[RecordLog_SyncDate] [datetime2](7) NULL,
	[RecordLog_ObjectKey] [nvarchar](64) NULL,
	[RecordLog_RecordKey] [nvarchar](36) NULL,
 CONSTRAINT [PK_AuditTrail] PRIMARY KEY CLUSTERED 
(
	[AuditTrailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bsc]    Script Date: 29/10/2024 18:50:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bsc](
	[BscId] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[RecordLog_CreatedBy] [nvarchar](256) NULL,
	[RecordLog_CreatedDate] [datetime2](7) NULL,
	[RecordLog_UpdatedBy] [nvarchar](256) NULL,
	[RecordLog_UpdatedDate] [datetime2](7) NULL,
	[RecordLog_IsActive] [bit] NULL,
	[RecordLog_IsSystem] [bit] NULL,
	[RecordLog_SyncStatus] [int] NULL,
	[RecordLog_SyncDate] [datetime2](7) NULL,
	[RecordLog_ObjectKey] [nvarchar](64) NULL,
	[RecordLog_RecordKey] [nvarchar](36) NULL,
 CONSTRAINT [PK_Bsc] PRIMARY KEY CLUSTERED 
(
	[BscId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Classification]    Script Date: 29/10/2024 18:50:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Classification](
	[ClassificationId] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[RecordLog_CreatedBy] [nvarchar](256) NULL,
	[RecordLog_CreatedDate] [datetime2](7) NULL,
	[RecordLog_UpdatedBy] [nvarchar](256) NULL,
	[RecordLog_UpdatedDate] [datetime2](7) NULL,
	[RecordLog_IsActive] [bit] NULL,
	[RecordLog_IsSystem] [bit] NULL,
	[RecordLog_SyncStatus] [int] NULL,
	[RecordLog_SyncDate] [datetime2](7) NULL,
	[RecordLog_ObjectKey] [nvarchar](64) NULL,
	[RecordLog_RecordKey] [nvarchar](36) NULL,
 CONSTRAINT [PK_Classification] PRIMARY KEY CLUSTERED 
(
	[ClassificationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Photo]    Script Date: 29/10/2024 18:50:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Photo](
	[PhotoId] [int] IDENTITY(1,1) NOT NULL,
	[BytePhone] [varbinary](max) NULL,
	[BytePdf] [varbinary](max) NULL,
	[AuditFindingId] [int] NOT NULL,
	[RecordLog_CreatedBy] [nvarchar](256) NULL,
	[RecordLog_CreatedDate] [datetime2](7) NULL,
	[RecordLog_UpdatedBy] [nvarchar](256) NULL,
	[RecordLog_UpdatedDate] [datetime2](7) NULL,
	[RecordLog_IsActive] [bit] NULL,
	[RecordLog_IsSystem] [bit] NULL,
	[RecordLog_SyncStatus] [int] NULL,
	[RecordLog_SyncDate] [datetime2](7) NULL,
	[RecordLog_ObjectKey] [nvarchar](64) NULL,
	[RecordLog_RecordKey] [nvarchar](36) NULL,
 CONSTRAINT [PK_Photo] PRIMARY KEY CLUSTERED 
(
	[PhotoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ShortF]    Script Date: 29/10/2024 18:50:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShortF](
	[ShortFId] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[RecordLog_CreatedBy] [nvarchar](256) NULL,
	[RecordLog_CreatedDate] [datetime2](7) NULL,
	[RecordLog_UpdatedBy] [nvarchar](256) NULL,
	[RecordLog_UpdatedDate] [datetime2](7) NULL,
	[RecordLog_IsActive] [bit] NULL,
	[RecordLog_IsSystem] [bit] NULL,
	[RecordLog_SyncStatus] [int] NULL,
	[RecordLog_SyncDate] [datetime2](7) NULL,
	[RecordLog_ObjectKey] [nvarchar](64) NULL,
	[RecordLog_RecordKey] [nvarchar](36) NULL,
 CONSTRAINT [PK_ShortF] PRIMARY KEY CLUSTERED 
(
	[ShortFId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 29/10/2024 18:50:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](max) NOT NULL,
	[UserEmail] [nvarchar](max) NOT NULL,
	[UserPhone] [nvarchar](max) NULL,
	[UserPassword] [nvarchar](max) NOT NULL,
	[UserRoleId] [int] NOT NULL,
	[UserRole] [nvarchar](max) NULL,
	[RecordLog_CreatedBy] [nvarchar](256) NULL,
	[RecordLog_CreatedDate] [datetime2](7) NULL,
	[RecordLog_UpdatedBy] [nvarchar](256) NULL,
	[RecordLog_UpdatedDate] [datetime2](7) NULL,
	[RecordLog_IsActive] [bit] NULL,
	[RecordLog_IsSystem] [bit] NULL,
	[RecordLog_SyncStatus] [int] NULL,
	[RecordLog_SyncDate] [datetime2](7) NULL,
	[RecordLog_ObjectKey] [nvarchar](64) NULL,
	[RecordLog_RecordKey] [nvarchar](36) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WeightingClassification]    Script Date: 29/10/2024 18:50:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WeightingClassification](
	[WeighingId] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[RecordLog_CreatedBy] [nvarchar](256) NULL,
	[RecordLog_CreatedDate] [datetime2](7) NULL,
	[RecordLog_UpdatedBy] [nvarchar](256) NULL,
	[RecordLog_UpdatedDate] [datetime2](7) NULL,
	[RecordLog_IsActive] [bit] NULL,
	[RecordLog_IsSystem] [bit] NULL,
	[RecordLog_SyncStatus] [int] NULL,
	[RecordLog_SyncDate] [datetime2](7) NULL,
	[RecordLog_ObjectKey] [nvarchar](64) NULL,
	[RecordLog_RecordKey] [nvarchar](36) NULL,
 CONSTRAINT [PK_WeightingClassification] PRIMARY KEY CLUSTERED 
(
	[WeighingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario que creo el registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuditFinding', @level2type=N'COLUMN',@level2name=N'RecordLog_CreatedBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y hora de creación del registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuditFinding', @level2type=N'COLUMN',@level2name=N'RecordLog_CreatedDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ultimo usuario que modificó el registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuditFinding', @level2type=N'COLUMN',@level2name=N'RecordLog_UpdatedBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ultima fecha y hora de actualización del registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuditFinding', @level2type=N'COLUMN',@level2name=N'RecordLog_UpdatedDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Registro activo' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuditFinding', @level2type=N'COLUMN',@level2name=N'RecordLog_IsActive'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Es un registro del sistema, los registros del sistema no pueden ser eliminados' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuditFinding', @level2type=N'COLUMN',@level2name=N'RecordLog_IsSystem'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estatus de sincronización del registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuditFinding', @level2type=N'COLUMN',@level2name=N'RecordLog_SyncStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ultima fecha de sincronización' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuditFinding', @level2type=N'COLUMN',@level2name=N'RecordLog_SyncDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código identificador del objeto representado en el registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuditFinding', @level2type=N'COLUMN',@level2name=N'RecordLog_ObjectKey'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador único del registro, asignado en el momento de creación' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuditFinding', @level2type=N'COLUMN',@level2name=N'RecordLog_RecordKey'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario que creo el registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuditPrint', @level2type=N'COLUMN',@level2name=N'RecordLog_CreatedBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y hora de creación del registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuditPrint', @level2type=N'COLUMN',@level2name=N'RecordLog_CreatedDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ultimo usuario que modificó el registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuditPrint', @level2type=N'COLUMN',@level2name=N'RecordLog_UpdatedBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ultima fecha y hora de actualización del registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuditPrint', @level2type=N'COLUMN',@level2name=N'RecordLog_UpdatedDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Registro activo' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuditPrint', @level2type=N'COLUMN',@level2name=N'RecordLog_IsActive'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Es un registro del sistema, los registros del sistema no pueden ser eliminados' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuditPrint', @level2type=N'COLUMN',@level2name=N'RecordLog_IsSystem'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estatus de sincronización del registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuditPrint', @level2type=N'COLUMN',@level2name=N'RecordLog_SyncStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ultima fecha de sincronización' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuditPrint', @level2type=N'COLUMN',@level2name=N'RecordLog_SyncDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código identificador del objeto representado en el registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuditPrint', @level2type=N'COLUMN',@level2name=N'RecordLog_ObjectKey'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador único del registro, asignado en el momento de creación' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuditPrint', @level2type=N'COLUMN',@level2name=N'RecordLog_RecordKey'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario que creo el registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuditReport', @level2type=N'COLUMN',@level2name=N'RecordLog_CreatedBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y hora de creación del registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuditReport', @level2type=N'COLUMN',@level2name=N'RecordLog_CreatedDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ultimo usuario que modificó el registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuditReport', @level2type=N'COLUMN',@level2name=N'RecordLog_UpdatedBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ultima fecha y hora de actualización del registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuditReport', @level2type=N'COLUMN',@level2name=N'RecordLog_UpdatedDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Registro activo' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuditReport', @level2type=N'COLUMN',@level2name=N'RecordLog_IsActive'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Es un registro del sistema, los registros del sistema no pueden ser eliminados' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuditReport', @level2type=N'COLUMN',@level2name=N'RecordLog_IsSystem'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estatus de sincronización del registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuditReport', @level2type=N'COLUMN',@level2name=N'RecordLog_SyncStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ultima fecha de sincronización' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuditReport', @level2type=N'COLUMN',@level2name=N'RecordLog_SyncDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código identificador del objeto representado en el registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuditReport', @level2type=N'COLUMN',@level2name=N'RecordLog_ObjectKey'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador único del registro, asignado en el momento de creación' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuditReport', @level2type=N'COLUMN',@level2name=N'RecordLog_RecordKey'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario que creo el registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuditTrail', @level2type=N'COLUMN',@level2name=N'RecordLog_CreatedBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y hora de creación del registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuditTrail', @level2type=N'COLUMN',@level2name=N'RecordLog_CreatedDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ultimo usuario que modificó el registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuditTrail', @level2type=N'COLUMN',@level2name=N'RecordLog_UpdatedBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ultima fecha y hora de actualización del registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuditTrail', @level2type=N'COLUMN',@level2name=N'RecordLog_UpdatedDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Registro activo' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuditTrail', @level2type=N'COLUMN',@level2name=N'RecordLog_IsActive'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Es un registro del sistema, los registros del sistema no pueden ser eliminados' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuditTrail', @level2type=N'COLUMN',@level2name=N'RecordLog_IsSystem'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estatus de sincronización del registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuditTrail', @level2type=N'COLUMN',@level2name=N'RecordLog_SyncStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ultima fecha de sincronización' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuditTrail', @level2type=N'COLUMN',@level2name=N'RecordLog_SyncDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código identificador del objeto representado en el registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuditTrail', @level2type=N'COLUMN',@level2name=N'RecordLog_ObjectKey'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador único del registro, asignado en el momento de creación' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AuditTrail', @level2type=N'COLUMN',@level2name=N'RecordLog_RecordKey'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario que creo el registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Bsc', @level2type=N'COLUMN',@level2name=N'RecordLog_CreatedBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y hora de creación del registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Bsc', @level2type=N'COLUMN',@level2name=N'RecordLog_CreatedDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ultimo usuario que modificó el registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Bsc', @level2type=N'COLUMN',@level2name=N'RecordLog_UpdatedBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ultima fecha y hora de actualización del registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Bsc', @level2type=N'COLUMN',@level2name=N'RecordLog_UpdatedDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Registro activo' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Bsc', @level2type=N'COLUMN',@level2name=N'RecordLog_IsActive'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Es un registro del sistema, los registros del sistema no pueden ser eliminados' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Bsc', @level2type=N'COLUMN',@level2name=N'RecordLog_IsSystem'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estatus de sincronización del registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Bsc', @level2type=N'COLUMN',@level2name=N'RecordLog_SyncStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ultima fecha de sincronización' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Bsc', @level2type=N'COLUMN',@level2name=N'RecordLog_SyncDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código identificador del objeto representado en el registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Bsc', @level2type=N'COLUMN',@level2name=N'RecordLog_ObjectKey'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador único del registro, asignado en el momento de creación' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Bsc', @level2type=N'COLUMN',@level2name=N'RecordLog_RecordKey'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario que creo el registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Classification', @level2type=N'COLUMN',@level2name=N'RecordLog_CreatedBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y hora de creación del registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Classification', @level2type=N'COLUMN',@level2name=N'RecordLog_CreatedDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ultimo usuario que modificó el registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Classification', @level2type=N'COLUMN',@level2name=N'RecordLog_UpdatedBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ultima fecha y hora de actualización del registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Classification', @level2type=N'COLUMN',@level2name=N'RecordLog_UpdatedDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Registro activo' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Classification', @level2type=N'COLUMN',@level2name=N'RecordLog_IsActive'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Es un registro del sistema, los registros del sistema no pueden ser eliminados' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Classification', @level2type=N'COLUMN',@level2name=N'RecordLog_IsSystem'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estatus de sincronización del registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Classification', @level2type=N'COLUMN',@level2name=N'RecordLog_SyncStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ultima fecha de sincronización' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Classification', @level2type=N'COLUMN',@level2name=N'RecordLog_SyncDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código identificador del objeto representado en el registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Classification', @level2type=N'COLUMN',@level2name=N'RecordLog_ObjectKey'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador único del registro, asignado en el momento de creación' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Classification', @level2type=N'COLUMN',@level2name=N'RecordLog_RecordKey'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario que creo el registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Photo', @level2type=N'COLUMN',@level2name=N'RecordLog_CreatedBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y hora de creación del registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Photo', @level2type=N'COLUMN',@level2name=N'RecordLog_CreatedDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ultimo usuario que modificó el registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Photo', @level2type=N'COLUMN',@level2name=N'RecordLog_UpdatedBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ultima fecha y hora de actualización del registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Photo', @level2type=N'COLUMN',@level2name=N'RecordLog_UpdatedDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Registro activo' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Photo', @level2type=N'COLUMN',@level2name=N'RecordLog_IsActive'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Es un registro del sistema, los registros del sistema no pueden ser eliminados' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Photo', @level2type=N'COLUMN',@level2name=N'RecordLog_IsSystem'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estatus de sincronización del registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Photo', @level2type=N'COLUMN',@level2name=N'RecordLog_SyncStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ultima fecha de sincronización' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Photo', @level2type=N'COLUMN',@level2name=N'RecordLog_SyncDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código identificador del objeto representado en el registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Photo', @level2type=N'COLUMN',@level2name=N'RecordLog_ObjectKey'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador único del registro, asignado en el momento de creación' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Photo', @level2type=N'COLUMN',@level2name=N'RecordLog_RecordKey'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario que creo el registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ShortF', @level2type=N'COLUMN',@level2name=N'RecordLog_CreatedBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y hora de creación del registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ShortF', @level2type=N'COLUMN',@level2name=N'RecordLog_CreatedDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ultimo usuario que modificó el registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ShortF', @level2type=N'COLUMN',@level2name=N'RecordLog_UpdatedBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ultima fecha y hora de actualización del registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ShortF', @level2type=N'COLUMN',@level2name=N'RecordLog_UpdatedDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Registro activo' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ShortF', @level2type=N'COLUMN',@level2name=N'RecordLog_IsActive'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Es un registro del sistema, los registros del sistema no pueden ser eliminados' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ShortF', @level2type=N'COLUMN',@level2name=N'RecordLog_IsSystem'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estatus de sincronización del registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ShortF', @level2type=N'COLUMN',@level2name=N'RecordLog_SyncStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ultima fecha de sincronización' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ShortF', @level2type=N'COLUMN',@level2name=N'RecordLog_SyncDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código identificador del objeto representado en el registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ShortF', @level2type=N'COLUMN',@level2name=N'RecordLog_ObjectKey'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador único del registro, asignado en el momento de creación' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ShortF', @level2type=N'COLUMN',@level2name=N'RecordLog_RecordKey'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario que creo el registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'RecordLog_CreatedBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y hora de creación del registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'RecordLog_CreatedDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ultimo usuario que modificó el registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'RecordLog_UpdatedBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ultima fecha y hora de actualización del registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'RecordLog_UpdatedDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Registro activo' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'RecordLog_IsActive'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Es un registro del sistema, los registros del sistema no pueden ser eliminados' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'RecordLog_IsSystem'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estatus de sincronización del registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'RecordLog_SyncStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ultima fecha de sincronización' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'RecordLog_SyncDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código identificador del objeto representado en el registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'RecordLog_ObjectKey'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador único del registro, asignado en el momento de creación' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'User', @level2type=N'COLUMN',@level2name=N'RecordLog_RecordKey'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Usuario que creo el registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WeightingClassification', @level2type=N'COLUMN',@level2name=N'RecordLog_CreatedBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha y hora de creación del registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WeightingClassification', @level2type=N'COLUMN',@level2name=N'RecordLog_CreatedDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ultimo usuario que modificó el registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WeightingClassification', @level2type=N'COLUMN',@level2name=N'RecordLog_UpdatedBy'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ultima fecha y hora de actualización del registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WeightingClassification', @level2type=N'COLUMN',@level2name=N'RecordLog_UpdatedDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Registro activo' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WeightingClassification', @level2type=N'COLUMN',@level2name=N'RecordLog_IsActive'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Es un registro del sistema, los registros del sistema no pueden ser eliminados' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WeightingClassification', @level2type=N'COLUMN',@level2name=N'RecordLog_IsSystem'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Estatus de sincronización del registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WeightingClassification', @level2type=N'COLUMN',@level2name=N'RecordLog_SyncStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ultima fecha de sincronización' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WeightingClassification', @level2type=N'COLUMN',@level2name=N'RecordLog_SyncDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código identificador del objeto representado en el registro' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WeightingClassification', @level2type=N'COLUMN',@level2name=N'RecordLog_ObjectKey'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Identificador único del registro, asignado en el momento de creación' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WeightingClassification', @level2type=N'COLUMN',@level2name=N'RecordLog_RecordKey'
GO
