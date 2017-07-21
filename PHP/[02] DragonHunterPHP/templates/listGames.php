<!DOCTYPE html>
<!--
  Készítő:    Lestár Norbert
  Neptun kód: A8UZ7T
  E-mail cím: lestarnrbert@inf.elte.hu
-->
<html>
  <head>
    <meta charset="utf-8">
    <link href="css/default.css" rel="stylesheet">
    <title> Sárkányharcos - Játék kiválasztása </title>
  </head>
  <body>
    <div id="wrapper">
      <div class="defaultBox">
        <?php if (strcmp($_SESSION['name'], "admin") === 0) : ?>
        <h2> Pálya hozzáadása </h2>
        <form method="post" action="" id="add">
            <label for="name"> Pálya neve: </label> <br> <input type="text" id="name" name="name" required="required"> <br>
            <label for="dimension"> Mérete: </label> <br>
            <input type="number" id="dimension" name="n" required="required"> x <input type="number" id="dimension" name="m" required="required"> <br>
            <label for="k"> Tereptárgyak száma: </label> <br> <input type="number" id="k" name="k" required="required"> <br>
            <input type="submit" value="Pálya hozzáadása!" name="add">
        </form>
        <?php endif; ?>
        <h2> Pálya kiválasztása </h2>
        <form action="index.php?game" method="post">
            <?php foreach($games as $k => $v) : ?>
                <input type="radio" name="game" value="<?= $k ?>"> <?= $k ?> | <?= $v ?> <br>
            <?php endforeach; ?>
            <input type="submit" value="Pálya kiválasztása!">
        </form>
      </div>
    </div>
  </body>
</html>
