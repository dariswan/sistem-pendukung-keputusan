-- phpMyAdmin SQL Dump
-- version 4.7.7
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Nov 26, 2018 at 08:08 AM
-- Server version: 10.1.30-MariaDB
-- PHP Version: 7.2.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `dbwisatamalang`
--

-- --------------------------------------------------------

--
-- Table structure for table `wisata`
--

CREATE TABLE `wisata` (
  `id_wisata` int(3) NOT NULL,
  `nama` varchar(50) NOT NULL,
  `harga` int(7) NOT NULL,
  `rating` int(3) NOT NULL,
  `jam_op` int(2) NOT NULL,
  `jlh_pengunjung` int(3) NOT NULL,
  `jarak` int(5) NOT NULL,
  `prioritas` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `wisata`
--

INSERT INTO `wisata` (`id_wisata`, `nama`, `harga`, `rating`, `jam_op`, `jlh_pengunjung`, `jarak`, `prioritas`) VALUES
(1, 'Museum Brawijaya', 6000, 43, 8, 250, 3600, 0.0650864435492497),
(2, 'Kampung Jodipan', 6000, 38, 8, 400, 5200, 0.0666692968769736),
(3, 'Alun - Alun Malang', 3000, 44, 24, 320, 4400, 0.113252681907662),
(4, 'Hawai Waterpark', 80000, 43, 9, 450, 10100, 0.0156313439216556),
(5, 'Malang Night Paradise', 35000, 44, 5, 300, 9800, 0.0220515086031885),
(6, 'Alun - Alun Tugu', 3000, 45, 24, 150, 4200, 0.10339807622924),
(7, 'Kampung Tridi', 10000, 43, 8, 270, 5000, 0.0484083842987409),
(8, 'Candi Badut', 3000, 44, 10, 120, 5600, 0.0882532959960992),
(9, 'Wendit Water Park', 20000, 39, 10, 350, 7700, 0.0335971208798096),
(10, 'Brawijaya Edupark', 18000, 40, 9, 120, 3800, 0.0320059298107246),
(11, 'Taman Rekreasi Kota Malang', 5000, 39, 7, 130, 4500, 0.0636665467711099),
(12, 'Museum Kesehatan Jiwa', 3000, 39, 8, 90, 32200, 0.0740272537303076),
(13, 'Kampung Wisata Keramik Dinoyo', 3000, 42, 7, 250, 1200, 0.100116434633086),
(14, 'Wisma Tumapel', 8000, 39, 24, 80, 4400, 0.0537853053304122),
(15, 'Taman Tlogomas', 3000, 40, 24, 330, 1300, 0.12005037746174);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `wisata`
--
ALTER TABLE `wisata`
  ADD PRIMARY KEY (`id_wisata`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `wisata`
--
ALTER TABLE `wisata`
  MODIFY `id_wisata` int(3) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
