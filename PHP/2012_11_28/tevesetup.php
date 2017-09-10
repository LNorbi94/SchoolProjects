<?
if (isset($_COOKIE['teve'])) {
?>
<head>
<title>Tevenevelde</title>
<link href="tevenevelde.css" rel="stylesheet" type="text/css">
</head> 
<body>
<div class="keret">
<?
echo $_COOKIE['teve']." gazdája, most linken keresztül jöttél, de tudom hogy te jelentkeztél be!<br>\n";
echo "<a href='login_suti.php'>Kijelentkezés</a>";
?>
</div>
</body>
<?
} else {
?>
<head>
<title>Tevenevelde</title>
<link href="tevenevelde.css" rel="stylesheet" type="text/css">
</head> 
<body>
<div class="keret">
<?
echo "NAAAAA, az nem úgy van ám! Tunés <a href='login_suti.php'>bejelentkezni</a>!"; 
?>
</div>
</body>
<?
}
?>