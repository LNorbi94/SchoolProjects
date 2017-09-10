-- phpMyAdmin SQL Dump
-- version 3.2.4
-- http://www.phpmyadmin.net
--
-- Hoszt: localhost
-- Létrehozás ideje: 2013. febr. 27. 11:24
-- Szerver verzió: 5.1.41
-- PHP verzió: 5.3.1

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Adatbázis: `webshop`
--
CREATE DATABASE `webshop` DEFAULT CHARACTER SET latin2 COLLATE latin2_hungarian_ci;
USE `webshop`;

-- --------------------------------------------------------

--
-- Tábla szerkezet: `kosar`
--

CREATE TABLE IF NOT EXISTS `kosar` (
  `ID` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `user` varchar(50) COLLATE latin2_hungarian_ci NOT NULL,
  `termek` varchar(50) COLLATE latin2_hungarian_ci NOT NULL,
  `darab` int(50) NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID` (`ID`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin2 COLLATE=latin2_hungarian_ci AUTO_INCREMENT=10 ;

--
-- A tábla adatainak kiíratása `kosar`
--


-- --------------------------------------------------------

--
-- Tábla szerkezet: `termekek`
--

CREATE TABLE IF NOT EXISTS `termekek` (
  `ID` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `nev` varchar(50) COLLATE latin2_hungarian_ci NOT NULL,
  `kep` varchar(50) COLLATE latin2_hungarian_ci NOT NULL,
  `raktaron` int(11) NOT NULL,
  `darabar` int(50) NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID` (`ID`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin2 COLLATE=latin2_hungarian_ci AUTO_INCREMENT=15 ;

--
-- A tábla adatainak kiíratása `termekek`
--

INSERT INTO `termekek` (`ID`, `nev`, `kep`, `raktaron`, `darabar`) VALUES
(1, 'Banán', 'img/banan.jpg', 20, 1000),
(3, 'Alma', 'img/alma.jpg', 4, 200),
(4, 'Dinnye', 'img/dinnye.jpg', 20, 400);

-- --------------------------------------------------------

--
-- Tábla szerkezet: `users`
--

CREATE TABLE IF NOT EXISTS `users` (
  `ID` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `user` varchar(20) COLLATE latin2_hungarian_ci NOT NULL,
  `password` varchar(100) COLLATE latin2_hungarian_ci NOT NULL,
  `tipus` varchar(50) COLLATE latin2_hungarian_ci NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID` (`ID`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin2 COLLATE=latin2_hungarian_ci AUTO_INCREMENT=9 ;

--
-- A tábla adatainak kiíratása `users`
--

INSERT INTO `users` (`ID`, `user`, `password`, `tipus`) VALUES
(6, 'bla1', 'c4ca4238a0b923820dcc509a6f75849b', 'felhasznalo'),
(5, 'bla', '128ecf542a35ac5270a87dc740918404', 'felhasznalo'),
(7, 'Norbi', 'efc847fa5a386a38fcc9d0573bb87272', 'kereskedo'),
(8, 'valaki', 'a566108566847a20ebe77fb60ff29ad6', 'felhasznalo');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
