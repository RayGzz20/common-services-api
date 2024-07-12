DELETE FROM [dbo].[CatPreguntaFrecuenteRespuesta]
WHERE [CREATED_BY] = 'CargaInicial';

DELETE FROM [dbo].[CatPreguntaFrecuente]
WHERE [CREATED_BY] = 'CargaInicial';

DELETE FROM [dbo].[CatSeccionPreguntaFrecuente]
WHERE [CREATED_BY] = 'CargaInicial';
GO