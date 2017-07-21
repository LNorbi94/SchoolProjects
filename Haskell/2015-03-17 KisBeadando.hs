swap_t '>' = "&gt;"
swap_t '<' = "&lt;"
swap_t x = [x]
toHtml :: String -> String
toHtml x = unwords [swap_t y | y<-x]