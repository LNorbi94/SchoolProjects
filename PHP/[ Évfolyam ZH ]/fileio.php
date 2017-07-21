<?php
    function loadFromFile($filename, $base = array())
    {
        $r = @file_get_contents($filename);
        return ($r === false 
            ? $base 
            : json_decode($r, true));
    }

    function saveToFile($filename, $data)
    {
        $r = json_encode($data);
        return file_put_contents($filename, $r, LOCK_EX);
    }
?>