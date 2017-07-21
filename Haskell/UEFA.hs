-- Feladat linkje
-- http://pnyf.inf.elte.hu/fp/UEFA.xml

import Data.List -- transpose
import Data.Tuple -- swap

type Match = (Int,Int)
type MatchTable = [[Match]]
type Team = String

groupATable :: MatchTable
groupATable =
    [[(-1,-1), (2,0)  , (1,2)  , (0,1)  , (1,0)  , (2,0)  ]
    ,[(1,1)  , (-1,-1), (0,3)  , (2,0)  , (5,1)  , (6,1)  ]
    ,[(1,1)  , (2,1)  , (-1,-1), (2,0)  , (1,0)  , (1,1)  ]
    ,[(2,0)  , (0,0)  , (0,2)  , (-1,-1), (1,1)  , (1,2)  ]
    ,[(1,2)  , (1,0)  , (0,2)  , (1,2)  , (-1,-1), (2,1)  ]
    ,[(1,2)  , (0,3)  , (0,2)  , (2,1)  , (1,0)  , (-1,-1)]]

groupGTable :: MatchTable
groupGTable =
    [[(-1,-1), (1,0)  , (0,0)  , (2,0)  , (1,0)  , (2,0)  ]
    ,[(0,1)  , (-1,-1), (1,2)  , (1,1)  , (2,1)  , (2,0)  ]
    ,[(3,1)  , (0,1)  , (-1,-1), (3,0)  , (4,1)  , (4,1)  ]
    ,[(0,1)  , (1,1)  , (0,1)  , (-1,-1), (2,0)  , (2,0)  ]
    ,[(1,2)  , (2,2)  , (0,5)  , (2,1)  , (-1,-1), (2,0)  ]
    ,[(0,1)  , (1,1)  , (1,8)  , (0,2)  , (1,1)  , (-1,-1)]]

groupANames :: [Team]
groupANames = ["Croatia", "Serbia", "Belgium", "Scotland", "Macedonia", "Wales"]

groupGNames :: [Team]
groupGNames = ["Greece", "Slovakia", "Bosnia and Hercegovina"
              ,"Lithuania", "Latvia", "Liechtenstein"]

------------------------------------------------------ 
------------------------------------------------------

point :: Match -> Int
point (a,b)
 | a>b = 3
 | a==b && a/=(-1) = 1
 | otherwise = 0
-- point (1,3)

 
homePoints :: [Match] -> Int
homePoints l = sum [point x | x <- l]
-- homePoints $ head groupATable


awayPoints :: [Match] -> Int
awayPoints l = sum [point (swap x) | x <- l]
-- awayPoints $ map head groupATable


totals :: MatchTable -> [Int]
totals l = zipWith (+) (map homePoints l) (map awayPoints (transpose l))
-- totals groupGTable


highestPoint :: MatchTable -> Int
highestPoint = maximum . totals
-- highestPoint groupGTable


winners :: MatchTable -> [Int]
winners l = [ fst x | x <- (zip [0..] (totals l)), snd x == (highestPoint l)]
-- VAGY 
-- winners a = map fst $ filter (\(b,c) -> c==highestPoint a) (zip [0..] (totals a))
-- winners groupGTable


homeGoals :: [Match] -> (Int,Int)
homeGoals l = (sum (filter (/=(-1)) $ map fst l),sum (filter (/=(-1)) $ map snd l))
-- homeGoals $ head groupATable


goalDiffs :: MatchTable -> [Int]
goalDiffs l = zipWith (+) (map (sum . map (\(a,b) -> a-b)) l) (map (sum . map (\(a,b) -> b-a)) (transpose l))
-- goalDiffs groupGTable


winner :: MatchTable -> Int
winner l = fst $ last [ x | x <- (zip [0..] $ goalDiffs l), elem (fst x) (winners l)]
-- winner groupGTable


winnerName :: [Team] -> MatchTable -> Team
winnerName name score = name !! (winner score)
-- winnerName groupGNames groupGTable