-- Feladat linkje:
-- http://pnyf.inf.elte.hu/fp/IBAN.xml

import Data.Char -- ord

data IBAN = IBAN String
 deriving (Eq,Show) -- Typeable,Data
 
type Codes = [(String,Int)]
codes :: Codes
codes = [("GB",22),("GR",27),("SA",24),("CH",21),("IL",23)]


---------------------------------------------

isValidBlock :: String -> Bool
check ch = elem ch ['A'..'Z'] || elem ch ['0'..'9']
isValidBlock l
 | length l /= 4 = False
 | otherwise = foldr (&&) True [check ch | ch <- l]
-- isValidBlock "12.1" == False
-- isValidBlock "12A1" = True

---------------------------------------------

isValidCountryCode :: String -> Bool
isValidCountryCode l = elem l (map fst codes)
-- isValidCountryCode "HU" == False
-- isValidCountryCode "GB" == True

---------------------------------------------

getLength :: String -> Int
getLength l = snd $ head $ filter ((== l) . fst) codes
-- getLength "GB" == 22

---------------------------------------------

pack :: String -> String
pack = concat . words
-- VAGY 	pack l = [x | x <- l, x /= ' ']
-- pack "GR16 0110 1250 0000 0001 2300 695" == "GR1601101250000000012300695"

---------------------------------------------

isWellFormed :: String -> Bool
isWellFormed [] = False
isWellFormed [x] = False
isWellFormed l@(x:y:xs)
 | isValidCountryCode [x,y] == False = False
 | length (pack l) /= getLength [x,y] = False
 | otherwise = foldr (&&) True $ map isValidBlock $ init $ words l
-- isWellFormed "GB29 NW BK60 161331 9 268 19" == False
-- isWellFormed "SA03 8000 0000 6080 1016 7519" == True

---------------------------------------------

resolve :: String -> String
resolve [] = []
resolve (x:xs)
 | not (elem x ['A'..'Z']) = x : resolve xs
 | otherwise = (show $ snd $ head $ filter ((== x) . fst) szamok) ++ resolve xs
  where
   szamok = zip ['A'..'Z'] [10..]
-- resolve "123456789ABC" == "123456789101112"

---------------------------------------------

numerize :: String -> Integer
numerize [] = 0
numerize l@(x:xs) = (10^(length l - 1) * fromIntegral (digitToInt x)) + numerize xs
-- numerize "0000001234" == 1234
-- numerize "af" == 115	

---------------------------------------------

isValidIBAN :: String -> Bool
isValidIBAN l = mod (numerize $ resolve (drop 4 l ++ take 4 l)) 97 == 1
-- isValidIBAN "GB29NWBK60161331926819" == True

---------------------------------------------

fromString :: String -> Maybe IBAN
fromString l
 | isValidIBAN (pack l) = Just (IBAN (pack l))
 | otherwise = Nothing
-- fromString "GR16 0110 1250 0000 0001 2300 695" == Just (IBAN "GR1601101250000000012300695")