﻿USE [ShopDB]
GO

/****** Object:  Table [dbo].[TB_CUSTOMER_INFO]    Script Date: 9/19/2020 1:02:10 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_COMMUNE] (
    [ID]          INT           IDENTITY (1, 1) NOT NULL,
    [ID_DISTRICT] INT           NULL,
    [Name]        NVARCHAR (50) NULL,
   
);

