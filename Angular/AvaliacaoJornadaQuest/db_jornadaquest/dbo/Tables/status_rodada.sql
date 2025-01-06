CREATE TABLE [dbo].[status_rodada]
(
	[id_status_rodada] INT NOT NULL PRIMARY KEY, 
    [nm_status_rodada] VARCHAR(50) NOT NULL,
	CONSTRAINT [UN_status_rodada] UNIQUE NONCLUSTERED ([nm_status_rodada] asc)
)
