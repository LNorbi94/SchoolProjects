<!DOCTYPE html>
<html>
  <head>
    <meta charset="utf-8">
    <link href="css/default.css" rel="stylesheet">
    <title> Sárkányharcos - Belépés </title>
  </head>
  <body>
    <div id="wrapper">
        <div class="defaultBox">
        <h2> Belépés </h2>
        <ul id="errorList">
            <?php foreach($errors as $k) : ?>
                <li> <?= $k ?> </li>
            <?php endforeach; ?>
        </ul>
        <form action="" method="post">
            <label for="name"> E-mail: </label> <br> <input type="email" id="email" name="email" required="required" autocomplete="off"> <br>
            <label for="pw"> Jelszó: </label> <br> <input type="password" id="pw" name="pw" required="required"> <br>
            <input type="submit" value="Belépés">
        </form>
        </div>
    </div>
  </body>
</html>
