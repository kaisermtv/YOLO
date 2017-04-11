CREATE TABLE tblAcctGroup(
	ID			INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	NAME		NVARCHAR(256) NOT NULL UNIQUE,
	DESCRIBE	NVARCHAR(50) NULL,
	
	NSTATUS		INT NOT NULL DEFAULT(0),
	EDITTIME	DATETIME NULL,
	EDITUSER	INT NULL,
	CREATETIME	DATETIME DEFAULT(GETDATE()) -- Ngày khởi tạo
);

INSERT INTO tblAcctGroup(NAME,DESCRIBE) VALUES (N'Admin',N'Quản trị viên');
INSERT INTO tblAcctGroup(NAME,DESCRIBE) VALUES (N'User',N'Thành viên');

CREATE TABLE tblAccount(
	ACCT_ID			INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	ACCT_NAME		NVARCHAR(30) NOT NULL UNIQUE,
	ACCT_PASS		NVARCHAR(50) NOT NULL,
	
	NSTATUS		INT NOT NULL DEFAULT(0),	
	ACCT_GROUP		INT NULL FOREIGN KEY REFERENCES dbo.tblAcctGroup(ID),
	ACCT_CREATE		DATETIME DEFAULT(GETDATE()) -- Ngày khởi tạo
);

INSERT INTO tblAccount(ACCT_NAME,ACCT_PASS,ACCT_GROUP) VALUES ('kaisermtv','123123',1);
INSERT INTO tblAccount(ACCT_NAME,ACCT_PASS,ACCT_GROUP) VALUES ('admin','123',1);

CREATE TABLE tblAccountInfo(
	ACCT_ID			INT PRIMARY KEY NOT NULL FOREIGN KEY REFERENCES dbo.tblAccount(ACCT_ID),
	FULLNAME		NVARCHAR(50) NOT NULL,
	AGE				DATETIME NULL,
	SEX				BIT NULL,
	EMAIL			NVARCHAR(50) NULL,
		
	ACCT_CREATE		DATETIME DEFAULT(GETDATE()) -- Ngày khởi tạo
);


CREATE TABLE tblSetting(
	STKEY			NVARCHAR(30) PRIMARY KEY NOT NULL,
	VALUE			NTEXT NULL
)


CREATE TABLE tblRemember(
	RMKEY			NVARCHAR(50) PRIMARY KEY NOT NULL DEFAULT NEWID(),
	USERID			INT NOT NULL,
	PASS			NVARCHAR(50) NOT NULL,
	LGROUP			INT NOT NULL DEFAULT(0),

	LOGINDATE		DATETIME DEFAULT(GETDATE()),
	ONLINEDATE		DATETIME DEFAULT(GETDATE()),
	CREATEDATE		DATETIME DEFAULT(GETDATE())
)

CREATE TABLE tblCategory(
	ID			INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	NAME		NVARCHAR(256) NULL,
	[DESCRIBE]	NTEXT NULL,
	LINK		NVARCHAR(256),
	CREATEDATE		DATETIME DEFAULT(GETDATE())
)

CREATE TABLE tblStatus(
	ID			INT PRIMARY KEY NOT NULL IDENTITY(0,1),
	NAME		NVARCHAR(256) NULL,
	[DESCRIBE]	NTEXT NULL,

	CREATEDATE		DATETIME DEFAULT(GETDATE())
)

INSERT INTO tblStatus(NAME,[DESCRIBE]) VALUES (N'-/-',N'Chờ xử lý');
INSERT INTO tblStatus(NAME,[DESCRIBE]) VALUES (N'Kích hoạt',N'Được chia sẻ');
INSERT INTO tblStatus(NAME,[DESCRIBE]) VALUES (N'Lưu trữ',N'Đã xóa, nhưng chưa chả khỏi sql');
