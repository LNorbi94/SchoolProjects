<?
$f = fopen("tevebazis.txt", r);
while(!feof($f))
{
$tombnev[] = trim(fgets($f));
$tombjelszo[] = trim(fgets($f));
}
fclose($f);
foreach ($tombnev as $ind => $ert)
{
if ($tombjelszo[$ind] == $_POST['jelszo'])
{
setcookie("teve", $_POST['select']);
?>
<head>
<title>Tevenevelde</title>
<link href="tevenevelde.css" rel="stylesheet" type="text/css">
</head> 
<body>
<div class="keret">
<?
echo "�dv, ".$_POST['select']." gazd�ja!<br>\n";
echo "Tov�bbl�p�s a tev�dhez: <a href='tevesetup.php'>ITT �S MOST</a>";
?>
</div>
</body>
<?
$bejelentkezve = 1;
}
}
if ($bejelentkezve != 1)
{
?>
<head>
<title>Tevenevelde</title>
<link href="tevenevelde.css" rel="stylesheet" type="text/css">
</head> 
<body>
<div class="keret">
<?
echo "H�t ez nem nyert bar�tom, <a href='login_suti.php'>try again</a>.";
?>
</div>
</body>
<?
}

?>