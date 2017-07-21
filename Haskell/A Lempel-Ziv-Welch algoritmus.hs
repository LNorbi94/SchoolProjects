-- Feladat linkje:
-- http://pnyf.inf.elte.hu/fp/LZW.xml

import Data.Char -- chr, ord
import Data.List -- maximumBy
import Data.Function -- on


dictionary :: [String]
dictionary = [[chr n] | n <- [0..127]]


prefixes :: String -> [String] -> [(Int,String)]
prefixes l list = [x | x <- (zip [0..] list), isPrefixOf (snd x) l]
-- prefixes "almafa" ["al","alma","fa"] == [(0, "al"), (1, "alma")]


longest :: [(Int,String)] -> (Int,String)
longest l = maximumBy (compare `on` snd) l
-- longest [ (0,"abc"), (1,"dab"), (2,"bb") ] == (1, "dab")


munch :: [String] -> String -> (Int,String,String)
munch fromList l = (fst list, snd list, drop (length (snd list)) l)
  where list = longest $ prefixes l fromList 
-- munch (dictionary ++ ["al","alm"]) "almafa" == (129, "alm", "afa")


append :: [String] -> String -> String -> [String]
append fromList l1 [] = fromList
append fromList l1 l2 = fromList ++ [l1++[head l2]]
-- append dictionary "a" "" == dictionary
-- append dictionary "a" "lmafa" == (dictionary ++ ["al"])


encode :: [String] -> String -> [Int]
encode _ [] = []
encode fromList l = a : encode (append fromList b c) c
  where (a,b,c) = munch fromList l
-- encode dictionary "aaa" == [97, 128] 


compress :: String -> String
compress = map chr . encode dictionary
-- compress "lalalala" == la\128\130a"
-- compress "aaabbbccc" == "a\128b\130c\132"


decode :: [String] -> [Int] -> String
decode _ [] = []
decode list [x] = list!!x
decode list (x:y:xs)
 | length list > y = list!!x ++ decode (append list (list!!x) (list!!y)) (y:xs)
 | otherwise = list!!x ++ decode (append list (list!!x) (list!!x)) (y:xs) 
-- decode dictionary [97,128] == "aaa"
-- decode dictionary [108,97,128,130,97] 						== "lalalala"


decompress :: String -> String
decompress = decode dictionary . map ord
-- decompress "a\128" == "aaa"