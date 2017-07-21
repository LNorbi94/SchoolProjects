-- Feladat:
-- http://pnyf.inf.elte.hu/fp/WordSnake.xml


import Data.List -- group, sort
import Data.Function -- on

type Snake = [String]

mayStartWith :: [String] -> String
mayStartWith = nub . map head


startsWith :: Char -> [String] -> [String]
startsWith ch = filter ((==ch) . head)


endsWith :: Char -> [String] -> [String]
endsWith ch = filter ((==ch) . last)


snakeEndsWith :: Snake -> Char
snakeEndsWith = last . last


step :: Snake -> [String] -> [Snake]
step str l = [[head str, x ] | x <- l, snakeEndsWith str == head x]
-- VAGY step l list = [ l ++ [x] | x <- list, head x == (snakeEndsWith l)]


(<->) :: [String] -> Snake -> [String]
(<->) l list = [x | x <- l, not (elem x list)]


step' :: Snake -> [String] -> [Snake]
step' l list = [ l ++ [x] | x <- (list<->l), head x == (snakeEndsWith l)]


derive :: [Snake] -> [String] -> [Snake]
derive n l
 | concat [step' x l | x <- n] == [] = n
 | otherwise = n ++ derive (concat [step' x l | x <- n]) l


snakesStartingWith :: Char -> [String] -> [Snake]
snakesStartingWith ch l = derive (map (:[]) (startsWith ch l)) l


longestSnakeStartingWith :: Char -> [String] -> Snake
longestSnakeStartingWith ch l
 | not (elem ch (mayStartWith l)) = []
 | otherwise = maximumBy (compare `on` length) $ snakesStartingWith ch l
 
 
allSnakes :: [String] -> [Snake]
allSnakes l = concat [snakesStartingWith x l | x <- mayStartWith l]


longestSnake :: [String] -> Snake
longestSnake = maximumBy (compare `on` length) . allSnakes