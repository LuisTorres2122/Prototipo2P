drop database hotelsancarlos;
create database hotelsancarlos;
use hotelsancarlos;
-- ------------------------------------------------------------------------------------------------------------
-- 							MÓDULO DE HOTELERÍA
-- ------------------------------------------------------------------------------------------------------------
create table empresa(
	idEmpresa varchar(15) primary key not null,
	nit varchar(13) not null,
    nombre varchar(35) not null,
    direccion text not null,
    telefono int(10) not null,
    estatus char(1) not null
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
create table sucursal(
	idSucursal varchar(15) primary key not null,
	idEmpresa varchar(15) not null,
    nombre varchar(35) not null,
    direccion text not null,
    telefono int(10) not null,
    codigoPostal int not null,
    estatus char(1) not null,
    foreign key (idEmpresa) references empresa (idEmpresa)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
create table tipoInventario(
	Pkid varchar(15) primary key,
	nombre varchar(30) not null,
	estatus varchar(1)
)engine=InnoDB DEFAULT CHARSET=latin1;
create table tipoBodega(
	pkid varchar(15) primary key,
	nombre varchar(30) not null,
	estado varchar(1) not null
)engine=InnoDB DEFAULT CHARSET=latin1;

create table bodega(
	pkid varchar(15) primary key,
	fkidTipobodega varchar(15) not null,
	nombre varchar(30) not null,
	direccion varchar(65) not null,
	estado varchar(1) not null,
	foreign key (fkidTipobodega) references tipoBodega(pkid)
)engine=InnoDB DEFAULT CHARSET=latin1;

create table proveedor(
	idProveedor varchar(15),
	nombre varchar(100) not NULL,
	direccion varchar(500) not NULL,
	telefono int not NULL,
	email varchar(200) not NULL,
	idEmpresa varchar(15),
	stsproveedor varchar(1),
	primary key (idProveedor),
    
	foreign key (idEmpresa) references empresa (idEmpresa)
)ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE marca (
	idMarca varchar(15),
	nombre varchar(100) not NULL,
	descripcion varchar(500) not NULL,
	primary key (idMarca)
 )ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE linea (
	idLinea varchar(15),
	nombre varchar(100) not NULL,
	descripcion varchar(500) not NULL,
	idMarca varchar(15) not null,
	primary key (idLinea),
	foreign key (idMarca) references marca (idMarca)
)ENGINE=InnoDB DEFAULT CHARSET=latin1;

create table inventario(
	Pkid varchar(15) primary key,
	fkidsucursal varchar(15) not null,
	Fktipoinventario varchar(15) not null,
	fkidbodega varchar(15) NOT NULL,

	foreign key (Fktipoinventario) references tipoInventario (Pkid),
	foreign key (Fkidsucursal) references sucursal (idsucursal),
	foreign key (Fkidbodega) references bodega (pkid)
)engine=InnoDB DEFAULT CHARSET=latin1;

create table producto (
	pkid varchar(15) primary key,
	fkinventario varchar(15) not null,
	Nombre varchar(30) not null,
	Fkidlinea varchar(15) not null,
	Stock int not null,
    StockMaximo int not null,
    StockMinimo int not null,
	Costo float not null,
	Precio float not null,
	Estatus varchar(1),

	foreign key (Fkidlinea) references linea (idLinea),
	foreign key (fkinventario) references inventario (Pkid)
)engine=InnoDB DEFAULT CHARSET=latin1;
create table tipoCuenta(
	idTipoCuenta varchar(15), -- si es activo o pasivo
	nombre varchar(65), -- escribir nombre completo ej Activo Corriente
	estado varchar(1),

	primary key (idTipoCuenta)
) ENGINE = InnoDB DEFAULT CHARSET=latin1;
create table cuenta(
	idCuenta varchar(15), -- Identificador de la cuenta
	nombre varchar(65), -- Nombre de la cuenta
	idTipoCuenta varchar(15), -- foránea con Tipo Cuenta, se utiliza para los estados financieros
    cargo float default 0, -- cargo de la cuenta, inicia en 0 al crear la cuenta
    abono float default 0, -- abono de la cuenta, inicia en 0 al crear la cuenta
    saldoAcumulado float default 0, -- Saldo acumulado en la cuenta, inicia en 0 al crear la cuenta
	estado varchar(1) ,-- A-Activo , I-Inactivo
    -- Se usa Recursividad -> Para indicar el padre de la cuenta
    idCuentaPadre varchar(15) default null,
    -- Primaria
	primary key (idCuenta),
	-- Foránea
    foreign key (idTipoCuenta) references tipoCuenta (idTipoCuenta),
	-- Foránea
    foreign key (idCuentaPadre) references cuenta (idCuenta)
) ENGINE = InnoDB DEFAULT CHARSET=latin1;
create table impuesto(
	idImpuesto varchar(15), -- ID del impuesto que cada módulo podra usar
    nombre varchar(65), -- el nombre del impuesto, ej: IVA
    porcentaje float, -- Porcentaje del impuesto, Ej el IVA que es del 12% se ingresa como 0.12, asi con los demás
    estado varchar(1), -- A activo, I inactivo
    primary key(idImpuesto) -- primaria del impuesto
)ENGINE = InnoDB DEFAULT CHARSET=latin1;
create table tipoCliente(                      /*Huésped, Invitado(consumidor)*/
	idTipo varchar(15) primary key not null,
    nombre varchar(35) not null,
    estatus char(1) not null
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
create table cliente(
	Pkid varchar(15) primary key,
	nombre varchar(30) not null,
	apellido varchar(30) not null,
	nit varchar(15) not null,
	telefono varchar(15) not null,
	direccion varchar(50) not null,
	correo varchar(50) not null,
	estatus varchar(1), 
    idTipo varchar(15),

foreign key (idTipo) references tipoCliente(idTipo)
)engine=InnoDB DEFAULT CHARSET=latin1;
-- Reservaciones
create table tipoCama(
	idTipoCama varchar(15) primary key not null,
    nombre varchar(35) not null,
    idCuenta varchar(15) not null,
	estatus varchar(1) not null
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

create table tipoHabitacion(
	idTipoHabitacion varchar(15) primary key not null, 
    nombre varchar(35) not null,
    estatus varchar(1) not null
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

create table habitacion(
	idHabitacion varchar(15) primary key not null,
    idTipoHabitacion varchar(15) not null,
    idTipoCama varchar(15) not null,
    precio float not null,
    estatus varchar(1) not null,
    /*Llaves foráneas*/
    foreign key (idTipoHabitacion) references tipoHabitacion(idTipoHabitacion),
    foreign key (idTipoCama) references tipoCama(idTipoCama)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- servicios
create table tipoServicio(    /*Lavanderia, de cuarto, atracciones y otros*/
	idTipoServicio varchar(15) primary key not null,
    nombre varchar(35) not null, 
    estatus varchar(1) not null
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

create table reservacion(
	idReservacion varchar(15) primary key not null,
    idCliente varchar(15) not null,
    idHabitacion varchar(15) not null,
    cantidadHabitacion int not null,
    fechaInicio date not null,
    fechaFin date not null,
    estatus varchar(1) not null,             -- checkin, checkout, activo, inactivo
    
    /*Llaves foráneas*/
    foreign key (idCliente) references cliente (pkid),
    foreign key (idHabitacion) references habitacion (idHabitacion)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;


create table servicioEncabezado(
	idServicioE varchar(15) not null,
    idReservacion varchar(15) not null,
    idImpuesto varchar(15) not null,          -- cambiar por ID que tomaremos de contabilidad (tabla de impuesto)
    descripcion varchar(80) not null,
    total float not null,
    estatus varchar(1) not null, 
    
    primary key (idServicioE, idReservacion),
    
    /*Llaves foráneas*/
    foreign key (idReservacion) references reservacion (idReservacion),
    foreign key (idImpuesto) references impuesto (idImpuesto)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

create table servicioDetallado(
	idServicioE varchar(15) not null,
    idOrdenServicio int auto_increment not null,
	idReservacion varchar(15) not null,
    idTipoServicio varchar(15) not null,
    fechaAdquisicion date not null,
    cantidad int not null,
    costo float not null, 
    
    primary key(idOrdenServicio, idServicioE, idReservacion, idTipoServicio),
    
	/*Llaves foráneas*/
	foreign key (idServicioE) references servicioEncabezado(idServicioE),
    foreign key (idReservacion) references reservacion (idReservacion),
    foreign key (idTipoServicio) references tipoServicio(idTipoServicio)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Restaurante
create table salon(
	idSalon varchar(15) primary key not null,
    nombre varchar(30) not null,
    idCuenta varchar(15) not null,
    estatus varchar(1) not null,
    
    /*relacion mantenimiento y cuenta*/
    foreign key (idCuenta) references cuenta(idCuenta)

) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Reservacion de eventos*/
create table actividadReservacion(
	idActividad varchar(15) primary key not null,
    nombre varchar(80) not null,
    idCliente varchar(15) not null,  -- clientes que no son huéspedes, tienen derecho a realizar pedidos  -- en el cbx los clientes que no son huespedes
    idSalon varchar(15) not null,
    costoActividad float not null,   -- Costo o precio de la actividad (total)
    descripcion text not null,
    estatus varchar(1) not null, 
    
    /*Llaves foráneas*/
    foreign key (idCliente) references cliente(pkid),
    foreign key (idSalon) references salon(idSalon)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

create table mesa(
	idMesa varchar(15) primary key not null,
    nombre varchar(30) not null,
    idSalon varchar(15) not null,
    idCuenta varchar(15) not null,
    estado varchar(1) not null,
    estadoDisponibilidad varchar(1) not null,
    
    /*Llaves foráneas*/
    foreign key (idSalon) references salon(idSalon)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*
create table ingrediente( -- van a estar con el inventario 
	idIngrediente varchar(15) primary key not null,
    nombre varchar(35) not null,
    estado varchar(1) not null
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
*/

create table recetaEncabezado(
	idRecetaE varchar(15) primary key not null,
    nombre varchar(80) not null,
    preparacion text not null,
    estado varchar(1) not null
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

create table recetaDetalle(
	idRecetaE varchar(15) not null,
    idproducto varchar(15) not null,
    descripcion text not null, 				-- descripcion con respecto al prodcuto (ingrediente)
    
	primary key(idRecetaE, idproducto),
    
    foreign key (idRecetaE) references recetaEncabezado(idRecetaE),
    foreign key (idProducto) references producto(pkid)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

create table pedidoEncabezadoHoteleria(
	idPedidoE varchar(15) not null,
    idActividad varchar(15) not null,
    cantidad int not null,
    fecha date not null,
    total float not null,
    
    primary key (idPedidoE, idActividad),
    
    /*Llaves foráneas*/
    foreign key (idActividad) references actividadReservacion(idActividad)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

create table pedidoDetalleHoteleria(
	idPedidoE varchar(15) not null,
    idOrdenPedido int auto_increment not null,
    idActividad varchar(15) not null,
    idRecetaE varchar(15) not null,
    
    primary key (idOrdenPedido, idPedidoE, idActividad, idRecetaE),
    
    foreign key (idPedidoE) references pedidoEncabezadoHoteleria (idPedidoE),
    foreign key (idActividad) references actividadReservacion(idActividad),
    foreign key (idRecetaE) references recetaEncabezado (idRecetaE)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
