CREATE TABLE dbo.tblAcctGroup(
	ID			INT PRIMARY KEY NOT NULL IDENTITY(0,1),
	NAME		NVARCHAR(256) NOT NULL UNIQUE,
	DESCRIBE	NVARCHAR(50) NULL,
	
	NSTATUS		INT NOT NULL DEFAULT(0) FOREIGN KEY REFERENCES dbo.tblStatus(ID),
	EDITTIME	DATETIME NULL,
	EDITUSER	INT NULL,
	CREATETIME	DATETIME DEFAULT(GETDATE()) -- Ngày khởi tạo
);

INSERT INTO dbo.tblAcctGroup(NAME,DESCRIBE) VALUES (N'Register',N'Mới đăng ký, chờ duyệt');
INSERT INTO dbo.tblAcctGroup(NAME,DESCRIBE) VALUES (N'Admin',N'Quản trị viên');
INSERT INTO dbo.tblAcctGroup(NAME,DESCRIBE) VALUES (N'User',N'Thành viên');

CREATE TABLE dbo.tblAccount(
	ACCT_ID			INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	ACCT_NAME		NVARCHAR(30) NOT NULL UNIQUE,
	ACCT_PASS		NVARCHAR(50) NOT NULL,
	
	NSTATUS			INT NOT NULL DEFAULT(0) FOREIGN KEY REFERENCES dbo.tblStatus(ID),	
	ACCT_GROUP		INT NULL FOREIGN KEY REFERENCES dbo.tblAcctGroup(ID),
	ACCT_CREATE		DATETIME DEFAULT(GETDATE()) -- Ngày khởi tạo
);

INSERT INTO dbo.tblAccount(ACCT_NAME,ACCT_PASS,ACCT_GROUP) VALUES ('kaisermtv','123123',1);
INSERT INTO dbo.tblAccount(ACCT_NAME,ACCT_PASS,ACCT_GROUP) VALUES ('admin','123',1);

CREATE TABLE dbo.tblAccountInfo(
	ACCT_ID			INT PRIMARY KEY NOT NULL FOREIGN KEY REFERENCES dbo.tblAccount(ACCT_ID),
	FULLNAME		NVARCHAR(50) NOT NULL,
	AGE				DATETIME NULL,
	SEX				BIT NULL,
	EMAIL			NVARCHAR(50) NULL,
	PHONE			VARCHAR(20) NULL,
		
	ACCT_CREATE		DATETIME DEFAULT(GETDATE()) -- Ngày khởi tạo
);


CREATE TABLE dbo.tblSetting(
	STKEY			NVARCHAR(30) PRIMARY KEY NOT NULL,
	VALUE			NTEXT NULL
)


CREATE TABLE dbo.tblRemember(
	RMKEY			NVARCHAR(50) PRIMARY KEY NOT NULL DEFAULT NEWID(),
	USERID			INT NOT NULL,
	PASS			NVARCHAR(50) NOT NULL,
	LGROUP			INT NOT NULL DEFAULT(0),
	REMEMBER		BIT NOT NULL DEFAULT(0),

	LOGINDATE		DATETIME DEFAULT(GETDATE()),
	ONLINEDATE		DATETIME DEFAULT(GETDATE()),
	CREATEDATE		DATETIME DEFAULT(GETDATE())
)

CREATE TABLE dbo.tblCategory(
	ID			INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	NAME		NVARCHAR(256) NULL,
	[DESCRIBE]	NTEXT NULL,
	LINK		NVARCHAR(256),
	CREATEDATE		DATETIME DEFAULT(GETDATE())
)

CREATE TABLE dbo.tblStatus(
	ID			INT PRIMARY KEY NOT NULL IDENTITY(0,1),
	NAME		NVARCHAR(256) NULL,
	[DESCRIBE]	NTEXT NULL,

	CREATEDATE		DATETIME DEFAULT(GETDATE())
)

INSERT INTO dbo.tblStatus(NAME,[DESCRIBE]) VALUES (N'-/-',N'Chờ xử lý');
INSERT INTO dbo.tblStatus(NAME,[DESCRIBE]) VALUES (N'Kích hoạt',N'Được chia sẻ');
INSERT INTO dbo.tblStatus(NAME,[DESCRIBE]) VALUES (N'Lưu trữ',N'Đã xóa, nhưng chưa chả khỏi sql');
INSERT INTO dbo.tblStatus(NAME,[DESCRIBE]) VALUES (N'Ẩn danh mục',N'Sẽ không hiển thị trong danh mục');

CREATE TABLE dbo.tblMenu(
	ID INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	MenuID INT NOT NULL DEFAULT(1),

	NAME NVARCHAR(256) NOT NULL,
	[DESCRIBE]	NTEXT NULL,

	NTYPE INT NULL,
	LINK NVARCHAR(512) NULL,

	IORDER INT NULL,
	
	PID INT NULL FOREIGN KEY REFERENCES dbo.tblMenu(ID),
	CREATEDATE		DATETIME DEFAULT(GETDATE())
);

CREATE TABLE dbo.tblSlider(
	ID INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	TITLE NVARCHAR(256) NOT NULL,
	[DESCRIBE]	NTEXT NULL,

	NTYPE INT NOT NULL DEFAULT(1),
	LINK NVARCHAR(512) NULL,
	IMG NVARCHAR(512) null,

	IORDER INT NULL,
		
	CREATEDATE		DATETIME DEFAULT(GETDATE())
);

CREATE TABLE dbo.tblNewsGroup(
	ID			INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	NAME		NVARCHAR(256) NOT NULL UNIQUE,
	DESCRIBE	NVARCHAR(50) NULL,
	
	NSTATUS		INT NOT NULL DEFAULT(0) FOREIGN KEY REFERENCES dbo.tblStatus(ID),
	EDITTIME	DATETIME NULL,
	EDITUSER	INT NULL,
	CREATETIME	DATETIME DEFAULT(GETDATE()) -- Ngày khởi tạo
);

CREATE TABLE [dbo].[tblNews](
	[Id] INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[CatId] INT NULL FOREIGN KEY REFERENCES dbo.tblNewsGroup(ID),
	[Title] NVARCHAR(500) NULL,
	[ShortContent] NVARCHAR(1500) NULL,
	[Content] NTEXT NULL,
	[ImgUrl] NVARCHAR(250) NULL,
	NoiBat BIT NOT NULL DEFAULT(0),
	tag	NVARCHAR(512) NULL,

	NSTATUS		INT NOT NULL DEFAULT(0) FOREIGN KEY REFERENCES dbo.tblStatus(ID),
	[DayPost] DATETIME NULL DEFAULT(GETDATE()),
	[DayEdit] DATETIME NULL,
	[UserPost] INT  NULL FOREIGN KEY REFERENCES dbo.tblAccount(ACCT_ID),
	[UserEdit] INT NULL FOREIGN KEY REFERENCES dbo.tblAccount(ACCT_ID),
	[Author] NVARCHAR(150) NULL,
);

CREATE TABLE [dbo].[tblContact](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[FullName] [nvarchar](250) NULL,
	[Email] [nvarchar](250) NULL,
	[Title] [nvarchar](250) NULL,
	[Question] [nvarchar](500) NULL,
	[Answer] [ntext] NULL,
	NSTATUS		INT NOT NULL DEFAULT(0) FOREIGN KEY REFERENCES dbo.tblStatus(ID),
	[DayPost] [datetime] NULL  DEFAULT (getdate()),
	[DayAnswer] [datetime] NULL,
	[UserAnswer] [nvarchar](250) NULL
);

CREATE TABLE dbo.tblQuestion(
	ID			INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	Question	NVARCHAR(512) NOT NULL,
	DESCRIBE	NTEXT NULL,

	NSTATUS		INT NOT NULL DEFAULT(0) FOREIGN KEY REFERENCES dbo.tblStatus(ID),
	IORDER		INT NULL,

	EDITUSER	INT NULL FOREIGN KEY REFERENCES dbo.tblAccount(ACCT_ID),
	EDITTIME	DATETIME NULL,

	CREATEUSER	INT NULL FOREIGN KEY REFERENCES dbo.tblAccount(ACCT_ID),
	CREATETIME	DATETIME DEFAULT(GETDATE()) -- Ngày khởi tạo
);

CREATE TABLE dbo.tblAnswer(
	ID			INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	QuestionID	INT NOT NULL FOREIGN KEY REFERENCES dbo.tblQuestion(ID),

	[Content]	NTEXT NULL,

	IORDER		INT NULL,

	CREATETIME	DATETIME DEFAULT(GETDATE()) -- Ngày khởi tạo
);

CREATE TABLE dbo.tblAnswerResult(
	ID			INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	QuestionID	INT NOT NULL FOREIGN KEY REFERENCES dbo.tblQuestion(ID),
	AnswerID	INT NULL FOREIGN KEY REFERENCES dbo.tblAnswer(ID),

	USERID	INT NULL FOREIGN KEY REFERENCES dbo.tblAccount(ACCT_ID),
	CREATETIME	DATETIME DEFAULT(GETDATE()) -- Ngày khởi tạo
); 

CREATE  TABLE dbo.tblFacebookPost (
			PostPhotoId int identity(1,1)  not null primary key,
			id char(100) ,
			message nvarchar(max) ,
			full_picture char(450) ,
			picture char(450) ,
			link char(500),
			created_time char(30) ,
			comments nvarchar(30),
			likes nvarchar(10),
			 time_sync datetime default getdate()  ,
			 state int default 1,
			 ) ; 
--/* SEO Optimization */
----CREATE   PROCEDURE GetSiteMapContent
----	-- Tạo mới procedure tạo các dữ liệu để seo---
----AS
----BEGIN

----	SET NOCOUNT ON;

--SELECT TOP 100  create_time FROM tblFacebookPost ORDER BY id DESC
--SELECT id,tblFacebookPost.link  FROM tblFacebookPost ORDER BY create_time DESC

--END

/*Tạo riêng bảng đặc biệt dành cho cuộc thi Yolo Damchiase */

CREATE TABLE [dbo].[tblFacebookPhotoPost](
	[PostPhotoId] [int] IDENTITY(1,1) NOT NULL,
	[id] [char](100) NULL,
	[name] [nvarchar](max) NULL,
	[user_name] nvarchar(100),
	[user_address] nvarchar(100),
	[user_birthday] nvarchar(100),
	[picture] [char](450) NULL,
	[link] [char](500) NULL,
	[comments] [nvarchar](30) NULL,
	[likes] [nvarchar](10) NULL,
	[create_time] [nvarchar](30) NULL,
	[time_sync] [datetime] NULL DEFAULT (getdate()),
	[state] [int] NULL DEFAULT ((1)),
PRIMARY KEY  
(
	[PostPhotoId] )
	)

