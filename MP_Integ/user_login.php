
<?php

include_once('connect.php');

	
	$username = $_GET['uname'];
	$password = $_GET['password'];

	
	$result = mysqli_query($con,"SELECT * FROM usertable WHERE username = '$username' AND password = '$password'");
		
	if(!$row = mysqli_fetch_assoc($result)) 
        {
        echo "Failed!";
	} 
	else 
	{
	echo "OK!";	
	}

	mysqli_close($con);
?>