<?php

    if (!logged())
    {
        header('Location: index.php?game');
        exit();
    }
    
    function addGame($data)
    {
        $filename = 'data/games.json';
        $games = loadFromFile($filename);
        $games[$data['name']] = [
            'n' => $data['n']
            , 'm' => $data['m']
            , 'k' => $data['k']
        ];
        saveToFile($filename, $games);
    }
    
    function listGames()
    {
        $filename = 'data/games.json';
        $games = loadFromFile($filename);
        $filename = 'data/scores.json';
        $scores = loadFromFile($filename);
        $retGames = array();
        if (empty($games))
        {
            return array();
        }
        foreach ($games as $k => $v)
        {
            $best = -1;
            $oBest = -1;
            $oBestName;
            if (!empty($scores))
            {
                foreach($scores as $key => $val)
                {
                    if($val['name'] == $_SESSION['name'] && $val['game'] == $k)
                    {
                        if ($val['score'] > $best)
                        {
                            $best = $val['score'];
                        }
                    }
                    if($val['game'] == $k)
                    {
                        if ($val['score'] > $oBest)
                        {
                            $oBest = $val['score'];
                            $oBestName = $val['name'];
                        }
                    }
                }
            }
            $retGames[$k] = "Pálya méretei: ${v['n']} x ${v['m']}, Tereptárgyak száma: ${v['k']}.";
            if($best == -1)
            {
                $retGames[$k] .= " | Ezen a pályán még nem játszott.";
            }
            else
            {
                $retGames[$k] .= " | Ezen a pályán elért legjobb pontszáma: " . $best;
            }
            if($oBest == -1)
            {
                $retGames[$k] .= " | Ezen a pályán még senki sem játszott.";
            }
            else
            {
                $retGames[$k] .= " | Ezen a pályán elért legjobb pontszám: " . $oBest . ", " . $oBestName . " által.";
            }
        }
        return $retGames;
    }
    
    if($_POST)
    {
        $data = $_POST;
        addGame($data);
    }
    
    $games = listGames();
    
    include("templates/listGames.php");
?>