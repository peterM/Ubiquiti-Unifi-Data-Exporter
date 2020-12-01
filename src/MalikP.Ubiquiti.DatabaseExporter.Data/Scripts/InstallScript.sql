CREATE SCHEMA ace
go
CREATE SCHEMA ace_stat
go 
CREATE SCHEMA local
go



--ALTER TABLE stat_5minutes
--    ADD CONSTRAINT [JsonData record should be formatted as JSON]
--                   CHECK (ISJSON(JsonData)=1);

--ALTER SCHEMA ace_stat TRANSFER OBJECT::dbo.stat_5minutes;

USE [Ubiquiti-Unifi-Backup]
GO

/****** Object:  Table [ace_stat].[stat_5minutes]    Script Date: 21. 7. 2018 12:05:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE TABLE [ace].[account](
	[KeyId] [int] IDENTITY(1,1) NOT NULL,
	[JsonData] [nvarchar](max) NOT NULL,
	[JsonDataId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_account] PRIMARY KEY CLUSTERED 
(
	[KeyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


ALTER TABLE [ace].[account]  WITH CHECK ADD  CONSTRAINT [account JsonData record should be formatted as JSON] CHECK  ((isjson([JsonData])=(1)))
GO

ALTER TABLE [ace].[account] CHECK CONSTRAINT [account JsonData record should be formatted as JSON]
GO

CREATE TABLE [ace].[admin](
	[KeyId] [int] IDENTITY(1,1) NOT NULL,
	[JsonData] [nvarchar](max) NOT NULL,
	[JsonDataId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_admin] PRIMARY KEY CLUSTERED 
(
	[KeyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


ALTER TABLE [ace].[admin]  WITH CHECK ADD  CONSTRAINT [admin JsonData record should be formatted as JSON] CHECK  ((isjson([JsonData])=(1)))
GO

ALTER TABLE [ace].[admin] CHECK CONSTRAINT [admin JsonData record should be formatted as JSON]
GO

CREATE TABLE [ace].[alarm](
	[KeyId] [int] IDENTITY(1,1) NOT NULL,
	[JsonData] [nvarchar](max) NOT NULL,
	[JsonDataId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_alarm] PRIMARY KEY CLUSTERED 
(
	[KeyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


ALTER TABLE [ace].[alarm]  WITH CHECK ADD  CONSTRAINT [alarm JsonData record should be formatted as JSON] CHECK  ((isjson([JsonData])=(1)))
GO

ALTER TABLE [ace].[alarm] CHECK CONSTRAINT [alarm JsonData record should be formatted as JSON]
GO

CREATE TABLE [ace].[broadcastgroup](
	[KeyId] [int] IDENTITY(1,1) NOT NULL,
	[JsonData] [nvarchar](max) NOT NULL,
	[JsonDataId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_broadcastgroup] PRIMARY KEY CLUSTERED 
(
	[KeyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


ALTER TABLE [ace].[broadcastgroup]  WITH CHECK ADD  CONSTRAINT [broadcastgroup JsonData record should be formatted as JSON] CHECK  ((isjson([JsonData])=(1)))
GO

ALTER TABLE [ace].[broadcastgroup] CHECK CONSTRAINT [broadcastgroup JsonData record should be formatted as JSON]
GO

CREATE TABLE [ace].[dashboard](
	[KeyId] [int] IDENTITY(1,1) NOT NULL,
	[JsonData] [nvarchar](max) NOT NULL,
	[JsonDataId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_dashboard] PRIMARY KEY CLUSTERED 
(
	[KeyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


ALTER TABLE [ace].[dashboard]  WITH CHECK ADD  CONSTRAINT [dashboard JsonData record should be formatted as JSON] CHECK  ((isjson([JsonData])=(1)))
GO

ALTER TABLE [ace].[dashboard] CHECK CONSTRAINT [dashboard JsonData record should be formatted as JSON]
GO

CREATE TABLE [ace].[device](
	[KeyId] [int] IDENTITY(1,1) NOT NULL,
	[JsonData] [nvarchar](max) NOT NULL,
	[JsonDataId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_device] PRIMARY KEY CLUSTERED 
(
	[KeyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


ALTER TABLE [ace].[device]  WITH CHECK ADD  CONSTRAINT [device JsonData record should be formatted as JSON] CHECK  ((isjson([JsonData])=(1)))
GO

ALTER TABLE [ace].[device] CHECK CONSTRAINT [device JsonData record should be formatted as JSON]
GO

CREATE TABLE [ace].[dhcpoption](
	[KeyId] [int] IDENTITY(1,1) NOT NULL,
	[JsonData] [nvarchar](max) NOT NULL,
	[JsonDataId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_dhcpoption] PRIMARY KEY CLUSTERED 
(
	[KeyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


ALTER TABLE [ace].[dhcpoption]  WITH CHECK ADD  CONSTRAINT [dhcpoption JsonData record should be formatted as JSON] CHECK  ((isjson([JsonData])=(1)))
GO

ALTER TABLE [ace].[dhcpoption] CHECK CONSTRAINT [dhcpoption JsonData record should be formatted as JSON]
GO

CREATE TABLE [ace].[dpiapp](
	[KeyId] [int] IDENTITY(1,1) NOT NULL,
	[JsonData] [nvarchar](max) NOT NULL,
	[JsonDataId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_dpiapp] PRIMARY KEY CLUSTERED 
(
	[KeyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


ALTER TABLE [ace].[dpiapp]  WITH CHECK ADD  CONSTRAINT [dpiapp JsonData record should be formatted as JSON] CHECK  ((isjson([JsonData])=(1)))
GO

ALTER TABLE [ace].[dpiapp] CHECK CONSTRAINT [dpiapp JsonData record should be formatted as JSON]
GO

CREATE TABLE [ace].[dpigroup](
	[KeyId] [int] IDENTITY(1,1) NOT NULL,
	[JsonData] [nvarchar](max) NOT NULL,
	[JsonDataId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_dpigroup] PRIMARY KEY CLUSTERED 
(
	[KeyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


ALTER TABLE [ace].[dpigroup]  WITH CHECK ADD  CONSTRAINT [dpigroup JsonData record should be formatted as JSON] CHECK  ((isjson([JsonData])=(1)))
GO

ALTER TABLE [ace].[dpigroup] CHECK CONSTRAINT [dpigroup JsonData record should be formatted as JSON]
GO

CREATE TABLE [ace].[dynamicdns](
	[KeyId] [int] IDENTITY(1,1) NOT NULL,
	[JsonData] [nvarchar](max) NOT NULL,
	[JsonDataId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_dynamicdns] PRIMARY KEY CLUSTERED 
(
	[KeyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


ALTER TABLE [ace].[dynamicdns]  WITH CHECK ADD  CONSTRAINT [dynamicdns JsonData record should be formatted as JSON] CHECK  ((isjson([JsonData])=(1)))
GO

ALTER TABLE [ace].[dynamicdns] CHECK CONSTRAINT [dynamicdns JsonData record should be formatted as JSON]
GO

CREATE TABLE [ace].[event](
	[KeyId] [int] IDENTITY(1,1) NOT NULL,
	[JsonData] [nvarchar](max) NOT NULL,
	[JsonDataId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_event] PRIMARY KEY CLUSTERED 
(
	[KeyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


ALTER TABLE [ace].[event]  WITH CHECK ADD  CONSTRAINT [event JsonData record should be formatted as JSON] CHECK  ((isjson([JsonData])=(1)))
GO

ALTER TABLE [ace].[event] CHECK CONSTRAINT [event JsonData record should be formatted as JSON]
GO

CREATE TABLE [ace].[firewallgroup](
	[KeyId] [int] IDENTITY(1,1) NOT NULL,
	[JsonData] [nvarchar](max) NOT NULL,
	[JsonDataId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_firewallgroup] PRIMARY KEY CLUSTERED 
(
	[KeyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


ALTER TABLE [ace].[firewallgroup]  WITH CHECK ADD  CONSTRAINT [firewallgroup JsonData record should be formatted as JSON] CHECK  ((isjson([JsonData])=(1)))
GO

ALTER TABLE [ace].[firewallgroup] CHECK CONSTRAINT [firewallgroup JsonData record should be formatted as JSON]
GO

CREATE TABLE [ace].[firewallrule](
	[KeyId] [int] IDENTITY(1,1) NOT NULL,
	[JsonData] [nvarchar](max) NOT NULL,
	[JsonDataId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_firewallrule] PRIMARY KEY CLUSTERED 
(
	[KeyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


ALTER TABLE [ace].[firewallrule]  WITH CHECK ADD  CONSTRAINT [firewallrule JsonData record should be formatted as JSON] CHECK  ((isjson([JsonData])=(1)))
GO

ALTER TABLE [ace].[firewallrule] CHECK CONSTRAINT [firewallrule JsonData record should be formatted as JSON]
GO

CREATE TABLE [ace].[guest](
	[KeyId] [int] IDENTITY(1,1) NOT NULL,
	[JsonData] [nvarchar](max) NOT NULL,
	[JsonDataId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_guest] PRIMARY KEY CLUSTERED 
(
	[KeyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


ALTER TABLE [ace].[guest]  WITH CHECK ADD  CONSTRAINT [guest JsonData record should be formatted as JSON] CHECK  ((isjson([JsonData])=(1)))
GO

ALTER TABLE [ace].[guest] CHECK CONSTRAINT [guest JsonData record should be formatted as JSON]
GO

CREATE TABLE [ace].[heatmap](
	[KeyId] [int] IDENTITY(1,1) NOT NULL,
	[JsonData] [nvarchar](max) NOT NULL,
	[JsonDataId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_heatmap] PRIMARY KEY CLUSTERED 
(
	[KeyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


ALTER TABLE [ace].[heatmap]  WITH CHECK ADD  CONSTRAINT [heatmap JsonData record should be formatted as JSON] CHECK  ((isjson([JsonData])=(1)))
GO

ALTER TABLE [ace].[heatmap] CHECK CONSTRAINT [heatmap JsonData record should be formatted as JSON]
GO

CREATE TABLE [ace].[heatmappoint](
	[KeyId] [int] IDENTITY(1,1) NOT NULL,
	[JsonData] [nvarchar](max) NOT NULL,
	[JsonDataId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_heatmappoint] PRIMARY KEY CLUSTERED 
(
	[KeyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


ALTER TABLE [ace].[heatmappoint]  WITH CHECK ADD  CONSTRAINT [heatmappoint JsonData record should be formatted as JSON] CHECK  ((isjson([JsonData])=(1)))
GO

ALTER TABLE [ace].[heatmappoint] CHECK CONSTRAINT [heatmappoint JsonData record should be formatted as JSON]
GO

CREATE TABLE [ace].[hotspot2conf](
	[KeyId] [int] IDENTITY(1,1) NOT NULL,
	[JsonData] [nvarchar](max) NOT NULL,
	[JsonDataId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_hotspot2conf] PRIMARY KEY CLUSTERED 
(
	[KeyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


ALTER TABLE [ace].[hotspot2conf]  WITH CHECK ADD  CONSTRAINT [hotspot2conf JsonData record should be formatted as JSON] CHECK  ((isjson([JsonData])=(1)))
GO

ALTER TABLE [ace].[hotspot2conf] CHECK CONSTRAINT [hotspot2conf JsonData record should be formatted as JSON]
GO

CREATE TABLE [ace].[hotspotop](
	[KeyId] [int] IDENTITY(1,1) NOT NULL,
	[JsonData] [nvarchar](max) NOT NULL,
	[JsonDataId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_hotspotop] PRIMARY KEY CLUSTERED 
(
	[KeyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


ALTER TABLE [ace].[hotspotop]  WITH CHECK ADD  CONSTRAINT [hotspotop JsonData record should be formatted as JSON] CHECK  ((isjson([JsonData])=(1)))
GO

ALTER TABLE [ace].[hotspotop] CHECK CONSTRAINT [hotspotop JsonData record should be formatted as JSON]
GO

CREATE TABLE [ace].[hotspotpackage](
	[KeyId] [int] IDENTITY(1,1) NOT NULL,
	[JsonData] [nvarchar](max) NOT NULL,
	[JsonDataId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_hotspotpackage] PRIMARY KEY CLUSTERED 
(
	[KeyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


ALTER TABLE [ace].[hotspotpackage]  WITH CHECK ADD  CONSTRAINT [hotspotpackage JsonData record should be formatted as JSON] CHECK  ((isjson([JsonData])=(1)))
GO

ALTER TABLE [ace].[hotspotpackage] CHECK CONSTRAINT [hotspotpackage JsonData record should be formatted as JSON]
GO

CREATE TABLE [ace].[map](
	[KeyId] [int] IDENTITY(1,1) NOT NULL,
	[JsonData] [nvarchar](max) NOT NULL,
	[JsonDataId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_map] PRIMARY KEY CLUSTERED 
(
	[KeyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


ALTER TABLE [ace].[map]  WITH CHECK ADD  CONSTRAINT [map JsonData record should be formatted as JSON] CHECK  ((isjson([JsonData])=(1)))
GO

ALTER TABLE [ace].[map] CHECK CONSTRAINT [map JsonData record should be formatted as JSON]
GO

CREATE TABLE [ace].[mediafile](
	[KeyId] [int] IDENTITY(1,1) NOT NULL,
	[JsonData] [nvarchar](max) NOT NULL,
	[JsonDataId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_mediafile] PRIMARY KEY CLUSTERED 
(
	[KeyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


ALTER TABLE [ace].[mediafile]  WITH CHECK ADD  CONSTRAINT [mediafile JsonData record should be formatted as JSON] CHECK  ((isjson([JsonData])=(1)))
GO

ALTER TABLE [ace].[mediafile] CHECK CONSTRAINT [mediafile JsonData record should be formatted as JSON]
GO

CREATE TABLE [ace].[networkconf](
	[KeyId] [int] IDENTITY(1,1) NOT NULL,
	[JsonData] [nvarchar](max) NOT NULL,
	[JsonDataId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_networkconf] PRIMARY KEY CLUSTERED 
(
	[KeyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


ALTER TABLE [ace].[networkconf]  WITH CHECK ADD  CONSTRAINT [networkconf JsonData record should be formatted as JSON] CHECK  ((isjson([JsonData])=(1)))
GO

ALTER TABLE [ace].[networkconf] CHECK CONSTRAINT [networkconf JsonData record should be formatted as JSON]
GO

CREATE TABLE [ace].[payment](
	[KeyId] [int] IDENTITY(1,1) NOT NULL,
	[JsonData] [nvarchar](max) NOT NULL,
	[JsonDataId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_payment] PRIMARY KEY CLUSTERED 
(
	[KeyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


ALTER TABLE [ace].[payment]  WITH CHECK ADD  CONSTRAINT [payment JsonData record should be formatted as JSON] CHECK  ((isjson([JsonData])=(1)))
GO

ALTER TABLE [ace].[payment] CHECK CONSTRAINT [payment JsonData record should be formatted as JSON]
GO

CREATE TABLE [ace].[portalfile](
	[KeyId] [int] IDENTITY(1,1) NOT NULL,
	[JsonData] [nvarchar](max) NOT NULL,
	[JsonDataId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_portalfile] PRIMARY KEY CLUSTERED 
(
	[KeyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


ALTER TABLE [ace].[portalfile]  WITH CHECK ADD  CONSTRAINT [portalfile JsonData record should be formatted as JSON] CHECK  ((isjson([JsonData])=(1)))
GO

ALTER TABLE [ace].[portalfile] CHECK CONSTRAINT [portalfile JsonData record should be formatted as JSON]
GO

CREATE TABLE [ace].[portconf](
	[KeyId] [int] IDENTITY(1,1) NOT NULL,
	[JsonData] [nvarchar](max) NOT NULL,
	[JsonDataId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_portconf] PRIMARY KEY CLUSTERED 
(
	[KeyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


ALTER TABLE [ace].[portconf]  WITH CHECK ADD  CONSTRAINT [portconf JsonData record should be formatted as JSON] CHECK  ((isjson([JsonData])=(1)))
GO

ALTER TABLE [ace].[portconf] CHECK CONSTRAINT [portconf JsonData record should be formatted as JSON]
GO

CREATE TABLE [ace].[portforward](
	[KeyId] [int] IDENTITY(1,1) NOT NULL,
	[JsonData] [nvarchar](max) NOT NULL,
	[JsonDataId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_portforward] PRIMARY KEY CLUSTERED 
(
	[KeyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


ALTER TABLE [ace].[portforward]  WITH CHECK ADD  CONSTRAINT [portforward JsonData record should be formatted as JSON] CHECK  ((isjson([JsonData])=(1)))
GO

ALTER TABLE [ace].[portforward] CHECK CONSTRAINT [portforward JsonData record should be formatted as JSON]
GO

CREATE TABLE [ace].[privilege](
	[KeyId] [int] IDENTITY(1,1) NOT NULL,
	[JsonData] [nvarchar](max) NOT NULL,
	[JsonDataId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_privilege] PRIMARY KEY CLUSTERED 
(
	[KeyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


ALTER TABLE [ace].[privilege]  WITH CHECK ADD  CONSTRAINT [privilege JsonData record should be formatted as JSON] CHECK  ((isjson([JsonData])=(1)))
GO

ALTER TABLE [ace].[privilege] CHECK CONSTRAINT [privilege JsonData record should be formatted as JSON]
GO

CREATE TABLE [ace].[radiusprofile](
	[KeyId] [int] IDENTITY(1,1) NOT NULL,
	[JsonData] [nvarchar](max) NOT NULL,
	[JsonDataId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_radiusprofile] PRIMARY KEY CLUSTERED 
(
	[KeyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


ALTER TABLE [ace].[radiusprofile]  WITH CHECK ADD  CONSTRAINT [radiusprofile JsonData record should be formatted as JSON] CHECK  ((isjson([JsonData])=(1)))
GO

ALTER TABLE [ace].[radiusprofile] CHECK CONSTRAINT [radiusprofile JsonData record should be formatted as JSON]
GO

CREATE TABLE [ace].[rogue](
	[KeyId] [int] IDENTITY(1,1) NOT NULL,
	[JsonData] [nvarchar](max) NOT NULL,
	[JsonDataId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_rogue] PRIMARY KEY CLUSTERED 
(
	[KeyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


ALTER TABLE [ace].[rogue]  WITH CHECK ADD  CONSTRAINT [rogue JsonData record should be formatted as JSON] CHECK  ((isjson([JsonData])=(1)))
GO

ALTER TABLE [ace].[rogue] CHECK CONSTRAINT [rogue JsonData record should be formatted as JSON]
GO

CREATE TABLE [ace].[rogueknown](
	[KeyId] [int] IDENTITY(1,1) NOT NULL,
	[JsonData] [nvarchar](max) NOT NULL,
	[JsonDataId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_rogueknown] PRIMARY KEY CLUSTERED 
(
	[KeyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


ALTER TABLE [ace].[rogueknown]  WITH CHECK ADD  CONSTRAINT [rogueknown JsonData record should be formatted as JSON] CHECK  ((isjson([JsonData])=(1)))
GO

ALTER TABLE [ace].[rogueknown] CHECK CONSTRAINT [rogueknown JsonData record should be formatted as JSON]
GO

CREATE TABLE [ace].[routing](
	[KeyId] [int] IDENTITY(1,1) NOT NULL,
	[JsonData] [nvarchar](max) NOT NULL,
	[JsonDataId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_routing] PRIMARY KEY CLUSTERED 
(
	[KeyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


ALTER TABLE [ace].[routing]  WITH CHECK ADD  CONSTRAINT [routing JsonData record should be formatted as JSON] CHECK  ((isjson([JsonData])=(1)))
GO

ALTER TABLE [ace].[routing] CHECK CONSTRAINT [routing JsonData record should be formatted as JSON]
GO

CREATE TABLE [ace].[scheduletask](
	[KeyId] [int] IDENTITY(1,1) NOT NULL,
	[JsonData] [nvarchar](max) NOT NULL,
	[JsonDataId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_scheduletask] PRIMARY KEY CLUSTERED 
(
	[KeyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


ALTER TABLE [ace].[scheduletask]  WITH CHECK ADD  CONSTRAINT [scheduletask JsonData record should be formatted as JSON] CHECK  ((isjson([JsonData])=(1)))
GO

ALTER TABLE [ace].[scheduletask] CHECK CONSTRAINT [scheduletask JsonData record should be formatted as JSON]
GO

CREATE TABLE [ace].[setting](
	[KeyId] [int] IDENTITY(1,1) NOT NULL,
	[JsonData] [nvarchar](max) NOT NULL,
	[JsonDataId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_setting] PRIMARY KEY CLUSTERED 
(
	[KeyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


ALTER TABLE [ace].[setting]  WITH CHECK ADD  CONSTRAINT [setting JsonData record should be formatted as JSON] CHECK  ((isjson([JsonData])=(1)))
GO

ALTER TABLE [ace].[setting] CHECK CONSTRAINT [setting JsonData record should be formatted as JSON]
GO

CREATE TABLE [ace].[site](
	[KeyId] [int] IDENTITY(1,1) NOT NULL,
	[JsonData] [nvarchar](max) NOT NULL,
	[JsonDataId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_site] PRIMARY KEY CLUSTERED 
(
	[KeyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


ALTER TABLE [ace].[site]  WITH CHECK ADD  CONSTRAINT [site JsonData record should be formatted as JSON] CHECK  ((isjson([JsonData])=(1)))
GO

ALTER TABLE [ace].[site] CHECK CONSTRAINT [site JsonData record should be formatted as JSON]
GO

CREATE TABLE [ace].[stat](
	[KeyId] [int] IDENTITY(1,1) NOT NULL,
	[JsonData] [nvarchar](max) NOT NULL,
	[JsonDataId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_stat] PRIMARY KEY CLUSTERED 
(
	[KeyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


ALTER TABLE [ace].[stat]  WITH CHECK ADD  CONSTRAINT [stat JsonData record should be formatted as JSON] CHECK  ((isjson([JsonData])=(1)))
GO

ALTER TABLE [ace].[stat] CHECK CONSTRAINT [stat JsonData record should be formatted as JSON]
GO

CREATE TABLE [ace].[system.indexes](
	[KeyId] [int] IDENTITY(1,1) NOT NULL,
	[JsonData] [nvarchar](max) NOT NULL,
	[JsonDataId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_system.indexes] PRIMARY KEY CLUSTERED 
(
	[KeyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


ALTER TABLE [ace].[system.indexes]  WITH CHECK ADD  CONSTRAINT [system.indexes JsonData record should be formatted as JSON] CHECK  ((isjson([JsonData])=(1)))
GO

ALTER TABLE [ace].[system.indexes] CHECK CONSTRAINT [system.indexes JsonData record should be formatted as JSON]
GO

CREATE TABLE [ace].[tag](
	[KeyId] [int] IDENTITY(1,1) NOT NULL,
	[JsonData] [nvarchar](max) NOT NULL,
	[JsonDataId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_tag] PRIMARY KEY CLUSTERED 
(
	[KeyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


ALTER TABLE [ace].[tag]  WITH CHECK ADD  CONSTRAINT [tag JsonData record should be formatted as JSON] CHECK  ((isjson([JsonData])=(1)))
GO

ALTER TABLE [ace].[tag] CHECK CONSTRAINT [tag JsonData record should be formatted as JSON]
GO

CREATE TABLE [ace].[task](
	[KeyId] [int] IDENTITY(1,1) NOT NULL,
	[JsonData] [nvarchar](max) NOT NULL,
	[JsonDataId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_task] PRIMARY KEY CLUSTERED 
(
	[KeyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


ALTER TABLE [ace].[task]  WITH CHECK ADD  CONSTRAINT [task JsonData record should be formatted as JSON] CHECK  ((isjson([JsonData])=(1)))
GO

ALTER TABLE [ace].[task] CHECK CONSTRAINT [task JsonData record should be formatted as JSON]
GO

CREATE TABLE [ace].[user](
	[KeyId] [int] IDENTITY(1,1) NOT NULL,
	[JsonData] [nvarchar](max) NOT NULL,
	[JsonDataId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[KeyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


ALTER TABLE [ace].[user]  WITH CHECK ADD  CONSTRAINT [user JsonData record should be formatted as JSON] CHECK  ((isjson([JsonData])=(1)))
GO

ALTER TABLE [ace].[user] CHECK CONSTRAINT [user JsonData record should be formatted as JSON]
GO

CREATE TABLE [ace].[usergroup](
	[KeyId] [int] IDENTITY(1,1) NOT NULL,
	[JsonData] [nvarchar](max) NOT NULL,
	[JsonDataId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_usergroup] PRIMARY KEY CLUSTERED 
(
	[KeyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


ALTER TABLE [ace].[usergroup]  WITH CHECK ADD  CONSTRAINT [usergroup JsonData record should be formatted as JSON] CHECK  ((isjson([JsonData])=(1)))
GO

ALTER TABLE [ace].[usergroup] CHECK CONSTRAINT [usergroup JsonData record should be formatted as JSON]
GO

CREATE TABLE [ace].[verification](
	[KeyId] [int] IDENTITY(1,1) NOT NULL,
	[JsonData] [nvarchar](max) NOT NULL,
	[JsonDataId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_verification] PRIMARY KEY CLUSTERED 
(
	[KeyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


ALTER TABLE [ace].[verification]  WITH CHECK ADD  CONSTRAINT [verification JsonData record should be formatted as JSON] CHECK  ((isjson([JsonData])=(1)))
GO

ALTER TABLE [ace].[verification] CHECK CONSTRAINT [verification JsonData record should be formatted as JSON]
GO

CREATE TABLE [ace].[virtualdevice](
	[KeyId] [int] IDENTITY(1,1) NOT NULL,
	[JsonData] [nvarchar](max) NOT NULL,
	[JsonDataId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_virtualdevice] PRIMARY KEY CLUSTERED 
(
	[KeyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


ALTER TABLE [ace].[virtualdevice]  WITH CHECK ADD  CONSTRAINT [virtualdevice JsonData record should be formatted as JSON] CHECK  ((isjson([JsonData])=(1)))
GO

ALTER TABLE [ace].[virtualdevice] CHECK CONSTRAINT [virtualdevice JsonData record should be formatted as JSON]
GO

CREATE TABLE [ace].[voucher](
	[KeyId] [int] IDENTITY(1,1) NOT NULL,
	[JsonData] [nvarchar](max) NOT NULL,
	[JsonDataId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_voucher] PRIMARY KEY CLUSTERED 
(
	[KeyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


ALTER TABLE [ace].[voucher]  WITH CHECK ADD  CONSTRAINT [voucher JsonData record should be formatted as JSON] CHECK  ((isjson([JsonData])=(1)))
GO

ALTER TABLE [ace].[voucher] CHECK CONSTRAINT [voucher JsonData record should be formatted as JSON]
GO

CREATE TABLE [ace].[wall](
	[KeyId] [int] IDENTITY(1,1) NOT NULL,
	[JsonData] [nvarchar](max) NOT NULL,
	[JsonDataId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_wall] PRIMARY KEY CLUSTERED 
(
	[KeyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


ALTER TABLE [ace].[wall]  WITH CHECK ADD  CONSTRAINT [wall JsonData record should be formatted as JSON] CHECK  ((isjson([JsonData])=(1)))
GO

ALTER TABLE [ace].[wall] CHECK CONSTRAINT [wall JsonData record should be formatted as JSON]
GO

CREATE TABLE [ace].[wlanconf](
	[KeyId] [int] IDENTITY(1,1) NOT NULL,
	[JsonData] [nvarchar](max) NOT NULL,
	[JsonDataId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_wlanconf] PRIMARY KEY CLUSTERED 
(
	[KeyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


ALTER TABLE [ace].[wlanconf]  WITH CHECK ADD  CONSTRAINT [wlanconf JsonData record should be formatted as JSON] CHECK  ((isjson([JsonData])=(1)))
GO

ALTER TABLE [ace].[wlanconf] CHECK CONSTRAINT [wlanconf JsonData record should be formatted as JSON]
GO

CREATE TABLE [ace].[wlangroup](
	[KeyId] [int] IDENTITY(1,1) NOT NULL,
	[JsonData] [nvarchar](max) NOT NULL,
	[JsonDataId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_wlangroup] PRIMARY KEY CLUSTERED 
(
	[KeyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


ALTER TABLE [ace].[wlangroup]  WITH CHECK ADD  CONSTRAINT [wlangroup JsonData record should be formatted as JSON] CHECK  ((isjson([JsonData])=(1)))
GO

ALTER TABLE [ace].[wlangroup] CHECK CONSTRAINT [wlangroup JsonData record should be formatted as JSON]
GO

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

CREATE TABLE [ace_stat].[stat_5minutes](
	[KeyId] [int] IDENTITY(1,1) NOT NULL,
	[JsonData] [nvarchar](max) NOT NULL,
	[JsonDataId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_stat_5minutes] PRIMARY KEY CLUSTERED 
(
	[KeyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [ace_stat].[stat_5minutes]  WITH CHECK ADD  CONSTRAINT [stat_5minutes JsonData record should be formatted as JSON] CHECK  ((isjson([JsonData])=(1)))
GO

ALTER TABLE [ace_stat].[stat_5minutes] CHECK CONSTRAINT [stat_5minutes JsonData record should be formatted as JSON]
GO



CREATE TABLE [ace_stat].[stat_archive](
	[KeyId] [int] IDENTITY(1,1) NOT NULL,
	[JsonData] [nvarchar](max) NOT NULL,
	[JsonDataId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_stat_archive] PRIMARY KEY CLUSTERED 
(
	[KeyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [ace_stat].[stat_archive]  WITH CHECK ADD  CONSTRAINT [stat_archive JsonData record should be formatted as JSON] CHECK  ((isjson([JsonData])=(1)))
GO

ALTER TABLE [ace_stat].[stat_archive] CHECK CONSTRAINT [stat_archive JsonData record should be formatted as JSON]
GO


CREATE TABLE [ace_stat].[stat_daily](
	[KeyId] [int] IDENTITY(1,1) NOT NULL,
	[JsonData] [nvarchar](max) NOT NULL,
	[JsonDataId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_stat_daily] PRIMARY KEY CLUSTERED 
(
	[KeyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [ace_stat].[stat_daily]  WITH CHECK ADD  CONSTRAINT [stat_daily JsonData record should be formatted as JSON] CHECK  ((isjson([JsonData])=(1)))
GO

ALTER TABLE [ace_stat].[stat_daily] CHECK CONSTRAINT [stat_daily JsonData record should be formatted as JSON]
GO


CREATE TABLE [ace_stat].[stat_dpi](
	[KeyId] [int] IDENTITY(1,1) NOT NULL,
	[JsonData] [nvarchar](max) NOT NULL,
	[JsonDataId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_stat_dpi] PRIMARY KEY CLUSTERED 
(
	[KeyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [ace_stat].[stat_dpi]  WITH CHECK ADD  CONSTRAINT [stat_dpi JsonData record should be formatted as JSON] CHECK  ((isjson([JsonData])=(1)))
GO

ALTER TABLE [ace_stat].[stat_dpi] CHECK CONSTRAINT [stat_dpi JsonData record should be formatted as JSON]
GO


CREATE TABLE [ace_stat].[stat_hourly](
	[KeyId] [int] IDENTITY(1,1) NOT NULL,
	[JsonData] [nvarchar](max) NOT NULL,
	[JsonDataId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_stat_hourly] PRIMARY KEY CLUSTERED 
(
	[KeyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [ace_stat].[stat_hourly]  WITH CHECK ADD  CONSTRAINT [stat_hourly JsonData record should be formatted as JSON] CHECK  ((isjson([JsonData])=(1)))
GO

ALTER TABLE [ace_stat].[stat_hourly] CHECK CONSTRAINT [stat_hourly JsonData record should be formatted as JSON]
GO


CREATE TABLE [ace_stat].[stat_life](
	[KeyId] [int] IDENTITY(1,1) NOT NULL,
	[JsonData] [nvarchar](max) NOT NULL,
	[JsonDataId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_stat_life] PRIMARY KEY CLUSTERED 
(
	[KeyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [ace_stat].[stat_life]  WITH CHECK ADD  CONSTRAINT [stat_life JsonData record should be formatted as JSON] CHECK  ((isjson([JsonData])=(1)))
GO

ALTER TABLE [ace_stat].[stat_life] CHECK CONSTRAINT [stat_life JsonData record should be formatted as JSON]
GO


CREATE TABLE [ace_stat].[stat_minute](
	[KeyId] [int] IDENTITY(1,1) NOT NULL,
	[JsonData] [nvarchar](max) NOT NULL,
	[JsonDataId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_stat_minute] PRIMARY KEY CLUSTERED 
(
	[KeyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [ace_stat].[stat_minute]  WITH CHECK ADD  CONSTRAINT [stat_minute JsonData record should be formatted as JSON] CHECK  ((isjson([JsonData])=(1)))
GO

ALTER TABLE [ace_stat].[stat_minute] CHECK CONSTRAINT [stat_minute JsonData record should be formatted as JSON]
GO


CREATE TABLE [ace_stat].[stat_monthly](
	[KeyId] [int] IDENTITY(1,1) NOT NULL,
	[JsonData] [nvarchar](max) NOT NULL,
	[JsonDataId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_stat_monthly] PRIMARY KEY CLUSTERED 
(
	[KeyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [ace_stat].[stat_monthly]  WITH CHECK ADD  CONSTRAINT [stat_monthly JsonData record should be formatted as JSON] CHECK  ((isjson([JsonData])=(1)))
GO

ALTER TABLE [ace_stat].[stat_monthly] CHECK CONSTRAINT [stat_monthly JsonData record should be formatted as JSON]
GO


CREATE TABLE [local].[startup_log](
	[KeyId] [int] IDENTITY(1,1) NOT NULL,
	[JsonData] [nvarchar](max) NOT NULL,
	[JsonDataId] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_startup_log] PRIMARY KEY CLUSTERED 
(
	[KeyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

--local database 

ALTER TABLE [local].[startup_log]  WITH CHECK ADD  CONSTRAINT [startup_log JsonData record should be formatted as JSON] CHECK  ((isjson([JsonData])=(1)))
GO

ALTER TABLE [local].[startup_log] CHECK CONSTRAINT [startup_log JsonData record should be formatted as JSON]
GO


CREATE NONCLUSTERED  INDEX NonClustered_Index_account_JsonDataId ON [Ubiquiti-Unifi-Backup].[ace].[account] (JsonDataId asc);  
GO

CREATE NONCLUSTERED  INDEX NonClustered_Index_admin_JsonDataId ON [Ubiquiti-Unifi-Backup].[ace].[admin] (JsonDataId asc);  
GO

CREATE NONCLUSTERED  INDEX NonClustered_Index_alarm_JsonDataId ON [Ubiquiti-Unifi-Backup].[ace].[alarm] (JsonDataId asc);  
GO

CREATE NONCLUSTERED  INDEX NonClustered_Index_broadcastgroup_JsonDataId ON [Ubiquiti-Unifi-Backup].[ace].[broadcastgroup] (JsonDataId asc);  
GO

CREATE NONCLUSTERED  INDEX NonClustered_Index_dashboard_JsonDataId ON [Ubiquiti-Unifi-Backup].[ace].[dashboard] (JsonDataId asc);  
GO

CREATE NONCLUSTERED  INDEX NonClustered_Index_device_JsonDataId ON [Ubiquiti-Unifi-Backup].[ace].[device] (JsonDataId asc);  
GO

CREATE NONCLUSTERED  INDEX NonClustered_Index_dhcpoption_JsonDataId ON [Ubiquiti-Unifi-Backup].[ace].[dhcpoption] (JsonDataId asc);  
GO

CREATE NONCLUSTERED  INDEX NonClustered_Index_dpiapp_JsonDataId ON [Ubiquiti-Unifi-Backup].[ace].[dpiapp] (JsonDataId asc);  
GO

CREATE NONCLUSTERED  INDEX NonClustered_Index_dpigroup_JsonDataId ON [Ubiquiti-Unifi-Backup].[ace].[dpigroup] (JsonDataId asc);  
GO

CREATE NONCLUSTERED  INDEX NonClustered_Index_dynamicdns_JsonDataId ON [Ubiquiti-Unifi-Backup].[ace].[dynamicdns] (JsonDataId asc);  
GO

CREATE NONCLUSTERED  INDEX NonClustered_Index_event_JsonDataId ON [Ubiquiti-Unifi-Backup].[ace].[event] (JsonDataId asc);  
GO

CREATE NONCLUSTERED  INDEX NonClustered_Index_firewallgroup_JsonDataId ON [Ubiquiti-Unifi-Backup].[ace].[firewallgroup] (JsonDataId asc);  
GO

CREATE NONCLUSTERED  INDEX NonClustered_Index_firewallrule_JsonDataId ON [Ubiquiti-Unifi-Backup].[ace].[firewallrule] (JsonDataId asc);  
GO

CREATE NONCLUSTERED  INDEX NonClustered_Index_guest_JsonDataId ON [Ubiquiti-Unifi-Backup].[ace].[guest] (JsonDataId asc);  
GO

CREATE NONCLUSTERED  INDEX NonClustered_Index_heatmap_JsonDataId ON [Ubiquiti-Unifi-Backup].[ace].[heatmap] (JsonDataId asc);  
GO

CREATE NONCLUSTERED  INDEX NonClustered_Index_heatmappoint_JsonDataId ON [Ubiquiti-Unifi-Backup].[ace].[heatmappoint] (JsonDataId asc);  
GO

CREATE NONCLUSTERED  INDEX NonClustered_Index_hotspot2conf_JsonDataId ON [Ubiquiti-Unifi-Backup].[ace].[hotspot2conf] (JsonDataId asc);  
GO

CREATE NONCLUSTERED  INDEX NonClustered_Index_hotspotop_JsonDataId ON [Ubiquiti-Unifi-Backup].[ace].[hotspotop] (JsonDataId asc);  
GO

CREATE NONCLUSTERED  INDEX NonClustered_Index_hotspotpackage_JsonDataId ON [Ubiquiti-Unifi-Backup].[ace].[hotspotpackage] (JsonDataId asc);  
GO

CREATE NONCLUSTERED  INDEX NonClustered_Index_map_JsonDataId ON [Ubiquiti-Unifi-Backup].[ace].[map] (JsonDataId asc);  
GO

CREATE NONCLUSTERED  INDEX NonClustered_Index_mediafile_JsonDataId ON [Ubiquiti-Unifi-Backup].[ace].[mediafile] (JsonDataId asc);  
GO

CREATE NONCLUSTERED  INDEX NonClustered_Index_networkconf_JsonDataId ON [Ubiquiti-Unifi-Backup].[ace].[networkconf] (JsonDataId asc);  
GO

CREATE NONCLUSTERED  INDEX NonClustered_Index_payment_JsonDataId ON [Ubiquiti-Unifi-Backup].[ace].[payment] (JsonDataId asc);  
GO

CREATE NONCLUSTERED  INDEX NonClustered_Index_portalfile_JsonDataId ON [Ubiquiti-Unifi-Backup].[ace].[portalfile] (JsonDataId asc);  
GO

CREATE NONCLUSTERED  INDEX NonClustered_Index_portconf_JsonDataId ON [Ubiquiti-Unifi-Backup].[ace].[portconf] (JsonDataId asc);  
GO

CREATE NONCLUSTERED  INDEX NonClustered_Index_portforward_JsonDataId ON [Ubiquiti-Unifi-Backup].[ace].[portforward] (JsonDataId asc);  
GO

CREATE NONCLUSTERED  INDEX NonClustered_Index_privilege_JsonDataId ON [Ubiquiti-Unifi-Backup].[ace].[privilege] (JsonDataId asc);  
GO

CREATE NONCLUSTERED  INDEX NonClustered_Index_radiusprofile_JsonDataId ON [Ubiquiti-Unifi-Backup].[ace].[radiusprofile] (JsonDataId asc);  
GO

CREATE NONCLUSTERED  INDEX NonClustered_Index_rogue_JsonDataId ON [Ubiquiti-Unifi-Backup].[ace].[rogue] (JsonDataId asc);  
GO

CREATE NONCLUSTERED  INDEX NonClustered_Index_rogueknown_JsonDataId ON [Ubiquiti-Unifi-Backup].[ace].[rogueknown] (JsonDataId asc);  
GO

CREATE NONCLUSTERED  INDEX NonClustered_Index_routing_JsonDataId ON [Ubiquiti-Unifi-Backup].[ace].[routing] (JsonDataId asc);  
GO

CREATE NONCLUSTERED  INDEX NonClustered_Index_scheduletask_JsonDataId ON [Ubiquiti-Unifi-Backup].[ace].[scheduletask] (JsonDataId asc);  
GO

CREATE NONCLUSTERED  INDEX NonClustered_Index_setting_JsonDataId ON [Ubiquiti-Unifi-Backup].[ace].[setting] (JsonDataId asc);  
GO

CREATE NONCLUSTERED  INDEX NonClustered_Index_site_JsonDataId ON [Ubiquiti-Unifi-Backup].[ace].[site] (JsonDataId asc);  
GO

CREATE NONCLUSTERED  INDEX NonClustered_Index_stat_JsonDataId ON [Ubiquiti-Unifi-Backup].[ace].[stat] (JsonDataId asc);  
GO

--CREATE NONCLUSTERED  INDEX NonClustered_Index_system.indexes_JsonDataId ON [Ubiquiti-Unifi-Backup].[ace].[system.indexes] (JsonDataId asc);  
--GO

CREATE NONCLUSTERED  INDEX NonClustered_Index_tag_JsonDataId ON [Ubiquiti-Unifi-Backup].[ace].[tag] (JsonDataId asc);  
GO

CREATE NONCLUSTERED  INDEX NonClustered_Index_task_JsonDataId ON [Ubiquiti-Unifi-Backup].[ace].[task] (JsonDataId asc);  
GO

CREATE NONCLUSTERED  INDEX NonClustered_Index_user_JsonDataId ON [Ubiquiti-Unifi-Backup].[ace].[user] (JsonDataId asc);  
GO

CREATE NONCLUSTERED  INDEX NonClustered_Index_usergroup_JsonDataId ON [Ubiquiti-Unifi-Backup].[ace].[usergroup] (JsonDataId asc);  
GO

CREATE NONCLUSTERED  INDEX NonClustered_Index_verification_JsonDataId ON [Ubiquiti-Unifi-Backup].[ace].[verification] (JsonDataId asc);  
GO

CREATE NONCLUSTERED  INDEX NonClustered_Index_virtualdevice_JsonDataId ON [Ubiquiti-Unifi-Backup].[ace].[virtualdevice] (JsonDataId asc);  
GO

CREATE NONCLUSTERED  INDEX NonClustered_Index_voucher_JsonDataId ON [Ubiquiti-Unifi-Backup].[ace].[voucher] (JsonDataId asc);  
GO

CREATE NONCLUSTERED  INDEX NonClustered_Index_wall_JsonDataId ON [Ubiquiti-Unifi-Backup].[ace].[wall] (JsonDataId asc);  
GO

CREATE NONCLUSTERED  INDEX NonClustered_Index_wlanconf_JsonDataId ON [Ubiquiti-Unifi-Backup].[ace].[wlanconf] (JsonDataId asc);  
GO

CREATE NONCLUSTERED  INDEX NonClustered_Index_wlangroup_JsonDataId ON [Ubiquiti-Unifi-Backup].[ace].[wlangroup] (JsonDataId asc);  
GO

CREATE NONCLUSTERED  INDEX NonClustered_Index_ipsalert_JsonDataId ON [Ubiquiti-Unifi-Backup].[ace].[ipsalert] (JsonDataId asc);  
GO

CREATE NONCLUSTERED  INDEX NonClustered_Index_featuremigration_JsonDataId ON [Ubiquiti-Unifi-Backup].[ace].[featuremigration] (JsonDataId asc);  
GO

CREATE NONCLUSTERED  INDEX NonClustered_Index_storeddpistats_JsonDataId ON [Ubiquiti-Unifi-Backup].[ace].[storeddpistats] (JsonDataId asc);  
GO

CREATE NONCLUSTERED  INDEX NonClustered_Index_stat_5minutes_JsonDataId ON [Ubiquiti-Unifi-Backup].[ace_stat].[stat_5minutes] (JsonDataId asc);  
GO

CREATE NONCLUSTERED  INDEX NonClustered_Index_stat_archive_JsonDataId ON [Ubiquiti-Unifi-Backup].[ace_stat].[stat_archive] (JsonDataId asc);  
GO

CREATE NONCLUSTERED  INDEX NonClustered_Index_stat_daily_JsonDataId ON [Ubiquiti-Unifi-Backup].[ace_stat].[stat_daily] (JsonDataId asc);  
GO

CREATE NONCLUSTERED  INDEX NonClustered_Index_stat_dpi_JsonDataId ON [Ubiquiti-Unifi-Backup].[ace_stat].[stat_dpi] (JsonDataId asc);  
GO

CREATE NONCLUSTERED  INDEX NonClustered_Index_stat_hourly_JsonDataId ON [Ubiquiti-Unifi-Backup].[ace_stat].[stat_hourly] (JsonDataId asc);  
GO

CREATE NONCLUSTERED  INDEX NonClustered_Index_stat_life_JsonDataId ON [Ubiquiti-Unifi-Backup].[ace_stat].[stat_life] (JsonDataId asc);  
GO

CREATE NONCLUSTERED  INDEX NonClustered_Index_stat_minute_JsonDataId ON [Ubiquiti-Unifi-Backup].[ace_stat].[stat_minute] (JsonDataId asc);  
GO

CREATE NONCLUSTERED  INDEX NonClustered_Index_stat_monthly_JsonDataId ON [Ubiquiti-Unifi-Backup].[ace_stat].[stat_monthly] (JsonDataId asc);  
GO

--CREATE NONCLUSTERED  INDEX NonClustered_Index_system.indexes_JsonDataId ON [Ubiquiti-Unifi-Backup].[ace_stat].[system.indexes] (JsonDataId asc);  
--GO

CREATE NONCLUSTERED  INDEX NonClustered_Index_startup_log_JsonDataId ON [Ubiquiti-Unifi-Backup].[local].[startup_log] (JsonDataId asc);  
GO