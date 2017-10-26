CREATE TABLE [dbo].[Categzers] (
    [CategzerID] INT            IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (MAX) NOT NULL,
    [SectoneID]  INT            NOT NULL,
    CONSTRAINT [PK_dbo.Categzers] PRIMARY KEY CLUSTERED ([CategzerID] ASC)
);

CREATE TABLE [dbo].[Categones] (
    [CategoneID] INT            IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (MAX) NOT NULL,
    [SectionID]  INT            NOT NULL,
    CONSTRAINT [PK_dbo.Categones] PRIMARY KEY CLUSTERED ([CategoneID] ASC)
);
CREATE TABLE [dbo].[Categtws] (
    [CategtwID] INT            IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_dbo.Categtws] PRIMARY KEY CLUSTERED ([CategtwID] ASC)
);

CREATE TABLE [dbo].[Producers] (
    [ProducerID] INT            IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_dbo.Producers] PRIMARY KEY CLUSTERED ([ProducerID] ASC)
);



CREATE TABLE [dbo].[Packings] (
    [PackingID] INT            IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (MAX) NOT NULL,
    [Measure]   NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_dbo.Packings] PRIMARY KEY CLUSTERED ([PackingID] ASC)
);
CREATE TABLE [dbo].[Products] (
    [ProductID]      INT             IDENTITY (1, 1) NOT NULL,
    [Name]           NVARCHAR (MAX)  NOT NULL,
    [Description]    NVARCHAR (1000) NOT NULL,
    [Price]          DECIMAL (18, 2) NOT NULL,
    [Category]       NVARCHAR (MAX)  NULL,
    [ImageData]      VARBINARY (MAX) NULL,
    [ImageMimeType]  NVARCHAR (MAX)  NULL,
    [CategzerID]     INT             NOT NULL,
    [CategoneID]     INT             NOT NULL,
    [CategtwID]      INT             NOT NULL,
    [PackingID]      INT             NOT NULL,
    [Alldescription] NVARCHAR (MAX)  NULL,
    [ImgUrl]         NVARCHAR (1024) NULL,
    [ProdcodeID]     INT             NOT NULL,
    [ProducerID]     INT             NOT NULL,
    [Recomend]       BIT             NOT NULL,
    CONSTRAINT [PK_dbo.Products] PRIMARY KEY CLUSTERED ([ProductID] ASC),
    CONSTRAINT [FK_dbo.Products_dbo.Categones_CategoneID] FOREIGN KEY ([CategoneID]) REFERENCES [dbo].[Categones] ([CategoneID]) ON DELETE SET NULL,
    CONSTRAINT [FK_dbo.Products_dbo.Categtws_CategtwID] FOREIGN KEY ([CategtwID]) REFERENCES [dbo].[Categtws] ([CategtwID]) ON DELETE SET NULL,
    CONSTRAINT [FK_dbo.Products_dbo.Categzers_CategzerID] FOREIGN KEY ([CategzerID]) REFERENCES [dbo].[Categzers] ([CategzerID]) ON DELETE SET NULL,
    CONSTRAINT [FK_dbo.Products_dbo.Packings_PackingID] FOREIGN KEY ([PackingID]) REFERENCES [dbo].[Packings] ([PackingID]) ON DELETE SET NULL,
    CONSTRAINT [FK_dbo.Products_dbo.Producers_ProducerID] FOREIGN KEY ([ProducerID]) REFERENCES [dbo].[Producers] ([ProducerID]) ON DELETE SET NULL
);


GO
CREATE NONCLUSTERED INDEX [IX_CategzerID]
    ON [dbo].[Products]([CategzerID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CategoneID]
    ON [dbo].[Products]([CategoneID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_CategtwID]
    ON [dbo].[Products]([CategtwID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PackingID]
    ON [dbo].[Products]([PackingID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ProducerID]
    ON [dbo].[Products]([ProducerID] ASC);



CREATE TABLE [dbo].[Shippings] (
    [ShippingID] INT            IDENTITY (1, 1) NOT NULL,
    [DateAdded]  DATETIME       NOT NULL,
    [Name]       NVARCHAR (50)  NOT NULL,
    [City]       NVARCHAR (50)  NOT NULL,
    [State]      NVARCHAR (100) NOT NULL,
    [Zip]        NVARCHAR (6)   NOT NULL,
    [Address]    NVARCHAR (100) NOT NULL,
    [Phone]      NVARCHAR (13)  NOT NULL,
    [Email]      NVARCHAR (30)  NOT NULL,
    [Message]    NVARCHAR (500) NOT NULL,
    CONSTRAINT [PK_dbo.Shippings] PRIMARY KEY CLUSTERED ([ShippingID] ASC)
);


CREATE TABLE [dbo].[Orders] (
    [OrderID]            INT             IDENTITY (1, 1) NOT NULL,
    [DateAdded]          DATETIME        NOT NULL,
    [Prodnumb]           INT             NOT NULL,
    [Prodname]           NVARCHAR (MAX)  NULL,
    [Total]              DECIMAL (18, 2) NOT NULL,
    [Price]              DECIMAL (18, 2) NOT NULL,
    [Allprice]           DECIMAL (18, 2) NOT NULL,
    [ShippingShippingID] INT             NULL,
    CONSTRAINT [PK_dbo.Orders] PRIMARY KEY CLUSTERED ([OrderID] ASC),
    CONSTRAINT [FK_dbo.Orders_dbo.Shippings_ShippingShippingID] FOREIGN KEY ([ShippingShippingID]) REFERENCES [dbo].[Shippings] ([ShippingID])
);


GO
CREATE NONCLUSTERED INDEX [IX_ShippingShippingID]
    ON [dbo].[Orders]([ShippingShippingID] ASC);


CREATE TABLE [dbo].[Offers] (
    [OfferID]       INT             IDENTITY (1, 1) NOT NULL,
    [DateAdded]     DATETIME        NOT NULL,
    [Name]          NVARCHAR (50)   NOT NULL,
    [Phone]         NVARCHAR (10)   NOT NULL,
    [Email]         NVARCHAR (MAX)  NOT NULL,
    [Title]         NVARCHAR (50)   NOT NULL,
    [Description]   NVARCHAR (500)  NOT NULL,
    [ImageData]     VARBINARY (MAX) NULL,
    [ImageMimeType] NVARCHAR (MAX)  NULL,
    CONSTRAINT [PK_dbo.Offers] PRIMARY KEY CLUSTERED ([OfferID] ASC)
);

CREATE TABLE [dbo].[Guestbooks] (
    [GuestbookID] INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (50)  NOT NULL,
    [Message]     NVARCHAR (500) NOT NULL,
    [DateAdded]   DATETIME       NOT NULL,
    CONSTRAINT [PK_dbo.Guestbooks] PRIMARY KEY CLUSTERED ([GuestbookID] ASC)
);


CREATE TABLE [dbo].[Applyings] (
    [ApplyingID] INT            IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_dbo.Applyings] PRIMARY KEY CLUSTERED ([ApplyingID] ASC)
);


CREATE TABLE [dbo].[ApplyingProduct] (
    [ApplyingID] INT NOT NULL,
    [ProductID]  INT NOT NULL,
    CONSTRAINT [PK_dbo.ApplyingProduct] PRIMARY KEY CLUSTERED ([ApplyingID] ASC, [ProductID] ASC),
    CONSTRAINT [FK_dbo.ApplyingProduct_dbo.Applyings_ApplyingID] FOREIGN KEY ([ApplyingID]) REFERENCES [dbo].[Applyings] ([ApplyingID]) ON DELETE SET NULL,
    CONSTRAINT [FK_dbo.ApplyingProduct_dbo.Products_ProductID] FOREIGN KEY ([ProductID]) REFERENCES [dbo].[Products] ([ProductID]) ON DELETE SET NULL
);


GO
CREATE NONCLUSTERED INDEX [IX_ApplyingID]
    ON [dbo].[ApplyingProduct]([ApplyingID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ProductID]
    ON [dbo].[ApplyingProduct]([ProductID] ASC);

CREATE TABLE [dbo].[Propers] (
    [ProperID] INT            IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_dbo.Propers] PRIMARY KEY CLUSTERED ([ProperID] ASC)
);



CREATE TABLE [dbo].[ProperProduct] (
    [ProperID]  INT NOT NULL,
    [ProductID] INT NOT NULL,
    CONSTRAINT [PK_dbo.ProperProduct] PRIMARY KEY CLUSTERED ([ProperID] ASC, [ProductID] ASC),
    CONSTRAINT [FK_dbo.ProperProduct_dbo.Propers_ProperID] FOREIGN KEY ([ProperID]) REFERENCES [dbo].[Propers] ([ProperID]) ON DELETE SET NULL,
    CONSTRAINT [FK_dbo.ProperProduct_dbo.Products_ProductID] FOREIGN KEY ([ProductID]) REFERENCES [dbo].[Products] ([ProductID]) ON DELETE SET NULL
);


GO
CREATE NONCLUSTERED INDEX [IX_ProperID]
    ON [dbo].[ProperProduct]([ProperID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ProductID]
    ON [dbo].[ProperProduct]([ProductID] ASC);


CREATE TABLE [dbo].[Techcharacters] (
    [TechcharacterID] INT            IDENTITY (1, 1) NOT NULL,
    [Name]            NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_dbo.Techcharacters] PRIMARY KEY CLUSTERED ([TechcharacterID] ASC)
);


CREATE TABLE [dbo].[TechcharacterProduct] (
    [TechcharacterID] INT NOT NULL,
    [ProductID]       INT NOT NULL,
    CONSTRAINT [PK_dbo.TechcharacterProduct] PRIMARY KEY CLUSTERED ([TechcharacterID] ASC, [ProductID] ASC),
    CONSTRAINT [FK_dbo.TechcharacterProduct_dbo.Techcharacters_TechcharacterID] FOREIGN KEY ([TechcharacterID]) REFERENCES [dbo].[Techcharacters] ([TechcharacterID]) ON DELETE SET NULL,
    CONSTRAINT [FK_dbo.TechcharacterProduct_dbo.Products_ProductID] FOREIGN KEY ([ProductID]) REFERENCES [dbo].[Products] ([ProductID]) ON DELETE SET NULL
);


GO
CREATE NONCLUSTERED INDEX [IX_TechcharacterID]
    ON [dbo].[TechcharacterProduct]([TechcharacterID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ProductID]
    ON [dbo].[TechcharacterProduct]([ProductID] ASC);





