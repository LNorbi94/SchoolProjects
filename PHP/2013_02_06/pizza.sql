-- phpMyAdmin SQL Dump
-- version 3.2.4
-- http://www.phpmyadmin.net
--
-- Hoszt: localhost
-- Létrehozás ideje: 2013. febr. 06. 11:46
-- Szerver verzió: 5.1.41
-- PHP verzió: 5.3.1

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Adatbázis: `pizza`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet: `pizzak`
--

CREATE TABLE IF NOT EXISTS `pizzak` (
  `pizzanev` varchar(50) COLLATE latin2_hungarian_ci NOT NULL,
  `ar` int(50) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin2 COLLATE=latin2_hungarian_ci;

--
-- A tábla adatainak kiíratása `pizzak`
--

INSERT INTO `pizzak` (`pizzanev`, `ar`) VALUES
('Songoku', 1000);

-- --------------------------------------------------------

--
-- Tábla szerkezet: `rendeles`
--

CREATE TABLE IF NOT EXISTS `rendeles` (
  `pizzanev` varchar(50) COLLATE latin2_hungarian_ci NOT NULL,
  `felhasznalonev` varchar(50) COLLATE latin2_hungarian_ci NOT NULL,
  `DB` int(11) NOT NULL,
  `ar` int(11) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin2 COLLATE=latin2_hungarian_ci;

--
-- A tábla adatainak kiíratása `rendeles`
--


-- --------------------------------------------------------

--
-- Tábla szerkezet: `users`
--

CREATE TABLE IF NOT EXISTS `users` (
  `felhasznalonev` varchar(50) COLLATE latin2_hungarian_ci NOT NULL,
  `jelszo` varchar(50) COLLATE latin2_hungarian_ci NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin2 COLLATE=latin2_hungarian_ci;

--
-- A tábla adatainak kiíratása `users`
--

INSERT INTO `users` (`felhasznalonev`, `jelszo`) VALUES
('admin', 'admin'),
('norbi', 'jelszo');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
