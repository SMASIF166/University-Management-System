USE [master]
GO
/****** Object:  Database [UniversityDB]    Script Date: 06-Jun-18 1:23:04 AM ******/
CREATE DATABASE [UniversityDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'UniversityDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\UniversityDB.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'UniversityDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\UniversityDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [UniversityDB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UniversityDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UniversityDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UniversityDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UniversityDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UniversityDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UniversityDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [UniversityDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [UniversityDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UniversityDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UniversityDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UniversityDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UniversityDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UniversityDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UniversityDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UniversityDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UniversityDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [UniversityDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UniversityDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UniversityDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UniversityDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UniversityDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UniversityDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [UniversityDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UniversityDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [UniversityDB] SET  MULTI_USER 
GO
ALTER DATABASE [UniversityDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UniversityDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [UniversityDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [UniversityDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [UniversityDB] SET DELAYED_DURABILITY = DISABLED 
GO
USE [UniversityDB]
GO
/****** Object:  Table [dbo].[t_course]    Script Date: 06-Jun-18 1:23:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[t_course](
	[course_id] [int] IDENTITY(1,1) NOT NULL,
	[course_code] [varchar](50) NOT NULL,
	[course_name] [varchar](50) NOT NULL,
	[course_credit] [int] NOT NULL,
	[course_description] [varchar](100) NOT NULL,
	[dept_id] [int] NOT NULL,
	[semester_id] [int] NOT NULL,
	[course_status] [varchar](50) NULL,
	[teacher_id] [int] NULL,
 CONSTRAINT [PK_t_course] PRIMARY KEY CLUSTERED 
(
	[course_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[t_department]    Script Date: 06-Jun-18 1:23:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[t_department](
	[dept_id] [int] IDENTITY(1,1) NOT NULL,
	[dept_code] [varchar](50) NOT NULL,
	[dept_name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_t_department] PRIMARY KEY CLUSTERED 
(
	[dept_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[t_designation]    Script Date: 06-Jun-18 1:23:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[t_designation](
	[designation_id] [int] NOT NULL,
	[designation_name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_t_designation] PRIMARY KEY CLUSTERED 
(
	[designation_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[t_semester]    Script Date: 06-Jun-18 1:23:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[t_semester](
	[semester_id] [int] NOT NULL,
	[semester_name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_t_semester] PRIMARY KEY CLUSTERED 
(
	[semester_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[t_student]    Script Date: 06-Jun-18 1:23:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[t_student](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[contact_no] [varchar](50) NOT NULL,
	[date] [varchar](50) NOT NULL,
	[address] [varchar](100) NULL,
	[dept_id] [int] NOT NULL,
	[reg_no] [varchar](50) NULL,
 CONSTRAINT [PK_t_student] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[t_teacher]    Script Date: 06-Jun-18 1:23:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[t_teacher](
	[teacher_id] [int] IDENTITY(1,1) NOT NULL,
	[teacher_name] [varchar](50) NOT NULL,
	[teacher_address] [varchar](100) NULL,
	[teacher_email] [varchar](50) NOT NULL,
	[teacher_contactno] [varchar](50) NOT NULL,
	[designation_id] [int] NOT NULL,
	[teacher_credit] [int] NOT NULL,
	[assigned_credit] [int] NULL,
	[remain_credit] [int] NULL,
	[dept_id] [int] NOT NULL,
 CONSTRAINT [PK_t_teacher] PRIMARY KEY CLUSTERED 
(
	[teacher_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[t_designation] ([designation_id], [designation_name]) VALUES (1, N'Professor')
INSERT [dbo].[t_designation] ([designation_id], [designation_name]) VALUES (2, N'Assistant Professor')
INSERT [dbo].[t_designation] ([designation_id], [designation_name]) VALUES (3, N'Associate Professor')
INSERT [dbo].[t_designation] ([designation_id], [designation_name]) VALUES (4, N'Senior Lecturer')
INSERT [dbo].[t_designation] ([designation_id], [designation_name]) VALUES (5, N'Lecturer')
INSERT [dbo].[t_semester] ([semester_id], [semester_name]) VALUES (1, N'1st Semester')
INSERT [dbo].[t_semester] ([semester_id], [semester_name]) VALUES (2, N'2nd Semester')
INSERT [dbo].[t_semester] ([semester_id], [semester_name]) VALUES (3, N'3rd Semester')
INSERT [dbo].[t_semester] ([semester_id], [semester_name]) VALUES (4, N'4th Semester')
INSERT [dbo].[t_semester] ([semester_id], [semester_name]) VALUES (5, N'5th Semester')
INSERT [dbo].[t_semester] ([semester_id], [semester_name]) VALUES (6, N'6th Semester')
INSERT [dbo].[t_semester] ([semester_id], [semester_name]) VALUES (7, N'7th Semester')
INSERT [dbo].[t_semester] ([semester_id], [semester_name]) VALUES (8, N'8th Semester')
ALTER TABLE [dbo].[t_course]  WITH CHECK ADD  CONSTRAINT [FK_t_course_t_department] FOREIGN KEY([dept_id])
REFERENCES [dbo].[t_department] ([dept_id])
GO
ALTER TABLE [dbo].[t_course] CHECK CONSTRAINT [FK_t_course_t_department]
GO
ALTER TABLE [dbo].[t_course]  WITH CHECK ADD  CONSTRAINT [FK_t_course_t_semester] FOREIGN KEY([semester_id])
REFERENCES [dbo].[t_semester] ([semester_id])
GO
ALTER TABLE [dbo].[t_course] CHECK CONSTRAINT [FK_t_course_t_semester]
GO
ALTER TABLE [dbo].[t_teacher]  WITH CHECK ADD  CONSTRAINT [FK_t_teacher_t_department] FOREIGN KEY([dept_id])
REFERENCES [dbo].[t_department] ([dept_id])
GO
ALTER TABLE [dbo].[t_teacher] CHECK CONSTRAINT [FK_t_teacher_t_department]
GO
ALTER TABLE [dbo].[t_teacher]  WITH CHECK ADD  CONSTRAINT [FK_t_teacher_t_designation] FOREIGN KEY([designation_id])
REFERENCES [dbo].[t_designation] ([designation_id])
GO
ALTER TABLE [dbo].[t_teacher] CHECK CONSTRAINT [FK_t_teacher_t_designation]
GO
USE [master]
GO
ALTER DATABASE [UniversityDB] SET  READ_WRITE 
GO
