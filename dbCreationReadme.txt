1. ������� ������� Recipients
CREATE TABLE [dbo].[Recipients]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(MAX) NULL, 
    [Email] NVARCHAR(MAX) NULL
)

2. ��������� ������� Recipients ��������� �������
INSERT INTO [dbo].[Recipients] ([Id], [Name], [Email]) VALUES (1, N'������ �.', N'vasya@mail.ru')
INSERT INTO [dbo].[Recipients] ([Id], [Name], [Email]) VALUES (2, N'�������� �.', N'e.petrosyan@gmail.com')
INSERT INTO [dbo].[Recipients] ([Id], [Name], [Email]) VALUES (3, N'������ �.', N'biber@yandex.ru')
INSERT INTO [dbo].[Recipients] ([Id], [Name], [Email]) VALUES (4, N'��������� �.', N'khabib@rambler.ru')
INSERT INTO [dbo].[Recipients] ([Id], [Name], [Email]) VALUES (5, N'������ �.', N'ivanivan@mail.ru')