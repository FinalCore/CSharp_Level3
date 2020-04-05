1. Создать таблицу Recipients
CREATE TABLE [dbo].[Recipients]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(MAX) NULL, 
    [Email] NVARCHAR(MAX) NULL
)

2. Заполнить таблицу Recipients тестовыми данными
INSERT INTO [dbo].[Recipients] ([Id], [Name], [Email]) VALUES (1, N'Пупкин В.', N'vasya@mail.ru')
INSERT INTO [dbo].[Recipients] ([Id], [Name], [Email]) VALUES (2, N'Петросян Е.', N'e.petrosyan@gmail.com')
INSERT INTO [dbo].[Recipients] ([Id], [Name], [Email]) VALUES (3, N'Бобров В.', N'biber@yandex.ru')
INSERT INTO [dbo].[Recipients] ([Id], [Name], [Email]) VALUES (4, N'Хабибулин Р.', N'khabib@rambler.ru')
INSERT INTO [dbo].[Recipients] ([Id], [Name], [Email]) VALUES (5, N'Иванов И.', N'ivanivan@mail.ru')