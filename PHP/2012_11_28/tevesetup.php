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
echo $_COOKIE['teve']." gazd�ja, most linken kereszt�l j�tt�l, de tudom hogy te jelentkezt�l be!<br>\n";
echo "<a href='login_suti.php'>Kijelentkez�s</a>";
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
echo "NAAAAA, az nem �gy van �m! Tun�s <a href='login_suti.php'>bejelentkezni</a>!"; 
?>
</div>
</body>
<?
}
?>