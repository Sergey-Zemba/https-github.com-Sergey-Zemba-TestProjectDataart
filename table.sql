USE [SZemba_Practice]
GO

/****** Object:  Table [dbo].[article]    Script Date: 15.09.2016 18:22:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[article](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](200) NOT NULL,
	[ShortDescription] [nvarchar](500) NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
	[PicturePath] [nvarchar](max) NOT NULL,
	[CreationDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

