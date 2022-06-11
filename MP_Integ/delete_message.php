<?php 

include_once('connect.php');
$messageID = $_GET['messageID'];



$command = "DELETE FROM messagetable WHERE messageID= '". $messageID ."'";
$removereport = "DELETE FROM reporttable WHERE messageID= '". $messageID ."'";

$result = mysqli_query($con,$command);
$removereport = mysqli_query($con,$removereport);
if($result && $removereport) { 
  echo "Success: ";
} else {
	echo"ERROR IN DATABASE.";
}

mysqli_close($con);
?>