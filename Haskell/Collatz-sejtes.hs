-- Feladat linkje:
-- http://pnyf.inf.elte.hu/fp/Collatz.xml


f :: Integer -> Integer
f 1 = 1
f n
 | even n = div n 2
 | otherwise = 3*n+1

 
applyTo :: Integer -> [Integer]
applyTo n = n : applyTo (f n)
-- applyTo = iterate f


cutRepeated :: Eq a => [a] -> [a]
cutRepeated [] = []
cutRepeated [x] = [x]
cutRepeated (x:y:xs)
 | x == y = [x]
 | otherwise = x : cutRepeated (y:xs)


reducedApplyTo :: Integer -> [Integer]
reducedApplyTo = cutRepeated . applyTo


runSize :: Integer -> Int
runSize = length . reducedApplyTo


runSizes :: [Int]
runSizes = map runSize [1..]


increasingly :: (a -> a -> Bool) -> [a] -> [a]
increasingly _ [] = []
increasingly _ [x] = [x]
increasingly p (x:y:xs)
 | p x y = x : increasingly p (y:xs)
 | otherwise = increasingly p (x:xs)


 
increasingSizes :: [Int]
increasingSizes = increasingly (<) runSizes


increasingNumbersByRun :: [Integer]
increasingNumbersByRun = map snd $ increasingly (<) $ zip runSizes [1..]