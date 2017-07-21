-- pi közelítése
4 * sum (take (10^3) [ (-1) ** n / (2 * n + 1) | n <- [0..] ])

-- szamtani sorozat
take 6 [l | i <- [1..], j <- [1.. i - 1], l <- init $ tails $ reverse [i,j..1], sum l == head l * i]