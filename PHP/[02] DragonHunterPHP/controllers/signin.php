<?php

    if (logged())
    {
        header('Location: index.php?game');
        exit();
    }
    
    function login($name)
    {
        $_SESSION['logged'] = true;
        $_SESSION['name'] = $name;
    }
    
    function selectUser($email)
    {
        $users = loadFromFile('data/users.json');
        $user = null;
        foreach($users as $name => $data)
        {
            if ($data['email'] == $email)
            {
                $user = $data;
                $user['name'] = $name;
            }
        }
        return $user;
    }
    
    $errors = array();
    if ($_POST)
    {
        $data = $_POST;
        $email = trim($data['email']);
        $pw = $data['pw'];
        $user = selectUser($email);
        if (!$user)
        {
            $errors[] = 'Nincs ilyen e-mail címmel regisztrált felhasználó!';
        }
        if (!($user && $user['pw'] == md5($pw)))
        {
            $errors[] = 'Hibás jelszó!';
        }
        if (!$errors)
        {
            login($user['name']);
            header('Location: index.php?game');
            exit();
        }
    }
    include('templates/signin.php');
    
?>