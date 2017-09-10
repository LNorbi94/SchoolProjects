<html>
    <head>
  	  <link href="urlap.css" rel="stylesheet" type="text/css">
    </head>
<body>
	<?
		if ($_POST['nev'] == "" || $_POST['pw'] == "" || ($_POST['ev'] == "1900" && $_POST['honap1'] == "1" && $_POST['nap'] == "1"))
		{
	?>
<div id="form">
	<form action="" method="post">
	Név: 
	<input type='text' name='nev'
		<?
		if(isset($_POST['kuldes']))
		{
			if($_POST['nev'] == "")
			{
				echo "> <font color='red'>!</font>";
			}
			else
			{
				echo " value='".$_POST['nev']."'>";
			}
		}	

	if (!isset($_POST['kuldes']))
	{
		echo ">";
	}
		?>
<br>
Jelszó: 
<input type='password' name='pw'
	<?
		if(isset($_POST['kuldes']))
		{
			if($_POST['pw'] == "")
			{
				echo "> <font color='red'>!</font>";
			}
			else
			{
				echo " value='".$_POST['pw']."'>";
			}
		}	

if (!isset($_POST['kuldes']))
{
	echo ">";
}
	?>
<br>
Születési év: 
<select name="ev">
	<?
	for($i=1900;$i<2013;$i++)
		{
		if ($i==$_POST['ev']) {
			echo "<option value='".$i."' checked selected='selected'>$i</option>"; }
		else {
			echo "<option value='".$i."'>$i</option>"; }
		}
	?>
</select>
Hónap: 
<select name="honap1">
	<?			
		for($i = 1; $i <= 12; $i++ )
		{
			if ($i==$honap) {
			echo "<option value='".$i."' checked selected='selected'>$i</option>"; }
			else {
			echo "<option value='".$i."'>$i</option>"; }
		}
	?>
</select>
Nap: 
<select name="nap">
<?
	for($i = 1; $i <= 31; $i++ )
	{
		if ($i==$_POST['nap']) {
			echo "<option value='".$i."' checked selected='selected'>$i</option>"; }
		else {
			echo "<option value='".$i."'>$i</option>"; }
	}
?>
</select>
<?
if ($_POST['ev'] == "1900" && $_POST['honap1'] == "1" && $_POST['nap'] == "1") {
	echo "<font color='red'>!</font>";
}
?>
<br>
<input type="submit" value="Küldés" name="kuldes">
</form>
</div>
</body>
</html>
<?
} else {
$honapok = array('január','február','március','április','május','június','július','augsztus','szeptember','október','november','december');
$honap = $_POST['honap1']-1;
	echo "<div id='form'>";
	echo "<font color='#009933' size='+5'>Sikeres regisztráció!</font><br><br>";
	echo "Név: ".$_POST['nev']."<br>\n";
	echo "Jelszó: ";
		for ($i=0;$i<strlen($_POST['pw']);$i++)
		{
			echo "*";
		}
	echo "<br>\n";
	echo "Születési idő: ".$_POST['ev'].". ";
	echo $honapok[$honap].". ";
	echo $_POST['nap'].". ";
	echo "</div>";
}
?>