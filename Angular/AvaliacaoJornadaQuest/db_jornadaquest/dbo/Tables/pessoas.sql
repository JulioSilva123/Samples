CREATE TABLE [dbo].[pessoas]
(
	[id_pessoa] INT NOT NULL PRIMARY KEY, 
    [nm_pessoa] VARCHAR(80) NOT NULL,
	CONSTRAINT [UN_pessoas] UNIQUE NONCLUSTERED ([nm_pessoa] asc),
)
