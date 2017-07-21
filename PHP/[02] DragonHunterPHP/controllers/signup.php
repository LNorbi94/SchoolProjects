<?php

    if (logged())
    {
        header('Location: index.php?game');
        exit();
    }
    
    function signup($data)
    {
        $filename = 'data/users.json';
        $users = loadFromFile($filename);
        if (empty($users))
        {
            $users["admin"] = [
              "email" => "admin@admin.hu"
              , "pw" => md5("admin")  
            ];
        }
        $users[$data['name']] = [
            'email' => $data['email']
            , 'pw' => md5($data['pw'])
        ];
        saveToFile($filename, $users);
    }
    
    $errors = array();
    if($_POST)
    {
        $name = trim($_POST['name']);
        $pw = $_POST['pw'];
        $users = loadFromFile('data/users.json');
        if (strlen($name) == 0)
        {
            $errors[] = 'Nem adtál meg felhasználónevet!';
        }
        if (strlen($pw) == 0)
        {
            $errors[] = 'Nem adtál meg jelszót!';
        }
        if ($name == "admin" || array_key_exists($name, $users))
        {
            $errors[] = 'Ilyen felhasználónév már létezik!';
        }
        if (!$errors)
        {
            signup($_POST);
            header('Location: index.php?signin');
            exit();
        }
    }
    include('templates/signup.php');
    
?>