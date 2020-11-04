USE [ShopDB]
GO

/****** Object:  Table [dbo].[TB_CUSTOMER_INFO]    Script Date: 9/19/2020 1:02:10 PM ******/
SET ANSI_NULLS ON
GO
CREATE TABLE [dbo].[TB_CUSTOMER_INFO] (
    [ID]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (50)  NULL,
    [PhoneNumber] CHAR (15)      NOT NULL,
    [Gender]      BIT            NULL,
    [Address]     NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_TB_CUSTOMER_INFO_1] PRIMARY KEY CLUSTERED ([PhoneNumber] ASC)
);

