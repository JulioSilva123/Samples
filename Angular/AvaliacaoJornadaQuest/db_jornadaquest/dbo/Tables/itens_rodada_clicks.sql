CREATE TABLE [dbo].[itens_rodada_clicks]
(
	[id_item_rodada_click] INT NOT NULL PRIMARY KEY, 
    [id_item_rodada] INT NOT NULL, 
    [dt_item_click] DATETIME NOT NULL,
    CONSTRAINT [UN_itens_rodada_clicks] UNIQUE NONCLUSTERED ([id_item_rodada] asc, [dt_item_click] asc ),
    CONSTRAINT [FK_itens_rodada_clicks_itens_rodada] FOREIGN KEY ([id_item_rodada]) REFERENCES [dbo].[itens_rodada] ([id_item_rodada]),    
)
