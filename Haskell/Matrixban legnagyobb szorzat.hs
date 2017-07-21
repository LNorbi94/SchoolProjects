-- Feladat linkje
-- http://pnyf.inf.elte.hu/fp/GridProduct.xml

import Data.List -- maximumBy
import Data.Function -- on

type Matrix = [[Int]]
type Position = (Int, Int)


sublists :: Int -> [a] -> [[a]]
sublists n l@(x:xs)
 | n > length l = []
 | otherwise = take n l : sublists n xs
-- VAGY		sublists n l = [take n (drop x l) | x <- [0..(length l - n)]]
-- sublists 2 [ 1, 2, 3, 4] == [[1, 2], [2, 3], [3, 4]] :: [[Integer]]


sublistsOfRowCol :: Int -> Matrix -> [[Int]]
sublistsOfRowCol n l = concatMap (sublists n) (l ++ (transpose l))
-- sublistsOfRowCol 3 matrix1 == [[1, 2, 3], [4, 5, 6], [7, 8, 9], [1, 4, 7], [2, 5, 8], [3, 6, 9]] :: [[Int]]


mainDiagonalPositions :: Matrix -> [Position]
mainDiagonalPositions l = [(n,n) | n <- [0.. length l -1]]
-- mainDiagonalPositions matrix1 == [(0, 0), (1, 1), (2, 2)] :: [Position]


antiDiagonalPositions :: Matrix -> [Position]
antiDiagonalPositions l = [(length l - 1 -n, n) | n <- [0..length l -1]]
-- antiDiagonalPositions matrix1 == [(2, 0), (1, 1), (0, 2)] :: [Position]


iterateUntilNotNull :: (a -> a) -> [a] {-nem üres-} -> [[a]]
iterateUntilNotNull p [x] = []
iterateUntilNotNull p l = [init $ map p l] ++ iterateUntilNotNull p (init $ map p l)
-- iterateUntilNotNull (+1) [1..4] == [[2, 3, 4], [3, 4], [4]] :: [[Integer]]


diagonalPositions :: Matrix -> [[Position]]
diagonalPositions l =
  (reverse $ iterateUntilNotNull (\(i,j) -> (i+1, j)) (mainDiagonalPositions l)) 	-- Főátló alattiak
  ++ [mainDiagonalPositions l] ++													-- Főátló
  (iterateUntilNotNull ( \(i,j) -> (i, j+1)) (mainDiagonalPositions l)) ++			-- Főátló felettiek
  (reverse $ iterateUntilNotNull ( \(i,j) -> (i, j+1)) (antiDiagonalPositions l))	-- Mellékátló alattiak
  ++ [antiDiagonalPositions l] ++													-- Mellékátló
  (iterateUntilNotNull ( \(i,j) -> (i-1, j)) (antiDiagonalPositions l))				-- Mellékátló felettiek
-- diagonalPositions matrix2


diagonals :: Matrix -> [[Int]]
diagonals x = [[(x !! (fst f)) !! (snd f) | f<-e ] | e<-diagonalPositions x]
--diagonals m = [ map (\x -> (m !! (fst x) !! (snd x))) x | x <- diagonalPositions m ]
-- diagonals matrix1 == [[7], [4, 8], [1, 5, 9], [2, 6], [3], [9], [8, 6], [7, 5, 3], [4, 2], [1]] :: [[Int]]


sublistsOfDiags :: Int -> Matrix -> [[Int]]
sublistsOfDiags n x = concat [sublists n e | e <- diagonals x]
--sublistsOfDiags n m = concatMap (sublists n) (diagonals m)
-- sublistsOfDiags 3 matrix1 == [[1, 5, 9], [7, 5, 3]] :: [[Int]]


maximumProductNeighbours :: Int -> Matrix -> [Int]
maximumProductNeighbours n x = snd $ maximumBy (compare `on` fst) [(product e,e)|e<-(sublistsOfDiags n x++sublistsOfRowCol n x)]
--maximumProductNeighbours n m = maximumBy (compare `on` product) t where
--   soroszlop = sublistsOfRowCol n m
--   atlo = sublistsOfDiags n m
--   t = soroszlop ++ atlo
-- maximumProductNeighbours 2 matrix2 == [15, 16] :: [Int]


-- Mátrixok
matrix1 :: Matrix
matrix1 = [[1,2,3]
          ,[4,5,6]
          ,[7,8,9]]
		  
matrix2 :: Matrix
matrix2 = [[ 1, 2, 3, 4]
          ,[ 5, 6, 7, 8]
          ,[ 9,10,11,12]
          ,[13,14,15,16]]
		  
matrix3 :: Matrix
matrix3 = [[ 1, 2, 3, 4, 5]
          ,[ 6, 7, 8, 9,10]
          ,[11,12,13,14,15]
          ,[16,17,18,19,20]
          ,[21,22,23,24,25]]
		  
matrix4 :: Matrix
matrix4 =
 [[08,02,22,97,38,15,00,40,00,75,04,05,07,78,52,12,50,77,91,08]
 ,[49,49,99,40,17,81,18,57,60,87,17,40,98,43,69,48,04,56,62,00]
 ,[81,49,31,73,55,79,14,29,93,71,40,67,53,88,30,03,49,13,36,65]
 ,[52,70,95,23,04,60,11,42,69,24,68,56,01,32,56,71,37,02,36,91]
 ,[22,31,16,71,51,67,63,89,41,92,36,54,22,40,40,28,66,33,13,80]
 ,[24,47,32,60,99,03,45,02,44,75,33,53,78,36,84,20,35,17,12,50]
 ,[32,98,81,28,64,23,67,10,26,38,40,67,59,54,70,66,18,38,64,70]
 ,[67,26,20,68,02,62,12,20,95,63,94,39,63,08,40,91,66,49,94,21]
 ,[24,55,58,05,66,73,99,26,97,17,78,78,96,83,14,88,34,89,63,72]
 ,[21,36,23,09,75,00,76,44,20,45,35,14,00,61,33,97,34,31,33,95]
 ,[78,17,53,28,22,75,31,67,15,94,03,80,04,62,16,14,09,53,56,92]
 ,[16,39,05,42,96,35,31,47,55,58,88,24,00,17,54,24,36,29,85,57]
 ,[86,56,00,48,35,71,89,07,05,44,44,37,44,60,21,58,51,54,17,58]
 ,[19,80,81,68,05,94,47,69,28,73,92,13,86,52,17,77,04,89,55,40]
 ,[04,52,08,83,97,35,99,16,07,97,57,32,16,26,26,79,33,27,98,66]
 ,[88,36,68,87,57,62,20,72,03,46,33,67,46,55,12,32,63,93,53,69]
 ,[04,42,16,73,38,25,39,11,24,94,72,18,08,46,29,32,40,62,76,36]
 ,[20,69,36,41,72,30,23,88,34,62,99,69,82,67,59,85,74,04,36,16]
 ,[20,73,35,29,78,31,90,01,74,31,49,71,48,86,81,16,23,57,05,54]
 ,[01,70,54,71,83,51,54,69,16,92,33,48,61,43,52,01,89,19,67,48]]