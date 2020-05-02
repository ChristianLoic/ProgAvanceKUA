

CREATE TABLE [dbo].[BreastFeed] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (MAX)  NULL,
    [ReleaseDate] DATETIME2 (7)   NOT NULL,
    [Side]        NVARCHAR (MAX)  NULL,
    [hour]        DECIMAL (18, 2) NOT NULL,
	[Note]       NVARCHAR (MAX) NOT NULL,

    CONSTRAINT [PK_BreastFeed] PRIMARY KEY CLUSTERED ([Id] ASC)
);

