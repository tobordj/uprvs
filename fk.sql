ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK__Product__ProductID__123] FOREIGN KEY([CategoneID])
REFERENCES [dbo].[Categones] ([CategoneID])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK__Product__ProductID__123]