USE [master]
GO
/****** Object:  Database [Manpower ]    Script Date: 2021/7/16 13:39:27 ******/
CREATE DATABASE [Manpower ]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Manpower', FILENAME = N'D:\仓库\sql脚本\DATA1\Manpower .mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Manpower _log', FILENAME = N'D:\仓库\sql脚本\DATA1\Manpower _log.ldf' , SIZE = 3456KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Manpower ] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Manpower ].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Manpower ] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Manpower ] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Manpower ] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Manpower ] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Manpower ] SET ARITHABORT OFF 
GO
ALTER DATABASE [Manpower ] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Manpower ] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Manpower ] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Manpower ] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Manpower ] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Manpower ] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Manpower ] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Manpower ] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Manpower ] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Manpower ] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Manpower ] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Manpower ] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Manpower ] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Manpower ] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Manpower ] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Manpower ] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Manpower ] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Manpower ] SET RECOVERY FULL 
GO
ALTER DATABASE [Manpower ] SET  MULTI_USER 
GO
ALTER DATABASE [Manpower ] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Manpower ] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Manpower ] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Manpower ] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Manpower ] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Manpower ] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Manpower ', N'ON'
GO
ALTER DATABASE [Manpower ] SET QUERY_STORE = OFF
GO
USE [Manpower ]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 2021/7/16 13:39:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NULL,
	[PID] [int] NULL,
 CONSTRAINT [PK__Departme__3214EC27F65D5B98] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 2021/7/16 13:39:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentID] [int] NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[Sex] [int] NOT NULL,
	[Birthday] [datetime] NOT NULL,
	[IdCard] [varchar](255) NOT NULL,
	[Position] [int] NOT NULL,
	[Phone] [varchar](255) NOT NULL,
	[Email] [varchar](255) NOT NULL,
	[Nation] [int] NOT NULL,
	[Polity] [int] NOT NULL,
	[Degree] [int] NOT NULL,
	[Salary] [money] NOT NULL,
	[Resume] [varchar](255) NOT NULL,
	[Meno] [varchar](255) NULL,
	[Status] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee_DIC]    Script Date: 2021/7/16 13:39:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee_DIC](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NULL,
	[PID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[View_EmployeeSEL]    Script Date: 2021/7/16 13:39:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_EmployeeSEL] AS SELECT a.ID,a.Name,a.DepartmentID,d.Name AS Department,a.Sex,a.Birthday,a.IdCard,d1.Name AS [Position],a.Phone,a.Email,d2.Name AS Nation,d3.Name AS Polity,d4.Name AS Degree,a.Salary,a.Resume,a.Meno,a.Status FROM Employee AS a INNER JOIN Department AS d ON a.DepartmentID = d.ID LEFT JOIN Employee_DIC AS d1 ON a.[Position] = d1.ID LEFT JOIN Employee_DIC AS d2 ON a.Nation = d2.ID LEFT JOIN Employee_DIC AS d3 ON a.Polity = d3.ID LEFT JOIN Employee_DIC AS d4 ON a.Degree = d4.ID;
GO
/****** Object:  View [dbo].[View_Degree]    Script Date: 2021/7/16 13:39:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_Degree] AS SELECT
	Employee_DIC.Name,
	COUNT(*) AS 'Count',
	COALESCE(Employee.Degree,0) AS 'booler'
FROM
	Employee
	RIGHT JOIN
	Employee_DIC
	ON 
		Employee.Degree = Employee_DIC.ID
WHERE
	Employee_DIC.PID = 28
GROUP BY
	Employee_DIC.Name
	,Employee.Degree
GO
/****** Object:  View [dbo].[View_Department]    Script Date: 2021/7/16 13:39:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_Department] AS SELECT
	Department.Name,
	COUNT(*) AS 'Count',
	COALESCE(Employee.DepartmentID,0) AS 'booler'
FROM
	Employee
	RIGHT JOIN
	Department
	ON 
		Employee.DepartmentID = Department.ID
WHERE
	1=1
GROUP BY
	Department.Name
	,Employee.DepartmentID
GO
/****** Object:  View [dbo].[View_Salary]    Script Date: 2021/7/16 13:39:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_Salary] AS SELECT '0-3k' AS name ,COUNT(*) AS value FROM Employee WHERE Employee.Salary<=3000
UNION
SELECT '3-5k' AS name ,COUNT(*) AS value FROM Employee WHERE Employee.Salary<=5000 AND Employee.Salary>3000
UNION
SELECT '5-8k' AS name ,COUNT(*) AS value FROM Employee WHERE Employee.Salary<=8000 AND Employee.Salary >5000
UNION
SELECT '8-?k' AS name ,COUNT(*) AS value FROM Employee WHERE Employee.Salary>8000
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2021/7/16 13:39:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Account] [varchar](255) NOT NULL,
	[Password] [varchar](255) NOT NULL,
	[RoleID] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
 CONSTRAINT [PK__Users__3214EC276B6F652F] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 2021/7/16 13:39:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[Content] [varchar](255) NULL,
	[Expower] [varchar](255) NULL,
	[CreateDate] [datetime2](0) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[View_UserEdit]    Script Date: 2021/7/16 13:39:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_UserEdit] AS SELECT
	Users.ID, 
	Users.Account, 
	Users.Password, 
	Users.IsActive, 
	Role.Name, 
	Users.CreateDate,
	Role.ID as RID
FROM
	Role
	INNER JOIN
	Users
	ON 
		Role.ID = Users.RoleID
GO
/****** Object:  Table [dbo].[Menus]    Script Date: 2021/7/16 13:39:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menus](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[Url] [varchar](255) NOT NULL,
	[ParentID] [int] NULL,
	[Sort] [int] NULL,
	[CreateDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pwdSafe]    Script Date: 2021/7/16 13:39:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pwdSafe](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[se1] [int] NOT NULL,
	[sesave1] [varchar](255) NOT NULL,
	[UID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Secret_security]    Script Date: 2021/7/16 13:39:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Secret_security](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Content] [varchar](255) NOT NULL,
 CONSTRAINT [PK__Secret_s__3214EC2709E39C42] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Department] ON 

INSERT [dbo].[Department] ([ID], [Name], [PID]) VALUES (1, N'技术部', NULL)
INSERT [dbo].[Department] ([ID], [Name], [PID]) VALUES (2, N'前端', 1)
INSERT [dbo].[Department] ([ID], [Name], [PID]) VALUES (3, N'后端', 1)
INSERT [dbo].[Department] ([ID], [Name], [PID]) VALUES (4, N'Java开发', 3)
INSERT [dbo].[Department] ([ID], [Name], [PID]) VALUES (5, N'Python开发', 3)
SET IDENTITY_INSERT [dbo].[Department] OFF
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([ID], [DepartmentID], [Name], [Sex], [Birthday], [IdCard], [Position], [Phone], [Email], [Nation], [Polity], [Degree], [Salary], [Resume], [Meno], [Status]) VALUES (2, 5, N'张三', 1, CAST(N'2021-01-05T00:00:00.000' AS DateTime), N'22010219990716897X', 21, N'15052112138', N'admin@admin.com', 91, 24, 33, 13800.2000, N'高级算法工程师', N'1', N'1')
INSERT [dbo].[Employee] ([ID], [DepartmentID], [Name], [Sex], [Birthday], [IdCard], [Position], [Phone], [Email], [Nation], [Polity], [Degree], [Salary], [Resume], [Meno], [Status]) VALUES (3, 1, N'Theresa Chavez', 0, CAST(N'2021-01-04T00:00:00.000' AS DateTime), N'121212121212121212', 14, N'17667160357', N'Adaogei@nikm.cn', 36, 25, 29, 5999.0000, N'1', N'1', N'1')
INSERT [dbo].[Employee] ([ID], [DepartmentID], [Name], [Sex], [Birthday], [IdCard], [Position], [Phone], [Email], [Nation], [Polity], [Degree], [Salary], [Resume], [Meno], [Status]) VALUES (4, 1, N'Theresa Chavez', 1, CAST(N'2021-01-04T00:00:00.000' AS DateTime), N'121212121212121212', 14, N'17667160357', N'Adaogei@nikm.cn', 91, 24, 33, 1111111.0000, N'5555555', N'1', N'1')
INSERT [dbo].[Employee] ([ID], [DepartmentID], [Name], [Sex], [Birthday], [IdCard], [Position], [Phone], [Email], [Nation], [Polity], [Degree], [Salary], [Resume], [Meno], [Status]) VALUES (5, 2, N'Theresa Chavez', 0, CAST(N'2021-01-05T00:00:00.000' AS DateTime), N'121212121212121212', 19, N'17667160357', N'Adaogei@nikm.cn', 36, 24, 30, 3888.0000, N'1111', N'1', N'1')
INSERT [dbo].[Employee] ([ID], [DepartmentID], [Name], [Sex], [Birthday], [IdCard], [Position], [Phone], [Email], [Nation], [Polity], [Degree], [Salary], [Resume], [Meno], [Status]) VALUES (6, 2, N'Theresa Chavez', 1, CAST(N'2021-01-04T00:00:00.000' AS DateTime), N'121212121212121212', 13, N'17667160357', N'Adaogei@nikm.cn', 91, 24, 30, 8111.0000, N'1111', N'1', N'0')
INSERT [dbo].[Employee] ([ID], [DepartmentID], [Name], [Sex], [Birthday], [IdCard], [Position], [Phone], [Email], [Nation], [Polity], [Degree], [Salary], [Resume], [Meno], [Status]) VALUES (7, 3, N'张三', 1, CAST(N'2021-01-05T00:00:00.000' AS DateTime), N'22010219990716897X', 21, N'15052112138', N'admin@admin.com', 91, 24, 31, 13800.2000, N'超高级高级算法工程师', N'1', N'0')
INSERT [dbo].[Employee] ([ID], [DepartmentID], [Name], [Sex], [Birthday], [IdCard], [Position], [Phone], [Email], [Nation], [Polity], [Degree], [Salary], [Resume], [Meno], [Status]) VALUES (8, 5, N'张三', 1, CAST(N'2021-01-05T00:00:00.000' AS DateTime), N'22010219990716897X', 21, N'15052112138', N'admin@admin.com', 91, 24, 33, 13800.2000, N'超高级高级算法工程师', N'1', N'1')
INSERT [dbo].[Employee] ([ID], [DepartmentID], [Name], [Sex], [Birthday], [IdCard], [Position], [Phone], [Email], [Nation], [Polity], [Degree], [Salary], [Resume], [Meno], [Status]) VALUES (29, 4, N'Theresa Chavez', 1, CAST(N'2021-01-05T00:00:00.000' AS DateTime), N'121121121121121121', 13, N'17667160357', N'Adaogei@nikm.cn', 36, 24, 30, 1.0000, N'00000000000000000000000', NULL, N'0')
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
SET IDENTITY_INSERT [dbo].[Employee_DIC] ON 

INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (1, N'职位', NULL)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (13, N'副总经理', 1)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (14, N'人力资源总监', 1)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (15, N'财务总监(CFO)', 1)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (16, N'营销总监', 1)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (17, N'市场总监(CMO)', 1)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (18, N'销售总监', 1)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (19, N'生产总监', 1)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (20, N'运营总监', 1)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (21, N'技术总监(CTO)', 1)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (22, N'总经理助理', 1)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (23, N'政治面貌', NULL)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (24, N'党员', 23)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (25, N'预备党员', 23)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (26, N'团员', 23)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (27, N'普通居民', 23)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (28, N'学历', NULL)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (29, N'初中', 28)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (30, N'高中', 28)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (31, N'大专', 28)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (32, N'二本', 28)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (33, N'—本', 28)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (34, N'民族', NULL)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (35, N'蒙古族', 34)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (36, N'满族', 34)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (37, N'朝鲜族', 34)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (38, N'赫哲族', 34)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (39, N'达斡尔族', 34)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (40, N'鄂温克族', 34)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (41, N'鄂伦春族', 34)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (42, N'回族', 34)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (43, N'东乡族', 34)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (44, N'土族', 34)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (45, N'撒拉族', 34)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (46, N'保安族', 34)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (47, N'裕固族', 34)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (48, N'维吾尔族', 34)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (49, N'哈萨克族', 34)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (50, N'柯尔克孜族', 34)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (51, N'锡伯族', 34)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (52, N'塔吉克族', 34)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (53, N'乌孜别克族', 34)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (54, N'俄罗斯族', 34)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (55, N'塔塔尔族', 34)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (56, N'藏族', 34)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (57, N'门巴族', 34)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (58, N'珞巴族', 34)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (59, N'羌族', 34)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (60, N'彝族', 34)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (61, N'白族', 34)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (62, N'哈尼族', 34)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (63, N'傣族', 34)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (64, N'僳僳族', 34)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (65, N'佤族', 34)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (66, N'拉祜族', 34)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (67, N'纳西族', 34)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (68, N'景颇族', 34)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (69, N'布朗族', 34)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (70, N'阿昌族', 34)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (71, N'普米族', 34)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (72, N'怒族', 34)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (73, N'德昂族', 34)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (74, N'独龙族', 34)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (75, N'基诺族', 34)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (76, N'苗族', 34)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (77, N'布依族', 34)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (78, N'侗族', 34)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (79, N'水族', 34)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (80, N'仡佬族', 34)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (81, N'壮族', 34)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (82, N'瑶族', 34)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (83, N'仫佬族', 34)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (84, N'毛南族', 34)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (85, N'京族', 34)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (86, N'土家族', 34)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (87, N'黎族', 34)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (88, N'畲族', 34)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (89, N'高山族', 34)
INSERT [dbo].[Employee_DIC] ([ID], [Name], [PID]) VALUES (91, N'汉族', 34)
SET IDENTITY_INSERT [dbo].[Employee_DIC] OFF
GO
SET IDENTITY_INSERT [dbo].[Menus] ON 

INSERT [dbo].[Menus] ([ID], [Name], [Url], [ParentID], [Sort], [CreateDate]) VALUES (1, N'员工管理', N'#', NULL, NULL, CAST(N'2020-12-11T09:45:09.843' AS DateTime))
INSERT [dbo].[Menus] ([ID], [Name], [Url], [ParentID], [Sort], [CreateDate]) VALUES (2, N'统计管理', N'#', NULL, NULL, CAST(N'2020-12-11T09:45:41.650' AS DateTime))
INSERT [dbo].[Menus] ([ID], [Name], [Url], [ParentID], [Sort], [CreateDate]) VALUES (3, N'系统管理', N'#', NULL, NULL, CAST(N'2020-12-11T09:46:07.340' AS DateTime))
INSERT [dbo].[Menus] ([ID], [Name], [Url], [ParentID], [Sort], [CreateDate]) VALUES (4, N'员工列表', N'Serviceroot/User_management/Employee_list.html', 1, NULL, CAST(N'2020-12-11T09:46:23.660' AS DateTime))
INSERT [dbo].[Menus] ([ID], [Name], [Url], [ParentID], [Sort], [CreateDate]) VALUES (6, N'员工添加', N'Serviceroot/User_management/Employee_add.html', 1, NULL, CAST(N'2020-12-11T09:46:49.250' AS DateTime))
INSERT [dbo].[Menus] ([ID], [Name], [Url], [ParentID], [Sort], [CreateDate]) VALUES (7, N'性别统计', N'Serviceroot/Statistics_management/SexStatistics.html', 2, NULL, CAST(N'2020-12-11T09:48:32.877' AS DateTime))
INSERT [dbo].[Menus] ([ID], [Name], [Url], [ParentID], [Sort], [CreateDate]) VALUES (8, N'学历统计', N'Serviceroot/Statistics_management/DegreeStatistics.html', 2, NULL, CAST(N'2020-12-11T09:49:49.750' AS DateTime))
INSERT [dbo].[Menus] ([ID], [Name], [Url], [ParentID], [Sort], [CreateDate]) VALUES (9, N'部门统计', N'Serviceroot/Statistics_management/DepartmentStatistics.html', 2, NULL, CAST(N'2020-12-11T09:50:04.563' AS DateTime))
INSERT [dbo].[Menus] ([ID], [Name], [Url], [ParentID], [Sort], [CreateDate]) VALUES (10, N'工资统计', N'Serviceroot/Statistics_management/SalaryStatistics.html', 2, NULL, CAST(N'2020-12-11T09:50:18.193' AS DateTime))
INSERT [dbo].[Menus] ([ID], [Name], [Url], [ParentID], [Sort], [CreateDate]) VALUES (11, N'用户管理', N'Serviceroot/System_management/user.html', 3, NULL, CAST(N'2020-12-11T09:50:52.820' AS DateTime))
INSERT [dbo].[Menus] ([ID], [Name], [Url], [ParentID], [Sort], [CreateDate]) VALUES (12, N'角色管理', N'Serviceroot/System_management/roleaddedit.html', 3, NULL, CAST(N'2020-12-11T09:51:06.740' AS DateTime))
INSERT [dbo].[Menus] ([ID], [Name], [Url], [ParentID], [Sort], [CreateDate]) VALUES (14, N'修改密码', N'Serviceroot/System_management/resetpwd.html', 3, NULL, CAST(N'2020-12-11T09:51:31.383' AS DateTime))
INSERT [dbo].[Menus] ([ID], [Name], [Url], [ParentID], [Sort], [CreateDate]) VALUES (15, N'退出登录', N'', 3, NULL, CAST(N'2020-12-11T09:51:41.053' AS DateTime))
SET IDENTITY_INSERT [dbo].[Menus] OFF
GO
SET IDENTITY_INSERT [dbo].[pwdSafe] ON 

INSERT [dbo].[pwdSafe] ([ID], [se1], [sesave1], [UID]) VALUES (2, 2, N'asssss', 164)
INSERT [dbo].[pwdSafe] ([ID], [se1], [sesave1], [UID]) VALUES (3, 5, N'test00001', 165)
INSERT [dbo].[pwdSafe] ([ID], [se1], [sesave1], [UID]) VALUES (4, 2, N'4', 230)
SET IDENTITY_INSERT [dbo].[pwdSafe] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([ID], [Name], [Content], [Expower], [CreateDate]) VALUES (1, N'管理员', N'所有列表的管理', N'1,4,6,2,7,8,9,10,3,11,12,13,14,15', CAST(N'2020-12-21T13:28:42.0000000' AS DateTime2))
INSERT [dbo].[Role] ([ID], [Name], [Content], [Expower], [CreateDate]) VALUES (2, N'文章撰写员', N'负责文章的编写', N'2,7,8,9,10', CAST(N'2020-12-21T13:28:45.0000000' AS DateTime2))
INSERT [dbo].[Role] ([ID], [Name], [Content], [Expower], [CreateDate]) VALUES (3, N'纠错员', N'负责文章内容的修改', N'2,7,8,9,10', CAST(N'2020-12-21T13:28:45.0000000' AS DateTime2))
INSERT [dbo].[Role] ([ID], [Name], [Content], [Expower], [CreateDate]) VALUES (4, N'统计人员', N'对数据进行统计', N'2,7,8,9,10', CAST(N'2020-12-21T13:28:45.0000000' AS DateTime2))
INSERT [dbo].[Role] ([ID], [Name], [Content], [Expower], [CreateDate]) VALUES (5, N'评估员', N'对统计数据进行评估', N'2,7,8,9,10', CAST(N'2020-12-21T13:28:45.0000000' AS DateTime2))
INSERT [dbo].[Role] ([ID], [Name], [Content], [Expower], [CreateDate]) VALUES (6, N'采购员', N'负责员工的伙食', N'2,7,8,9,10', CAST(N'2020-12-21T13:28:45.0000000' AS DateTime2))
INSERT [dbo].[Role] ([ID], [Name], [Content], [Expower], [CreateDate]) VALUES (7, N'推销员', N'介绍销售公司产品', N'3,11,12,13,14,15', CAST(N'2020-12-21T13:28:45.0000000' AS DateTime2))
INSERT [dbo].[Role] ([ID], [Name], [Content], [Expower], [CreateDate]) VALUES (1001, N'无权限', N'用户注册时默认权限', N'3,14', CAST(N'2021-01-12T22:37:32.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[Secret_security] ON 

INSERT [dbo].[Secret_security] ([ID], [Content]) VALUES (1, N'你父亲姓名?')
INSERT [dbo].[Secret_security] ([ID], [Content]) VALUES (2, N'你的生日?')
INSERT [dbo].[Secret_security] ([ID], [Content]) VALUES (3, N'你毕业于哪个初中?')
INSERT [dbo].[Secret_security] ([ID], [Content]) VALUES (4, N'你喜欢看的电影?')
INSERT [dbo].[Secret_security] ([ID], [Content]) VALUES (5, N'你初恋的名字?')
INSERT [dbo].[Secret_security] ([ID], [Content]) VALUES (6, N'你最要好的朋友?')
SET IDENTITY_INSERT [dbo].[Secret_security] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (1, N'admin', N'123123', 7, 0, CAST(N'2020-12-23T15:57:37.000' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (2, N'lxxh', N'lxxh123666', 3, 0, CAST(N'2020-12-18T09:34:00.000' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (103, N'T88888888', N'WRiL8L7c1', 8, 0, CAST(N'2020-12-18T10:11:33.000' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (104, N'lwRuQrOZ', N'Lnt6HoIz', 5, 0, CAST(N'2020-12-11T00:00:00.000' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (105, N'jdXPqGIo', N'GHDxGoQn', 4, 0, CAST(N'2020-12-12T00:00:00.000' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (106, N'QikCdknG', N'N6SVn4wN', 3, 0, CAST(N'2020-12-17T23:36:18.000' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (107, N'aQiYkdPB', N'qkO2LnSQ', 2, 0, CAST(N'2020-12-17T23:40:16.000' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (108, N'ZqVWjoPI', N'rMYnoZ1v', 3, 0, CAST(N'2020-12-15T00:00:00.000' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (109, N'ohcdCDar', N'9cakPcnr', 4, 0, CAST(N'2020-12-16T00:00:00.000' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (110, N'OHvtGlIF', N'uCLBg5m2', 5, 0, CAST(N'2020-12-17T00:00:00.000' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (111, N'QXGEsBBq', N'55PNPNXm', 6, 0, CAST(N'2020-12-18T00:00:00.000' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (112, N'DXFnNxxM', N'cVeDCSKp', 1, 1, CAST(N'2020-12-19T00:00:00.000' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (113, N'tNXdLBbb', N'9LfjZ0t9', 3, 1, CAST(N'2020-12-20T00:00:00.000' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (114, N'Zgeqobcb', N'9rEzH0dv', 4, 1, CAST(N'2020-12-21T00:00:00.000' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (115, N'jkDfOztw', N'bu9hM1NE', 5, 1, CAST(N'2020-12-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (116, N'CvNEQGEq', N'htBPdcqf', 4, 1, CAST(N'2020-12-23T00:00:00.000' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (117, N'fCPnChDu', N'kXlMKScP', 3, 1, CAST(N'2020-12-24T00:00:00.000' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (118, N'nPBoVmmG', N'IR1Q6WFN', 2, 1, CAST(N'2020-12-25T00:00:00.000' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (119, N'KbAGNNuH', N'RYsDTqgp', 3, 1, CAST(N'2020-12-26T00:00:00.000' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (120, N'vkrtYyIN', N'PK60Ps68', 4, 1, CAST(N'2020-12-27T00:00:00.000' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (121, N'GgTQHfwV', N'NmXnyPuV', 5, 1, CAST(N'2020-12-28T00:00:00.000' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (122, N'EgGsLWgS', N'Gv0sSo9D', 6, 1, CAST(N'2020-12-29T00:00:00.000' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (123, N'gyaTtSGf', N'k41njFot', 1, 1, CAST(N'2020-12-30T00:00:00.000' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (124, N'aDwLhjty', N'dAlsx39X', 1, 1, CAST(N'2020-12-31T00:00:00.000' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (125, N'TMzxPBZI', N'F24pyG0X', 1, 1, CAST(N'2021-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (126, N'TTfHoqYa', N'yvxU9pZl', 1, 1, CAST(N'2021-01-02T00:00:00.000' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (127, N'lkpfwjQC', N'4VrhD8Yl', 3, 1, CAST(N'2021-01-03T00:00:00.000' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (128, N'Bypquurw', N'yCadMf6X', 4, 1, CAST(N'2021-01-04T00:00:00.000' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (129, N'LceUTGPg', N'nkjg4z6Q', 5, 1, CAST(N'2021-01-05T00:00:00.000' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (130, N'nZcouHAn', N'q48Bc8AB', 4, 1, CAST(N'2021-01-06T00:00:00.000' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (131, N'QaNhIwPC', N'rQwmwvR5', 3, 1, CAST(N'2021-01-07T00:00:00.000' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (132, N'ObBxMwqB', N'HI3NfuGC', 2, 1, CAST(N'2021-01-08T00:00:00.000' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (133, N'pLBhfEXZ', N'DNQ3wE2u', 3, 1, CAST(N'2021-01-09T00:00:00.000' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (134, N'pHzbLRXU', N'2DyefMvi', 4, 1, CAST(N'2021-01-10T00:00:00.000' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (135, N'KMhQlUnZ', N'jHPOBaXG', 5, 1, CAST(N'2021-01-11T00:00:00.000' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (136, N'tQDkynKZ', N'OBGrHTUu', 6, 1, CAST(N'2021-01-12T00:00:00.000' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (137, N'pSMRFHxK', N'o5bro2vs', 1, 1, CAST(N'2021-01-13T00:00:00.000' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (138, N'kEVEauZq', N'3C1PT9tW', 1, 1, CAST(N'2021-01-14T00:00:00.000' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (139, N'VFUqlFam', N'fzqQzHaB', 1, 1, CAST(N'2021-01-15T00:00:00.000' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (140, N'skKweNcI', N'zcMRyNbS', 1, 1, CAST(N'2021-01-16T00:00:00.000' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (141, N'qpdwgKgg', N'v8TP0u3i', 1, 1, CAST(N'2021-01-17T00:00:00.000' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (142, N'mHlcGDML', N'OMmOOOUe', 3, 1, CAST(N'2021-01-18T00:00:00.000' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (143, N'nGfyaqjE', N'cMvExpbO', 4, 1, CAST(N'2021-01-19T00:00:00.000' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (144, N'KfpRQtXA', N'2OGrgVAN', 5, 1, CAST(N'2021-01-20T00:00:00.000' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (145, N'lEtyAxvU', N'mrpMteBX', 4, 1, CAST(N'2021-01-21T00:00:00.000' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (146, N'wLGpRxVl', N's7FCFPd9', 3, 1, CAST(N'2021-01-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (147, N'aGLNujUQ', N'r0Sck4O7', 2, 1, CAST(N'2021-01-23T00:00:00.000' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (148, N'mfdLDnfo', N'3AymClqy', 3, 1, CAST(N'2021-01-24T00:00:00.000' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (149, N'AGGkzDeD', N'2d3js1Yy', 4, 1, CAST(N'2021-01-25T00:00:00.000' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (150, N'sKeWFQYg', N'fYphRkHb', 5, 1, CAST(N'2021-01-26T00:00:00.000' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (151, N'ASAnxgzd', N'vyfDeRdP', 6, 1, CAST(N'2021-01-27T00:00:00.000' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (152, N'vlsEONhA', N'9HKnRUVC', 1, 1, CAST(N'2021-01-28T00:00:00.000' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (153, N'TfSBPOrX', N'WRiL8L7c', 4, 1, CAST(N'2020-12-10T15:43:52.570' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (154, N'TfSBPOrX', N'WRiL8L7c', 4, 1, CAST(N'2020-12-17T11:17:14.520' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (155, N'TfSBPOrX', N'WRiL8L7c', 4, 1, CAST(N'2020-12-17T11:17:35.863' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (156, N'TfSBPOrX', N'WRiL8L7c', 4, 1, CAST(N'2020-12-17T15:45:22.930' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (157, N'QikCdknG', N'N6SVn4wN', 3, 1, CAST(N'2020-12-17T22:36:34.333' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (158, N'QikCdknG', N'N6SVn4wN', 2, 1, CAST(N'2020-12-17T23:49:48.007' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (159, N'1', N'1', 1, 1, CAST(N'2020-12-24T10:27:53.000' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (160, N'1111111111', N'111111111', 7, 1, CAST(N'2020-12-23T15:12:09.000' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (164, N'uk9999', N'uk9999', 1001, 1, CAST(N'2021-01-12T16:04:20.797' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (165, N'test00001', N'test00', 0, 1, CAST(N'2021-01-12T22:25:31.600' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (166, N'02', N'02', 6, 1, CAST(N'2021-01-14T01:47:55.597' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (167, N'03', N'03', 1, 1, CAST(N'2021-01-14T01:47:55.597' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (168, N'04', N'04', 4, 1, CAST(N'2021-01-14T01:47:55.597' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (169, N'05', N'05', 6, 1, CAST(N'2021-01-14T01:47:55.597' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (170, N'06', N'06', 1, 1, CAST(N'2021-01-14T01:47:55.597' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (171, N'07', N'07', 2, 1, CAST(N'2021-01-14T01:47:55.597' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (172, N'08', N'08', 3, 1, CAST(N'2021-01-14T01:47:55.597' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (173, N'09', N'09', 3, 1, CAST(N'2021-01-14T01:47:55.597' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (174, N'10', N'10', 5, 1, CAST(N'2021-01-14T01:47:55.597' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (175, N'11', N'11', 6, 1, CAST(N'2021-01-14T01:47:55.597' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (176, N'12', N'12', 3, 1, CAST(N'2021-01-14T01:47:55.597' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (177, N'13', N'13', 3, 1, CAST(N'2021-01-14T01:47:55.597' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (178, N'14', N'14', 4, 1, CAST(N'2021-01-14T01:47:55.597' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (179, N'15', N'15', 7, 1, CAST(N'2021-01-14T01:47:55.597' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (180, N'16', N'16', 6, 1, CAST(N'2021-01-14T01:47:55.597' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (181, N'17', N'17', 7, 1, CAST(N'2021-01-14T01:47:55.597' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (182, N'18', N'18', 1, 1, CAST(N'2021-01-14T01:47:55.597' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (183, N'19', N'19', 2, 1, CAST(N'2021-01-14T01:47:55.597' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (184, N'20', N'20', 3, 1, CAST(N'2021-01-14T01:47:55.597' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (185, N'21', N'21', 5, 1, CAST(N'2021-01-14T01:47:55.597' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (186, N'22', N'22', 3, 1, CAST(N'2021-01-14T01:47:55.597' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (187, N'23', N'23', 1, 1, CAST(N'2021-01-14T01:47:55.597' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (188, N'24', N'24', 7, 1, CAST(N'2021-01-14T01:47:55.597' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (189, N'25', N'25', 1, 1, CAST(N'2021-01-14T01:47:55.597' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (190, N'26', N'26', 3, 1, CAST(N'2021-01-14T01:47:55.597' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (191, N'27', N'27', 3, 1, CAST(N'2021-01-14T01:47:55.597' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (192, N'28', N'28', 6, 1, CAST(N'2021-01-14T01:47:55.597' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (193, N'29', N'29', 5, 1, CAST(N'2021-01-14T01:47:55.597' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (194, N'30', N'30', 5, 1, CAST(N'2021-01-14T01:47:55.597' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (195, N'31', N'31', 3, 1, CAST(N'2021-01-14T01:47:55.597' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (196, N'32', N'32', 5, 1, CAST(N'2021-01-14T01:47:55.597' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (197, N'33', N'33', 3, 1, CAST(N'2021-01-14T01:47:55.597' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (198, N'34', N'34', 4, 1, CAST(N'2021-01-14T01:47:55.597' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (199, N'35', N'35', 4, 1, CAST(N'2021-01-14T01:47:55.597' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (200, N'36', N'36', 3, 1, CAST(N'2021-01-14T01:47:55.597' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (201, N'37', N'37', 4, 1, CAST(N'2021-01-14T01:47:55.597' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (202, N'38', N'38', 4, 1, CAST(N'2021-01-14T01:47:55.597' AS DateTime))
GO
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (203, N'39', N'39', 6, 1, CAST(N'2021-01-14T01:47:55.597' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (204, N'40', N'40', 2, 1, CAST(N'2021-01-14T01:47:55.597' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (205, N'41', N'41', 2, 1, CAST(N'2021-01-14T01:47:55.597' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (206, N'42', N'42', 3, 1, CAST(N'2021-01-14T01:47:55.597' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (207, N'43', N'43', 5, 1, CAST(N'2021-01-14T01:47:55.597' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (208, N'44', N'44', 7, 1, CAST(N'2021-01-14T01:47:55.597' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (209, N'45', N'45', 1, 1, CAST(N'2021-01-14T01:47:55.597' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (210, N'46', N'46', 6, 1, CAST(N'2021-01-14T01:47:55.597' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (211, N'47', N'47', 7, 1, CAST(N'2021-01-14T01:47:55.597' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (212, N'48', N'48', 6, 1, CAST(N'2021-01-14T01:47:55.597' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (213, N'49', N'49', 2, 1, CAST(N'2021-01-14T01:47:55.597' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (214, N'50', N'50', 7, 1, CAST(N'2021-01-14T01:47:55.597' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (215, N'51', N'51', 7, 1, CAST(N'2021-01-14T01:47:55.597' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (216, N'52', N'52', 6, 1, CAST(N'2021-01-14T01:47:55.597' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (217, N'53', N'53', 3, 1, CAST(N'2021-01-14T01:47:55.597' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (218, N'54', N'54', 6, 1, CAST(N'2021-01-14T01:47:55.597' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (219, N'55', N'55', 3, 1, CAST(N'2021-01-14T01:47:55.597' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (220, N'56', N'56', 3, 1, CAST(N'2021-01-14T01:47:55.597' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (221, N'57', N'57', 3, 1, CAST(N'2021-01-14T01:47:55.597' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (222, N'58', N'58', 7, 1, CAST(N'2021-01-14T01:47:55.597' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (223, N'59', N'59', 6, 1, CAST(N'2021-01-14T01:47:55.597' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (224, N'60', N'60', 3, 1, CAST(N'2021-01-14T01:47:55.597' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (225, N'01', N'01', 5, 1, CAST(N'2021-01-14T01:48:34.443' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (226, N'lxxh', N'lxxh123666', 3, 0, CAST(N'2020-12-18T09:34:00.000' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (228, N'hahahahaha', N'8A910B910636A109E304AA540D800FED', 4, 1, CAST(N'2021-03-12T13:48:40.513' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (229, N'testoa', N'testoa', 1, 1, CAST(N'2021-07-11T09:53:31.030' AS DateTime))
INSERT [dbo].[Users] ([ID], [Account], [Password], [RoleID], [IsActive], [CreateDate]) VALUES (230, N'qqq', N'e3ceb5881a0a1fdaad01296d7554868d', 1, 1, CAST(N'2021-07-14T13:50:52.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Employee] ADD  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Menus] ADD  CONSTRAINT [DF_Menus_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Role] ADD  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF__Users__IsActive__117F9D94]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
/****** Object:  StoredProcedure [dbo].[p_Login]    Script Date: 2021/7/16 13:39:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[p_Login]
	@userName varchar(50),	--用户名
	@userPass varchar(50)	--密码
As
	Declare @getPass varchar(50) --声明密码，准备接受查询结果
	DECLARE @isActive VARCHAR(50) -- 接受用户状态
	
	Select @getPass = Password From Users Where Account = @userName
	if @getPass is not null	 --密码存在
	Begin
		if @getPass = @userPass  
		Begin
			--返回的判断消息
			--Select 1 As Result -- 登录成功 1
			--取回登录人员的信息
			Select @isActive = Users.IsActive From Users Where Account = @userName and Password = @userPass
			IF @isActive = 0
			BEGIN
				SELECT @isActive AS Result			-- 状态为停用 0
			END
			ELSE
			BEGIN
				SELECT Users.ID AS Result FROM Users WHERE Account = @userName and Password = @userPass 
			END
			--返回登录人员可以访问的Models编号	
		End
		Else  --密码错误
		Begin
			Select -2 As Result --密码错误 -2
		End
	End
	Else --密码不存在
	Begin
		Select -1 As Result  --用户名错误  -1
	End
GO
/****** Object:  StoredProcedure [dbo].[p_Repwd]    Script Date: 2021/7/16 13:39:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[p_Repwd]
	@useroldpwd VARCHAR(50), -- 用户旧密码
	@id INT,                 -- 修改用户密码的条件【ID】
	@usernewpwd VARCHAR(50) -- 新密码
AS
BEGIN
	DECLARE @s_userpwd VARCHAR(50)  --存储查询后的用户密码
	SELECT @s_userpwd = Users.Password FROM Users WHERE Users.ID = @id
	
	IF @s_userpwd = @useroldpwd  -- 判断输入密码和数据库中密码是否相同
		BEGIN
			UPDATE [dbo].[Users] SET [Password] = @usernewpwd WHERE [ID] = @id AND [Password] = @useroldpwd -- 执行修改密码
			SELECT 1 AS Result;  -- 返回修改状态  1修改密码成功
		END
	ELSE 
		BEGIN
			SELECT 0 AS Result;  -- 返回修改状态  0初始密码不正确
		END
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'员工编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employee', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'部门编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employee', @level2type=N'COLUMN',@level2name=N'DepartmentID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'员工姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employee', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'性别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employee', @level2type=N'COLUMN',@level2name=N'Sex'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生日' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employee', @level2type=N'COLUMN',@level2name=N'Birthday'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'身份证' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employee', @level2type=N'COLUMN',@level2name=N'IdCard'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'职位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employee', @level2type=N'COLUMN',@level2name=N'Position'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employee', @level2type=N'COLUMN',@level2name=N'Phone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'邮箱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employee', @level2type=N'COLUMN',@level2name=N'Email'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'民族' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employee', @level2type=N'COLUMN',@level2name=N'Nation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'政治面貌' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employee', @level2type=N'COLUMN',@level2name=N'Polity'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'学历' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employee', @level2type=N'COLUMN',@level2name=N'Degree'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'月薪' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employee', @level2type=N'COLUMN',@level2name=N'Salary'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'个人履历' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employee', @level2type=N'COLUMN',@level2name=N'Resume'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employee', @level2type=N'COLUMN',@level2name=N'Meno'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否在职' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Employee', @level2type=N'COLUMN',@level2name=N'Status'
GO
USE [master]
GO
ALTER DATABASE [Manpower ] SET  READ_WRITE 
GO
