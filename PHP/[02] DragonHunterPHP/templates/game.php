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
    <title> Sárkányharcos - Játék </title>
    <script type="text/javascript" src="js/variables.js"></script>
    <script type="text/javascript">
        function start()
        {
            n = <?= $n ?>;
            m = <?= $m ?>;
            k = <?= $k ?>;
            game = '<?= $game ?>';
            name = '<?= $name ?>';
            initGame(n, m, k);
        }
    </script>
    <script type="text/javascript" src="js/ajax.js"></script>
    <script type="text/javascript" src="js/gui.js"></script>
    <script type="text/javascript" src="js/gameLogic.js"></script>
    <script type="text/javascript" src="js/commonFunctions.js"></script>
  </head>
  <body>
    <div id="wrapper">
      <div id="game">
        <table id="gameTable">
        </table>
        <div id="topBar"> <p id="score"> Pontszám: <span id="points">1</span> </p>
        <p id="scroll"> Aktív tekercs: <span id="activeScroll">-</span> </p> </div>
        <div> <p id="newGame"> <input type="button" value="Új játék!" id="newGameBtn"> </p> </div>
      </div>
    </div>
  </body>
</html>
