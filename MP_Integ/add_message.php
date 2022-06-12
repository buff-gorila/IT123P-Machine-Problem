<?php 

include_once('connect.php');
$message = $_GET['message'];
$username = $_GET['username'];

$queryCommand = "INSERT INTO messagetable (message, username) VALUES ('$message','$username')";
$result = mysqli_query($con,$queryCommand);
if ($result) {
	echo "Message Sent! Thank You!";
} else {
	echo "Unable to send message."; 
}

$con-> close();
?>