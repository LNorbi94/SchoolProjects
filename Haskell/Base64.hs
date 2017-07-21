-- Feladat linkje:
-- http://pnyf.inf.elte.hu/fp/Base64.xml


import Data.Char -- ord,chr

type Entry = (Int, Char)
type Dictionary = [Entry]
type BitString = [Int]


dictionary :: Dictionary
dictionary = zip [0..] (['A'..'Z']++['a'..'z']++['0'..'9']++"+/")
-- VAGY
-- dictionary = zip [0..] "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/"


pad :: ([a] -> [a] -> [a]) -> a -> Int -> [a] -> [a]
pad p ch n list = p (replicate (n - length list) ch) list
-- pad (\p l -> l ++ p) '0' 5 "11" == "11000"
-- pad (\p l -> p ++ l) '0' 5 "11" == "00011"


toBitString :: Int -> BitString
toBitString 0 = []
toBitString n = toBitString (div n 2) ++ [mod n 2]
-- toBitString 5 == [1,0,1]
 
 
fromBitString :: BitString -> Int
fromBitString = sum . map (\(a,b)->2^a*b) . zip [0..] . reverse
-- fromBitString [1,0,1] == 5


toBinary :: String -> BitString
toBinary = concat . map ((pad (\p -> (p ++)) 0 8) . toBitString . ord)
-- toBinary "Pl" == [0,1,0,1,0,0,0,0,0,1,1,0,1,1,0,0]


chunksOf :: Int -> [a] -> [[a]]
chunksOf n l
 | n <= 0 = error "chunksOf: Invalid chunk length"
 | null l = []
 | otherwise = take n l : chunksOf n (drop n l)
-- chunksOf 2 [1..10] == [[1,2],[3,4],[5,6],[7,8],[9,10]]
 
 
findFirst :: (a -> Bool) -> [a] -> a
findFirst p l
 | null(filter p l) = error "findFirst: No such entry"
 | otherwise = head $ filter p l
-- findFirst (<4) [1..10] == 1 


findChar :: Dictionary -> BitString -> Char
findChar fromList l = snd $ fromList !! findFirst (==(fromBitString l)) [0..length fromList-1]
-- findChar dictionary [1,0,1] == 'F'

translate :: Dictionary -> String -> String
translate fromList l = map (findChar fromList) $ chunksOf 6 $ pad (\p -> (++ p)) 0 (findFirst (\ a -> mod a 6 == 0) [length (toBinary l)..]) (toBinary l)
-- translate dictionary "Pl" == "UGw"


encode :: Dictionary -> String -> String
encode fromList l = pad (\p -> (++ p)) '=' (findFirst (\n -> mod n 4 == 0) [length (translate fromList l)..]) (translate fromList l)
--  encode dictionary "Pl" == "UGw="


findCode :: Dictionary -> Char -> BitString
findCode fromList ch = toBitString $ head [fst x | x<- fromList, snd x == ch]
-- findCode dictionary 'F' == [1,0,1]


decode :: Dictionary -> String -> String
decode fromList = map (chr . fromBitString) . filter ((==8).length) . chunksOf 8 . concat . map ((pad (\p -> (p ++)) 0 6) . findCode fromList) . takeWhile (/='=')
-- decode dictionary "UGw" == "Pl"
-- decode dictionary "UGw=" =="Pl"