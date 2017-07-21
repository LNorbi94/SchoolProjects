-- Feladat linkje:
-- http://pnyf.inf.elte.hu/fp/Z.xml


roman :: Integral a => [a]
roman = [1,1,1,4,5,9,10,10,10,40,50,90,100,100,100,400,500,900,1000,1000]

time :: Integral a => [a]
time = makeSystem [60,60,24,7,52]


elemsForZ :: Integral a => a -> [a] -> [a]
elemsForZ n = reverse . takeWhile (<=n)


remainingElems :: Integral a => a -> [a] -> [a]
remainingElems n = filter (<=n)


z :: Integral a => [a] -> a -> [a]
z' _ [] = []
z' 0 _ = []
z' n (x:xs)
 | x <= n = x: z' (n-x) xs
 | x > n = z' n xs
z l n = z' n $ remainingElems n $ elemsForZ n l


fibs :: Integral a => [a]
fibs = map fst $ iterate (\(a,b) -> (b,a+b)) (1,1)


zFromFibs :: Integral a => a -> [a]
zFromFibs n = z fibs n


powersOf2 :: Integral a => [a]
powersOf2 = [2^n | n <- [0..]]


zFromPowersOf2 :: Integral a => a -> [a]
zFromPowersOf2 n = z powersOf2 n


powersFor10 :: Integral a => [a]
powersFor10 = concat $ iterate (map (*10)) (replicate 9 1)


zFromPowersFor10 :: Integral a => a -> [a]
zFromPowersFor10 n = z powersFor10 n


toRoman :: Integral a => a -> String
toRoman n
 | n == 1 = "I"
 | n == 4 = "IV"
 | n == 5 = "V"
 | n == 9 = "IX"
 | n == 10 = "X"
 | n == 40 = "XL"
 | n == 50 = "L"
 | n == 90 = "XC"
 | n == 100 = "C"
 | n == 400 = "CD"
 | n == 500 = "D"
 | n == 900 = "CM"
 | n == 1000 = "M"
 | otherwise = error "toRoman: No roman numeral is assigned to the given number."

 
zToRoman :: Integral a => a -> String
zToRoman n = concat $ map toRoman $ z roman n


makeSystem :: Integral a => [a] -> [a]
produktum [] = [1]
produktum l = product l : produktum (init l)

replikatum [] _ = []
replikatum _ [] = []
replikatum (x:xs) (y:ys) = replicate (fromIntegral x) y ++ replikatum xs ys

makeSystem l = replikatum l (reverse (produktum l))


showInteger :: Integral a => a -> String
showInteger n = show (fromIntegral n)


showTime :: Integral a => a -> String
ch x str
 | x > 0 = (showInteger x) ++ str
 | otherwise = []
 
count n b = length $ filter (== n) b

showTime n = ch w "w" ++ ch d "d" ++ ch h "h" ++ ch m "m" ++ ch s "s"
  where
   zs = z time n
   w = count 604800 zs
   d = count 86400 zs
   h = count 3600 zs
   m = count 60 zs
   s = count 1 zs