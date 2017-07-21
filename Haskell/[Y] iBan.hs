{-# LANGUAGE DeriveDataTypeable #-}
 
import Data.Char
import Data.Typeable
import Data.Data

isValidBlock :: String -> Bool
isValidBlock [] = False
isValidBlock x = length x <= 4 && length [y | y<-x, elem y ['a'..'z']] == 0

type Codes = [(String,Int)]
codes :: Codes
codes = [("GB",22),("GR",27),("SA",24),("CH",21),("IL",23)]

isValidCountryCode :: String -> Bool
isValidCountryCode x = elem x [y | y<-(map fst codes)]

getLength :: String -> Int
getLength x
  | length list /= 0 =  list !! 0
  | otherwise = 0
   where list =  [z | (y,z)<-(codes), y == x]

pack :: String -> String
pack x = filter (/=' ') x

isWellFormed :: String -> Bool
isWellFormed x@(y:z:xs)
  | not (isValidCountryCode countryCode) || not (getLength countryCode == length (pack x)) = False
  | otherwise = length [y | y<-words x, isValidBlock y] == length (words x)
    where countryCode = [y] ++ [z]

move :: String -> String
move [] = []
move x = drop 4 x ++ take 4 x

resolve :: String -> String
resolve [] = []
resolve (x:xs)
  | isNumber x = x : resolve xs
  | elem x ['A'..'Z'] = (show ([snd z | z<-(zip ['A'..'Z'] [10..]), (fst z)==x] !! 0) :: [Char]) ++ resolve xs
  | otherwise = resolve xs

numerize :: String -> Integer
numerize [] = 0
numerize x = read x

isValidIBAN :: String -> Bool
isValidIBAN [] = False
isValidIBAN x = numerize (resolve (move x)) `mod` 97 == 1

data IBAN = IBAN String
       deriving (Show, Eq, Typeable, Data)
 
toIBAN :: String -> IBAN
toIBAN x = IBAN (filter (/=' ') x)
fromString x
  | isValidIBAN (pack x) = Just (toIBAN x)
  | otherwise = Nothing