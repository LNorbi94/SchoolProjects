<?php

    function getParameter($key, $default)
    {
        if (isset($_GET[$key]) && $_GET[$key] != '')
        {
            return $_GET[$key];
        }
        if (isset($_POST[$key]) && $_POST[$key] != '')
        {
            return $_POST[$key];
        }
        return $default;
    }
    
    function logged()
    {
        return array_key_exists('logged', $_SESSION) && $_SESSION['logged'];
    }

?>