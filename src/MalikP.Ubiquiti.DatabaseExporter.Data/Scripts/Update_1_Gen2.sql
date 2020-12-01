CREATE TABLE [ace].[ipsalert](
	[KeyId] [int] IDENTITY(1,1) NOT NULL,
	[JsonData] [nvarchar](max) NOT NULL,
	[JsonDataId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ipsalert] PRIMARY KEY CLUSTERED 
(
	[KeyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


ALTER TABLE [ace].[ipsalert]  WITH CHECK ADD  CONSTRAINT [ipsalert JsonData record should be formatted as JSON] CHECK  ((isjson([JsonData])=(1)))
GO

ALTER TABLE [ace].[ipsalert] CHECK CONSTRAINT [ipsalert JsonData record should be formatted as JSON]
GO


CREATE TABLE [ace].[featuremigration](
	[KeyId] [int] IDENTITY(1,1) NOT NULL,
	[JsonData] [nvarchar](max) NOT NULL,
	[JsonDataId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_featuremigration] PRIMARY KEY CLUSTERED 
(
	[KeyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


ALTER TABLE [ace].[featuremigration]  WITH CHECK ADD  CONSTRAINT [featuremigration JsonData record should be formatted as JSON] CHECK  ((isjson([JsonData])=(1)))
GO

ALTER TABLE [ace].[featuremigration] CHECK CONSTRAINT [featuremigration JsonData record should be formatted as JSON]
GO

CREATE TABLE [ace].[storeddpistats](
	[KeyId] [int] IDENTITY(1,1) NOT NULL,
	[JsonData] [nvarchar](max) NOT NULL,
	[JsonDataId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_storeddpistats] PRIMARY KEY CLUSTERED 
(
	[KeyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


ALTER TABLE [ace].[storeddpistats]  WITH CHECK ADD  CONSTRAINT [storeddpistats JsonData record should be formatted as JSON] CHECK  ((isjson([JsonData])=(1)))
GO

ALTER TABLE [ace].[storeddpistats] CHECK CONSTRAINT [storeddpistats JsonData record should be formatted as JSON]
GO



CREATE NONCLUSTERED  INDEX NonClustered_Index_ipsalert_JsonDataId ON [Ubiquiti-Unifi-Backup].[ace].[ipsalert] (JsonDataId asc);  
GO

CREATE NONCLUSTERED  INDEX NonClustered_Index_featuremigration_JsonDataId ON [Ubiquiti-Unifi-Backup].[ace].[featuremigration] (JsonDataId asc);  
GO

CREATE NONCLUSTERED  INDEX NonClustered_Index_storeddpistats_JsonDataId ON [Ubiquiti-Unifi-Backup].[ace].[storeddpistats] (JsonDataId asc);  
GO