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
	VALUES ( @SeccionPreguntaFrecuenteID, 'FACTURACI�N', 'https://oxg-imagenes-des.oxxogas.com/promotions/iconFacturacion.png', 1, 1, @CREATED_AT, @CREATED_BY );
 
-- Insert Questions and their answers
 
-- Insert question 1
-- Generate guid for question 
DECLARE @PreguntaFrecuenteID uniqueidentifier
SET @PreguntaFrecuenteID = NEWID()
 
-- Insert question
INSERT INTO [dbo].[CatPreguntaFrecuente]
	( [PreguntaFrecuenteID], [Descripcion], [Posicion], [Activa], [SeccionPreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( @PreguntaFrecuenteID, '�Puedo registrar varios tickets?', 1, 1, @SeccionPreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
--Insert answers of question
INSERT INTO [dbo].[CatPreguntaFrecuenteRespuesta]
	( [PreguntaFrecuenteRespuestaID], [Descripcion], [Posicion], [Activa], [PreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( NEWID(), 'S�, cada vez que cargues gasolina en OXXO GAS puedes ir registrando tus tickets de carga.', 1, 1, @PreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
 
-- Insert question 2
-- Generate guid for question 
SET @PreguntaFrecuenteID = NEWID()
 
-- Insert question
INSERT INTO [dbo].[CatPreguntaFrecuente]
	( [PreguntaFrecuenteID], [Descripcion], [Posicion], [Activa], [SeccionPreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( @PreguntaFrecuenteID, '�El servicio de Facturaci�n en APP OXXO GAS tiene costo?', 2, 1, @SeccionPreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
--Insert answers of question
INSERT INTO [dbo].[CatPreguntaFrecuenteRespuesta]
	( [PreguntaFrecuenteRespuestaID], [Descripcion], [Posicion], [Activa], [PreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( NEWID(), 'Todo servicio de facturaci�n en OXXO GAS no tiene costo o comisi�n por tramitar la factura.', 1, 1, @PreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
 
-- Insert question 3
-- Generate guid for question 
SET @PreguntaFrecuenteID = NEWID()
 
-- Insert question
INSERT INTO [dbo].[CatPreguntaFrecuente]
	( [PreguntaFrecuenteID], [Descripcion], [Posicion], [Activa], [SeccionPreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( @PreguntaFrecuenteID, '�Necesito contar con Internet para utilizar APP OXXO GAS?', 3, 1, @SeccionPreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
--Insert answers of question
INSERT INTO [dbo].[CatPreguntaFrecuenteRespuesta]
	( [PreguntaFrecuenteRespuestaID], [Descripcion], [Posicion], [Activa], [PreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( NEWID(), 'Se requiere conexi�n a internet para el registro de tickets, facturaci�n y localizaci�n de estaciones..', 1, 1, @PreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
 
-- Insert question 4
-- Generate guid for question 
SET @PreguntaFrecuenteID = NEWID()
 
-- Insert question
INSERT INTO [dbo].[CatPreguntaFrecuente]
	( [PreguntaFrecuenteID], [Descripcion], [Posicion], [Activa], [SeccionPreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( @PreguntaFrecuenteID, '�Qu� pasa si me roban o pierdo mi celular? �Alguien podr� ver mi informaci�n y mis movimientos?', 4, 1, @SeccionPreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
--Insert answers of question
INSERT INTO [dbo].[CatPreguntaFrecuenteRespuesta]
	( [PreguntaFrecuenteRespuestaID], [Descripcion], [Posicion], [Activa], [PreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( NEWID(), 
		'No, el celular no guarda informaci�n alguna de las operaciones y la persona que lo tenga no puede realizar ninguna transacci�n ni ver informaci�n de tus cuentas porque no tiene tu contrase�a de acceso.', 
		1, 1, @PreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
 
-- Insert question 5
-- Generate guid for question 
SET @PreguntaFrecuenteID = NEWID()
 
-- Insert question
INSERT INTO [dbo].[CatPreguntaFrecuente]
	( [PreguntaFrecuenteID], [Descripcion], [Posicion], [Activa], [SeccionPreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( @PreguntaFrecuenteID, '�Cu�ntas facturas se pueden solicitar de una misma cuenta fiscal?', 5, 1, @SeccionPreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
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
	VALUES ( @PreguntaFrecuenteID, '�C�mo puedo cancelar una factura?', 6, 1, @SeccionPreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
--Insert answers of question
INSERT INTO [dbo].[CatPreguntaFrecuenteRespuesta]
	( [PreguntaFrecuenteRespuestaID], [Descripcion], [Posicion], [Activa], [PreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( NEWID(), 'Las cancelaciones se pueden realizar marcando a la l�nea OXXO GAS: 01-800-OXXOGAS (6996-427).', 1, 1, @PreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
 
-- Insert question7
-- Generate guid for question 
SET @PreguntaFrecuenteID = NEWID()
 
-- Insert question
INSERT INTO [dbo].[CatPreguntaFrecuente]
	( [PreguntaFrecuenteID], [Descripcion], [Posicion], [Activa], [SeccionPreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( @PreguntaFrecuenteID, '�Cu�ntos RFCs puedo dar de alta?', 7, 1, @SeccionPreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
--Insert answers of question
INSERT INTO [dbo].[CatPreguntaFrecuenteRespuesta]
	( [PreguntaFrecuenteRespuestaID], [Descripcion], [Posicion], [Activa], [PreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( NEWID(), 'Se cuenta con la funcionalidad de tener m�ltiples RFCs registrados.', 1, 1, @PreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
 
-- Insert question 8
-- Generate guid for question 
SET @PreguntaFrecuenteID = NEWID()
 
-- Insert question
INSERT INTO [dbo].[CatPreguntaFrecuente]
	( [PreguntaFrecuenteID], [Descripcion], [Posicion], [Activa], [SeccionPreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( @PreguntaFrecuenteID, '�Qu� pasa sino recibo comprobante XML de la factura?', 8, 1, @SeccionPreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
--Insert answers of question
INSERT INTO [dbo].[CatPreguntaFrecuenteRespuesta]
	( [PreguntaFrecuenteRespuestaID], [Descripcion], [Posicion], [Activa], [PreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( NEWID(), 
		'En caso de que no llegue el correo con el PDF y el XML podr�s ingresar a la secci�n de mis facturas para descargarlo o solicitar ayuda al 01-800-OXXOGAS (6996-427).', 
		1, 1, @PreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
 
-- Insert question 9
-- Generate guid for question 
SET @PreguntaFrecuenteID = NEWID()
 
-- Insert question
INSERT INTO [dbo].[CatPreguntaFrecuente]
	( [PreguntaFrecuenteID], [Descripcion], [Posicion], [Activa], [SeccionPreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( @PreguntaFrecuenteID, '�Qu� informaci�n se puede consultar sobre cada estaci�n de servicio?', 9, 1, @SeccionPreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
--Insert answers of question
INSERT INTO [dbo].[CatPreguntaFrecuenteRespuesta]
	( [PreguntaFrecuenteRespuestaID], [Descripcion], [Posicion], [Activa], [PreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( NEWID(), 
		'Las opciones que se muestran en la secci�n de mapas de cada estaci�n OXXO GAS son distancia y como llegar a la estaci�n, combustibles disponibles y precio, formas de pago y servicios adicionales.', 
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
	VALUES ( @PreguntaFrecuenteID, '�Por qu� no puedo ver ninguna promoci�n?', 1, 1, @SeccionPreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
--Insert answers of question
INSERT INTO [dbo].[CatPreguntaFrecuenteRespuesta]
	( [PreguntaFrecuenteRespuestaID], [Descripcion], [Posicion], [Activa], [PreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( NEWID(), 'Deber�s verificar que tu GPS este activado para validar tu ubicaci�n. En dado caso de que no existan promociones en tu zona ver�s el mensaje de: "No hay promociones vigentes en tu zona".', 1, 1, @PreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
 
-- Insert question 2
-- Generate guid for question 
SET @PreguntaFrecuenteID = NEWID()
 
-- Insert question
INSERT INTO [dbo].[CatPreguntaFrecuente]
	( [PreguntaFrecuenteID], [Descripcion], [Posicion], [Activa], [SeccionPreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( @PreguntaFrecuenteID, '�D�nde canjeo los art�culos y productos que estan dentro de la secci�n "promociones"?', 2, 1, @SeccionPreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
--Insert answers of question
INSERT INTO [dbo].[CatPreguntaFrecuenteRespuesta]
	( [PreguntaFrecuenteRespuestaID], [Descripcion], [Posicion], [Activa], [PreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( NEWID(), 'La secci�n de "promociones" muestra las promociones vigentes en las estaciones, por lo que deber�s de cargar gasolina en tu OXXO GAS m�s cercano y ah� mismo comprar tu promoci�n favorita.', 1, 1, @PreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
 
-- Insert question 3
-- Generate guid for question 
SET @PreguntaFrecuenteID = NEWID()
 
-- Insert question
INSERT INTO [dbo].[CatPreguntaFrecuente]
	( [PreguntaFrecuenteID], [Descripcion], [Posicion], [Activa], [SeccionPreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( @PreguntaFrecuenteID, '�C�mo puedo participar en una promoci�n de Registra y Gana?', 3, 1, @SeccionPreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
--Insert answers of question
INSERT INTO [dbo].[CatPreguntaFrecuenteRespuesta]
	( [PreguntaFrecuenteRespuestaID], [Descripcion], [Posicion], [Activa], [PreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( NEWID(), 'Primero deber�s aceptar participar en la promoci�n, de esta forma aceptas los t�rminos y condiciones de la promoci�n. Una vez que aceptes participar deber�s registrar tu ticket y este mismo deber� cumplir con la mec�nica para ser v�lido.', 1, 1, @PreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
 
-- Insert question 4
-- Generate guid for question 
SET @PreguntaFrecuenteID = NEWID()
 
-- Insert question
INSERT INTO [dbo].[CatPreguntaFrecuente]
	( [PreguntaFrecuenteID], [Descripcion], [Posicion], [Activa], [SeccionPreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( @PreguntaFrecuenteID, '�Qu� pasa si respond� de forma incorrecta la pregunta al momento de registrar mi ticket para una promoci�n de Registra y Gana?', 4, 1, @SeccionPreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
--Insert answers of question
INSERT INTO [dbo].[CatPreguntaFrecuenteRespuesta]
	( [PreguntaFrecuenteRespuestaID], [Descripcion], [Posicion], [Activa], [PreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( NEWID(), 
		'Tu ticket ya no ser� valido para participar en esa promoci�n o en cualquier otra. Deber�s registrar un ticket nuevo.', 
		1, 1, @PreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
 
-- Insert question 5
-- Generate guid for question 
SET @PreguntaFrecuenteID = NEWID()
 
-- Insert question
INSERT INTO [dbo].[CatPreguntaFrecuente]
	( [PreguntaFrecuenteID], [Descripcion], [Posicion], [Activa], [SeccionPreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( @PreguntaFrecuenteID, 'Registre tickets en la secci�n de facturaci�n �esos tickets guardados ya estan participando en alguna promoci�n?', 5, 1, @SeccionPreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
--Insert answers of question
INSERT INTO [dbo].[CatPreguntaFrecuenteRespuesta]
	( [PreguntaFrecuenteRespuestaID], [Descripcion], [Posicion], [Activa], [PreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( NEWID(), 'No, deber�s de registrar tus tickets en la promoci�n de Registra y Gana directamente. Deber�s dar click en participar y posteriormente registrar dicho ticket, ah� podr�s ver la cantidad de tickets que tienes registrados para una promoci�n. ', 1, 1, @PreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
 
-- Insert question 6
-- Generate guid for question 
SET @PreguntaFrecuenteID = NEWID()
 
-- Insert question
INSERT INTO [dbo].[CatPreguntaFrecuente]
	( [PreguntaFrecuenteID], [Descripcion], [Posicion], [Activa], [SeccionPreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( @PreguntaFrecuenteID, '�Puedo participar en varias promociones de Registra y Gana al mismo tiempo?', 6, 1, @SeccionPreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
--Insert answers of question
INSERT INTO [dbo].[CatPreguntaFrecuenteRespuesta]
	( [PreguntaFrecuenteRespuestaID], [Descripcion], [Posicion], [Activa], [PreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( NEWID(), 'S�, siempre y cuando se registren dirferentes tickets que cumplan con la mec�nica de promoci�n.', 1, 1, @PreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
 
-- Insert question7
-- Generate guid for question 
SET @PreguntaFrecuenteID = NEWID()
 
-- Insert question
INSERT INTO [dbo].[CatPreguntaFrecuente]
	( [PreguntaFrecuenteID], [Descripcion], [Posicion], [Activa], [SeccionPreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( @PreguntaFrecuenteID, 'Al momento de registrar mi ticket, le di participar en una promoci�n de Registra y Gana �Ese ticket ya est� participando?', 7, 1, @SeccionPreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
--Insert answers of question
INSERT INTO [dbo].[CatPreguntaFrecuenteRespuesta]
	( [PreguntaFrecuenteRespuestaID], [Descripcion], [Posicion], [Activa], [PreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( NEWID(), 'S�, al momento de dar click en participar, dicho ticket ya ser� contabilizado en dicha promoci�n. Podr�s ver tus tickets participantes al dar click en dicha promoci�n.', 1, 1, @PreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
 
-- Insert question 8
-- Generate guid for question 
SET @PreguntaFrecuenteID = NEWID()
 
-- Insert question
INSERT INTO [dbo].[CatPreguntaFrecuente]
	( [PreguntaFrecuenteID], [Descripcion], [Posicion], [Activa], [SeccionPreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( @PreguntaFrecuenteID, '�1 ticket puede participar en varias promociones de Registra y Gana?', 8, 1, @SeccionPreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
--Insert answers of question
INSERT INTO [dbo].[CatPreguntaFrecuenteRespuesta]
	( [PreguntaFrecuenteRespuestaID], [Descripcion], [Posicion], [Activa], [PreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( NEWID(), 'No, solo participa 1 ticket por promoci�n. ', 1, 1, @PreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
 
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
	VALUES ( NEWID(), 'Verifica que la ifnormaci�n que estes registrando sea correcta y que estes conectado a internet. Si el problema continua, probablemente en estos momento exista alguna intermitencia en la informaci�n, se recomienda que intentes registrar tu ticket m�s tarde. Si el problema persiste favor de reportarlo al: 8006996427', 1, 1, @PreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
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
	VALUES ( @PreguntaFrecuenteID, '�C�mo puedo filtrar estaciones que solamente cuenten con alguna forma de pago?', 1, 1, @SeccionPreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
--Insert answers of question
INSERT INTO [dbo].[CatPreguntaFrecuenteRespuesta]
	( [PreguntaFrecuenteRespuestaID], [Descripcion], [Posicion], [Activa], [PreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( NEWID(), 'Al entrar al localizador de estaciones, en la parte superior izquierda podr�s filtrar por alg�n servicio que requieras o forma de pago', 1, 1, @PreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
 
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
	VALUES ( NEWID(), 'Deber�s de activar el GPS de tu celular para poder visualizar localizador de estaciones y promociones en tu ciudad.', 1, 1, @PreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
 
-- Insert question 3
-- Generate guid for question 
SET @PreguntaFrecuenteID = NEWID()
 
-- Insert question
INSERT INTO [dbo].[CatPreguntaFrecuente]
	( [PreguntaFrecuenteID], [Descripcion], [Posicion], [Activa], [SeccionPreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( @PreguntaFrecuenteID, '�Qu� es el pago digital?', 3, 1, @SeccionPreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
--Insert answers of question
INSERT INTO [dbo].[CatPreguntaFrecuenteRespuesta]
	( [PreguntaFrecuenteRespuestaID], [Descripcion], [Posicion], [Activa], [PreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( NEWID(), 'Es la evoluci�n de nuestro vale de papel, es la funcionalidad que te permitir� gestionar los veh�culos que desees a trav�s de vales de combustible digitales. Para acceder a ellos deber�s de crear una cuenta y hacer una transferencia para poder generar tus vales. ', 1, 1, @PreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
 
-- Insert question 4
-- Generate guid for question 
SET @PreguntaFrecuenteID = NEWID()
 
-- Insert question
INSERT INTO [dbo].[CatPreguntaFrecuente]
	( [PreguntaFrecuenteID], [Descripcion], [Posicion], [Activa], [SeccionPreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( @PreguntaFrecuenteID, '�Qu� informaci�n personal puedo editar?', 4, 1, @SeccionPreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
--Insert answers of question
INSERT INTO [dbo].[CatPreguntaFrecuenteRespuesta]
	( [PreguntaFrecuenteRespuestaID], [Descripcion], [Posicion], [Activa], [PreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( NEWID(), 'En la secci�n de "Perfil" podr�s editar tus datos personales, tu n�mero celular, correo electr�nico y contrase�a.', 1, 1, @PreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
 
-- Insert question 5
-- Generate guid for question 
SET @PreguntaFrecuenteID = NEWID()
 
-- Insert question
INSERT INTO [dbo].[CatPreguntaFrecuente]
	( [PreguntaFrecuenteID], [Descripcion], [Posicion], [Activa], [SeccionPreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( @PreguntaFrecuenteID, '�Puedo eliminar mi cuenta?', 5, 1, @SeccionPreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
--Insert answers of question
INSERT INTO [dbo].[CatPreguntaFrecuenteRespuesta]
	( [PreguntaFrecuenteRespuestaID], [Descripcion], [Posicion], [Activa], [PreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( NEWID(), 'S�, en la secci�n de "Perfil" podr�s eliminar tu cuenta definitivamente, sin embargo no podr�s acceder de nuevo a la App OXXO GAS. Tienes 30 d�as naturales para poder recuperar tu cuenta una vez eliminada. ', 1, 1, @PreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
 
-- Insert question 6
-- Generate guid for question 
SET @PreguntaFrecuenteID = NEWID()
 
-- Insert question
INSERT INTO [dbo].[CatPreguntaFrecuente]
	( [PreguntaFrecuenteID], [Descripcion], [Posicion], [Activa], [SeccionPreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( @PreguntaFrecuenteID, '�En donde puedo agregar y eliminar mis RFC?', 6, 1, @SeccionPreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
--Insert answers of question
INSERT INTO [dbo].[CatPreguntaFrecuenteRespuesta]
	( [PreguntaFrecuenteRespuestaID], [Descripcion], [Posicion], [Activa], [PreguntaFrecuenteID], [CREATED_AT], [CREATED_BY] )
	VALUES ( NEWID(), 'Los movimientos de tu RFC se pueden realizar en "Perfil" en el bot�n de "Mis RFCs".', 1, 1, @PreguntaFrecuenteID, @CREATED_AT, @CREATED_BY );
 
GO