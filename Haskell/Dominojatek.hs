-- Feladat linkje:
-- http://pnyf.inf.elte.hu/fp/Dominoes.xml


type Domino = (Int, Int)
type DominoSequence = [Domino]


dominoes :: Int -> [Domino]
dominoes n = [(x,y) | x <- [0..n], y<-[x..n]]


flipDomino :: Domino -> Domino
flipDomino (a,b) = (b,a)


matches :: Domino -> Domino -> Bool
matches (a,b) (x,y) = b==x


getDominoesWithSide :: Int -> [Domino] -> [Domino]
getDominoesWithSide n l = [x | x<-l, snd x == n || fst x == n]


isValidDominoSequence :: [Domino] -> Bool
isValidDominoSequence [] = True
isValidDominoSequence [x] = True
isValidDominoSequence (x:y:xs) = matches x y && isValidDominoSequence (y:xs)


fromDominoes :: [Domino] -> DominoSequence
fromDominoes l
 | isValidDominoSequence l = l
 | otherwise = error "Invalid domino sequence"

 
dominoSequenceEndsWith :: DominoSequence {-Nem üres, véges sorozat-} -> Int
dominoSequenceEndsWith = snd . last


(<+>) :: DominoSequence -> Domino -> DominoSequence
(<+>) l x
 | matches (last l) x = l ++ [x]
 | otherwise = error "Domino cannot be appended"

 
fork :: DominoSequence -> [Domino] -> [DominoSequence]
fork l list =
	[l <+> (flipDomino x) | x<-list, snd x == (dominoSequenceEndsWith l) && snd x /= fst x]
	++
	[l <+> x | x<-list, fst x == (dominoSequenceEndsWith l)]

	
filterDominoesBy :: [Domino] -> DominoSequence -> [Domino]
filterDominoesBy list l = [x | x <- list, not(elem x l) && not(elem (flipDomino x) l)]


fork' :: DominoSequence -> [Domino] -> [DominoSequence]
fork' l list =
	[l <+> (flipDomino x) | x<-(filterDominoesBy list l), snd x == (dominoSequenceEndsWith l) && snd x /= fst x]
	++
	[l <+> x | x<-(filterDominoesBy list l), fst x == (dominoSequenceEndsWith l)]
	
	
generate :: [DominoSequence] -> [Domino] -> [DominoSequence]
generate [] _ = []
generate (x:xs) l = [x] ++ generate (fork' x l) l ++ generate xs l
-- Megjegyzés:
-- Nem a honlapon lévő a sorrend, de tartalmilag ugyanaz. 
-- Ez a függvény megegyezik: sort $ generate [[(0,1)]] (dominoes 2)
-- Saját kód szerint == Honlapon definiált szerint