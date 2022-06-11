<?php 

include_once('connects.php');
$message = $_GET['message'];
$username = $_GET['username'];

$queryCommand = "INSERT INTO messagetable (message, username) VALUES ('$message','$username')";
$result = mysqli_query($con));
echo "Message Sent! Thank You!";

$con-> close();
?>