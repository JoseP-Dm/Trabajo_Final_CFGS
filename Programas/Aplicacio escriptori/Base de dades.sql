-- phpMyAdmin SQL Dump
-- version 4.8.4
-- https://www.phpmyadmin.net/
--
-- Host: br6yuhxjtf6d9t43hrii-mysql.services.clever-cloud.com:3306
-- Generation Time: May 07, 2021 at 08:57 AM
-- Server version: 8.0.22-13
-- PHP Version: 7.2.34

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `br6yuhxjtf6d9t43hrii`
--

-- --------------------------------------------------------

--
-- Table structure for table `casos`
--

CREATE TABLE `casos` (
  `codi_cas` bigint NOT NULL,
  `codi_veterinari` bigint DEFAULT NULL,
  `codi_mascota` bigint DEFAULT NULL,
  `Data_Registre` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `Data_Revisio` date DEFAULT NULL,
  `Observacio` varchar(800) DEFAULT NULL,
  `pes` double DEFAULT NULL,
  `tractament` varchar(400) DEFAULT NULL,
  `medicaments` varchar(400) DEFAULT NULL,
  `enfermetats` varchar(400) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `casos`
--

INSERT INTO `casos` (`codi_cas`, `codi_veterinari`, `codi_mascota`, `Data_Revisio`, `Observacio`, `pes`, `tractament`, `medicaments`, `enfermetats`) VALUES
(1, 64264416524, 234341241234253, '2021-04-28', 'N/A', 6, 'Reposo', 'N/A', 'N/A'),
(2, 23426546545, 642654264443655, '2029-12-28', 'Castrar', 8, 'reposo', 'N/A', 'N/A'),
(3, 23426546545, 642654264443655, '2029-12-11', 'vomitos ', 8, 'dieta', 'N/A', 'mareos'),
(4, 23426546545, 123136425654656, NULL, 'Herida en pata trasera izquierda.\r\nPerdida de pelo.', 20, 'Curar herida de la pata.\r\nDar pastillas 3 veces al dia.', 'No se medicamentos para animales. Hibuprofeno, clorexidina, etc....', 'Ni idea de que poner'),
(5, 23426546545, 123123124532613, '2029-12-25', 'wetgsegqqwre', 97, 'fwergfwegf', 'wrgwergweg', 'rwfwqfe');

-- --------------------------------------------------------

--
-- Table structure for table `enfermetat`
--

CREATE TABLE `enfermetat` (
  `codi` int NOT NULL,
  `Enfermetat` varchar(60) NOT NULL,
  `Familia` varchar(60) DEFAULT NULL,
  `Categoria` varchar(30) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `enfermetat`
--

INSERT INTO `enfermetat` (`codi`, `Enfermetat`, `Familia`, `Categoria`) VALUES
(1, 'gastrointeritis', 'estomacal', 'normal'),
(2, 'gastrel', 'estomacal', 'grave'),
(3, 'masteris', 'linear', 'leve'),
(4, 'lunas', 'si', 'mortal');

-- --------------------------------------------------------

--
-- Table structure for table `mascota`
--

CREATE TABLE `mascota` (
  `codi` bigint NOT NULL,
  `Propietari` varchar(9) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `nom` varchar(20) DEFAULT NULL,
  `edat` date DEFAULT NULL,
  `enfermetat` varchar(60) DEFAULT NULL,
  `tractat` int DEFAULT NULL,
  `Especie` varchar(20) DEFAULT NULL,
  `raza` varchar(30) DEFAULT NULL,
  `sexo` varchar(30) DEFAULT NULL,
  `color` varchar(30) DEFAULT NULL,
  `Tamaño` varchar(20) DEFAULT NULL,
  `pelo` varchar(35) DEFAULT NULL,
  `castrado` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `peso` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `mascota`
--

INSERT INTO `mascota` (`codi`, `Propietari`, `nom`, `edat`, `enfermetat`, `tractat`, `Especie`, `raza`, `sexo`, `color`, `Tamaño`, `pelo`, `castrado`, `peso`) VALUES
(123123124532613, '09433726T', 'roce', '2020-11-10', NULL, NULL, 'Perro', 'bodegero', 'Hembra', 'blanco', 'Pequeño', 'Semi Largo', 'Sin Castrar', 5),
(123136425654656, '00685667Z', 'Janis', '2019-11-21', NULL, NULL, 'Ave', 'Carolina', 'Hembra', 'blanco', 'Pequeño', 'Semi Largo', 'Sin Castrar', 1),
(123145465323432, '33903434P', 'Perifollo', '2019-11-26', NULL, NULL, 'Ave', 'periquito', 'Hembra', 'verde', 'Pequeño', 'Corto', 'Sin Castrar', 0.55),
(123165426543652, '40961821V', 'Nemo', '2020-10-23', NULL, NULL, 'Reptil', 'iguana', 'Macho', 'marron claro', 'Pequeño', 'Corto', 'Sin Castrar', 2),
(131589465123513, '09433726T', 'Amiga', '2019-11-21', NULL, NULL, 'Roedor', 'jerbo', 'Hembra', 'gris', 'Pequeño', 'Corto', 'Sin Castrar', 3),
(231231243631224, '40961821V', 'Barbie', '2020-10-27', NULL, NULL, 'Ave', 'loro', 'Hembra', 'rojo', 'Pequeño', NULL, NULL, 0.6),
(231236541324165, '40961821V', 'Klaus', '2020-10-22', NULL, NULL, 'Perro', 'Pug', 'Macho', 'blanco', 'Pequeño', 'Corto', 'Sin Castrar', 5),
(231263541226354, '40961821V', 'Kush', '2020-10-15', NULL, NULL, 'Gato', 'Europeo', 'Macho', 'gris', 'Pequeño', 'Corto', 'Sin Castrar', 5),
(231431231343212, '33903434P', 'Estrellita', '2019-11-13', NULL, NULL, 'Perro', 'chihuahua', 'Hembra', 'marron claro', 'Pequeño', 'Corto', 'Castrado', 0.7),
(234312312431231, '09433726T', 'Cardamomo', '2019-11-21', NULL, NULL, 'Reptil', 'Camaleon', 'Macho', 'verde', 'Pequeño', 'Corto', 'Sin Castrar', 0.5),
(234341241234253, '33903434P', 'Sasha', '2019-11-07', NULL, NULL, 'Roedor', 'uron', 'Hembra', 'blanco', 'Pequeño', NULL, 'Sin Castrar', 1.5),
(426548468523565, '00685667Z', 'Mimo', '2019-11-15', NULL, NULL, 'Roedor', 'hamster', 'Macho', 'negro', 'Pequeño', 'Corto', 'Sin Castrar', 2),
(546466125616519, '09433726T', 'Bonji', '2020-08-13', NULL, NULL, 'Perro', 'Idiota', 'Macho', 'Negro', 'Grande', 'Corto', 'Sin Castrar', 75),
(642364564516425, '00685667Z', 'Latis', '2020-11-10', NULL, NULL, 'Gato', 'Europeo', 'Hembra', 'atigrado', 'Pequeño', 'Corto', 'Castrado', 6),
(642654264443655, '09433726T', 'Monet', '2019-11-21', NULL, NULL, 'Perro', 'bodegero', 'Macho', 'blanco', 'Pequeño', 'Semi Largo', 'Castrado', 5),
(652542654654123, '09433726T', 'Morena', '2019-11-21', NULL, NULL, 'Gato', 'Europeo', 'Hembra', 'marron', 'Pequeño', 'Corto', 'Castrado', 3),
(654654265162465, '00685667Z', 'Diedle', '2018-06-17', NULL, NULL, 'Perro', 'Shiba inu', 'Macho', 'blanco', 'Grande', 'Semi Largo', 'Sin Castrar', 24),
(673465468346542, '33903434P', 'Whester', '2019-11-19', NULL, NULL, 'Perro', 'Chow Chow', 'Macho', 'negro', 'mediano', 'Corto', 'Sin Castrar', 3);

-- --------------------------------------------------------

--
-- Table structure for table `propietari`
--

CREATE TABLE `propietari` (
  `nom` varchar(50) DEFAULT NULL,
  `DNI` varchar(9) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `t1` int DEFAULT NULL,
  `t2` int DEFAULT NULL,
  `Adreça` varchar(40) DEFAULT NULL,
  `CP` int DEFAULT NULL,
  `gmail` varchar(24) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `pass` varchar(12) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `propietari`
--

INSERT INTO `propietari` (`nom`, `DNI`, `t1`, `t2`, `Adreça`, `CP`, `gmail`, `pass`) VALUES
('ELIAS BORREGO CARRERA', '00685667Z', 625815553, 625815552, 'PLACETA HORNO, 64', 46012, 'eliasborrego@gmail.com', '1111'),
('EUSEBIO VERA VIVES', '09433726T', 685322005, 685322004, 'PLACETA DE ESPAÑA, 8', 3863, 'eusebiovera@gmail.com', '2222'),
('CESAR GRANDE DOMINGO', '33903434P', 764550751, 764550751, 'PASAJE NUEVA, 81', 17971, NULL, NULL),
('LUCIANO SOLE GRANDE', '40961821V', 632127648, 632127647, 'ESTRADA DE ESPAÑA, 93', 47119, NULL, NULL),
('carles', '65465466J', 625255483, 973656484, 'Arriba España', 56597, NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `veterinari`
--

CREATE TABLE `veterinari` (
  `codi` bigint NOT NULL,
  `nom` varchar(50) DEFAULT NULL,
  `clinica` varchar(50) DEFAULT NULL,
  `Usuari` varchar(3) DEFAULT NULL,
  `password` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `veterinari`
--

INSERT INTO `veterinari` (`codi`, `nom`, `clinica`, `Usuari`, `password`) VALUES
(23426546545, 'JOAQUIN ESTEBAN POZO', 'Hospital Veterinari de Mollerussa', 'jep', 2222),
(54265453462, 'Lucia teresa de la huerta de plata', 'el campos', 'lth', 1234),
(64264416524, 'ALEJANDRO HERVAS MORAL', 'Centre Veterinari del Pla', 'ahm', 3333),
(65413232132, 'MAR ZAPATA BELLO', 'Clínica Veterinària Quiros', 'maz', 1111);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `casos`
--
ALTER TABLE `casos`
  ADD PRIMARY KEY (`codi_cas`),
  ADD KEY `codi_veterinari` (`codi_veterinari`),
  ADD KEY `codi_mascota` (`codi_mascota`);

--
-- Indexes for table `enfermetat`
--
ALTER TABLE `enfermetat`
  ADD PRIMARY KEY (`codi`,`Enfermetat`);

--
-- Indexes for table `mascota`
--
ALTER TABLE `mascota`
  ADD PRIMARY KEY (`codi`),
  ADD KEY `Propietari` (`Propietari`),
  ADD KEY `tractat` (`tractat`),
  ADD KEY `enfermetat` (`enfermetat`);

--
-- Indexes for table `propietari`
--
ALTER TABLE `propietari`
  ADD PRIMARY KEY (`DNI`),
  ADD UNIQUE KEY `gmail` (`gmail`);

--
-- Indexes for table `veterinari`
--
ALTER TABLE `veterinari`
  ADD PRIMARY KEY (`codi`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `casos`
--
ALTER TABLE `casos`
  MODIFY `codi_cas` bigint NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `casos`
--
ALTER TABLE `casos`
  ADD CONSTRAINT `casos_ibfk_2` FOREIGN KEY (`codi_mascota`) REFERENCES `mascota` (`codi`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `casos_ibfk_3` FOREIGN KEY (`codi_veterinari`) REFERENCES `veterinari` (`codi`) ON DELETE RESTRICT ON UPDATE RESTRICT;

--
-- Constraints for table `mascota`
--
ALTER TABLE `mascota`
  ADD CONSTRAINT `mascota_ibfk_1` FOREIGN KEY (`Propietari`) REFERENCES `propietari` (`DNI`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
