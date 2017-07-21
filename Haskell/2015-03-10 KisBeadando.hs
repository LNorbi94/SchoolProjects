(<<) :: Num a => a -> a -> Bool
osztok x = length([y | y<-[2..div x 2], mod x y == 0])
a << b = osztok a < osztok b