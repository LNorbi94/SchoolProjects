-- Feladat linkje:
-- http://pnyf.inf.elte.hu/fp/LinkExtractor.xml


import Data.Char -- intToDigit
import Data.List -- nub

type Link = String

isLink :: String -> Bool
isLink [] = False
isLink str = [head str,last str] == "<>"


getLink :: String -> Link
getLink (x:xs) = init xs


itoa :: Int -> String
itoa x
 |x < 10 = [intToDigit x]
 |otherwise= itoa (x `div` 10) ++ [intToDigit (x `mod` 10)]
--itoa x = show x
 
	
formatIndex :: Int -> String
formatIndex n = "[" ++ itoa n ++ "]"


indexLinks :: [String] -> [(Int, Link)]
indexLinks = zip [1..] . map getLink . nub . filter isLink


linkIndex :: [(Int, Link)] -> Link -> Int
linkIndex lst lnk= fst $ head (dropWhile (\(x,y) -> y/=lnk) lst)
-- linkIndex l link = head [fst x | x <-l, snd x == link]


listLinks :: [(Int, Link)] -> String
listLinks = concat . map (\(a,b) -> formatIndex a ++ " " ++ b ++ "\n")


convertLinks :: [String] -> ([String], [(Int, Link)])
convertLinks lst = (y,z)
 where
  y = map helper lst
  z = indexLinks lst
  helper x
   | isLink x = formatIndex(linkIndex z (getLink x))
   | otherwise = x


extractLinks :: String -> String
extractLinks str
 |y == [] = unwords x
 |otherwise = (unwords x) ++ "\n\n" ++ (listLinks y)
  where (x,y) = convertLinks(words str)