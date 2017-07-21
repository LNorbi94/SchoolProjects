<?php
    require_once('fileio.php');
    $stars = [];
    function loadStars()
    {
        $stars = loadFromFile('msg.json');
        $ret = [];
        if ($_GET && $_GET['type'] != '')
        {
            foreach ($stars as $s)
            {
                if ($s['type'] === $_GET['type'])
                {
                    $ret[] = $s;
                }
            }
        }
        else
        {
            $ret = $stars;
        }
        return $ret;
    }
    function check($data)
    {
        $errors = [];
        if ($data["type"] == "")
        {
            $errors[] = "Nem adta meg az üzenet típusát!";
        }
        if ($data["name"] == "")
        {
            $errors[] = "Nem adott meg nevet!";
        }
        if ($data["email"] == "")
        {
            $errors[] = "Nem adott meg e-mailt!";
        }
        else if (!filter_var($data["email"], FILTER_VALIDATE_EMAIL))
        {
            $errors[] = "Nem adott meg megfelelő e-mailt!";
        }
        if ($data["msg"] == "")
        {
            $errors[] = "Nem adott meg üzenetet!";
        }
        return $errors;
    }
    function write($data)
    {
        $filename = 'msg.json';
        $datas = loadFromFile($filename);
        $datas[] = [
            'id' => time()
            , 'date' => date("Y m d")
            , 'type' => $data['type']
            , 'name' => $data['name']
            , 'email' => $data['email']
            , 'msg' => $data['msg']
        ];
        saveToFile($filename, $datas);
    }
    $errors = [];
    if ($_POST)
    {
        $errors = check($_POST);
        if (empty($errors))
        {
            write($_POST);
        }
    }
?>
<!DOCTYPE html>
<html>
    <head>
        <meta charset="utf-8">
        <title> Üzenőfal </title>
        <script type="text/javascript" src="msg.js"> </script>
    </head>
    <body>
        <ul>
            <?php foreach ($errors as $e) : ?>
                <li> <?= $e ?> </li>
            <?php endforeach; ?>
        </ul>
        <form method="post" action="">
            Kategória:
            <select name="type">
                <option value="important"> Fontos </option>
                <option value="interesting"> Érdekes </option>
                <option value="funny"> Vicces </option>
                <option value="mandatory"> Kötelező </option>
            </select> <br>
            Beküldő neve: <input type="text" name="name"> <br>
            Beküldő e-mail címe: <input type="text" name="email"> <br>
            Üzenet: <textarea name="msg" id="msg" style="border-width: 1px"></textarea>
            <span id="msgLength"> 0 </span> <br>
            <input type="submit" value="Küldés">
        </form>
        <div id="msgPrev" style="word-wrap: break-word">
            
        </div>
    </body>
</html>