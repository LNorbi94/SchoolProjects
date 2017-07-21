-- Feladat linkje:
-- http://pnyf.inf.elte.hu/fp/Morse.xml

import Data.List -- sort
import Data.Char -- toUpper
import Data.Function -- on

morseTab :: [(Char, String)]
morseTab =
  [('A',".-"),('B',"-..."),('C',"-.-."),('D',"-.."),('E',".")
  ,('F',"..-."),('G',"--."),('H',"...."),('I',".."),('J',".---")
  ,('K',"-.-"),('L',".-.."),('M',"--"),('N',"-."),('O',"---")
  ,('P',".--."),('Q',"--.-"),('R',".-."),('S',"..."),('T',"-")
  ,('U',"..-"),('V',"...-"),('W',".--"),('X',"-..-")
  ,('Y',"-.--"),('Z',"--..")
  ]
  
  
normalizeText :: String -> String
normalizeText l = [toUpper x | x <- l, elem x ['A'..'Z'] || elem x ['a'..'z']]
-- normalizeText "asd...12aAA" == "ASDAAA" :: String


charToCode :: [(Char,String)] -> Char -> String
charToCode fromList ch = head [snd x | x <- fromList, fst x == toUpper ch]
-- charToCode morseTab 'A' == ".-" :: String


encodeToWords :: String -> [String]
encodeToWords = map (charToCode morseTab)
-- encodeToWords "SOS" == ["...", "---", "..."] :: [String]


encodeString :: String -> String
encodeString = concat . encodeToWords
-- encodeString "SOS" == "...---..." :: String


codeToChar :: [(a,String)] -> String -> a
codeToChar fromList l = head [fst x|x<-fromList,snd x == l]
-- codeToChar morseTab "...-" == 'V' :: Char


decodeWords :: [String] -> String
decodeWords = map (codeToChar morseTab)
-- decodeWords ["...","---","..."] == "SOS" :: String


withShortestCodes :: [(Char,String)] -> [Char]
withShortestCodes l = map fst [x | x <- l, length (snd x) == (head $ sort $ map (length . snd) l)]
-- withShortestCodes morseTab == "ET" :: String


getPossiblePrefixes :: [(Char,String)] -> String -> [(Char,String)]
getPossiblePrefixes fromList l = sortBy (compare `on` fst) [(codeToChar fromList (take n l),take n l) | n <- [1..length l], elem (take n l) (map snd fromList)]
-- getPossiblePrefixes morseTab ".-." == [('A',".-"),('E',"."),('R',".-.")]


decodeString :: String -> [String]
decodeString [] = [[]]
decodeString l = [fst x : y | x <- (getPossiblePrefixes morseTab l), y <- decodeString (drop (length (snd x)) l)]
-- decodeString ".-." == ["AE","EN","ETE","R"]