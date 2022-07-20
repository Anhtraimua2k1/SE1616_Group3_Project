USE [master]
GO
/****** Object:  Database [BakingIngredients]    Script Date: 7/21/2022 1:24:26 AM ******/
CREATE DATABASE [BakingIngredients]
 
GO
ALTER DATABASE [BakingIngredients] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BakingIngredients].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BakingIngredients] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BakingIngredients] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BakingIngredients] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BakingIngredients] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BakingIngredients] SET ARITHABORT OFF 
GO
ALTER DATABASE [BakingIngredients] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [BakingIngredients] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BakingIngredients] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BakingIngredients] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BakingIngredients] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BakingIngredients] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BakingIngredients] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BakingIngredients] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BakingIngredients] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BakingIngredients] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BakingIngredients] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BakingIngredients] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BakingIngredients] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BakingIngredients] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BakingIngredients] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BakingIngredients] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BakingIngredients] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BakingIngredients] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BakingIngredients] SET  MULTI_USER 
GO
ALTER DATABASE [BakingIngredients] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BakingIngredients] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BakingIngredients] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BakingIngredients] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BakingIngredients] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BakingIngredients] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [BakingIngredients] SET QUERY_STORE = OFF
GO
USE [BakingIngredients]
GO
/****** Object:  Table [dbo].[blog]    Script Date: 7/21/2022 1:24:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[blog](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](300) NOT NULL,
	[detail] [ntext] NOT NULL,
	[photo_link] [ntext] NOT NULL,
	[enable_status] [bit] NULL,
	[owner] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cart_item]    Script Date: 7/21/2022 1:24:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cart_item](
	[product_id] [int] NOT NULL,
	[quantity] [int] NOT NULL,
	[user_email] [nvarchar](100) NOT NULL,
	[added_date] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[product_id] ASC,
	[user_email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[category]    Script Date: 7/21/2022 1:24:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[category](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](200) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[delivery_status]    Script Date: 7/21/2022 1:24:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[delivery_status](
	[order_item] [int] NOT NULL,
	[updated_time] [datetime] NOT NULL,
	[delivery_unit] [nvarchar](100) NOT NULL,
	[shipping_status] [ntext] NOT NULL,
	[shipping_completed] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[order_item] ASC,
	[updated_time] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[feedback]    Script Date: 7/21/2022 1:24:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[feedback](
	[feedback_writter] [nvarchar](100) NOT NULL,
	[order_item] [int] NOT NULL,
	[feedback_photo] [ntext] NULL,
	[feedback_detail] [ntext] NOT NULL,
	[feedback_enable] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[order_item] ASC,
	[feedback_writter] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[order]    Script Date: 7/21/2022 1:24:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[order](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_email] [nvarchar](100) NULL,
	[amount] [money] NOT NULL,
	[payment_method] [int] NULL,
	[payment_status] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[order_item]    Script Date: 7/21/2022 1:24:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[order_item](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[order_id] [int] NULL,
	[product_name] [nvarchar](150) NOT NULL,
	[photo_link] [ntext] NOT NULL,
	[price] [money] NOT NULL,
	[quantity] [int] NOT NULL,
	[bought_date] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[product_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[payment_method]    Script Date: 7/21/2022 1:24:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[payment_method](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[method] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[product]    Script Date: 7/21/2022 1:24:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[product](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](150) NOT NULL,
	[detail] [ntext] NULL,
	[photo_link] [ntext] NOT NULL,
	[price] [money] NOT NULL,
	[quantity] [int] NOT NULL,
	[category_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[product_quantity]    Script Date: 7/21/2022 1:24:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[product_quantity](
	[product_id] [int] NOT NULL,
	[shop_id] [int] NOT NULL,
	[quantity] [int] NOT NULL,
	[update_date] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[product_id] ASC,
	[shop_id] ASC,
	[update_date] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[role]    Script Date: 7/21/2022 1:24:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[role](
	[id] [int] NOT NULL,
	[name] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[shop]    Script Date: 7/21/2022 1:24:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[shop](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[staff_email] [nvarchar](100) NULL,
	[address] [ntext] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user]    Script Date: 7/21/2022 1:24:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user](
	[email] [nvarchar](100) NOT NULL,
	[password] [nvarchar](100) NOT NULL,
	[phone] [char](10) NULL,
	[name] [nvarchar](100) NULL,
	[address] [ntext] NULL,
	[age] [int] NULL,
	[photo_link] [ntext] NULL,
	[role_id] [int] NULL,
	[gender] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[phone] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[blog] ADD  DEFAULT ((1)) FOR [enable_status]
GO
ALTER TABLE [dbo].[delivery_status] ADD  DEFAULT ((0)) FOR [shipping_completed]
GO
ALTER TABLE [dbo].[feedback] ADD  DEFAULT ((1)) FOR [feedback_enable]
GO
ALTER TABLE [dbo].[blog]  WITH CHECK ADD FOREIGN KEY([owner])
REFERENCES [dbo].[user] ([email])
GO
ALTER TABLE [dbo].[cart_item]  WITH CHECK ADD FOREIGN KEY([product_id])
REFERENCES [dbo].[product] ([id])
GO
ALTER TABLE [dbo].[cart_item]  WITH CHECK ADD FOREIGN KEY([user_email])
REFERENCES [dbo].[user] ([email])
GO
ALTER TABLE [dbo].[delivery_status]  WITH CHECK ADD FOREIGN KEY([order_item])
REFERENCES [dbo].[order_item] ([id])
GO
ALTER TABLE [dbo].[feedback]  WITH CHECK ADD FOREIGN KEY([feedback_writter])
REFERENCES [dbo].[user] ([email])
GO
ALTER TABLE [dbo].[feedback]  WITH CHECK ADD FOREIGN KEY([order_item])
REFERENCES [dbo].[order_item] ([id])
GO
ALTER TABLE [dbo].[order]  WITH CHECK ADD FOREIGN KEY([payment_method])
REFERENCES [dbo].[payment_method] ([id])
GO
ALTER TABLE [dbo].[order]  WITH CHECK ADD FOREIGN KEY([user_email])
REFERENCES [dbo].[user] ([email])
GO
ALTER TABLE [dbo].[order_item]  WITH CHECK ADD FOREIGN KEY([order_id])
REFERENCES [dbo].[order] ([id])
GO
ALTER TABLE [dbo].[product]  WITH CHECK ADD FOREIGN KEY([category_id])
REFERENCES [dbo].[category] ([id])
GO
ALTER TABLE [dbo].[product_quantity]  WITH CHECK ADD FOREIGN KEY([product_id])
REFERENCES [dbo].[product] ([id])
GO
ALTER TABLE [dbo].[product_quantity]  WITH CHECK ADD FOREIGN KEY([shop_id])
REFERENCES [dbo].[shop] ([id])
GO
ALTER TABLE [dbo].[shop]  WITH CHECK ADD FOREIGN KEY([staff_email])
REFERENCES [dbo].[user] ([email])
GO
ALTER TABLE [dbo].[user]  WITH CHECK ADD FOREIGN KEY([role_id])
REFERENCES [dbo].[role] ([id])
GO
USE [master]
GO
ALTER DATABASE [BakingIngredients] SET  READ_WRITE 
GO
