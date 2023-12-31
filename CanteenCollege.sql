USE [CanteenCollege]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 3/8/2023 9:26:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL,
	[IsDeleted] [int] NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dishes]    Script Date: 3/8/2023 9:26:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dishes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Image] [nvarchar](max) NULL,
	[Price] [float] NULL,
	[CategoryID] [int] NULL,
	[Description] [nvarchar](max) NULL,
	[Status] [int] NULL,
	[StaffId] [int] NULL,
	[DateCreated] [date] NULL,
	[DateUpdate] [date] NULL,
	[DateDeleted] [date] NULL,
	[IsDeleted] [int] NULL,
 CONSTRAINT [PK_Food] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 3/8/2023 9:26:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[Status] [int] NULL,
	[OrderDate] [smalldatetime] NULL,
	[IsDeleted] [int] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 3/8/2023 9:26:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[OrderId] [int] NOT NULL,
	[DishId] [int] NOT NULL,
	[Quantity] [int] NULL,
 CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC,
	[DishId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payment]    Script Date: 3/8/2023 9:26:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[StaffId] [int] NULL,
	[OrderId] [int] NULL,
	[PaymentDate] [smalldatetime] NULL,
	[IsDeleted] [int] NULL,
 CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 3/8/2023 9:26:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL,
	[IsDeleted] [int] NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Staff]    Script Date: 3/8/2023 9:26:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staff](
	[StaffID] [int] IDENTITY(1,1) NOT NULL,
	[StaffName] [nvarchar](100) NULL,
	[DateOfBirth] [date] NULL,
	[Address] [nvarchar](max) NULL,
 CONSTRAINT [PK_Staff] PRIMARY KEY CLUSTERED 
(
	[StaffID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 3/8/2023 9:26:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](50) NULL,
	[Password] [nvarchar](100) NULL,
	[Phone] [nvarchar](50) NULL,
	[Email] [nvarchar](100) NULL,
	[RoleId] [int] NULL,
	[IsDeleted] [int] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([ID], [Name], [Description], [IsDeleted]) VALUES (1, N'Đồ ăn', N'Những thứ dùng để ăn', 0)
INSERT [dbo].[Categories] ([ID], [Name], [Description], [IsDeleted]) VALUES (2, N'Đồ uống', N'những thứ không phải để ăn', 0)
INSERT [dbo].[Categories] ([ID], [Name], [Description], [IsDeleted]) VALUES (3, N'Deserttttt', N'', 1)
INSERT [dbo].[Categories] ([ID], [Name], [Description], [IsDeleted]) VALUES (4, N'Tráng miệng', N'có thể là trái cây', 0)
INSERT [dbo].[Categories] ([ID], [Name], [Description], [IsDeleted]) VALUES (5, N'Foood2', N'string', 1)
INSERT [dbo].[Categories] ([ID], [Name], [Description], [IsDeleted]) VALUES (6, N'Đồ hộp', N'', 0)
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Dishes] ON 

INSERT [dbo].[Dishes] ([ID], [Name], [Image], [Price], [CategoryID], [Description], [Status], [StaffId], [DateCreated], [DateUpdate], [DateDeleted], [IsDeleted]) VALUES (1, N'Nước mía nguyên chất', N'2023-03-08_cbbe65ea-cd0d-4136-bde2-88609c2e62a0_nuoc-mia-tuoi-vietmart-sieu-thi-do-viet-tai-nhat.jpg', 15000, 2, N'nước làm từ cây mía', 1, 1, CAST(N'2023-06-03' AS Date), CAST(N'2023-08-03' AS Date), NULL, 0)
INSERT [dbo].[Dishes] ([ID], [Name], [Image], [Price], [CategoryID], [Description], [Status], [StaffId], [DateCreated], [DateUpdate], [DateDeleted], [IsDeleted]) VALUES (2, N'Cơm tấm', N'2023-03-08_bd075978-b1b0-41ac-8583-eef59069247c_0000tam-15618714177501610709254.jpg', 25000, 1, N'Cơm tấm với sườn nướng', 1, 1, CAST(N'2023-06-03' AS Date), CAST(N'2023-08-03' AS Date), NULL, 0)
INSERT [dbo].[Dishes] ([ID], [Name], [Image], [Price], [CategoryID], [Description], [Status], [StaffId], [DateCreated], [DateUpdate], [DateDeleted], [IsDeleted]) VALUES (3, N'Cơm chiên trứng', N'2023-03-08_2ca98926-02d4-462f-ab0f-4a260d1d824a_com-chien-trung-14780.jpg', 30000, 1, N'Cơm và trứng', 1, 1, CAST(N'2023-08-03' AS Date), NULL, NULL, 0)
INSERT [dbo].[Dishes] ([ID], [Name], [Image], [Price], [CategoryID], [Description], [Status], [StaffId], [DateCreated], [DateUpdate], [DateDeleted], [IsDeleted]) VALUES (4, N'Cơm bò xào', N'2023-03-08_1ee77626-15e9-44f8-a67a-0b8fcb6c3376_1-mon-ngon-836-1671087987799-16710879881451714818115.png', 35000, 1, N'Cơm và bò', 1, 1, CAST(N'2023-08-03' AS Date), CAST(N'2023-08-03' AS Date), NULL, 0)
INSERT [dbo].[Dishes] ([ID], [Name], [Image], [Price], [CategoryID], [Description], [Status], [StaffId], [DateCreated], [DateUpdate], [DateDeleted], [IsDeleted]) VALUES (5, N'Sinh tố dâu', N'2023-03-08_e8d6a626-64e5-4ad7-bf5d-073e3778ffc6_Giam-Mo.jpg', 25000, 2, N'Sinh tố làm từ dâu tây', 1, 1, CAST(N'2023-08-03' AS Date), NULL, NULL, 0)
INSERT [dbo].[Dishes] ([ID], [Name], [Image], [Price], [CategoryID], [Description], [Status], [StaffId], [DateCreated], [DateUpdate], [DateDeleted], [IsDeleted]) VALUES (6, N'Cơm dừa', N'2023-03-08_21fc5cfe-1b72-4aaf-8a12-fe18eb104304_di-doc-Viet-Nam-thuong-thuc-12-mon-com-ngon-tuyet-ivivu.jpg', 40000, 1, N'Cơm nấu được đặt trong quả dừa', 1, 1, CAST(N'2023-08-03' AS Date), NULL, NULL, 0)
INSERT [dbo].[Dishes] ([ID], [Name], [Image], [Price], [CategoryID], [Description], [Status], [StaffId], [DateCreated], [DateUpdate], [DateDeleted], [IsDeleted]) VALUES (7, N'Cơm lam', N'2023-03-08_f24441ca-741f-4544-b14d-94d0bf7bfcb0_com-lam7.png', 35000, 1, N'cơm trong ông tre', 1, 1, CAST(N'2023-08-03' AS Date), NULL, NULL, 0)
INSERT [dbo].[Dishes] ([ID], [Name], [Image], [Price], [CategoryID], [Description], [Status], [StaffId], [DateCreated], [DateUpdate], [DateDeleted], [IsDeleted]) VALUES (8, N'Sinh tố bơ', N'2023-03-08_92450cab-f363-4be0-ac5e-b3cfed127955_sinh-tố-bơ.jpg', 20000, 2, N'bơ bơ bơ', 1, 1, CAST(N'2023-08-03' AS Date), NULL, NULL, 0)
INSERT [dbo].[Dishes] ([ID], [Name], [Image], [Price], [CategoryID], [Description], [Status], [StaffId], [DateCreated], [DateUpdate], [DateDeleted], [IsDeleted]) VALUES (9, N'Sinh tố xoài', N'2023-03-08_b54d1b9a-f73b-4946-8d45-2bdd29690ac4_cach-lam-sinh-to-xoai-sua-dac.webp', 20000, 2, N'XOÀI', 1, 1, CAST(N'2023-08-03' AS Date), NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[Dishes] OFF
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([ID], [UserId], [Status], [OrderDate], [IsDeleted]) VALUES (1, 1, 1, CAST(N'2023-08-03T04:54:00' AS SmallDateTime), 0)
INSERT [dbo].[Order] ([ID], [UserId], [Status], [OrderDate], [IsDeleted]) VALUES (2, 1, 1, CAST(N'2023-08-03T05:25:00' AS SmallDateTime), 0)
INSERT [dbo].[Order] ([ID], [UserId], [Status], [OrderDate], [IsDeleted]) VALUES (3, 1, 0, CAST(N'2023-08-03T09:02:00' AS SmallDateTime), 0)
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
INSERT [dbo].[OrderDetail] ([OrderId], [DishId], [Quantity]) VALUES (1, 1, 1)
INSERT [dbo].[OrderDetail] ([OrderId], [DishId], [Quantity]) VALUES (1, 2, 1)
INSERT [dbo].[OrderDetail] ([OrderId], [DishId], [Quantity]) VALUES (2, 1, 4)
INSERT [dbo].[OrderDetail] ([OrderId], [DishId], [Quantity]) VALUES (2, 2, 3)
INSERT [dbo].[OrderDetail] ([OrderId], [DishId], [Quantity]) VALUES (3, 6, 4)
INSERT [dbo].[OrderDetail] ([OrderId], [DishId], [Quantity]) VALUES (3, 8, 2)
GO
SET IDENTITY_INSERT [dbo].[Payment] ON 

INSERT [dbo].[Payment] ([ID], [StaffId], [OrderId], [PaymentDate], [IsDeleted]) VALUES (1, 1, 1, CAST(N'2023-08-03T05:18:00' AS SmallDateTime), 0)
INSERT [dbo].[Payment] ([ID], [StaffId], [OrderId], [PaymentDate], [IsDeleted]) VALUES (2, 1, 2, CAST(N'2023-08-03T05:26:00' AS SmallDateTime), 0)
SET IDENTITY_INSERT [dbo].[Payment] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([ID], [Name], [Description], [IsDeleted]) VALUES (1, N'Admin', NULL, 0)
INSERT [dbo].[Role] ([ID], [Name], [Description], [IsDeleted]) VALUES (2, N'Guest', N'string', 0)
INSERT [dbo].[Role] ([ID], [Name], [Description], [IsDeleted]) VALUES (3, N'Chef', N'string', 0)
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([ID], [Login], [Password], [Phone], [Email], [RoleId], [IsDeleted]) VALUES (1, N'sa', N'123', N'0866153642', N'tuananhxvt@gmail.com', 1, 0)
INSERT [dbo].[Users] ([ID], [Login], [Password], [Phone], [Email], [RoleId], [IsDeleted]) VALUES (2, N'user1', N'123', N'123779821', N'string', 2, 0)
INSERT [dbo].[Users] ([ID], [Login], [Password], [Phone], [Email], [RoleId], [IsDeleted]) VALUES (7, N'user2', N'123', N'01235123151', N'tuananhxvt@gmail.com', 2, 1)
INSERT [dbo].[Users] ([ID], [Login], [Password], [Phone], [Email], [RoleId], [IsDeleted]) VALUES (8, N'user2', N'123', N'01235123151', N'user1@gmail.com', 2, 0)
INSERT [dbo].[Users] ([ID], [Login], [Password], [Phone], [Email], [RoleId], [IsDeleted]) VALUES (11, N'user3', N'123', N'01235123151', N'abc123@gmail.com', 1, 0)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Categories] ADD  CONSTRAINT [DF_Categories_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Dishes] ADD  CONSTRAINT [DF_FoodAndDrink_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Order] ADD  CONSTRAINT [DF_Order_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Payment] ADD  CONSTRAINT [DF_Payment_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Role] ADD  CONSTRAINT [DF_Role_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_User_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Dishes]  WITH CHECK ADD  CONSTRAINT [FK_Dishes_Categories] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Categories] ([ID])
GO
ALTER TABLE [dbo].[Dishes] CHECK CONSTRAINT [FK_Dishes_Categories]
GO
ALTER TABLE [dbo].[Dishes]  WITH CHECK ADD  CONSTRAINT [FK_Dishes_Users] FOREIGN KEY([StaffId])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[Dishes] CHECK CONSTRAINT [FK_Dishes_Users]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Users]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Dishes] FOREIGN KEY([DishId])
REFERENCES [dbo].[Dishes] ([ID])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Dishes]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Order1] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([ID])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Order1]
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_Order] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([ID])
GO
ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_Payment_Order]
GO
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_Users] FOREIGN KEY([StaffId])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_Payment_Users]
GO
ALTER TABLE [dbo].[Staff]  WITH CHECK ADD  CONSTRAINT [FK_Staff_Users] FOREIGN KEY([StaffID])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[Staff] CHECK CONSTRAINT [FK_Staff_Users]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([ID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Role]
GO
/****** Object:  StoredProcedure [dbo].[Categories_Create]    Script Date: 3/8/2023 9:26:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Categories_Create]
	@Name NVARCHAR(MAX),
	@Description NVARCHAR(MAX)
	AS
BEGIN 
	INSERT INTO Categories
				(Name,
				Description, 
				IsDeleted)
	VALUES
				(@Name,
				@Description,
				0)
END
GO
/****** Object:  StoredProcedure [dbo].[Categories_Delete]    Script Date: 3/8/2023 9:26:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[Categories_Delete]
	@Id INt
	AS
BEGIN 
	UPDATE Categories
	SET
		IsDeleted = 1
	WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[Categories_GetById]    Script Date: 3/8/2023 9:26:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Categories_GetById]
	@Id INt
AS
BEGIN 
	SELECT 
		[Id],
		[Name],
		[Description]
	FROM [Categories]
	WHERE IsDeleted=0 AND Id =@Id
END
GO
/****** Object:  StoredProcedure [dbo].[Categories_List]    Script Date: 3/8/2023 9:26:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Categories_List]
AS
BEGIN 
	SELECT 
		[Id],
		[Name],
		[Description]
	FROM [Categories]
	WHERE IsDeleted=0
	Order BY Id DESC
END
GO
/****** Object:  StoredProcedure [dbo].[Categories_Update]    Script Date: 3/8/2023 9:26:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Categories_Update]
	@Id INt,
	@Name NVARCHAR(MAX),
	@Description NVARCHAR(MAX)
	AS
BEGIN 
	UPDATE Categories
	SET
		[Name] = @Name,
		[Description] = @Description
	WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[Dishes_Create]    Script Date: 3/8/2023 9:26:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Dishes_Create]
	@Name NVARCHAR(MAX),
	@Image NVARCHAR(MAX),
	@Price Int,
	@CategoryID Int,
	@Description NVARCHAR(MAX),
	@Status Int,
	@StaffId Int =1
	AS
BEGIN 
	INSERT INTO Dishes
				([Name]
				,[Image]
				,[Price]
				,[CategoryID]
				,[Description]
				,[Status]
				,[StaffId]
				,[DateCreated]
				,[IsDeleted])
	VALUES
				(@Name,
				@Image,
				@Price,
				@CategoryID,
				@Description,
				@Status,
				@StaffId,
				FORMAT(GETDATE(),'dd/MM/yyyy hh:mm:ss'),
				0)
END
GO
/****** Object:  StoredProcedure [dbo].[Dishes_Delete]    Script Date: 3/8/2023 9:26:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Dishes_Delete]
	@Id INt
	AS
BEGIN 
	UPDATE Dishes
	SET
		IsDeleted = 1,
		DateDeleted = FORMAT(GETDATE(),'dd/MM/yyyy hh:mm:ss')
	WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[Dishes_GetById]    Script Date: 3/8/2023 9:26:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Dishes_GetById]
	@Id INt
AS
BEGIN 
	SELECT 
			[ID]
		  ,[Name]
		  ,[Image]
		  ,[Price]
		  ,[CategoryID]
		  ,[Description]
		  ,[Status]
		  ,[StaffId]
	FROM Dishes
	WHERE IsDeleted=0 AND Id =@Id
END
GO
/****** Object:  StoredProcedure [dbo].[Dishes_List]    Script Date: 3/8/2023 9:26:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Dishes_List]
AS
BEGIN 
	SELECT 
		[ID]
		  ,[Name]
		  ,[Image]
		  ,[Price]
		  ,[CategoryID]
		  ,[Description]
		  ,[Status]
		  ,[StaffId]
	FROM Dishes
	WHERE IsDeleted=0
	Order BY Id DESC
END
GO
/****** Object:  StoredProcedure [dbo].[Dishes_ListInStock]    Script Date: 3/8/2023 9:26:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Dishes_ListInStock]
AS
BEGIN 
	SELECT 
		[ID]
		  ,[Name]
		  ,[Image]
		  ,[Price]
		  ,[CategoryID]
		  ,[Description]
		  ,[Status]
		  ,[StaffId]
	FROM Dishes
	WHERE IsDeleted=0 AND STATUS = 1 
	Order BY Id DESC
END
GO
/****** Object:  StoredProcedure [dbo].[Dishes_Update]    Script Date: 3/8/2023 9:26:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Dishes_Update]
	@Id INt,
	@Name NVARCHAR(MAX),
	@Image NVARCHAR(MAX),
	@Price Int,
	@CategoryID Int,
	@Description NVARCHAR(MAX),
	@Status Int,
	@StaffId Int
	AS
BEGIN 
	UPDATE Dishes
	SET
		[Name] = @Name,
		[Image] = @Image,
		[Price] = @Price,
		[CategoryID] = @CategoryID,
		[Description] = @Description,
		[Status] = @Status,
		[StaffId] = @StaffId,
		[DateUpdate] = FORMAT(GETDATE(),'dd/MM/yyyy hh:mm:ss')
	WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[Order_Create]    Script Date: 3/8/2023 9:26:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Order_Create]
	@UserId NVARCHAR(MAX)
	AS
BEGIN 
	INSERT INTO [Order]
				(UserId,
				Status,
				OrderDate,
				IsDeleted)
	VALUES
				(@UserId,
				0,
				FORMAT(GETDATE(),'dd/MM/yyyy hh:mm:ss'),
				0)
	SELECT SCOPE_IDENTITY();
END
GO
/****** Object:  StoredProcedure [dbo].[Order_Delete]    Script Date: 3/8/2023 9:26:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Order_Delete]
	@Id INt
	AS
BEGIN 
	UPDATE [Order]
	SET
		IsDeleted = 1
	WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[Order_GetById]    Script Date: 3/8/2023 9:26:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Order_GetById]
	@Id INt
AS
BEGIN 
	SELECT 
		o.Id
      ,o.UserId
	  ,u.Login as LoginName
      ,[Status]
      ,[OrderDate]
	FROM [Order] o
	LEFT JOIN Users u ON u.Id = o.UserId
	WHERE o.IsDeleted=0 AND o.Id =@Id
END
GO
/****** Object:  StoredProcedure [dbo].[Order_GrandTotalByOrderId]    Script Date: 3/8/2023 9:26:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Order_GrandTotalByOrderId]
	@OrderId Int
AS
BEGIN select SUM(Price*Quantity) as GrandTotal
FROM OrderDetail od
	INNER JOIN [Order] o ON o.Id = od.OrderID
	INNER JOIN Dishes d ON d.Id = od.DishId
WHERE o.IsDeleted=0
	AND d.IsDeleted = 0 AND o.Id = @OrderId
END
GO
/****** Object:  StoredProcedure [dbo].[Order_List]    Script Date: 3/8/2023 9:26:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Order_List]
	@UserId NVARCHAR(MAX) = NULL
AS
BEGIN 
	SELECT 
		o.Id
      ,o.UserId
	  ,u.Login as LoginName
	  ,[Status]
      ,[OrderDate]
	FROM [Order] o
	INNER JOIN Users u ON u.Id = o.UserId
	WHERE o.IsDeleted=0
	AND(@UserId IS NULL OR @UserId = o.UserId)
	Order BY [OrderDate] DESC
END
GO
/****** Object:  StoredProcedure [dbo].[Order_Update]    Script Date: 3/8/2023 9:26:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Order_Update]
	@Id INt,
	@Status INT
	AS
BEGIN 
	UPDATE [Order]
	SET
		Status = @Status
	WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[OrderDetail_Create]    Script Date: 3/8/2023 9:26:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[OrderDetail_Create]
	@OrderId INT,
	@DishId INT,
	@Quantity FLOAT
	AS
BEGIN 
	INSERT INTO OrderDetail
				(OrderId,
				DishId,
				Quantity)
	VALUES
				(@OrderId,
				@DishId,
				@Quantity)
END
GO
/****** Object:  StoredProcedure [dbo].[OrderDetail_GetByOrderId]    Script Date: 3/8/2023 9:26:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[OrderDetail_GetByOrderId]
	@OrderID INt
AS
BEGIN 
	SELECT 
		[OrderID]
      ,[DishID]
	  ,d.Name as DishName
	  ,d.Image as Image
	  ,c.Name as CategoryName
	  ,d.Price as Price
      ,[Quantity]
	FROM OrderDetail od
	INNER JOIN [Order] o ON o.Id = od.OrderID
	INNER JOIN Dishes d ON d.Id = od.DishID
	INNER JOIN Categories c ON c.Id = d.CategoryId
	WHERE o.IsDeleted=0 
	AND d.IsDeleted = 0 ANd c.IsDeleted = 0
	AND [OrderID] = @OrderID
END
GO
/****** Object:  StoredProcedure [dbo].[OrderDetail_List]    Script Date: 3/8/2023 9:26:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[OrderDetail_List]
AS
BEGIN 
	SELECT 
		[OrderID]
      , DishId
	  ,d.Name as DishName
      ,[Quantity]
	FROM OrderDetail od
	INNER JOIN [Order] o ON o.Id = od.OrderID
	INNER JOIN Dishes d ON d.Id = od.DishID
	WHERE o.IsDeleted=0 
END
GO
/****** Object:  StoredProcedure [dbo].[OrderDetail_Update]    Script Date: 3/8/2023 9:26:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[OrderDetail_Update]
	@OrderId INT,
	@DishId INT,
	@Quantity FLOAT
	AS
BEGIN 
	UPDATE OrderDetail
	SET
		Quantity = @Quantity 
	WHERE OrderId = @OrderId AND DishId = @DishId
END
GO
/****** Object:  StoredProcedure [dbo].[Payment_Create]    Script Date: 3/8/2023 9:26:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Payment_Create]
	@StaffId Int,
	@OrderId Int
	AS
BEGIN 
	INSERT INTO Payment
				([StaffId]
				  ,[OrderId]
				  ,[PaymentDate]
				  ,[IsDeleted])
	VALUES
				(@StaffId,
				@OrderId,
				FORMAT(GETDATE(),'dd/MM/yyyy hh:mm:ss'),
				0)
END
GO
/****** Object:  StoredProcedure [dbo].[Payment_Delete]    Script Date: 3/8/2023 9:26:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Payment_Delete]
	@Id INt
	AS
BEGIN 
	UPDATE Payment
	SET
		IsDeleted = 1
	WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[Payment_GetById]    Script Date: 3/8/2023 9:26:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Payment_GetById]
	@Id INt
AS
BEGIN 
	SELECT 
		[ID]
      ,[StaffId]
      ,[OrderId]
      ,[PaymentDate]
	FROM Payment
	WHERE IsDeleted=0 AND Id =@Id
END
GO
/****** Object:  StoredProcedure [dbo].[Payment_List]    Script Date: 3/8/2023 9:26:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Payment_List]
AS
BEGIN 
	SELECT 
		[ID]
      ,[StaffId]
      ,[OrderId]
      ,[PaymentDate]
	FROM Payment
	WHERE IsDeleted=0
	Order BY Id DESC
END
GO
/****** Object:  StoredProcedure [dbo].[Role_Create]    Script Date: 3/8/2023 9:26:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Role_Create]
	@Name NVARCHAR(MAX),
	@Description NVARCHAR(MAX)
	AS
BEGIN 
	INSERT INTO [Role]
				(Name,
				Description, 
				IsDeleted)
	VALUES
				(@Name,
				@Description,
				0)
END
GO
/****** Object:  StoredProcedure [dbo].[Role_Delete]    Script Date: 3/8/2023 9:26:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Role_Delete]
	@Id INt
	AS
BEGIN 
	UPDATE Role
	SET
		IsDeleted = 1
	WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[Role_GetById]    Script Date: 3/8/2023 9:26:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Role_GetById]
	@Id INt
AS
BEGIN 
	SELECT 
		[Id],
		[Name],
		[Description]
	FROM [Role]
	WHERE IsDeleted=0 AND Id =@Id
END
GO
/****** Object:  StoredProcedure [dbo].[Role_List]    Script Date: 3/8/2023 9:26:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Role_List]
AS
BEGIN 
	SELECT 
		[Id],
		[Name],
		[Description]
	FROM [Role]
	WHERE IsDeleted=0
	Order BY Id DESC
END
GO
/****** Object:  StoredProcedure [dbo].[Role_Update]    Script Date: 3/8/2023 9:26:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Role_Update]
	@Id INt,
	@Name NVARCHAR(MAX),
	@Description NVARCHAR(MAX)
	AS
BEGIN 
	UPDATE [Role]
	SET
		[Name] = @Name,
		[Description] = @Description
	WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[Users_Create]    Script Date: 3/8/2023 9:26:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Users_Create]
	@Login NVARCHAR(MAX),
	@Password NVARCHAR(MAX),
	@Phone NVARCHAR(MAX),
	@Email NVARCHAR(MAX),
	@RoleId Int
	AS
BEGIN 
	INSERT INTO Users
				([Login]
				  ,[Password]
				  ,[Phone]
				  ,[Email]
				  ,[RoleId]
				  ,[IsDeleted])
	VALUES
				(@Login,
				@Password,
				@Phone,
				@Email,
				@RoleId,
				0)
END
GO
/****** Object:  StoredProcedure [dbo].[USers_Delete]    Script Date: 3/8/2023 9:26:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USers_Delete]
	@Id INt
	AS
BEGIN 
	UPDATE USers
	SET
		IsDeleted = 1
	WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[USers_GetById]    Script Date: 3/8/2023 9:26:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USers_GetById]
	@Id INt
AS
BEGIN 
	SELECT 
			[ID]
		  ,[Login]
		  ,[Password]
		  ,[Phone]
		  ,[Email]
		  ,[RoleId]
	FROM USers
	WHERE IsDeleted=0 AND Id =@Id
END
GO
/****** Object:  StoredProcedure [dbo].[USers_GetByLoginAndPass]    Script Date: 3/8/2023 9:26:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[USers_GetByLoginAndPass]
	@Login NVARCHAR(MAX),
	@Password NVARCHAR(MAX)
AS
BEGIN 
	SELECT 
			[ID]
		  ,[Login]
		  ,[Password]
		  ,[Phone]
		  ,[Email]
		  ,[RoleId]
	FROM USers
	WHERE IsDeleted=0 AND Login = @Login AND Password =@Password
END
GO
/****** Object:  StoredProcedure [dbo].[Users_List]    Script Date: 3/8/2023 9:26:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Users_List]
AS
BEGIN 
	SELECT 
		[ID]
      ,[Login]
      ,[Password]
      ,[Phone]
      ,[Email]
      ,[RoleId]
	FROM Users
	WHERE IsDeleted=0
	Order BY Id DESC
END
GO
/****** Object:  StoredProcedure [dbo].[Users_Update]    Script Date: 3/8/2023 9:26:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Users_Update]
	@Id INt,
	@Login NVARCHAR(MAX),
	@Password NVARCHAR(MAX),
	@Phone NVARCHAR(MAX),
	@Email NVARCHAR(MAX),
	@RoleId Int
	AS
BEGIN 
	UPDATE Users
	SET
		[Login] = @Login,
		[Password] = @Password,
		[Phone] = @Phone,
		[Email] = @Email,
		[RoleId] = @RoleId
	WHERE Id = @Id
END
GO
