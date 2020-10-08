USE [master]
GO

/****** Object:  Database [EPAM.FinalProject.DB]    Script Date: 08.10.2020 19:59:29 ******/
CREATE DATABASE [EPAM.FinalProject.DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EPAM.FinalProject.DB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\EPAM.FinalProject.DB.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'EPAM.FinalProject.DB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\EPAM.FinalProject.DB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EPAM.FinalProject.DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [EPAM.FinalProject.DB] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [EPAM.FinalProject.DB] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [EPAM.FinalProject.DB] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [EPAM.FinalProject.DB] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [EPAM.FinalProject.DB] SET ARITHABORT OFF 
GO

ALTER DATABASE [EPAM.FinalProject.DB] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [EPAM.FinalProject.DB] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [EPAM.FinalProject.DB] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [EPAM.FinalProject.DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [EPAM.FinalProject.DB] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [EPAM.FinalProject.DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [EPAM.FinalProject.DB] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [EPAM.FinalProject.DB] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [EPAM.FinalProject.DB] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [EPAM.FinalProject.DB] SET  DISABLE_BROKER 
GO

ALTER DATABASE [EPAM.FinalProject.DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [EPAM.FinalProject.DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [EPAM.FinalProject.DB] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [EPAM.FinalProject.DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [EPAM.FinalProject.DB] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [EPAM.FinalProject.DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [EPAM.FinalProject.DB] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [EPAM.FinalProject.DB] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [EPAM.FinalProject.DB] SET  MULTI_USER 
GO

ALTER DATABASE [EPAM.FinalProject.DB] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [EPAM.FinalProject.DB] SET DB_CHAINING OFF 
GO

ALTER DATABASE [EPAM.FinalProject.DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [EPAM.FinalProject.DB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE [EPAM.FinalProject.DB] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [EPAM.FinalProject.DB] SET  READ_WRITE 
GO

USE [EPAM.FinalProject.DB]
GO

/****** Object:  Table [dbo].[Message]    Script Date: 08.10.2020 20:00:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Message](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Text] [nvarchar](500) NOT NULL,
	[AuthorName] [nvarchar](50) NOT NULL,
	[CreationDate] [date] NOT NULL,
	[TopicId] [int] NOT NULL,
 CONSTRAINT [PK_Message] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Topic]    Script Date: 08.10.2020 20:00:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Topic](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CreationDate] [date] NOT NULL,
 CONSTRAINT [PK_Topic] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[User]    Script Date: 08.10.2020 20:00:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](200) NOT NULL,
	[Role] [nvarchar](50) NOT NULL,
	[Icon] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  StoredProcedure [dbo].[AddMessage]    Script Date: 08.10.2020 20:00:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddMessage]
@text NVARCHAR(500),
@author NVARCHAR(50),
@creationDate date,
@topicId int
AS
BEGIN
	INSERT INTO Message(Text,AuthorName,CreationDate,TopicId)
	VALUES (@text,@author,@creationDate,@topicId)
END
GO

/****** Object:  StoredProcedure [dbo].[AddTopic]    Script Date: 08.10.2020 20:01:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddTopic]
@name nvarchar(50),
@creationDate date
AS
BEGIN
	INSERT INTO Topic(Name,CreationDate)
	values (@name, @creationDate)
END
GO

/****** Object:  StoredProcedure [dbo].[AddUser]    Script Date: 08.10.2020 20:01:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddUser]
@name NVARCHAR(50),
@dateOfBirth date,
@login NVARCHAR(50),
@pass nvarchar(200),
@role nvarchar(50),
@icon nvarchar(200)
AS
BEGIN
	INSERT INTO [dbo].[User](Name,DateOfBirth,Login,Password,Role,Icon)
	VALUES(@name,@dateOfBirth,@login,@pass,@role,@icon)
END
GO

/****** Object:  StoredProcedure [dbo].[DeleteMessage]    Script Date: 08.10.2020 20:01:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteMessage]
@id int
AS
BEGIN
	delete from Message where [Id]=@id
END
GO

/****** Object:  StoredProcedure [dbo].[DeleteTopic]    Script Date: 08.10.2020 20:02:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteTopic]
@id int
AS
BEGIN
	delete from Topic where [Id]=@id
END
GO

/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 08.10.2020 20:02:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteUser]
@id int
AS
BEGIN
	DELETE FROM [User]
	WHERE [Id]=@id
END
GO

/****** Object:  StoredProcedure [dbo].[EditMessage]    Script Date: 08.10.2020 20:02:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EditMessage]
@id int,
@text NVARCHAR(500)
AS
BEGIN
	update Message
	set [Text]=@text
	where [Id]=@id
END
GO

/****** Object:  StoredProcedure [dbo].[EditTopic]    Script Date: 08.10.2020 20:02:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EditTopic]
@id int,
@name nvarchar(50)
AS
BEGIN
	UPDATE Topic
	set [Name]=@name
	where [Id]=@id
END
GO

/****** Object:  StoredProcedure [dbo].[EditUser]    Script Date: 08.10.2020 20:03:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EditUser]
@id int,
@name NVARCHAR(50),
@dateOfBirth date,
@login NVARCHAR(50),
@pass nvarchar(200),
@role nvarchar(50),
@icon nvarchar(200)
AS
BEGIN
	UPDATE [dbo].[User] 
	SET [Name]=@name,	
		[DateOfBirth]=@dateOfBirth,
		[Login]=@login,
		[Password]=@pass,
		[Role]=@role,
		[Icon]=@icon
	WHERE [Id]=@id
END
GO

/****** Object:  StoredProcedure [dbo].[GetAllMessagesInTopic]    Script Date: 08.10.2020 20:03:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllMessagesInTopic]
@topicId int
AS
BEGIN
	select * from Message 
	where [TopicId]=@topicId
	order by [CreationDate] desc
END
GO

/****** Object:  StoredProcedure [dbo].[GetAllTopics]    Script Date: 08.10.2020 20:03:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllTopics]
AS
BEGIN
	select * from Topic 
END
GO

/****** Object:  StoredProcedure [dbo].[GetAllUsers]    Script Date: 08.10.2020 20:03:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllUsers]
AS
BEGIN
	Select * FROM [User]
END
GO

/****** Object:  StoredProcedure [dbo].[GetMessageById]    Script Date: 08.10.2020 20:04:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[GetMessageById]
@id int
AS
BEGIN
	select * from Message where [Id]=@id
END
GO

/****** Object:  StoredProcedure [dbo].[GetTopicById]    Script Date: 08.10.2020 20:04:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetTopicById]
@id int
AS
BEGIN
	select * from Topic where [Id]=@id
END
GO

/****** Object:  StoredProcedure [dbo].[GetUserById]    Script Date: 08.10.2020 20:04:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetUserById]
@id int
AS
BEGIN
	Select * FROM [User]
	WHERE [Id]=@id
END
GO