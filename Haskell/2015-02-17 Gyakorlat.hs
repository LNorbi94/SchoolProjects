-- �rjunk be egy olyan kifejez�st, amely pontosan akkor igaz (True) ha a 23 nem osztja a 532253373-at!
div 532253373 23 /= 0
not (div 532253373 23 == 0) 

-- �rjunk le egy olyan kifejez�st, amelynek a v�geredm�ny�b�l vil�goss� v�lik, hogy a (&&) er�sebben k�t a (||)-n�l!
3 > 4 && 2<3 || 1<2

-- �rjuk ki a rejtett z�r�jeleket!
(((6 < 4) || (4 >= 5)) && (12 /= (4 * 4)))
-- T�vol�tsunk el min�l t�bb z�r�jelp�rt!
1 < 2 && 50 > (100 - 2) `mod` 50
-- Z�r�jelezz�k a k�vetkez� kifejez�st!
(2 < (div 18 4)) || ((mod 15 5) > (-3))

-- Soroljuk fel 10-t�l visszafel� -10-ig a sz�mokat!
[10,9..(-10)]
[10,9.. -10]

-- Adjuk meg a 113. elem�t annak a sz�mtani sorozatnak, amelynek az els� k�t eleme 11 �s 32!
[11,32..] !! 112

-- H�nyf�lek�ppen lehet sorba rendezni 10 k�l�nb�z� elemet?
product [1..10]

-- H�nyf�lek�ppen v�laszthatunk ki 70 k�l�nb�z� elemb�l 30 elemet?
div (product [41..70]) (product [1..30])