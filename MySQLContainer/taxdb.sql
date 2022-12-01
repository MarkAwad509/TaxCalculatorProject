-- version 5.1.4
--
-- Host: mysql-generalhost.alwaysdata.net
-- Generation Time: Dec 01, 2022 at 06:38 AM
-- Server version: 10.6.7-MariaDB
-- PHP Version: 7.4.19
CREATE DATABASE IF NOT EXISTS TaxDB;
USE TaxDB;

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `TaxDB`
--

-- --------------------------------------------------------

--
-- Table structure for table `TaxRates`
--

CREATE TABLE `TaxRates` (
  `Id` int(11) NOT NULL,
  `Low` int(11) NOT NULL,
  `High` int(11) NOT NULL,
  `Rate` float NOT NULL,
  `Type` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `TaxRates`
--

INSERT INTO `TaxRates` (`Id`, `Low`, `High`, `Rate`, `Type`) VALUES
(1, 0, 49020, 15, 0),
(2, 49020, 98040, 20.5, 0),
(3, 98040, 151978, 26, 0),
(4, 151978, 216511, 29, 0),
(5, 216511, 1000000000, 33, 0),
(6, 0, 46295, 15, 1),
(7, 46295, 92580, 20, 1),
(8, 92580, 112655, 24, 1),
(9, 112655, 100000000, 25.75, 1);

-- --------------------------------------------------------

--
-- Table structure for table `__EFMigrationsHistory`
--

CREATE TABLE `__EFMigrationsHistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `__EFMigrationsHistory`
--

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`) VALUES
('20221116150942_Initial-Migration', '6.0.11');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `TaxRates`
--
ALTER TABLE `TaxRates`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `__EFMigrationsHistory`
--
ALTER TABLE `__EFMigrationsHistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `TaxRates`
--
ALTER TABLE `TaxRates`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
