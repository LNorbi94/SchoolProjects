#!/bin/bash

./cpp /Test/tesztfajlok/hibatlan/01.ok
./cpp /Test/tesztfajlok/hibatlan/02.ok
./cpp /Test/tesztfajlok/hibatlan/03.ok
./cpp /Test/tesztfajlok/hibatlan/04.ok
./cpp /Test/tesztfajlok/hibatlan/05.ok
./cpp /Test/tesztfajlok/hibatlan/06.ok

echo "Hibátlan tesztek vége. Nyomj meg egy gombot a hibás tesztekért."
read a

./cpp Test/tesztfajlok/lexikalis-hibas/01.lex-hibas

echo "Lexikális hibás teszt vége. Nyomj meg egy gombot a szintaktikailag hibás tesztekért."
read a

./cpp Test/tesztfajlok/szintaktikus-hibas/01.szint-hibas
./cpp Test/tesztfajlok/szintaktikus-hibas/02.szint-hibas
./cpp Test/tesztfajlok/szintaktikus-hibas/03.szint-hibas
./cpp Test/tesztfajlok/szintaktikus-hibas/04.szint-hibas
./cpp Test/tesztfajlok/szintaktikus-hibas/05.szint-hibas
./cpp Test/tesztfajlok/szintaktikus-hibas/06.szint-hibas
./cpp Test/tesztfajlok/szintaktikus-hibas/07.szint-hibas
./cpp Test/tesztfajlok/szintaktikus-hibas/08.szint-hibas
./cpp Test/tesztfajlok/szintaktikus-hibas/09.szint-hibas
./cpp Test/tesztfajlok/szintaktikus-hibas/10.szint-hibas
./cpp Test/tesztfajlok/szintaktikus-hibas/11.szint-hibas
./cpp Test/tesztfajlok/szintaktikus-hibas/12.szint-hibas
./cpp Test/tesztfajlok/szintaktikus-hibas/13.szint-hibas
./cpp Test/tesztfajlok/szintaktikus-hibas/14.szint-hibas
./cpp Test/tesztfajlok/szintaktikus-hibas/15.szint-hibas
./cpp Test/tesztfajlok/szintaktikus-hibas/16.szint-hibas
./cpp Test/tesztfajlok/szintaktikus-hibas/17.szint-hibas
./cpp Test/tesztfajlok/szintaktikus-hibas/18.szint-hibas
./cpp Test/tesztfajlok/szintaktikus-hibas/19.szint-hibas
./cpp Test/tesztfajlok/szintaktikus-hibas/20.szint-hibas
