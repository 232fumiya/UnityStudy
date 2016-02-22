<!DOCTYPE html>
<html>
<head>

<link href="css/bootstrap.min.css" rel="stylesheet">
<!-- jQuery読み込み -->
<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
<!-- BootstrapのJS読み込み -->
<script src="js/bootstrap.min.js"></script>

	<meta charset="utf-8">
	<title></title>
</head>
<body>
<?php
mb_language("uni");
mb_internal_encoding("utf-8");
mb_http_input("auto");
mb_http_output("utf-8");
$test=$_POST['test'];
if($image==null)
	die();
$con = mysql_connect('[localhost]','[name]','[password]');
mysql_set_charset("utf8", $con);
if (!$con) {
    die('接続失敗です。'.mysql_error());
}
mysql_select_db('unitytest') or die('Cannot select');
		$test_text=mysql_real_escape_string($test);
		$query = "insert into testdata (StringTest,Time)";
		$query .=sprintf("values ('$test_text's,now())");
		mysql_query($query);
mysql_close($con);
?>
</body>
</html>