<?php
if (isset($_COOKIE['forum']))
{
if (isset($_POST['logout'])) { setcookie("forum", "", time() -3600); Header("Location:belepes.php"); }
if (isset($_POST['msgdel']))
{
	$db = mysql_connect('localhost', 'root', '');
	if (!$db) {
    die('Could not connect: ' . mysql_error()); }
	mysql_select_db('forum');
	mysql_query("DELETE FROM `forum`.`forum` WHERE `forum`.`id` = '".$_POST['id']."'"); 
	mysql_close($db);
}
if (isset($_POST['newmsg']))
{
	$db = mysql_connect('localhost', 'root', '');
	if (!$db) {
    die('Could not connect: ' . mysql_error());
	}
	mysql_select_db('forum');
	$ugly_q = mysql_query("SELECT * FROM `ugly`");
	$ugly_f = 0;
	while ($ugly = mysql_fetch_assoc($ugly_q))
	{
	if (strpos(strtolower($_POST['msg']), $ugly["expression"]) !== false)
	{ $ugly_f = 1; }
	}
	if ($ugly_f == 0) {
	mysql_query("SET CHARACTER SET latin2");
	mysql_query("INSERT INTO `forum`.`forum` (`username`, `message`) VALUES ('".$_COOKIE['forum']."', '".$_POST['msg']."')");
	}
	mysql_close($db);
}
echo "<div class='kozepdiv'>�dv <b>".$_COOKIE['forum']."</b>! <br>";
?>
�j hozz�sz�l�s �r�sa:
<form action="" method="post">
<textarea name="msg" cols="35" rows="5"></textarea><br>
<input type="submit" name="newmsg" value="Mehet!">
</form>
<?php
	$db = mysql_connect('localhost', 'root', '');
	if (!$db) {
    die('Could not connect: ' . mysql_error());
	}
	mysql_select_db('forum');
	mysql_query("SET CHARACTER SET latin2");
	$m = mysql_query("SELECT * FROM forum ORDER BY id desc");
	while ($row = mysql_fetch_assoc($m)) {
	echo $row["message"]."<br>";
	echo "<b>�rta:</b> ".$row["username"]."<br>";
	if ($row["username"] == $_COOKIE['forum'] || $_COOKIE['forum'] == "admin")
	{
	echo "<form action='' method='post'><input type='hidden' name='id' value='".$row["id"]."'>
	<input type='submit' name='msgdel' value='Hozz�sz�l�s t�rl�se'></form>";
	}
	}
	mysql_close($db);
	echo "<form action='' method='post'><input type='submit' value='Kijelentkez�s!' name='logout'></form></div>";
	}
 else { 
echo "Nem vagy bel�pve! <a href='belepes.php'>Bejelentkez�s...</a>";
}
?>
<html>
    <head>
	  <title>F�rum</title>
	  <meta http-equiv="Content-Type" content="text/html; charset=windows-1250">
	  
      <link href="forum.css" rel="stylesheet" type="text/css">
    </head>
<body>
</body></html>