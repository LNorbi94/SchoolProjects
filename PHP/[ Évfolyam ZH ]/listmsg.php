 <?php
    require_once('fileio.php');
    $msgs = [];
    function loadMsgs()
    {
        $msgs = loadFromFile('msg.json');
        $ret = [];
        if ($_GET)
        {
            foreach ($msgs as $s)
            {
                if ($s['type'] === $_GET['type']
                || $_GET['type'] === '')
                {
                    if ($s['name'] === $_GET['name'] || $_GET['name'] == '')
                    {
                        $ret[] = $s;
                    }
                }
            }
        }
        else
        {
            $ret = $msgs;
        }
        return $ret;
    }
    $msgs = loadMsgs();
?>
<!DOCTYPE html>
<html>
    <head>
        <meta charset="utf-8">
        <title> Üzenőfal - listázás </title>
        <script type="text/javascript" src="msg.js"> </script>
    </head>
    <body>
        <form method="get" post="">
            <select name="type">
                <option> </option>
                <option value="important"> Fontos </option>
                <option value="interesting"> Érdekes </option>
                <option value="funny"> Vicces </option>
                <option value="mandatory"> Kötelező </option>
            </select> <br>
            Beküldő neve: <input type="text" name="name"> <br>
            <input type="submit" value="Szűrés">
        </form>
        <div id="msgs">
            <?php foreach ($msgs as $s) : ?>
            <div>
                Kategória: <?= $s["type"] ?> <br>
                Beküldő neve: <?= $s["name"] ?> <br>
                Beküldő e-mail címe: <?= $s["email"] ?> <br>
                Üzenet: <p id="msgPrev"> <?= $s["msg"] ?> </p>
            </div>
            <?php endforeach; ?>
        </div>
    </body>
</html>