type Base   = Int
type BigNum = [Int]

toBigNum :: Base -> Integer -> BigNum
toBigNum base x
  | x < 0 = 
      error ("toBigNum: improper arguments: " ++ (show x) ++ " " ++ (show base))
  | x == 0 = [0]
  | solution /= 0 = fromIntegral remainder : toBigNum base solution
  | otherwise = [fromIntegral remainder]
    where xFi = fromIntegral x
          solution = x `div` (fromIntegral base)
          remainder = x `mod` (fromIntegral base)
   
fromBigNum :: Base -> BigNum -> Integer
fromBigNum _ [0] = 0
fromBigNum base x
  | xT /= 0 =
     toInteger $ toInteger (last x) * toInteger base^xT + fromBigNum base (init x)
  | otherwise = fromIntegral (x !! 0)
     where xT = (length (tail x))
	
pad :: ([a] -> [a] -> [a]) -> a -> Int -> [a] -> [a]
pad function e nSize list = 
   function (take (nSize - length list) $ repeat e) list

padLeft :: a -> Int -> [a] -> [a]
padLeft e nSize list = pad (\p list -> (p ++ list)) e nSize list

padRight :: a -> Int -> [a] -> [a]
padRight e nSize list = pad (\p list -> (list ++ p)) e nSize list

(<=>) :: BigNum -> BigNum -> (BigNum, BigNum)
(<=>) x y
  | length x > length y = (x, padRight 0 (length x) y)
  | otherwise = (padRight 0 (length y) x, y)
  
-- length?
inc :: BigNum -> Int -> BigNum
inc x y = [head x + y] ++ x
addBigNums _ [0] x = x
addBigNums _ x [0] = x
addBigNums base xL yL
  | xs == [] && eqBase = [0] ++ [1]
  | xs == [0] && eqBase = [0] ++ [solution+1]
  | xySum >= base && hXs > hYs = remainder : addBigNums base xs (inc ys solution)
  | xySum > base = remainder : addBigNums base (inc xs solution) ys
  | otherwise = x + y : addBigNums base xs ys
   where (x:xs, y:ys) = xL <=> yL; 
                xySum = (x + y);
                eqBase = xySum == base;
             solution = xySum `div` base;
            remainder = xySum `mod` base;
                  hXs = head xs;
                  hYs = head ys
---------------------------------------------------------------------------------------

cut :: Num a => [a] -> a -> [a]
cut (x:xs) y
  | length xs >= 0 = x+y : xs
  | otherwise = [x+y]
addBigNums :: Base -> BigNum -> BigNum -> BigNum
addBigNums b x y
  | x == [0] = y
  | y == [0] = x
  | su >= b && length d == 1 && (head d /= 0) = [0] ++ [(dsu+(head d))]
  | su >= b && length c == 1 = [0] ++ [(dsu+(head c))]
  | su >= b && (head c > head d) = 0:addBigNums b c (cut d dsu)
  | su >= b = 0:addBigNums b (cut c dsu) d
  | otherwise = su:addBigNums b c d
   where (cx:c,cy:d) = (x <=> y)
         su = (cx + cy)
         dsu = div su b
 
sumBigNums :: Base -> [BigNum] -> BigNum
sumBigNums _ [] = []
sumBigNums b l@(x:y:xs)
  | length l > 2 = sumBigNums b (xs ++ [addBigNums b x y])
  | length l == 2 = addBigNums b x y
  | otherwise = x
  
minus x b
  | x < 0 = b - abs(x)
  | otherwise = x
subBigNums :: Base -> BigNum -> BigNum -> BigNum
subBigNums b x y
  | (fromBigNum b (addBigNums b x y)) < 0 = addBigNums b x y
  | x == [0] && head y >= b = minus du b:[-1]
  | x == [0] = [0-head y]
  | y == [0] = x
  | length c == 0 && du >= 0 = [du]
  | length c == 0 && du < 0 = [minus du b] ++ [-1]
  | du >= 0 = du : subBigNums b c d
  | du < 0 = minus du b : subBigNums b c (cut d 1)
   where (cx:c,cy:d) = (x <=> y)
         du = cx - cy
         dsu = div du b
		 
diffBigNums :: Base -> [BigNum] -> BigNum
diffBigNums _ [] = []
diffBigNums b l@(x:y:xs)
  | length l > 2 = diffBigNums b ([subBigNums b x y] ++ xs)
  | length l == 2 = subBigNums b x y
  | otherwise = x

logPowerBase :: Base -> Int -> (Int, Int)
powerBase x y z
 | (x^z) < y = z + powerBase (x^z) y z
 | otherwise = z
logPowerBase b x = (log,b^log)
 where log = powerBase b x b