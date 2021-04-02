DELIMITER '//'
INSERT INTO cochesdaw.usuario
(id, user, passwd, tipoUsuario, nombre, direccion, telefono)
VALUES
(NULL, 'JuanitoX', 'secret', 'user', 'Juan Perez', 'dir eccion', '01234'),
(NULL, 'mariavergara19', 'supersecret', 'user', 'Maria Vergara', 'dir accion', '04321'),
(NULL, 'xXsuperadminXx', 'cringelord', 'admin', 'Juan Nieves', 'dir rid', '00000')
//
INSERT INTO cochesdaw.coche
(id, nombre, descripcion, marca, modelo, motor, anyo, precio, img)
VALUES
(NULL, 'FIAT 500', 'FIAT pequenyo', 'FIAT', '500', 'motor', '2019', 14000, 'route/to/imgage.png'),
(NULL, 'LAMBO AVENTADOR S', 'Expensive car', 'LAMBORGHINI', 'AVENTADOR', 'V12', '2021', 140000, 'route/to/imgage.png'),
(NULL, 'FORD MUSTANG 5.0 GT', '4rd', 'FORD', 'MUSTANG', 'V8', '2020', 48000, 'route/to/imgage.png'),
(NULL, 'Ferrari SF90 SPIDER', 'Hibrido', 'FERRARI', 'SF90SPIDER', 'V8', '2021', 69000, 'route/to/imgage.png'),
(NULL, 'ALFA ROMEO GIULIA SPRINT PLUS 190 CV', 'Long name is long', 'ALFAROMEO', 'GIULIA', 'V8', '2021', 38000, 'route/to/imgage.png'),
(NULL, 'TOYOTA YARIS ACTIVE TECH', 'tyt', 'TOYOTA', 'YARIS', 'V8', '2021', 36000, 'route/to/imgage.png')
//
INSERT INTO cochesdaw.stock
(idCoche, unidades)
VALUES
(1, 10),
(2, 10),
(3, 10),
(4, 10),
(5, 10),
(6, 10)
//
INSERT INTO cochesdaw.pedido
(id, idCliente, precioTotal)
VALUES
(NULL, 1, 84000),
(NULL, 1, 69000),
(NULL, 2, 140000)
//
INSERT INTO cochesdaw.lineapedido
(id, idPedido, idCoche, precioCoche)
VALUES
(NULL, 1, 3, 48000),
(NULL, 1, 6, 36000),
(NULL, 2, 4, 69000),
(NULL, 3, 2, 140000)
//