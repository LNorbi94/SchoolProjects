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
echo "Üdv, ".$_POST['select']." gazdája!<br>\n";
echo "Továbblépés a tevédhez: <a href='tevesetup.php'>ITT ÉS MOST</a>";
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
echo "Hát ez nem nyert barátom, <a href='login_suti.php'>try again</a>.";
?>
</div>
</body>
<?
}

?>