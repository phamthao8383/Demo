CREATE TABLE [dbo].[TB_ITEM_INFO] (
    [ID]             INT             IDENTITY (1, 1) NOT NULL,
    [Name]           NVARCHAR (50)   NOT NULL,
    [Type]           NVARCHAR (50)   NULL,
    [Brand]          NVARCHAR (50)   NULL,
    [AvailbleAmount] INT             NULL,
    [SaleAmount]     INT             NULL,
    [Price]          DECIMAL (18, 2) NULL,
    [Discount]       INT             NULL,
    [Description]    NVARCHAR (MAX)  NULL,
    [ImagePath]      VARBINARY (MAX) NULL,
    CONSTRAINT [PK_TB_ITEM_INFO] PRIMARY KEY CLUSTERED ([ID] ASC)
);

