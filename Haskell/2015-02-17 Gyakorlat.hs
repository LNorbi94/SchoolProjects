-- Írjunk be egy olyan kifejezést, amely pontosan akkor igaz (True) ha a 23 nem osztja a 532253373-at!
div 532253373 23 /= 0
not (div 532253373 23 == 0) 

-- Írjunk le egy olyan kifejezést, amelynek a végeredményébõl világossá válik, hogy a (&&) erõsebben köt a (||)-nál!
3 > 4 && 2<3 || 1<2

-- Írjuk ki a rejtett zárójeleket!
(((6 < 4) || (4 >= 5)) && (12 /= (4 * 4)))
-- Távolítsunk el minél több zárójelpárt!
1 < 2 && 50 > (100 - 2) `mod` 50
-- Zárójelezzük a következõ kifejezést!
(2 < (div 18 4)) || ((mod 15 5) > (-3))

-- Soroljuk fel 10-tõl visszafelé -10-ig a számokat!
[10,9..(-10)]
[10,9.. -10]

-- Adjuk meg a 113. elemét annak a számtani sorozatnak, amelynek az elsõ két eleme 11 és 32!
[11,32..] !! 112

-- Hányféleképpen lehet sorba rendezni 10 különbözõ elemet?
product [1..10]

-- Hányféleképpen választhatunk ki 70 különbözõ elembõl 30 elemet?
div (product [41..70]) (product [1..30])