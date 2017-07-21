-- Feladat linkje:
-- http://pnyf.inf.elte.hu/fp/CodeBreaker.xml


data Code = Code Char Char Char Char
  deriving (Eq, Ord, Show)


blackStones :: (Eq a) => [a] -> [a] -> Int
blackStones l1 l2 = length [x | x <- (zip l1 l2), fst x == snd x]
-- blackStones [6,6,6,1] [6,6,5,1] == 2


whiteStones :: (Eq a) => [a] -> [a] -> Int
whiteStones l1 l2 = length $ map fst [ n | n <- list, elem (fst n) (map snd list)]
  where list = [x | x <- (zip l1 l2), fst x /= snd x]
-- whiteStones [4,2,7,1] [1,2,3,4] == 2
-- whiteStones [6,6,6,1] [6,6,5,1] == 0


readCode :: String -> Maybe Code
readCode l
 | length l /= 4 = Nothing
 | otherwise = Just(Code (l!!0) (l!!1) (l!!2) (l!!3))
-- readCode "12345" == Nothing
-- readCode "1234" == Just (Code '1' '2' '3' '4')


toList :: Code -> [Char]
toList (Code a b c d) = [a,b,c,d]
-- toList (Code '1' '2' '3' '4') == "1234"


whiteAndBlackStones :: Code -> String -> (Int,Int)
whiteAndBlackStones c l
 | readCode l == Nothing = (0,0)
 | otherwise = (whiteStones (toList c) l, blackStones (toList c) l)
-- whiteAndBlackStones (Code '4' '2' '7' '1') "1234" == (2,1)