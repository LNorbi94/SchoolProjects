-- Feladat linkje:
-- http://pnyf.inf.elte.hu/fp/NGram.xml


import Data.List -- maximumBy, minimumBy, sort, group, delete
import Data.Function -- on

type State = ([Int],Dictionary,[Int],Int)
type Dictionary = [(Int,[Int])]




mostCommonConsecutive :: Ord a => Int -> [a] -> ([a],Int)
mostCommonConsecutive _ [] = ([],0)
mostCommonConsecutive a b = (c,d)
 where
  c = head e
  d = length e
  e = maximumBy (compare `on` length) $ group $ sort $ seged2 a b
 
seged2 :: Int -> [a] -> [[a]]
seged2 a b
 | a > (length b) = []
 | True = take a b : seged2 a (tail b)
-- mostCommonConsecutive 2 "abcdefghi" == ("hi", 1)
-- mostCommonConsecutive 2 "abcabcabcd" == ("bc", 3)



replace :: Eq a => [a] -> [a] -> [a] -> [a]
replace []_ c = c
replace a b c
 | length c < length a = c
 | take (length a) c == a = b ++ replace a b (drop (length a) c)
 | otherwise = [head c] ++ replace a b (tail c)
-- replace "oo" "ee" "foobar" == "feebar"
-- replace "ooo" "ee" "foobar" == "foobar"



minus :: Eq a => [a] -> [a] -> [a]
minus x [] = x
minus x y = minus (delete (head(take 1 y)) x) (drop 1 y)
-- VAGY		minus = (\\)
-- "test list" `minus` "es" == "tt list"



step :: Int -> State -> State
step a (b,c,d,e) = (tail b,(head b,f):c,replace f [head b] d,g)
  where (f,g) = mostCommonConsecutive a d
-- step 2 ([0..5],[],[97,97,97,98,100,97,97,97,98,97,99],0) == 
-- ([1, 2, 3, 4, 5], [(0, [97, 97])], [0, 97, 98, 100, 0, 97, 98, 97, 99], 4)

  
  
while :: (a -> Bool) -> (a -> a) -> a -> a
while p f n
 | p (f n) = while p f (f n)
 | otherwise = n
-- while (< 1000) (+1) 0 == 999
 
 

fold :: Int -> [Int] -> [Int] -> (Dictionary, [Int])
fold a b c
 | a < 2 = error "fold: n must be greater than 2"
 | otherwise = (e,f)
  where (d,e,f,g) = while(\(h,i,j,k)->(k/=1)) (step a) ((minus b c),[],c,0)
-- fold 2 [0..255] [5,5,5,4,3,5,5,5,4,5,2] == ([(6, [0, 1]), (1, [5, 4]), (0, [5, 5])], [6, 3, 6, 5, 2])  



serialize :: (Dictionary, [Int]) -> [Int]
serialize ([],_) = []
serialize (a,b) = [(length (head c))-1] ++ [(length c)] ++ (concat c) ++ b
 where c = map (\(c,d)->(c:d)) a
-- serialize ([(88, [90,89]), (89, [97,98]), (90, [97,97])], [88,100,88,97,99]) ==
-- [2, 3, 88, 90, 89, 89, 97, 98, 90, 97, 97, 88, 100, 88, 97, 99]



unfold :: Dictionary -> [Int] -> [Int]
unfold [] a = a
unfold ((a,b):as) c = unfold as (replace [a] b c)
-- unfold [(98,[0,1,2])] [102,111,111,98,97,114] == [102, 111, 111, 0, 1, 2, 97, 114]



compress :: [Int] -> [Int]
compress a
 | c==[] = []
 | otherwise = minimumBy (compare `on` length) c
 where
  c = filter (/=[]) [serialize $ fold b [0..255] a | b<-[2..255]]
-- compress [97,98,114,97,107,97,100,97,98,114,97] == [4, 1, 0, 97, 98, 114, 97, 0, 107, 97, 100, 0]

   
 
deserialize :: [Int] -> (Dictionary, [Int])
deserialize (a:b:c) = ((seged (a+1) (take ((a+1)*b) c)),(drop ((a+1)*b) c))
deserialize _ = error "deserialize: Invalid format"
 
seged :: Int -> [Int] -> Dictionary
seged a [] = []
seged a c = (head (take a c),tail (take a c)) : seged a (drop a c)
-- deserialize [1..10] == ([(3, [4]), (5, [6])], [7, 8, 9, 10]) :: (Dictionary, [Int])
-- deserialize [4,1,0,97,98,114,97,0,107,97,100,0] == ([(0, [97, 98, 114, 97])], [0, 107, 97, 100, 0])
 
 
 
decompress :: [Int] -> [Int]
decompress a = unfold b c
 where (b,c) = deserialize a
-- decompress [1..10] == [7, 8, 9, 10] :: [Int]
-- decompress [4,1,0,97,98,114,97,0,107,97,100,0] == [97, 98, 114, 97, 107, 97, 100, 97, 98, 114, 97]