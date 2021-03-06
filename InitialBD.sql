﻿CREATE TABLE [dbo].[UserProfile] (
    [UserId] [int] NOT NULL IDENTITY,
    [UserName] [nvarchar](max),
    CONSTRAINT [PK_dbo.UserProfile] PRIMARY KEY ([UserId])
)
CREATE TABLE [dbo].[EstadoModels] (
    [EstadoId] [int] NOT NULL IDENTITY,
    [Descricao] [nvarchar](max),
    [Codigo] [nvarchar](max),
    CONSTRAINT [PK_dbo.EstadoModels] PRIMARY KEY ([EstadoId])
)
CREATE TABLE [dbo].[CidadeModels] (
    [CidadeId] [int] NOT NULL IDENTITY,
    [EstadoID] [int],
    [Descricao] [nvarchar](max),
    CONSTRAINT [PK_dbo.CidadeModels] PRIMARY KEY ([CidadeId])
)
CREATE INDEX [IX_EstadoID] ON [dbo].[CidadeModels]([EstadoID])
CREATE TABLE [dbo].[ImovelModels] (
    [ImovelId] [int] NOT NULL IDENTITY,
    [CidadeID] [int],
    [Descricao] [nvarchar](max),
    [Valor] [float] NOT NULL,
    [Condominio] [float] NOT NULL,
    [IPTU] [float] NOT NULL,
    [AreaUtil] [float] NOT NULL,
    [Vagas] [int] NOT NULL,
    [Dormitorios] [int] NOT NULL,
    [Suites] [int] NOT NULL,
    [Endereco] [nvarchar](max),
    [Tipo] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ImovelModels] PRIMARY KEY ([ImovelId])
)
CREATE INDEX [IX_CidadeID] ON [dbo].[ImovelModels]([CidadeID])
CREATE TABLE [dbo].[ParedeModels] (
    [ParedeId] [int] NOT NULL IDENTITY,
    [ImovelID] [int],
    [X] [int] NOT NULL,
    [Z] [int] NOT NULL,
    [Width] [int] NOT NULL,
    [Depth] [int] NOT NULL,
    CONSTRAINT [PK_dbo.ParedeModels] PRIMARY KEY ([ParedeId])
)
CREATE INDEX [IX_ImovelID] ON [dbo].[ParedeModels]([ImovelID])
ALTER TABLE [dbo].[CidadeModels] ADD CONSTRAINT [FK_dbo.CidadeModels_dbo.EstadoModels_EstadoID] FOREIGN KEY ([EstadoID]) REFERENCES [dbo].[EstadoModels] ([EstadoId])
ALTER TABLE [dbo].[ImovelModels] ADD CONSTRAINT [FK_dbo.ImovelModels_dbo.CidadeModels_CidadeID] FOREIGN KEY ([CidadeID]) REFERENCES [dbo].[CidadeModels] ([CidadeId])
ALTER TABLE [dbo].[ParedeModels] ADD CONSTRAINT [FK_dbo.ParedeModels_dbo.ImovelModels_ImovelID] FOREIGN KEY ([ImovelID]) REFERENCES [dbo].[ImovelModels] ([ImovelId])
CREATE TABLE [dbo].[__MigrationHistory] (
    [MigrationId] [nvarchar](255) NOT NULL,
    [Model] [varbinary](max) NOT NULL,
    [ProductVersion] [nvarchar](32) NOT NULL,
    CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY ([MigrationId])
)
BEGIN TRY
    EXEC sp_MS_marksystemobject 'dbo.__MigrationHistory'
END TRY
BEGIN CATCH
END CATCH
INSERT INTO [__MigrationHistory] ([MigrationId], [Model], [ProductVersion]) VALUES ('201311061202129_InitialCreate', 0x1F8B0800000000000400DD5CCD52E43610BEA72AEFE0F22949D58E61770F9BAD99DD2203A4A8F057CC40282E5BC2D60CAAC892636B2878B61CF2487985C8FF922CF9476680E506B2FA53ABBBD5AD5637FCF7CFBFD3AF0F2176EE619C204A66EEEE64C77520F16980C87AE66ED8EADD27F7EB971F7F981E04E1837355CEFB90CEE3942499B9778C459F3D2FF1EF6008924988FC982674C5263E0D3D1050EFFDCECEAFDEEEAE073984CBB11C677AB1210C8530FB85FF3AA7C48711DB007C42038893629C7F5964A8CE29086112011FCEDCBDE3F972924F739D3D8C00676101F1CA75A28F9F2F13B8603125EB4504180278F91841FE7D0570020B863F471FFBF2BCF33EE5D9038450C6E128B1DAB35BED86EFE780EF9B3DA66C657B9AB99CE3F83CA62B84A138914FFD033E4A037C884F8C60CC1E2FE04A203F0A5CC793693D95B82255E8524E66EE11611FDEBBCEE90663708B6125302ED105A331FC1D121803068373C0188CB9011C0530DB496365CD3AE94FE54A5C3BDCB25CE7103DC0E0189235BBAB563B010FE508FFD1752E09E286C88958BC812277F9EFE2C253AF166CABB80F12C6D593998F8DB873721B81D794DB16F93E4CFC18F9806E59E6CD95E7DC6DACB7BD6C6F55CF51000268ADEA9CDC46D535E5B6555D18D5BE71A53E5A7B467B3905F7689D7952ED465CE702E2EC737287A2DCAD4F04357E2BA71DC634BCA0585672F1F5DB826E623F7538D4386509E2356496767514D27B88ADED2A27B7B1AB9AF2EDBA902B80695CAEBA4F379C50B3C32E3744021A2282E848A0A3F3E5E54888BD18824B86F048982BB0064997DE3B744AE31071B3407424D06283181C897140021843FFF9ED6B89223A8EF5C2BB0FF4B946CF97C3693D9FE068BE95D36ACFD7FCDAF07C9A293ACFD7C6DE398861906A5BC35FFE2D87CF9712F96B7EAD162FF9D34C29B760E599053C1BCF9C93DB78E69A72DB9EB98801E322FEF5B81370338EFC4F14B0BB91BE8C278B43218C265E9AEE5358B87A025B0E411F0BDF4B12EAA38CABE6A5B6BC0DC9DBE49ED5E9BE1AE54E57B95E7157BBC10C4518F99C9799FB4B4386ADE0D5E9AEC1C56C4B01DF994C761BF8FC2CF2B040D2CC9D07F184C50011D63CB888F82802B8931585725046972AA55A49FDC2ED0F92F4C4768A7A000BFB3A16AA95148FD425A9A927D84EBB4969C28C49EB6D31A7D6BA78411E60522DD1AA9FBD3E9D499959E9A34F53E638C8A4CCA21EC0C24B9994C66F9AB4DEE6446BAD8B917D8049B5DD417AD9EBD3999499953EFA34258D834CCA2CEA012C3C8F49E5E190D3304E01E332993A9E2FD331F8C01AF694CE5F40D67C55E577D73AB8161A171F5D9BD62343E5DE59872245B70E94FC40EA502487D68192E900E950241BEE4011EC4007259D35054A5097BA37F9854698687EC751EDA8D7DDA5DA8D20D48645F6BAA808489592D59BBFBCE11EC2D0256D4D6174C5DCBE5157D842651B2DC26809B1DD62B51086EEFEDC144657B4E81B2F842DC826DE22919608D12DDB16899437FACA85D5252D2FAF6995B52FCF50FC9A9E802842642D14C38A11679157C2E6EF16C30B52618EE1F989A62E55715BADC4B355B086CAD7ECA51F1EA23861FB80815B90A65BF3206C4CEBE1B0CB95347EBBA9B5D2539544E9CF756828AA821363494D14E221DF5798C6C62C211774DD4A9D55240106B1A19C36A7781392B6D25C174A5E2C5371F2D126D2D453B6D308CD0DA12916AC2AA2979A4A7769AB216315AE97865AA94DB2ADF33C51B6E6ECCF8C243C8E8B50C2707FACB26226029563AF46DB653CB0D5B6B110D74BDBADD446B956299824596362D66937FB5ABBD15C869FD66E5E48E365BCB3D5B8B144D64BE3ADD426E9D61992285C73DEF4B47A326115E52C11A7181AE223EA7296EC27EAF1FE68794D4B925136D21FA12E698928F5E810E964552D593AD9D0006D89652D495FE287FE7865754B842AC706788DAABE25798D6AB43F525EB01251F29101F653BD05697CA1D683BD90D7912EEDB6AEC75803CA50BA5C4F2BB549C075F54714B0A99AD48654BFB1689CD8A060732D435C0FA1BD91696F86D016C51D91BE181AE2802315A3187A66536D2471EA946AF52A995392B669914075B7353632AA7C8AEB70E1DCA320CDA6168F0983E1249D3059FC8DE718F1FDD6134E00412B98B025FD0BF2D49A277C9F9406498BE6452F4902ACC9145F5B07234A25D1595B1D5866549B17C93D88FD3B10FF1482879FDF5A43E25624D868241A20C2269ADC5FB80D6DBC9A9EC1AD68436D17CC1619D92CB80D2DBC9A0EBBAD68416D207A662D34D1A49EBB15A6803D41CB9D1D8ED8716787A036DCD9A148FD768A826CBBED6C60E45E3B1B04B5D36E94A588DD73DDCC7C7F7D5B5B39EF6ACB96C579BF1E6301376388A5662DAB8320B66AD9DBCCA84E28A9503BA23D495B55B4EFA6B2EA23687F3ADF7E7FD31BEB68B250648769489578DBAEA8B18D702FD2A7F4C63A932C14D9611A5267856D77D3D886B617E937FA5E3A8C9A756DC3CBA5E6EDA3A3CD287FCF99B9C16D7A85CA03E0F03EA4C248DA7B91744B09139A7D0CFA6E25D35AD257DD5AC284EEB5A4E3D4DED7A45B4B98D0BD9674D0DA1B9F746BB575953C5B6B94C60E1A55F19E0D519AAE1F7DDBD7AB6883B260DCECCF0DE5C657D9F264C1B839EC188A1D5BE96C6A3E7E73872DFCE53F8F18095AD710E9FF0120D0975C7535E788AC681933148ECA294AEA7102F989E07E7C2F6668057CC63FFB3049B23F34BB0278931EA6F0160647E46CC3A20DE35B86E12D96FE06278D3C6DEB67ED5B32CFD3B328FB3392A7D80267935B378367E4B70DC241C5F7A126733240A421ADC866535DB234AB5D3F5648A794F4042AC45745E2250C23CCC19233B200F7D0CC5BB70C65894DF71158C7204C0A8C9A9EFFCACD2F081FBEFC0F4C0E5E1BBB420000, '5.0.0.net45')
