-- Set audit fields 
DECLARE @CREATED_BY nvarchar(50), @CREATED_AT [datetimeoffset];
SET @CREATED_AT = GETDATE();
SET @CREATED_BY = 'CargaInicial';
 
 
-- Generate guid for seccion facturas
DECLARE @SeccionPreguntaFrecuenteID uniqueidentifier
SET @SeccionPreguntaFrecuenteID = NEWID()
 
-- Insert Seccion
INSERT INTO [dbo].[CatSeccionPreguntaFrecuente]	
	( [SeccionPreguntaFrecuenteID], [Titulo] ,[UrlImagen] ,[Posicion], [Activa], [CREATED_AT], [CREATED_BY] )	
	VALUES ( @SeccionPreguntaFrecuenteID, 'FACTURACIÓN', 'https://oxg-imagenes-des.oxxogas.com/promotions/iconFacturacion.png', 1, 1, @CREATED_AT, @CREATED_BY );
 
-- Insert Questions and their answers
 
-- Insert question 1
-- Generate guid for question 
DECLARE @PreguntaFrecuenteID uniqueidentifier
SET @PreguntaFrecuenteID = NEWID()
 
-- Insert question
INSERT INTO [dbo].[CatPreguntaFrecuente]
	( [PreguntaFrecuenteID], [Descripcion], [Posicion], [Activa], [SeccionPreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( @PreguntaFrecuenteID, '¿Puedo registrar varios tickets?', 1, 1, @SeccionPreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
--Insert answers of question
INSERT INTO [dbo].[CatPreguntaFrecuenteRespuesta]
	( [PreguntaFrecuenteRespuestaID], [Descripcion], [Posicion], [Activa], [PreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( NEWID(), 'Sí, cada vez que cargues gasolina en OXXO GAS puedes ir registrando tus tickets de carga.', 1, 1, @PreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
 
-- Insert question 2
-- Generate guid for question 
SET @PreguntaFrecuenteID = NEWID()
 
-- Insert question
INSERT INTO [dbo].[CatPreguntaFrecuente]
	( [PreguntaFrecuenteID], [Descripcion], [Posicion], [Activa], [SeccionPreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( @PreguntaFrecuenteID, '¿El servicio de Facturación en APP OXXO GAS tiene costo?', 2, 1, @SeccionPreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
--Insert answers of question
INSERT INTO [dbo].[CatPreguntaFrecuenteRespuesta]
	( [PreguntaFrecuenteRespuestaID], [Descripcion], [Posicion], [Activa], [PreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( NEWID(), 'Todo servicio de facturación en OXXO GAS no tiene costo o comisión por tramitar la factura.', 1, 1, @PreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
 
-- Insert question 3
-- Generate guid for question 
SET @PreguntaFrecuenteID = NEWID()
 
-- Insert question
INSERT INTO [dbo].[CatPreguntaFrecuente]
	( [PreguntaFrecuenteID], [Descripcion], [Posicion], [Activa], [SeccionPreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( @PreguntaFrecuenteID, '¿Necesito contar con Internet para utilizar APP OXXO GAS?', 3, 1, @SeccionPreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
--Insert answers of question
INSERT INTO [dbo].[CatPreguntaFrecuenteRespuesta]
	( [PreguntaFrecuenteRespuestaID], [Descripcion], [Posicion], [Activa], [PreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( NEWID(), 'Se requiere conexión a internet para el registro de tickets, facturación y localización de estaciones..', 1, 1, @PreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
 
-- Insert question 4
-- Generate guid for question 
SET @PreguntaFrecuenteID = NEWID()
 
-- Insert question
INSERT INTO [dbo].[CatPreguntaFrecuente]
	( [PreguntaFrecuenteID], [Descripcion], [Posicion], [Activa], [SeccionPreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( @PreguntaFrecuenteID, '¿Qué pasa si me roban o pierdo mi celular? ¿Alguien podrá ver mi información y mis movimientos?', 4, 1, @SeccionPreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
--Insert answers of question
INSERT INTO [dbo].[CatPreguntaFrecuenteRespuesta]
	( [PreguntaFrecuenteRespuestaID], [Descripcion], [Posicion], [Activa], [PreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( NEWID(), 
		'No, el celular no guarda información alguna de las operaciones y la persona que lo tenga no puede realizar ninguna transacción ni ver información de tus cuentas porque no tiene tu contraseña de acceso.', 
		1, 1, @PreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
 
-- Insert question 5
-- Generate guid for question 
SET @PreguntaFrecuenteID = NEWID()
 
-- Insert question
INSERT INTO [dbo].[CatPreguntaFrecuente]
	( [PreguntaFrecuenteID], [Descripcion], [Posicion], [Activa], [SeccionPreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( @PreguntaFrecuenteID, '¿Cuántas facturas se pueden solicitar de una misma cuenta fiscal?', 5, 1, @SeccionPreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
--Insert answers of question
INSERT INTO [dbo].[CatPreguntaFrecuenteRespuesta]
	( [PreguntaFrecuenteRespuestaID], [Descripcion], [Posicion], [Activa], [PreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( NEWID(), 'No hay restricciones de cantidad de facturas, siempre que exista un ticket vigente registrado.', 1, 1, @PreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
 
-- Insert question 6
-- Generate guid for question 
SET @PreguntaFrecuenteID = NEWID()
 
-- Insert question
INSERT INTO [dbo].[CatPreguntaFrecuente]
	( [PreguntaFrecuenteID], [Descripcion], [Posicion], [Activa], [SeccionPreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( @PreguntaFrecuenteID, '¿Cómo puedo cancelar una factura?', 6, 1, @SeccionPreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
--Insert answers of question
INSERT INTO [dbo].[CatPreguntaFrecuenteRespuesta]
	( [PreguntaFrecuenteRespuestaID], [Descripcion], [Posicion], [Activa], [PreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( NEWID(), 'Las cancelaciones se pueden realizar marcando a la línea OXXO GAS: 01-800-OXXOGAS (6996-427).', 1, 1, @PreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
 
-- Insert question7
-- Generate guid for question 
SET @PreguntaFrecuenteID = NEWID()
 
-- Insert question
INSERT INTO [dbo].[CatPreguntaFrecuente]
	( [PreguntaFrecuenteID], [Descripcion], [Posicion], [Activa], [SeccionPreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( @PreguntaFrecuenteID, '¿Cuántos RFCs puedo dar de alta?', 7, 1, @SeccionPreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
--Insert answers of question
INSERT INTO [dbo].[CatPreguntaFrecuenteRespuesta]
	( [PreguntaFrecuenteRespuestaID], [Descripcion], [Posicion], [Activa], [PreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( NEWID(), 'Se cuenta con la funcionalidad de tener múltiples RFCs registrados.', 1, 1, @PreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
 
-- Insert question 8
-- Generate guid for question 
SET @PreguntaFrecuenteID = NEWID()
 
-- Insert question
INSERT INTO [dbo].[CatPreguntaFrecuente]
	( [PreguntaFrecuenteID], [Descripcion], [Posicion], [Activa], [SeccionPreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( @PreguntaFrecuenteID, '¿Qué pasa sino recibo comprobante XML de la factura?', 8, 1, @SeccionPreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
--Insert answers of question
INSERT INTO [dbo].[CatPreguntaFrecuenteRespuesta]
	( [PreguntaFrecuenteRespuestaID], [Descripcion], [Posicion], [Activa], [PreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( NEWID(), 
		'En caso de que no llegue el correo con el PDF y el XML podrás ingresar a la sección de mis facturas para descargarlo o solicitar ayuda al 01-800-OXXOGAS (6996-427).', 
		1, 1, @PreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
 
-- Insert question 9
-- Generate guid for question 
SET @PreguntaFrecuenteID = NEWID()
 
-- Insert question
INSERT INTO [dbo].[CatPreguntaFrecuente]
	( [PreguntaFrecuenteID], [Descripcion], [Posicion], [Activa], [SeccionPreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( @PreguntaFrecuenteID, '¿Qué información se puede consultar sobre cada estación de servicio?', 9, 1, @SeccionPreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
--Insert answers of question
INSERT INTO [dbo].[CatPreguntaFrecuenteRespuesta]
	( [PreguntaFrecuenteRespuestaID], [Descripcion], [Posicion], [Activa], [PreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( NEWID(), 
		'Las opciones que se muestran en la sección de mapas de cada estación OXXO GAS son distancia y como llegar a la estación, combustibles disponibles y precio, formas de pago y servicios adicionales.', 
		1, 1, @PreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
GO

-- Set audit fields 
DECLARE @CREATED_BY nvarchar(50), @CREATED_AT [datetimeoffset];
SET @CREATED_AT = GETDATE();
SET @CREATED_BY = 'CargaInicial';

-- Generate guid for seccion facturas
DECLARE @SeccionPreguntaFrecuenteID uniqueidentifier
SET @SeccionPreguntaFrecuenteID = NEWID()
 
-- Insert Seccion
INSERT INTO [dbo].[CatSeccionPreguntaFrecuente]	
	( [SeccionPreguntaFrecuenteID], [Titulo] ,[UrlImagen] ,[Posicion], [Activa], [CREATED_AT], [CREATED_BY] )	
	VALUES ( @SeccionPreguntaFrecuenteID, 'PROMOCIONES', 'https://oxg-imagenes-des.oxxogas.com/promotions/IconPromosExclusivas.png', 2, 1, @CREATED_AT, @CREATED_BY );
 
-- Insert Questions and their answers
 
-- Insert question 1
-- Generate guid for question 
DECLARE @PreguntaFrecuenteID uniqueidentifier
SET @PreguntaFrecuenteID = NEWID()
 
-- Insert question
INSERT INTO [dbo].[CatPreguntaFrecuente]
	( [PreguntaFrecuenteID], [Descripcion], [Posicion], [Activa], [SeccionPreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( @PreguntaFrecuenteID, '¿Por qué no puedo ver ninguna promoción?', 1, 1, @SeccionPreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
--Insert answers of question
INSERT INTO [dbo].[CatPreguntaFrecuenteRespuesta]
	( [PreguntaFrecuenteRespuestaID], [Descripcion], [Posicion], [Activa], [PreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( NEWID(), 'Deberás verificar que tu GPS este activado para validar tu ubicación. En dado caso de que no existan promociones en tu zona verás el mensaje de: "No hay promociones vigentes en tu zona".', 1, 1, @PreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
 
-- Insert question 2
-- Generate guid for question 
SET @PreguntaFrecuenteID = NEWID()
 
-- Insert question
INSERT INTO [dbo].[CatPreguntaFrecuente]
	( [PreguntaFrecuenteID], [Descripcion], [Posicion], [Activa], [SeccionPreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( @PreguntaFrecuenteID, '¿Dónde canjeo los artículos y productos que estan dentro de la sección "promociones"?', 2, 1, @SeccionPreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
--Insert answers of question
INSERT INTO [dbo].[CatPreguntaFrecuenteRespuesta]
	( [PreguntaFrecuenteRespuestaID], [Descripcion], [Posicion], [Activa], [PreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( NEWID(), 'La sección de "promociones" muestra las promociones vigentes en las estaciones, por lo que deberás de cargar gasolina en tu OXXO GAS más cercano y ahí mismo comprar tu promoción favorita.', 1, 1, @PreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
 
-- Insert question 3
-- Generate guid for question 
SET @PreguntaFrecuenteID = NEWID()
 
-- Insert question
INSERT INTO [dbo].[CatPreguntaFrecuente]
	( [PreguntaFrecuenteID], [Descripcion], [Posicion], [Activa], [SeccionPreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( @PreguntaFrecuenteID, '¿Cómo puedo participar en una promoción de Registra y Gana?', 3, 1, @SeccionPreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
--Insert answers of question
INSERT INTO [dbo].[CatPreguntaFrecuenteRespuesta]
	( [PreguntaFrecuenteRespuestaID], [Descripcion], [Posicion], [Activa], [PreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( NEWID(), 'Primero deberás aceptar participar en la promoción, de esta forma aceptas los términos y condiciones de la promoción. Una vez que aceptes participar deberás registrar tu ticket y este mismo deberá cumplir con la mecánica para ser válido.', 1, 1, @PreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
 
-- Insert question 4
-- Generate guid for question 
SET @PreguntaFrecuenteID = NEWID()
 
-- Insert question
INSERT INTO [dbo].[CatPreguntaFrecuente]
	( [PreguntaFrecuenteID], [Descripcion], [Posicion], [Activa], [SeccionPreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( @PreguntaFrecuenteID, '¿Qué pasa si respondí de forma incorrecta la pregunta al momento de registrar mi ticket para una promoción de Registra y Gana?', 4, 1, @SeccionPreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
--Insert answers of question
INSERT INTO [dbo].[CatPreguntaFrecuenteRespuesta]
	( [PreguntaFrecuenteRespuestaID], [Descripcion], [Posicion], [Activa], [PreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( NEWID(), 
		'Tu ticket ya no será valido para participar en esa promoción o en cualquier otra. Deberás registrar un ticket nuevo.', 
		1, 1, @PreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
 
-- Insert question 5
-- Generate guid for question 
SET @PreguntaFrecuenteID = NEWID()
 
-- Insert question
INSERT INTO [dbo].[CatPreguntaFrecuente]
	( [PreguntaFrecuenteID], [Descripcion], [Posicion], [Activa], [SeccionPreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( @PreguntaFrecuenteID, 'Registre tickets en la sección de facturación ¿esos tickets guardados ya estan participando en alguna promoción?', 5, 1, @SeccionPreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
--Insert answers of question
INSERT INTO [dbo].[CatPreguntaFrecuenteRespuesta]
	( [PreguntaFrecuenteRespuestaID], [Descripcion], [Posicion], [Activa], [PreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( NEWID(), 'No, deberás de registrar tus tickets en la promoción de Registra y Gana directamente. Deberás dar click en participar y posteriormente registrar dicho ticket, ahí podrás ver la cantidad de tickets que tienes registrados para una promoción. ', 1, 1, @PreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
 
-- Insert question 6
-- Generate guid for question 
SET @PreguntaFrecuenteID = NEWID()
 
-- Insert question
INSERT INTO [dbo].[CatPreguntaFrecuente]
	( [PreguntaFrecuenteID], [Descripcion], [Posicion], [Activa], [SeccionPreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( @PreguntaFrecuenteID, '¿Puedo participar en varias promociones de Registra y Gana al mismo tiempo?', 6, 1, @SeccionPreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
--Insert answers of question
INSERT INTO [dbo].[CatPreguntaFrecuenteRespuesta]
	( [PreguntaFrecuenteRespuestaID], [Descripcion], [Posicion], [Activa], [PreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( NEWID(), 'Sí, siempre y cuando se registren dirferentes tickets que cumplan con la mecánica de promoción.', 1, 1, @PreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
 
-- Insert question7
-- Generate guid for question 
SET @PreguntaFrecuenteID = NEWID()
 
-- Insert question
INSERT INTO [dbo].[CatPreguntaFrecuente]
	( [PreguntaFrecuenteID], [Descripcion], [Posicion], [Activa], [SeccionPreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( @PreguntaFrecuenteID, 'Al momento de registrar mi ticket, le di participar en una promoción de Registra y Gana ¿Ese ticket ya está participando?', 7, 1, @SeccionPreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
--Insert answers of question
INSERT INTO [dbo].[CatPreguntaFrecuenteRespuesta]
	( [PreguntaFrecuenteRespuestaID], [Descripcion], [Posicion], [Activa], [PreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( NEWID(), 'Sí, al momento de dar click en participar, dicho ticket ya será contabilizado en dicha promoción. Podrás ver tus tickets participantes al dar click en dicha promoción.', 1, 1, @PreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
 
-- Insert question 8
-- Generate guid for question 
SET @PreguntaFrecuenteID = NEWID()
 
-- Insert question
INSERT INTO [dbo].[CatPreguntaFrecuente]
	( [PreguntaFrecuenteID], [Descripcion], [Posicion], [Activa], [SeccionPreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( @PreguntaFrecuenteID, '¿1 ticket puede participar en varias promociones de Registra y Gana?', 8, 1, @SeccionPreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
--Insert answers of question
INSERT INTO [dbo].[CatPreguntaFrecuenteRespuesta]
	( [PreguntaFrecuenteRespuestaID], [Descripcion], [Posicion], [Activa], [PreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( NEWID(), 'No, solo participa 1 ticket por promoción. ', 1, 1, @PreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
 
-- Insert question 9
-- Generate guid for question 
SET @PreguntaFrecuenteID = NEWID()
 
-- Insert question
INSERT INTO [dbo].[CatPreguntaFrecuente]
	( [PreguntaFrecuenteID], [Descripcion], [Posicion], [Activa], [SeccionPreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( @PreguntaFrecuenteID, 'Quiero registrar mi ticket pero me aparece un mensaje de "tu ticket no existe".', 9, 1, @SeccionPreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
--Insert answers of question
INSERT INTO [dbo].[CatPreguntaFrecuenteRespuesta]
	( [PreguntaFrecuenteRespuestaID], [Descripcion], [Posicion], [Activa], [PreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( NEWID(), 'Verifica que la ifnormación que estes registrando sea correcta y que estes conectado a internet. Si el problema continua, probablemente en estos momento exista alguna intermitencia en la información, se recomienda que intentes registrar tu ticket más tarde. Si el problema persiste favor de reportarlo al: 8006996427', 1, 1, @PreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
GO

-- Set audit fields 
DECLARE @CREATED_BY nvarchar(50), @CREATED_AT [datetimeoffset];
SET @CREATED_AT = GETDATE();
SET @CREATED_BY = 'CargaInicial';

-- Generate guid for seccion facturas
DECLARE @SeccionPreguntaFrecuenteID uniqueidentifier
SET @SeccionPreguntaFrecuenteID = NEWID()
 
-- Insert Seccion
INSERT INTO [dbo].[CatSeccionPreguntaFrecuente]	
	( [SeccionPreguntaFrecuenteID], [Titulo] ,[UrlImagen] ,[Posicion], [Activa], [CREATED_AT], [CREATED_BY] )	
	VALUES ( @SeccionPreguntaFrecuenteID, 'DUDAS GENERALES', 'https://oxg-imagenes-des.oxxogas.com/promotions/iconDanosOpinion.png', 3, 1, @CREATED_AT, @CREATED_BY );
 
-- Insert Questions and their answers
 
-- Insert question 1
-- Generate guid for question 
DECLARE @PreguntaFrecuenteID uniqueidentifier
SET @PreguntaFrecuenteID = NEWID()
 
-- Insert question
INSERT INTO [dbo].[CatPreguntaFrecuente]
	( [PreguntaFrecuenteID], [Descripcion], [Posicion], [Activa], [SeccionPreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( @PreguntaFrecuenteID, '¿Cómo puedo filtrar estaciones que solamente cuenten con alguna forma de pago?', 1, 1, @SeccionPreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
--Insert answers of question
INSERT INTO [dbo].[CatPreguntaFrecuenteRespuesta]
	( [PreguntaFrecuenteRespuestaID], [Descripcion], [Posicion], [Activa], [PreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( NEWID(), 'Al entrar al localizador de estaciones, en la parte superior izquierda podrás filtrar por algún servicio que requieras o forma de pago', 1, 1, @PreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
 
-- Insert question 2
-- Generate guid for question 
SET @PreguntaFrecuenteID = NEWID()
 
-- Insert question
INSERT INTO [dbo].[CatPreguntaFrecuente]
	( [PreguntaFrecuenteID], [Descripcion], [Posicion], [Activa], [SeccionPreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( @PreguntaFrecuenteID, 'No puedo visualizar el localizador de estaciones', 2, 1, @SeccionPreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
--Insert answers of question
INSERT INTO [dbo].[CatPreguntaFrecuenteRespuesta]
	( [PreguntaFrecuenteRespuestaID], [Descripcion], [Posicion], [Activa], [PreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( NEWID(), 'Deberás de activar el GPS de tu celular para poder visualizar localizador de estaciones y promociones en tu ciudad.', 1, 1, @PreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
 
-- Insert question 3
-- Generate guid for question 
SET @PreguntaFrecuenteID = NEWID()
 
-- Insert question
INSERT INTO [dbo].[CatPreguntaFrecuente]
	( [PreguntaFrecuenteID], [Descripcion], [Posicion], [Activa], [SeccionPreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( @PreguntaFrecuenteID, '¿Qué es el pago digital?', 3, 1, @SeccionPreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
--Insert answers of question
INSERT INTO [dbo].[CatPreguntaFrecuenteRespuesta]
	( [PreguntaFrecuenteRespuestaID], [Descripcion], [Posicion], [Activa], [PreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( NEWID(), 'Es la evolución de nuestro vale de papel, es la funcionalidad que te permitirá gestionar los vehículos que desees a través de vales de combustible digitales. Para acceder a ellos deberás de crear una cuenta y hacer una transferencia para poder generar tus vales. ', 1, 1, @PreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
 
-- Insert question 4
-- Generate guid for question 
SET @PreguntaFrecuenteID = NEWID()
 
-- Insert question
INSERT INTO [dbo].[CatPreguntaFrecuente]
	( [PreguntaFrecuenteID], [Descripcion], [Posicion], [Activa], [SeccionPreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( @PreguntaFrecuenteID, '¿Qué información personal puedo editar?', 4, 1, @SeccionPreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
--Insert answers of question
INSERT INTO [dbo].[CatPreguntaFrecuenteRespuesta]
	( [PreguntaFrecuenteRespuestaID], [Descripcion], [Posicion], [Activa], [PreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( NEWID(), 'En la sección de "Perfil" podrás editar tus datos personales, tu número celular, correo electrónico y contraseña.', 1, 1, @PreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
 
-- Insert question 5
-- Generate guid for question 
SET @PreguntaFrecuenteID = NEWID()
 
-- Insert question
INSERT INTO [dbo].[CatPreguntaFrecuente]
	( [PreguntaFrecuenteID], [Descripcion], [Posicion], [Activa], [SeccionPreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( @PreguntaFrecuenteID, '¿Puedo eliminar mi cuenta?', 5, 1, @SeccionPreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
--Insert answers of question
INSERT INTO [dbo].[CatPreguntaFrecuenteRespuesta]
	( [PreguntaFrecuenteRespuestaID], [Descripcion], [Posicion], [Activa], [PreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( NEWID(), 'Sí, en la sección de "Perfil" podrás eliminar tu cuenta definitivamente, sin embargo no podrás acceder de nuevo a la App OXXO GAS. Tienes 30 días naturales para poder recuperar tu cuenta una vez eliminada. ', 1, 1, @PreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
 
-- Insert question 6
-- Generate guid for question 
SET @PreguntaFrecuenteID = NEWID()
 
-- Insert question
INSERT INTO [dbo].[CatPreguntaFrecuente]
	( [PreguntaFrecuenteID], [Descripcion], [Posicion], [Activa], [SeccionPreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( @PreguntaFrecuenteID, '¿En donde puedo agregar y eliminar mis RFC?', 6, 1, @SeccionPreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
--Insert answers of question
INSERT INTO [dbo].[CatPreguntaFrecuenteRespuesta]
	( [PreguntaFrecuenteRespuestaID], [Descripcion], [Posicion], [Activa], [PreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( NEWID(), 'Los movimientos de tu RFC se pueden realizar en "Perfil" en el botón de "Mis RFCs".', 1, 1, @PreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
GO