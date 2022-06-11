<?php 

include_once('connect.php');
$messageID = $_GET['messageID']; 
$reporter = $_GET("username");
#query command gets value

$command = "INSERT INTO reporttable (message, messageID, reporterUsername, reportedUsername) select message, messageID, '$reporter', username from messagetable where messageID=$messageID;"; 

$result = mysqli_query($con,$command);
echo "Data Updated";

?>