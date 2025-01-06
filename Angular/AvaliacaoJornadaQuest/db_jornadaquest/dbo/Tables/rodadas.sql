CREATE TABLE [dbo].[rodadas]
(
	[id_rodada] INT NOT NULL PRIMARY KEY, 
    [id_pessoa] INT NULL, 
    [id_status_rodada] INT NOT NULL DEFAULT 1,
    [nr_limite_click_minutos] INT NOT NULL DEFAULT 30, 
    [dt_inicio_rodada] DATETIME NOT NULL DEFAULT getdate(), 
    [dt_inicio_fim] DATETIME NULL,
    CONSTRAINT [FK_rodadas_pessoas] FOREIGN KEY ([id_pessoa]) REFERENCES [dbo].[pessoas] ([id_pessoa]),    
    CONSTRAINT [FK_rodadas_status_rodada] FOREIGN KEY ([id_status_rodada]) REFERENCES [dbo].[status_rodada] ([id_status_rodada]),
)
