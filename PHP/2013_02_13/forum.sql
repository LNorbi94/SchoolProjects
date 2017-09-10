-- phpMyAdmin SQL Dump
-- version 3.2.4
-- http://www.phpmyadmin.net
--
-- Hoszt: localhost
-- Létrehozás ideje: 2013. febr. 13. 09:43
-- Szerver verzió: 5.1.41
-- PHP verzió: 5.3.1

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Adatbázis: `forum`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet: `forum`
--

CREATE TABLE IF NOT EXISTS `forum` (
  `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `username` varchar(30) COLLATE latin2_hungarian_ci NOT NULL,
  `message` varchar(2000) COLLATE latin2_hungarian_ci NOT NULL,
  UNIQUE KEY `id` (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin2 COLLATE=latin2_hungarian_ci AUTO_INCREMENT=1 ;

--
-- A tábla adatainak kiíratása `forum`
--


-- --------------------------------------------------------

--
-- Tábla szerkezet: `ugly`
--

CREATE TABLE IF NOT EXISTS `ugly` (
  `expression` varchar(100) COLLATE latin2_hungarian_ci NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin2 COLLATE=latin2_hungarian_ci;

--
-- A tábla adatainak kiíratása `ugly`
--

INSERT INTO `ugly` (`expression`) VALUES
('agyatlan'),
('bolond'),
('böszme'),
('buta'),
('ciki'),
('csacsi'),
('dinka'),
('éretlen'),
('fafej'),
('gyagyás'),
('hülye'),
('idétlen'),
('jellemtelen'),
('komisz'),
('lusta'),
('mafla'),
('nulla'),
('ostoba'),
('pipogya'),
('rendetlen'),
('süsü'),
('tuskó'),
('undok'),
('vacak'),
('zsivány');

-- --------------------------------------------------------

--
-- Tábla szerkezet: `users`
--

CREATE TABLE IF NOT EXISTS `users` (
  `username` varchar(30) COLLATE latin2_hungarian_ci NOT NULL,
  `password` varchar(200) COLLATE latin2_hungarian_ci NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin2 COLLATE=latin2_hungarian_ci;

--
-- A tábla adatainak kiíratása `users`
--


/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
