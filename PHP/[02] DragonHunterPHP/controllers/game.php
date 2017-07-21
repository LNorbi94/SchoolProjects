<?php

    function getGameParameters($name)
    {
        $filename = 'data/games.json';
        $games = loadFromFile($filename);
        $game = array();
        foreach ($games as $k => $v)
        {
            if ($k == $name)
            {
                $game = $v;
            }
        }
        return $game;
    }

    $n = 10;
    $m = 10;
    $k = 2;
    $game = "Alapértelmezett";
    $name = isset($_SESSION['name']) ? $_SESSION['name'] : "Vendég";
    
    if (logged())
    {
        if(!$_POST)
        {
            header('Location: index.php?listGames');
            exit();
        }
        else
        {
            $game = $_POST['game'];
            $data = getGameParameters($game);
            $n = $data['n'];
            $m = $data['m'];
            $k = $data['k'];
            include('templates/game.php');
        }
    }
    else
    {
        include('templates/game.php');
    }
?>