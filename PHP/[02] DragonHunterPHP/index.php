<?php
    function start_routing()
    {
        $request_method = $_SERVER['REQUEST_METHOD'];
        $query_string = $_SERVER['QUERY_STRING'];

        $qsarr = explode('&', $query_string);
        $page = array_shift($qsarr);

        if ($page)
        {
            unset($_GET[$page]);
        } else
        {
            $page = 'main_page';
        }

        $method = strtolower($request_method);
        $page_with_method = "{$page}_{$method}";

        $controller_path = __DIR__ . '/controllers/' . $page_with_method . '.php';
        if (file_exists($controller_path))
        {
            require $controller_path;
        } else
        {
            $controller_path = __DIR__ . '/controllers/' . $page . '.php';
            if (file_exists($controller_path))
            {
                require $controller_path;
            } else
            {
                die('Az oldal nem található!');
            }   
        }
    }

    require_once('common/fileio.php');
    require_once('common/session.php');
    session_start();
    start_routing();
?>