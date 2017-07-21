import Prelude hiding (even, odd)

mountain x = [1..x] ++ reverse [1..x-1]
areTriangleSides a b c = a+b>c && a+c>b && b+c>a
even x = mod x 2 == 0
odd x = mod x 2 == 1
divides x y = mod y x == 0
isLeapYear x = mod x 4 == 0 && mod x 100 /= 0 || mod x 400 == 0
sumSquaresTo x = sum [n^2 | n<-[1..x]]
divisors x = [y | y<-[1..x], divides y x]
properDivisors x = [y | y<-[2..div x 2], divides y x]