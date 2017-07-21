<?php

    function saveScore($data)
    {
        $filename = 'data/scores.json';
        $scores = loadFromFile($filename);
        $scores[] = [
            'name' => $data[0]
            , 'game' => $data[1]
            , 'score' => $data[2]
        ];
        saveToFile($filename, $scores);
    }
    function filterGame($game)
    {
        $filename = 'data/scores.json';
        $scores = loadFromFile($filename);
        $ret = array();
        foreach ($scores as $k => $v)
        {
            if ($game == $v['game'])
            {
                $ret[] = $v;
            }
        }
        return $ret;
    }
    
    function maxInd($arr)
    {
        if (empty($arr))
        {
            return -1;
        }
        $i = -1;
        for($j = 0; $j < sizeof($arr); ++$j)
        {
            if(isset($arr[$j]) && !isset($arr[$i]) && $i == -1)
            {
                $i = $j;
            }
            if (isset($arr[$j]) && isset($arr[$i]) && $arr[$i]['score'] < $arr[$j]['score'])
            {
                $i = $j;
            }
        }
        return $i;
    }
    
    function topScores($game)
    {
        $scores = filterGame($game);
        $ret = "Toplista a " . $game . " pályán: \n";
        $tScores = array();
        $num = 0;
        $fNum = count($scores) < 10 ? count($scores) : 10;
        while ($num < $fNum)
        {
            $ind = maxInd($scores);
            if($ind != -1)
            {
                $tScores[] = $scores[$ind];
                unset($scores[$ind]);
            }
            $num++;
        }
        foreach ($tScores as $k => $v)
        {
            $ret .= $k + 1 . ". neve: " . $v['name'] . ", pontszáma: " . $v['score'] . ". \n";
        }
        return $ret;
    }
    
    if($_POST)
    {
        $data = explode(",", $_POST['values'][0]);
        saveScore($data);
        echo topScores($data[1]);
    }
    else
    {
        header('Location: index.php');
        exit();
    }
    
?>