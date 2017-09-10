<?php
session_start();
session_unset();
setcookie("ln_log", "", 0);
Header("Location:index.php");
?>