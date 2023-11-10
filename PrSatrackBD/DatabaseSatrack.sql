IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Clientes_Ubicacion_02]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Clientes] DROP CONSTRAINT [FK_Clientes_Ubicacion_02]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Productos_Clientes]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Productos] DROP CONSTRAINT [FK_Productos_Clientes]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Productos_TipoProducto]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Productos] DROP CONSTRAINT [FK_Productos_TipoProducto]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[FK_Productos_Transacciones]') AND OBJECTPROPERTY(id, 'IsForeignKey') = 1) 
ALTER TABLE [Productos] DROP CONSTRAINT [FK_Productos_Transacciones]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Clientes]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Clientes]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Productos]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Productos]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[TipoProducto]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [TipoProducto]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Transacciones]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Transacciones]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Ubicacion]') AND OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [Ubicacion]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[Data]')) 
DROP PROCEDURE [Data]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[SPActualizarSaldo]')) 
DROP PROCEDURE [SPActualizarSaldo]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[SPGetCancelarCDT]')) 
DROP PROCEDURE [SPGetCancelarCDT]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[SPGetProductosxCliente]')) 
DROP PROCEDURE [SPGetProductosxCliente]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[SPGetReporteMesaMes]')) 
DROP PROCEDURE [SPGetReporteMesaMes]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[SPGetReporteSaldoPromedio]')) 
DROP PROCEDURE [SPGetReporteSaldoPromedio]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[SPGetReporteTopClientes]')) 
DROP PROCEDURE [SPGetReporteTopClientes]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[SPGetTiposProdutos]')) 
DROP PROCEDURE [SPGetTiposProdutos]
;

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id('[SPGetUbicacion]')) 
DROP PROCEDURE [SPGetUbicacion]
;

CREATE TABLE [Clientes]
(
	[IDCliente] int NOT NULL IDENTITY (1, 1),
	[Nombre] varchar(350),
	[TipoDocumento] varchar(15),
	[Documento] int NOT NULL,
	[NIt] int,
	[TipoCliente] varchar(15),
	[TelefonoContacto] varchar(30),
	[FechaNacimiento] datetime,
	[Direccion] varchar(350),
	[IdUbicacion] varchar(8),
	[CorreoElectronico] varchar(250),
	[Genero] varchar(15),
	[Notas] varchar(5000)
)
;

CREATE TABLE [Productos]
(
	[IDProducto] int NOT NULL IDENTITY (1, 1),
	[IDCliente] int NOT NULL,
	[IDTransaccion] int,
	[TipoProducto] int,
	[Saldo] decimal(18),
	[InteresMensual] decimal(18),
	[Activo] bit NOT NULL DEFAULT 1,
	[Fecha] datetime
)
;

CREATE TABLE [TipoProducto]
(
	[IdTipoProducto] int NOT NULL IDENTITY (1, 1),
	[descripcion] varchar(250),
	[activo] varchar(1)
)
;

CREATE TABLE [Transacciones]
(
	[IDTransaccion] int NOT NULL IDENTITY (1, 1),
	[IDProducto] int NOT NULL,
	[Documento] varchar(20),
	[TipoTransaccion] varchar(50),
	[Monto] decimal(18),
	[Fecha] datetime
)
;

CREATE TABLE [Ubicacion]
(
	[IdUbicacion] int NOT NULL IDENTITY (1, 1),
	[CodDivipola] varchar(8) NOT NULL,
	[Descripcion] varchar(150),
	[Tipo] varchar(2),
	[IdPapa] varchar(8),
	[IdHijo] varchar(8),
	[Activo] varchar(1),
	[Indicativo] varchar(5)
)
;

CREATE INDEX [IXFK_Clientes_Ubicacion] 
 ON [Clientes] ([IdUbicacion] ASC)
;

CREATE INDEX [IXFK_Clientes_Ubicacion_02] 
 ON [Clientes] ([IdUbicacion] ASC)
;

ALTER TABLE [Clientes] 
 ADD CONSTRAINT [PK_Clientes]
	PRIMARY KEY CLUSTERED ([IDCliente])
;

ALTER TABLE [Clientes] 
 ADD CONSTRAINT [UNQ_documento_identidad] UNIQUE NONCLUSTERED ([Documento])
;

CREATE INDEX [IXFK_Productos_Clientes] 
 ON [Productos] ([IDCliente] ASC)
;

CREATE INDEX [IXFK_Productos_TipoProducto] 
 ON [Productos] ([TipoProducto] ASC)
;

CREATE INDEX [IXFK_Productos_Transacciones] 
 ON [Productos] ([IDTransaccion] ASC)
;

ALTER TABLE [Productos] 
 ADD CONSTRAINT [PK_Productos]
	PRIMARY KEY CLUSTERED ([IDProducto])
;

ALTER TABLE [TipoProducto] 
 ADD CONSTRAINT [PK_TipoProducto]
	PRIMARY KEY CLUSTERED ([IdTipoProducto])
;

ALTER TABLE [Transacciones] 
 ADD CONSTRAINT [PK_Transacciones]
	PRIMARY KEY CLUSTERED ([IDTransaccion])
;

ALTER TABLE [Ubicacion] 
 ADD CONSTRAINT [PK_Ubicacion]
	PRIMARY KEY CLUSTERED ([CodDivipola])
;

ALTER TABLE [Clientes] ADD CONSTRAINT [FK_Clientes_Ubicacion_02]
	FOREIGN KEY ([IdUbicacion]) REFERENCES [Ubicacion] ([CodDivipola]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [Productos] ADD CONSTRAINT [FK_Productos_Clientes]
	FOREIGN KEY ([IDCliente]) REFERENCES [Clientes] ([IDCliente]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [Productos] ADD CONSTRAINT [FK_Productos_TipoProducto]
	FOREIGN KEY ([TipoProducto]) REFERENCES [TipoProducto] ([IdTipoProducto]) ON DELETE No Action ON UPDATE No Action
;

ALTER TABLE [Productos] ADD CONSTRAINT [FK_Productos_Transacciones]
	FOREIGN KEY ([IDTransaccion]) REFERENCES [Transacciones] ([IDTransaccion]) ON DELETE No Action ON UPDATE No Action
;

INSERT INTO [dbo].[Ubicacion]
           ([CodDivipola]
           ,[Descripcion]
           ,[Tipo]
           ,[IdPapa]
           ,[IdHijo]
           ,[Activo]
           ,[Indicativo])
     VALUES
            ('01','COLOMBIA','P','1','0','1','+57'),
		    ('01001','BOGOTA','M','0','1','1',NULL),
		    ('01002','IBAGUE','M','0','1','1',NULL),
		    ('01003','CALI','M','0','1','1',NULL)
GO

select * from Ubicacion

INSERT INTO [dbo].[TipoProducto]
           ([descripcion]
           ,[activo])
     VALUES
			('Cuenta Ahorros','1'),
			('Cuenta Corriente','1'),
			('CDTs','1')
           
GO

select * from TipoProducto



;


if OBJECT_ID('[dbo].[SPActualizarSaldo]','P') is not null
drop procedure [dbo].[SPActualizarSaldo];
go 

create procedure [dbo].[SPActualizarSaldo]
@Documento varchar (20)
as
begin 


	declare @IdCliente int = (select top 1 idcliente from clientes c where c.Documento = @Documento)	

	insert into Productos (IDTransaccion ,IDCliente,TipoProducto,Saldo,Fecha)	
	(
	Select T.IDTransaccion 	
		,@IdCliente		
		,IDProducto
		,Monto
		,Fecha
		from transacciones T
		where T.Documento = @Documento
	)



end
go
;


if OBJECT_ID('[dbo].[SPGetCancelarCDT]','P') is not null
drop procedure [dbo].[SPGetCancelarCDT];
go 

create procedure [dbo].[SPGetCancelarCDT]
@documento varchar (20)
as
begin 	
	if ( select count(*) from Productos p
	inner join Clientes c on p.IDCliente = c.IDCliente
	where p.IDProducto = 3 
	and c.Documento = @documento
	) > 0
	begin 
		select 1
		select 'se cancela el producto y se agrega a la cuenta de ahorros o corriente'
	end 
	else 
	begin 
		select 'No tiene producto'
	end 
end
go
;


if OBJECT_ID('[dbo].[SPGetProductosxCliente]','P') is not null
drop procedure [dbo].[SPGetProductosxCliente];
go 

create procedure [dbo].[SPGetProductosxCliente]
@documento varchar (20)
as
begin 
	
	select p.TipoProducto,c.Nombre, Tp.descripcion	
	from Productos p
	inner join Clientes c on p.IDCliente = c.IDCliente
	inner join TipoProducto Tp on Tp.IdTipoProducto = p.TipoProducto
	where c.Documento = @documento
	GROUP BY p.TipoProducto,c.Nombre, Tp.descripcion
	

end
go
;


if OBJECT_ID('[dbo].[SPGetReporteMesaMes]','P') is not null
drop procedure [dbo].[SPGetReporteMesaMes];
go 

create procedure [dbo].[SPGetReporteMesaMes]
as
begin 
					
				DECLARE @fechaInicio DATE = '1900-01-01'; 
				DECLARE @fechaFin DATE = '2023-12-31'; 

				
				CREATE TABLE #ProyeccionSaldoTotalPorCliente
				(
					Mes INT
				  , DocumentoCliente varchar(30)
				  , SaldoTotal DECIMAL(18, 2)
				)

				
				INSERT INTO #ProyeccionSaldoTotalPorCliente
				(
					Mes
				  , DocumentoCliente
				  , SaldoTotal
				)
				SELECT 1
					 , C.Documento
					 , SUM(P.saldo)
				FROM Clientes            C
					INNER JOIN Productos P
						ON C.idcliente = P.idcliente
				WHERE P.Fecha <= @fechaInicio
				GROUP BY C.Documento;

				
				DECLARE @mes INT = 2;
				WHILE @fechaInicio < @fechaFin
				BEGIN
					INSERT INTO #ProyeccionSaldoTotalPorCliente
					(
						Mes
					  , Documentocliente
					  , SaldoTotal
					)
					SELECT @mes
						 , C.Documento
						 , SUM(P.saldo * (1 + P.interesMensual))
					FROM Clientes            C
						INNER JOIN Productos P
							ON C.idcliente = P.idcliente
					WHERE P.Fecha <= DATEADD(MONTH, @mes - 1, @fechaInicio)
					GROUP BY C.Documento;

					SET @mes = @mes + 1;
					SET @fechaInicio = DATEADD(MONTH, 1, @fechaInicio);
				END;

				
				SELECT *
				FROM #ProyeccionSaldoTotalPorCliente;

				
				DROP TABLE #ProyeccionSaldoTotalPorCliente;



end
go

;


if OBJECT_ID('[dbo].[GetReporteSaldoPromedio]','P') is not null
drop procedure [dbo].[GetReporteSaldoPromedio];
go 

create procedure [dbo].[GetReporteSaldoPromedio]
as
begin 
	
		SELECT
		  C.tipoCliente, 
		  AVG(P.saldo) AS SaldoPromedio 
		FROM
		  Clientes C
		INNER JOIN
		  Productos P ON C.idcliente = P.idcliente
		GROUP BY
		  C.tipoCliente;


end
go
;


if OBJECT_ID('[dbo].[SPGetReporteTopClientes]','P') is not null
drop procedure [dbo].[SPGetReporteTopClientes];
go 

create procedure [dbo].[SPGetReporteTopClientes]
as
begin 
	
	select top 10
    ROW_NUMBER() over (partition by c.IDCliente order by p.Saldo) as posicion
	  , c.Nombre
	  , Tp.descripcion
	  , sum(p.Saldo)   as Saldo
	from Productos              p
		inner join Clientes     c
			on p.IDCliente = c.IDCliente
		inner join TipoProducto Tp
			on Tp.IdTipoProducto = p.IDProducto
	GROUP BY c.Nombre
		   , Tp.descripcion
		   , c.IDCliente
		   , p.Saldo
	having sum(p.Saldo) > 1

end
go
;

if OBJECT_ID('[dbo].[SPGetTiposProdutos]','P') is not null
drop procedure [dbo].[SPGetTiposProdutos];
go 
create procedure [dbo].[SPGetTiposProdutos]
as
begin 
	select IdTipoProducto
		  ,descripcion
		  ,activo 
	from TipoProducto
end
go
;

if OBJECT_ID('[dbo].[SPGetUbicacion]','P') is not null
drop procedure [dbo].[SPGetUbicacion];
go 

create procedure [dbo].[SPGetUbicacion]
as
begin 
	SELECT 
		 IdUbicacion
		,CodDivipola
		,descripcion
		,Tipo
		,IdPapa
		,IdHijo
		,Activo	
	FROM UBICACION
end
go
;
