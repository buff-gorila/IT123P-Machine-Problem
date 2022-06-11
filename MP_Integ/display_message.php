<?php

include_once('connect.php');

$query = "SELECT message, messageID FROM messagetable ORDER BY RAND() LIMIT 1;";
$check=mysqli_query($con,$query);
$row=mysqli_num_rows($check);
$myArray = array();

if($check == FALSE) { 
    echo "messages are not available. Try entering a new one.";
	return;
} else {
	  while($row=mysqli_fetch_array($check))
		{
  	
		$myArray[] = $row;
	
		}
	echo json_encode($myArray);
}

mysqli_close($con);

?>