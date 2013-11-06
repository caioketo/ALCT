﻿CREATE TABLE [dbo].[ImagemModels] (
    [ImagemId] [int] NOT NULL IDENTITY,
    [Caminho] [nvarchar](max),
    [ImovelModel_ImovelId] [int],
    CONSTRAINT [PK_dbo.ImagemModels] PRIMARY KEY ([ImagemId])
)
CREATE INDEX [IX_ImovelModel_ImovelId] ON [dbo].[ImagemModels]([ImovelModel_ImovelId])
ALTER TABLE [dbo].[ImovelModels] ADD [ImagemID] [int]
ALTER TABLE [dbo].[ImovelModels] ADD CONSTRAINT [FK_dbo.ImovelModels_dbo.ImagemModels_ImagemID] FOREIGN KEY ([ImagemID]) REFERENCES [dbo].[ImagemModels] ([ImagemId])
CREATE INDEX [IX_ImagemID] ON [dbo].[ImovelModels]([ImagemID])
ALTER TABLE [dbo].[ImagemModels] ADD CONSTRAINT [FK_dbo.ImagemModels_dbo.ImovelModels_ImovelModel_ImovelId] FOREIGN KEY ([ImovelModel_ImovelId]) REFERENCES [dbo].[ImovelModels] ([ImovelId])
INSERT INTO [__MigrationHistory] ([MigrationId], [Model], [ProductVersion]) VALUES ('201311061308169_AddPlanta', 0x1F8B0800000000000400DD5C5F6FDB38127F5FE0BE83A1A7DD05D64EBBFBB057D82D724E7330B6698B3AED167D291889768895449D4407C967DB87FB48F7158EFACFFF22292B75F396509C1F8733C3D17034E3FFFDFDDFE5ABFB249EDDC1BC40385D05CFE667C10CA6218E50BA5F0507B2FBE5F7E0D5CB7FFCB07C1D25F7B34FEDBC5FCB7994322D56C12D21D98BC5A2086F61028A7982C21C177847E6214E1620C28BE76767FF5C3C7BB6801422A058B3D9F2C321252881D53FF4DF354E4398910388AF7004E3A219A74FB615EAEC2D4860918110AE82F337EBEB793D2D989DC7085016B630DE05B3ECB7171F0BB825394EF7DB0C1004E2EB870CD2E73B1017B061F845F69B2DCF67CF4B9E17204D31A17038F5DA73D0ED86EEE735DD377928D9AAF6B40A28C7F9FB1CEF500CD98974EA1FF0811BA04374620673F2F001EE18F24D14CC163CED4224EE4805BA929355B049C9AFCF83D9DB431C839B187602A312DD129CC37FC314E680C0E83D2004E6D4003611AC7622ADAC58A7FCAB5D896A875A5630BB44F7307A03D33DB9ED56BB02F7ED08FD33987D4C1135444A44F20364B9ABFF67175E2E7AC11AC5FDBA20543D95F9F888BB26F711784F39B5C82F6011E62804786299CB2BAFA9DBD84FBDACB5AAD7280211F456754DEEA3EA9E726A55374675A15DC9466B8F682F6FC11DDA579E54B99160F601C6D5E3E21665B55B9F336AFCDA4EBBCC71F201C7BC929BA75FB7F89087A5C3C1DA29D720DF43E269579B04DFC1D8DBAE6A721FBBEA299FAE0BF904629CB7AB5EE0032554EC70C80DA5114E508AF048A0CDFBEB8F2321CE73083E12148F84F904F6A018D2FB804E719E206A16088F04DA1E108123315EA711CC61F8F8F6758D323C8EF5C6BB8FF3B99B04EC61E20AA2759F354F4AF7C978ABAFEDB4DE7DCA4F25F7A998A2729F26F6DEC720256090BD769A9ABDFAA991BD668A2B7B979894676280BB66969AB9EAA191B77A86B3E4400E23A866AE7E56A3D72BB1DCC94FBBC55BF61453DA1D78BE184BA31EF162ACCE84D78BB1A59CFAC5B806F4BD727B32212EA3411F89D7E43E12EF29A7967813F48C73B79FC7B9FC2FE3C8FF4411B91DF9F286993384D6A9B4CEE2183E45747906B76363E1E7458143547125DFE2DAF09FDF260D2566C37781FAB80AF7097A480F3141598C42CACB2AF85992A111BCF3A73D389B5E10C0CFE6F367123E3D8B340E4ACB54158D5A0B92039412F9E0A234441988075911289D5218A552BA95C427D4FE605A9ED841513BB070A162A15B49F04843925A2E18DB319B942224D269DD141FF55A676F840E266588ACECECF57826A567C5469FBA54899349E945EDC0C229985413C6DA685D8C698F6A524234CC81F781DAA39814CF8A8D3E75C1A0B749F1A27660E1144CAABE7BD8285DB88858199452E726783793FA597CF55B8B40118DE8983485263D976CBCEC70AA4C77297F097B9D2A3D2B7626ADCE3D3A9D2ABDA81D58789C535507999486500A98B739B937EBEB720CDE13C99ECAF95B48E48F73F40EDE87AC8DC6D96F77B2F5F05075CCA342E162C60194FA35A742E1C28401944A074885C2D9F0204A77E4D5508C471880624C4A05C51D5B018AD1BC2826FE9B013351FF65413449ABCB45B71B463F92715BDD2418A4CE5EC4AB39BF610B61A83280B230868262DBB098D942676606611862E061B18E14469B6F340B4315CED90674238421446F1C127BEE8E2A9126C76916882218B10C474688830F3CA693862A01228B632830B10D4D987DF02ED020154330322C5F8344DA944CF7B6EC9E2D1775154E33B05C68CA75965720CB50BA67CA779A91D9B6AEDD59FFB2752FA1496A8C4558282A693A6EBB9508CEA945084FABDA047889F2825C00026E40992F5B478934CD22366857528408B2D6DA37594B54FEDD47214D1DD35C5B04C40AF192EE2B29C3B02AA3CAE8DA483D2B6BA8400C724D01D01AC787243515130DA1D4E53D224E3D2A232D17C276A42850129A60C1A222ACD4D4BE4E7D35A4AD1BB2D290915A27DB3E51C7CA569FBED323319FF3592866D81EABADF16181DAB193D1761B2FF86A5B5B3A64A56D23B556AE5D0E8D93AC36B3366837174ABB51DCBB8E6B37DF48E3EDFBCE57E3DAA21E2B8D1BA975D2ED2FE3AC70F557F4E3EA4987D514E0B038CD908B8FE80B70783FD18FDBA3D555389C8CAA117B84BE088745E9475DA453D5E1F0D2A9861CB4C516E270FA621FD8E3B5F5382C543BE6E035BA8A1CCE6B74A3F64875890D8B528F38D84F97CC57F842270FD6E770F933A6CBEC7E43FFC55C63FC9D98A600A34219766206EA01014B4E4C97BD3728BD2DADE074DE0E9E8CA2B87B9AAFA2B4751B568A3252EBC4DB576CB0F2D555809855DE667015EF2DA7D3F99987F8EC42FB85A7FDE242DB1464B0F4CD90CB3B3713319AA1C73755FE4EAF088CF8F4CE6004D44E74F01065824269278A3C902C1FE7F8884D7FA83F6730FCF8B0AAFDA872142F6864AF8C9250F5156C5394353E5D7D8FAB18C4648F6C3B52CE479CD2596E97FB11723CCB26DF32DCB7252560EA29C18CCAE10E4565F265FB501098CCCB09F3ED7FE2758CE859E9275C8114ED6041AEF15F305D05CFCFCE7E173AC03CBAB3164511C58AC4D2A9B568A1521283B5748E65656277567A07F2F016E43F26E0FEA7A7D671358904A54E090711CA687C03D514DA3899A6A849B421F643558B8CEC869A420B27D342348916C40E090F2D88FD118FAC48198DEB4BDAC5189023B425F9E1B05D497E086253921F0AD7932428C8B723C90786EF47F24110BB9146590ADB6134CCCCF7D75C318DCBE0FB2A4629401D1A5BFA91EFAFF562127D885D171EFEF7F39813F9650C31D76FE1E598D86E0BFF333CAA9981AB0A1BD161A0AC3BF26F88F02A5A347F3C9DBE45E18935257828D2BEC4D7BF0A7D6C2FCB3769357872CD054CD1E5888AFF53300DF3D78CE95B069E6C93C0D1FA029C6DED6896E1AAA42394BDBB9BA35DA2FA11ACC4A18FE2F866C2156FFBF6627C3F6662FEB47792FD107269A4A84B6D57C45053449DE35F05D14D79B7AB2368F7AE89C648CC9D13AAA598097229ACBAB742B716F754B5163361782DEE3899BB30546B31136CD662FCB1B94D43BD96A1C0DAD0C831D4C7A15ACB5404FD689D1E0A9B938A382DFB3B144D0CEA2E9693E8EAF0605CFFEED054C79D6807877442A4EFDDA7B5F163376AD8B23D566CA7D1913176E30A2F2715E64CD278217F6CA7C100F353AA341A29D0BE87286B095218726140376793EE701B8F081CB55384BCD815A41E90C608E739413B1012FA38844551FD04CE27101F4AE799DCC06893BE3B90EC40E89661721373BFF1524635A6F5ABEE129EE7E5BBACFA9992636C81B249BD1981EFD27F1D501C757C5F2AD27A1A88325C6A52ADA52E499972DD3F74486F716A09D488AF8BF2AE6192C514AC78976EC11DD4F3362C435E62CB0B04F639488A06A3A7A7FF52F38B92FB97FF07A3D297990C580000, '5.0.0.net45')
