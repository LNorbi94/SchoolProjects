-- Feladat linkje
-- http://pnyf.inf.elte.hu/fp/Biathlon.xml


type Time = (Int,Int)
type TimeAndFaults = (Time,[Int])
type Team = String

team1 :: [TimeAndFaults]
team1 = [((10,05),[1,1,0,2]),((11,50),[2,3,1,2])
        ,((09,45),[0,1,1,0]),((10,25),[0,0,0,1])]
team2 :: [TimeAndFaults]
team2 = [((10,15),[0,1,0,2]),((09,50),[2,0,1,2])
        ,((09,45),[0,1,1,0]),((10,25),[0,0,0,1])]
team3 :: [TimeAndFaults]
team3 = [((10,15),[0,1,0,2]),((10,10),[1,0,1,1])
        ,((09,45),[0,1,1,0]),((10,25),[0,0,2,1])]
team4 :: [TimeAndFaults]
team4 = [((10,15),[0,1,0,2]),((10,50),[1,0,1,2])
        ,((09,45),[0,1,1,0]),((10,25),[0,0,0,1])]
teams = [team1, team2, team3, team4]

teamNames :: [Team]
teamNames = ["Anfy Team","Team 17","Core Team","A-Team"]

------------------------------------------------------ 
------------------------------------------------------

timeToSeconds :: Time -> Int
timeToSeconds (a,b)
 | a<0 || b<0 || b > 59 = error "timeToSeconds: Invalid Time"
 | otherwise = a*60+b
-- timeToSeconds (1,20)
 
secondsToTime :: Int -> Time
secondsToTime n
 | n < 0 = error "secondsToTime: negative number"
 | otherwise = divMod n 60 -- vagy = (div a 60,mod a 60)
-- secondsToTime 65
 

(.<=.) :: Time -> Time -> Bool
(.<=.) a b = timeToSeconds a <= timeToSeconds b
-- (1,20) .<=. (1,21)


result :: TimeAndFaults -> Time
result (time,l) = secondsToTime $ timeToSeconds time + (60 * sum l)
-- VAGY		result ((a,b),c) = (a+(sum c),b)
-- result $ head team1


teamTime :: [TimeAndFaults] -> Time
teamTime = secondsToTime . sum . map (timeToSeconds . result)
-- teamTime team1


fastests :: [[TimeAndFaults]] -> [Int]
fastests l = [fst x | x <- zip [1..] (map teamTime l), snd x == (minimum $ map teamTime l)]
-- fastests teams


faults :: [TimeAndFaults] -> Int
faults = sum . map (sum.snd)
-- faults team1


winner :: [[TimeAndFaults]] -> Int
winner l = fst $ minimumBy (compare `on` snd) [ x | x <- (zip [1..] (map faults l)), elem (fst x) (fastests l)]
-- winner teams


winnerName :: [Team] -> [[TimeAndFaults]] -> Team
winnerName name teams = name !! ((winner teams)-1)
-- winnerName teamNames teams


statistics :: [[TimeAndFaults]] -> (Time, Time)
averageTime l = secondsToTime $ div (sum $ map (timeToSeconds.teamTime) l) $ length $ concat l
minTime = secondsToTime . minimum . map (timeToSeconds . result) . concat

statistics l = (minTime l, averageTime l)
-- statistics teams