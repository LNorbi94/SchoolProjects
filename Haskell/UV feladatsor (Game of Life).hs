--module GameOfLife where
import Data.List (intersect, (\\), nub, sort, union)

-- (Y, X) koordináta
type Coordinate = (Integer, Integer)
type Generation = [Coordinate]

single  :: Generation
single  = [ (42, 42) ]

block   :: Generation
block   = [ (5, 6), (5, 7)
          , (6, 6), (6, 7) ]

row     :: Generation
row     = [ (10, 1), (10, 2), (10, 3) ]

column  :: Generation
column  = [ (9,  2)
         , (10, 2)
         , (11, 2) ]

caterer :: Generation
caterer = [ (2, 4), (3, 2), (3, 6), (3, 7), (3, 8), (3, 9)
          , (4, 2), (4, 6), (5, 2), (6, 5), (7, 3), (7, 4) ]

neighbors :: Coordinate ->      [Coordinate]
-- Generáljuk ki az X szomszédjait... ez valahogy így néz ki a síkon:
-- 1 2 3
-- 4 X 5
-- 6 7 8
neighbors (y, x) = [ (y-1, x-1), (y-1, x), (y-1, x+1)
                   , (y  , x-1),           (y  , x+1)
                   , (y+1, x-1), (y+1, x), (y+1, x+1) ]


livingNeighbors :: Generation -> Coordinate ->      Int
-- Nézzük meg a szomszédos celláit az adott koordinátának. Ez lesz egy 8 elemû lista.
-- A generációban azok a koordináták vannak, ahol élõ sejt található. Ez valahány elemû lista.
-- Ha vesszük a metszetet, megkapjuk, hogy mely szomszédos koordinátákban található élõ cella. Ennek számossága a várt érték.
livingNeighbors gen coord = length (intersect (neighbors coord) gen)

staysAlive :: Generation -> Coordinate ->       Bool
-- A sejt túléli a kört, ha két vagy három szomszédja van.
staysAlive gen coord = ln == 2 || ln == 3
 where
  ln = livingNeighbors gen coord

stepLivingCells :: Generation ->    Generation
-- Egyesével végigmegyünk a generációban, mint koordináták listájában található elemeken.
-- Amelyik életben marad, az megy bele a kimenõ listába.

-- Meghívunk egy segédfüggvényt. Ez kezdetben megkapja a teljes inputot és egy olcsó üres listát. Majd válaszként megkapjuk tõle a helyes választ a feladatra.
stepLivingCells gen = slc_wrapper gen []
 where
  slc_wrapper :: Generation -> Generation ->       Generation
  -- A segédfüggvény tud iteratívan dolgozni a már létezõ két listával. Rekurzió alkalmazása.
  -- Alapeset: elfogyott az aktuális generáció. Hát akkor nincs tovább, ami eredményre jutottunk, arra jutottunk.
  slc_wrapper []           newGen = newGen
  -- Egy sejt maradt. Vele még elbánunk, ha szükséges.
  slc_wrapper [cell]       newGen
   | staysAlive gen cell   = (cell:newGen)
   | otherwise             = newGen
  -- Több sejt is van, amivel még el kéne bánnunk. Itt most dolgozik az, hogy egyesével végigvizsgáljuk a sejteket.
  slc_wrapper (cell:cells) newGen
   | staysAlive gen cell   = slc_wrapper cells (cell:newGen)
   | otherwise             = slc_wrapper cells newGen

{-
-- !!!!! ALTERNATÍV MEGOLDÁS!     !!!!! --
-- A saját magunk által írt rekurzió helyett nagyszerûen használható a beépített szûrõ.
-- A filter kér egy predikátumot (a -> Bool típusú függvényt) és egy azonos típusú listát ([a]) és elõállítja azon elemek listáját, amelyre a predikátum igazat adott.
-- A staysAlive alapvetõen 2 argumentumot vár, de az elsõt, jelen esetben a generációt tudjuk fixálni:
-- $ :t staysAlive gen :: Coordinate -> Bool
-- Ez már jól láthatóan valami a -> Bool típusú.
-}
stepLivingCells2 :: Generation ->    Generation
stepLivingCells2 gen = filter (staysAlive gen) gen
{-
-- ????? ALTERNATÍV MEGOLDÁS VÉGE ????? --
-}

deadNeighbors :: Generation ->      [Coordinate]
-- A neighbors ugye elõállítja egy sejt összes szomszédját.
-- Ezt kiszámítjuk MINDEN a generációban lévõ sejtre. Ezt teszi a map függvény, ezzel kapunk egy cella-listák listáját ([[Coordinate]] típusú)
-- A concattal ezt összefûzzük egyel kevesebb mélységû listává. A concatMap csak egy egyszerûbb írásmódja annak, hogy concat(map fgv lista)
-- A nub ebbõl a listából (ami az összes szomszédos hely koordinátája) eltávolítja a többször elõforduló elemeket, így minden hely csak egyszer szerepel.
-- Végül ebbõl a listából töröljük az eredeti, sejtekkel betöltött pontok koordinátáit. (A (\\) a két lista különbségét képzõ nemkommutatív operátor.)
deadNeighbors gen = (nub $ concatMap neighbors gen) \\ gen

stepDeadCells :: Generation ->      Generation
-- Új sejt születik minden olyan cellában, melynek környezetében pontosan három sejt található.
-- Rövid alakban:
-- stepDeadCells gen = filter (\cell -> livingNeighbors gen cell == 3) (deadNeighbors gen)
-- Kicsit hosszabban kiírva, így talán érthetõbb...
stepDeadCells gen = filter szulethet helyek
  where
   -- Az aktuális generáció potenciális szomszédos üres cellái, pontosan az elõzõ függvény eredménye.
   helyek :: [Coordinate]
   helyek =  deadNeighbors gen
   
   -- Akkor születhet sejt az adott helyen, ha pontosan 3 élõ szomszédja lenne.
   szulethet :: Coordinate ->   Bool
   szulethet cell = livingNeighbors gen cell == 3
-- Tehát amit csinálunk az az, hogy elõállítjuk az összes potenciális helyet majd ezek közül kivesszük azokat, amelyek tényleg jók.
-- Természetesen a stepLivingCells-hez hasonló módon itt is ki lehetett volna emelni a dolgot saját rekurzióba.

stepCells :: Generation ->      Generation
-- "vegyük az elõzõ két pont eredményének unióját, majd rendezzük"
stepCells gen = sort $ union eletben_marad szuletik
 where
  -- "számítsuk ki, hogy az élõ sejtek közül melyek maradnak életben"
  eletben_marad :: [Coordinate]
  eletben_marad = stepLivingCells gen
  -- "határozzuk meg, hogy az élõ sejtek körül mely cellákban születik új sejt"
  szuletik      :: [Coordinate]
  szuletik      = stepDeadCells   gen

play :: Generation -> Int ->    Generation
play gen num
 | num < 0   = error "play: generation number must be non-negative."
 | num == 0  = gen
 | num > 0   = play (stepCells gen) (num - 1)

isStill :: Generation ->    Bool
isStill gen = stepCells gen == gen

isOscillator :: Generation -> Int ->    Int
isOscillator gen threshold = io gen gen threshold
 where
  io :: Generation -> Generation -> Int -> Int
  -- Hasonlóan az slc_wrapper-ben foglaltakhoz, itt is "kiemeljük" az eredeti generációt egy segédkifejezésbe.
  -- Ez lesz az orig. A gener az éppen aktuálisan vizsgált generáció, tsh pedig a hátralevõ lehetséges lépések száma.
  io orig gener tsh
   -- Ha a lépések elfogytak, akkor nem találtunk egyezést, álljunk le.
   | tsh <= 0                = error "isOscillator: not an oscillator with the given limit"
   -- Ha még van lehetséges lépés, akkor vizsgáljuk, hogy a következõ lépés megegyezik-e az eredetivel.
   | tsh > 0 && orig == step = (threshold - tsh + 1)            -- Igen: adjuk meg az elhasznált lépések számát, ez könnyen kiszámítható)
   | tsh > 0 && orig /= step = io orig step (tsh - 1)           -- Nem:  lépjünk egyet és folytassuk, amíg nem találunk egyezést
   where
    step = stepCells gener
-- A függvény kiértékelése miatt az elsõ találatnál fog leállni (amennyiben van ilyen), tehát valóban a legkisebb lépésszámot adjuk meg, amennyi kell az önmagába visszatéréshez.
