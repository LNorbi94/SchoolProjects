<?
session_start();
session_unset();
setcookie("teve", "", time() -3600);
$f = fopen("tevebazis.txt", r);
while(!feof($f))
{
$tombnev[] = fgets($f);
$tombjelszo[] = fgets($f);
}
fclose($f);
?>
<html>

<head>
<title>Tevenevelde</title>
<link href="tevenevelde.css" rel="stylesheet" type="text/css">
</head>

<body>
<div class="keret">
Melyik tev�dhez szeretn�l bejelentkezni?
<form action="bent.php" method="POST">
  <select name="select">
  <?
  foreach ($tombnev as $ind => $ert)
  {
  echo "<option>".$ert."</option>";
  }
  ?>
  </select><br>
  Jelsz�: <input type="password" name="jelszo"><br>
  Felhaszn�l�n�v megjegyz�se <input type="checkbox" name="suti"><br>
  <input type="submit" value="Mehet!" name="kuldes">
</form>
</div>

</body>

</html>