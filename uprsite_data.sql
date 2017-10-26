SET IDENTITY_INSERT [dbo].[Producers] ON
INSERT INTO [dbo].[Producers] ([ProducerID], [Name]) VALUES (1, N'СНЕ.Т (Украина)')
INSERT INTO [dbo].[Producers] ([ProducerID], [Name]) VALUES (2, N'MARTINEZ AYALA (Испания)')
INSERT INTO [dbo].[Producers] ([ProducerID], [Name]) VALUES (3, N'MACDERMIND (Франция)')
INSERT INTO [dbo].[Producers] ([ProducerID], [Name]) VALUES (4, N'BOHMER (Китай)')
INSERT INTO [dbo].[Producers] ([ProducerID], [Name]) VALUES (5, N'KORU (Германия)')
SET IDENTITY_INSERT [dbo].[Producers] OFF

SET IDENTITY_INSERT [dbo].[Categzers] ON
INSERT INTO [dbo].[Categzers] ([CategzerID], [Name], [SectoneID]) VALUES (1, N'Препресс', 1)
INSERT INTO [dbo].[Categzers] ([CategzerID], [Name], [SectoneID]) VALUES (2, N'Пресс', 2)
INSERT INTO [dbo].[Categzers] ([CategzerID], [Name], [SectoneID]) VALUES (3, N'Постпресс', 3)
INSERT INTO [dbo].[Categzers] ([CategzerID], [Name], [SectoneID]) VALUES (4, N'Рекомендуем', 4)
INSERT INTO [dbo].[Categzers] ([CategzerID], [Name], [SectoneID]) VALUES (5, N'Акции и предл', 5)
SET IDENTITY_INSERT [dbo].[Categzers] OFF

SET IDENTITY_INSERT [dbo].[Categtws] ON
INSERT INTO [dbo].[Categtws] ([CategtwID], [Name]) VALUES (1, N'Химия для фотонаборных устройств')
INSERT INTO [dbo].[Categtws] ([CategtwID], [Name]) VALUES (2, N'Химия для обработки офсетных пластин')
INSERT INTO [dbo].[Categtws] ([CategtwID], [Name]) VALUES (3, N'Аналоговые офсетные пластины')
INSERT INTO [dbo].[Categtws] ([CategtwID], [Name]) VALUES (4, N'СТР офсетные пластины')
INSERT INTO [dbo].[Categtws] ([CategtwID], [Name]) VALUES (5, N'Пленка для лазерных принтеров, монтажная основа')
INSERT INTO [dbo].[Categtws] ([CategtwID], [Name]) VALUES (6, N'Лаки')
INSERT INTO [dbo].[Categtws] ([CategtwID], [Name]) VALUES (7, N'Вспомогательная химия')
INSERT INTO [dbo].[Categtws] ([CategtwID], [Name]) VALUES (8, N'Вспомогательные средства и материалы')
INSERT INTO [dbo].[Categtws] ([CategtwID], [Name]) VALUES (9, N'Резинотканевые полотна')
INSERT INTO [dbo].[Categtws] ([CategtwID], [Name]) VALUES (10, N'Офсетные краски')
INSERT INTO [dbo].[Categtws] ([CategtwID], [Name]) VALUES (11, N'Поддекельные материалы')
INSERT INTO [dbo].[Categtws] ([CategtwID], [Name]) VALUES (12, N'Переплетные материалы')
INSERT INTO [dbo].[Categtws] ([CategtwID], [Name]) VALUES (13, N'Материалы для упаковки')
INSERT INTO [dbo].[Categtws] ([CategtwID], [Name]) VALUES (14, N'Прочее')
SET IDENTITY_INSERT [dbo].[Categtws] OFF



SET IDENTITY_INSERT [dbo].[Categones] ON
INSERT INTO [dbo].[Categones] ([CategoneID], [Name], [SectionID]) VALUES (1, N'Химия для фотонаборных устройств', 1)
INSERT INTO [dbo].[Categones] ([CategoneID], [Name], [SectionID]) VALUES (2, N'Химия для обработки офсетных пластин', 1)
INSERT INTO [dbo].[Categones] ([CategoneID], [Name], [SectionID]) VALUES (3, N'Аналоговые офсетные пластины', 1)
INSERT INTO [dbo].[Categones] ([CategoneID], [Name], [SectionID]) VALUES (4, N'СТР офсетные пластины', 1)
INSERT INTO [dbo].[Categones] ([CategoneID], [Name], [SectionID]) VALUES (5, N'Лаки', 1)
INSERT INTO [dbo].[Categones] ([CategoneID], [Name], [SectionID]) VALUES (7, N'Вспомогательная химия', 1)
INSERT INTO [dbo].[Categones] ([CategoneID], [Name], [SectionID]) VALUES (8, N'Вспомогательные средства и материалы', 1)
INSERT INTO [dbo].[Categones] ([CategoneID], [Name], [SectionID]) VALUES (10, N'Резинотканевые полотна', 1)
INSERT INTO [dbo].[Categones] ([CategoneID], [Name], [SectionID]) VALUES (12, N'Офсетные краски', 1)
INSERT INTO [dbo].[Categones] ([CategoneID], [Name], [SectionID]) VALUES (14, N'Поддекельные материалы', 1)
INSERT INTO [dbo].[Categones] ([CategoneID], [Name], [SectionID]) VALUES (15, N'Переплетные материалы', 1)
INSERT INTO [dbo].[Categones] ([CategoneID], [Name], [SectionID]) VALUES (16, N'Материалы для упаковки', 1)
INSERT INTO [dbo].[Categones] ([CategoneID], [Name], [SectionID]) VALUES (17, N'Прочее', 1)
SET IDENTITY_INSERT [dbo].[Categones] OFF


SET IDENTITY_INSERT [dbo].[Categtws] ON
INSERT INTO [dbo].[Categtws] ([CategtwID], [Name]) VALUES (1, N'Проявители для СТР пластин')
INSERT INTO [dbo].[Categtws] ([CategtwID], [Name]) VALUES (2, N'Проявители для аналоговых пластин')
INSERT INTO [dbo].[Categtws] ([CategtwID], [Name]) VALUES (3, N'Средства для очистки активации и гуммирования')
INSERT INTO [dbo].[Categtws] ([CategtwID], [Name]) VALUES (4, N'Корректоры, зачернители и прочее')
INSERT INTO [dbo].[Categtws] ([CategtwID], [Name]) VALUES (5, N'Воднодисперсионные лаки')
INSERT INTO [dbo].[Categtws] ([CategtwID], [Name]) VALUES (6, N'Лаки')
INSERT INTO [dbo].[Categtws] ([CategtwID], [Name]) VALUES (7, N'УФ лаки')
INSERT INTO [dbo].[Categtws] ([CategtwID], [Name]) VALUES (8, N'Маслянные лаки')
INSERT INTO [dbo].[Categtws] ([CategtwID], [Name]) VALUES (9, N'Химия для систем увлажнения')
INSERT INTO [dbo].[Categtws] ([CategtwID], [Name]) VALUES (10, N'Химия для красочных валов и офсетной резины')
INSERT INTO [dbo].[Categtws] ([CategtwID], [Name]) VALUES (11, N'Добавки в краску')
INSERT INTO [dbo].[Categtws] ([CategtwID], [Name]) VALUES (12, N'Прочее')
INSERT INTO [dbo].[Categtws] ([CategtwID], [Name]) VALUES (13, N'Чехлы для валов систем увлажнения')
INSERT INTO [dbo].[Categtws] ([CategtwID], [Name]) VALUES (14, N'Противоотмарывающие порошки')
INSERT INTO [dbo].[Categtws] ([CategtwID], [Name]) VALUES (15, N'Триадные краски')
INSERT INTO [dbo].[Categtws] ([CategtwID], [Name]) VALUES (16, N'Металлизированные краски')
INSERT INTO [dbo].[Categtws] ([CategtwID], [Name]) VALUES (17, N'Специальные краски')
INSERT INTO [dbo].[Categtws] ([CategtwID], [Name]) VALUES (18, N'Базовые пантонные цвета')
SET IDENTITY_INSERT [dbo].[Categtws] OFF


SET IDENTITY_INSERT [dbo].[Packings] ON
INSERT INTO [dbo].[Packings] ([PackingID], [Name], [Measure]) VALUES (1, N'1', N'л')
INSERT INTO [dbo].[Packings] ([PackingID], [Name], [Measure]) VALUES (2, N'1,5', N'л')
INSERT INTO [dbo].[Packings] ([PackingID], [Name], [Measure]) VALUES (3, N'2', N'л')
INSERT INTO [dbo].[Packings] ([PackingID], [Name], [Measure]) VALUES (4, N'2,5', N'л')
INSERT INTO [dbo].[Packings] ([PackingID], [Name], [Measure]) VALUES (5, N'3', N'л')
INSERT INTO [dbo].[Packings] ([PackingID], [Name], [Measure]) VALUES (6, N'4', N'л')
INSERT INTO [dbo].[Packings] ([PackingID], [Name], [Measure]) VALUES (7, N'5', N'л')
INSERT INTO [dbo].[Packings] ([PackingID], [Name], [Measure]) VALUES (8, N'6', N'л')
INSERT INTO [dbo].[Packings] ([PackingID], [Name], [Measure]) VALUES (9, N'1', N'шт.')
INSERT INTO [dbo].[Packings] ([PackingID], [Name], [Measure]) VALUES (10, N'2', N'шт.')
INSERT INTO [dbo].[Packings] ([PackingID], [Name], [Measure]) VALUES (11, N'3', N'шт.')
INSERT INTO [dbo].[Packings] ([PackingID], [Name], [Measure]) VALUES (12, N'20л', N'л')
SET IDENTITY_INSERT [dbo].[Packings] OFF



SET IDENTITY_INSERT [dbo].[Applyings] ON
INSERT INTO [dbo].[Applyings] ([ApplyingID], [Name]) VALUES (1, N'Разбавить в соотношении 1 к 4 (для технологии Rapid Access).')
INSERT INTO [dbo].[Applyings] ([ApplyingID], [Name]) VALUES (2, N'10 литров концентрата и 40 литров воды образуют 50 литров готового к использованию фиксажа.')
INSERT INTO [dbo].[Applyings] ([ApplyingID], [Name]) VALUES (3, N'Разбавить в соотношении 1 к 3 (для технологии Hard Dot).')
INSERT INTO [dbo].[Applyings] ([ApplyingID], [Name]) VALUES (4, N'10 литров концентрата и 30 литров воды образуют 40 литров готового к использованию фиксажа. ')
SET IDENTITY_INSERT [dbo].[Applyings] OFF

SET IDENTITY_INSERT [dbo].[Techcharacters] ON
INSERT INTO [dbo].[Techcharacters] ([TechcharacterID], [Name]) VALUES (1, N'Оставляет печатный элемент в оптимальном для печати состоянии.')
INSERT INTO [dbo].[Techcharacters] ([TechcharacterID], [Name]) VALUES (2, N'Пригоден к использованию как с позитивными так и негативными пластинами;')
INSERT INTO [dbo].[Techcharacters] ([TechcharacterID], [Name]) VALUES (3, N'Очищает проявочный процессор от частичек эмульсии и других остатков')
SET IDENTITY_INSERT [dbo].[Techcharacters] OFF

SET IDENTITY_INSERT [dbo].[Propers] ON
INSERT INTO [dbo].[Propers] ([ProperID], [Name]) VALUES (1, N'Быстрое время закрепления, отлично подходит для использования с рециркуляторами, отсутствие резкого запаха. ')
INSERT INTO [dbo].[Propers] ([ProperID], [Name]) VALUES (2, N'Концентрат фиксажа для всех типов фотонаборных пленок и бумаг.')
SET IDENTITY_INSERT [dbo].[Propers] OFF

SET IDENTITY_INSERT [dbo].[Products] ON
INSERT INTO [dbo].[Products] ([ProductID], [Name], [Description], [Price], [Category], [ImageData], [ImageMimeType], [CategzerID], [CategoneID], [CategtwID], [PackingID], [Alldescription], [ImgUrl], [ProdcodeID], [ProducerID], [Recomend]) VALUES (4, N'Chembyo Plate Gum', N'Гуммирующий раствор для пластин.', CAST(33.00 AS Decimal(18, 2)), NULL, NULL, NULL, 1, 1, 3, 2, N'Гуммирующий раствор для пластин. Может использоваться как для ручной, так и автоматической обработки пластин.', N'--', 9, 1, 1)
SET IDENTITY_INSERT [dbo].[Products] OFF




