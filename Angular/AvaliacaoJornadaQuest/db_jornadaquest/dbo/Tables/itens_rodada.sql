CREATE TABLE [dbo].[itens_rodada]
(
	[id_item_rodada] INT NOT NULL PRIMARY KEY, 
    [id_rodada] INT NOT NULL, 
    [id_pessoa] INT NOT NULL, 
    [ui_conexao] UNIQUEIDENTIFIER NULL, 
    [bo_ativo] BIT NOT NULL DEFAULT 0, 
    [nr_clicks] INT NOT NULL DEFAULT 0,
    CONSTRAINT [FK_itens_rodada_pessoas] FOREIGN KEY ([id_pessoa]) REFERENCES [dbo].[pessoas] ([id_pessoa]),    
    CONSTRAINT [FK_itens_rodada_rodadas] FOREIGN KEY ([id_rodada]) REFERENCES [dbo].[rodadas] ([id_rodada]),
)
