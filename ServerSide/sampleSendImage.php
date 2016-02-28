<!DOCTYPE html>
<html>
<head>

<meta charset="utf-8">
	<title></title>
</head>
<body>
<?php
//バイナリデータ用
$file=$_FILES['image'];
$tmp_name = $file['tmp_name'];  
$img=file_get_contents($tmp_name);
if($img==null)
{
	die();
}
$path='C:\xampp\htdocs\images\img.png';
file_put_contents($path,$img);
	
?>
</body>
</html>