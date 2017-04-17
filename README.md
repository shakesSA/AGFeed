# AGFeed
AGFeed Solution for users and tweets

The AGFeed Console Application has been developed in C# on Visual Studio 2017 Community Edition.

This application processes user information and tweet information, it then displays the tweets to the console by user in alphabetical order.

	APPLICATION PROCESSING
	The application will read int the user.txt and tweet.txt files.

	It will then process the files and write the output to the console.
	The ouput will be in the format of user in alphabetical order and all tweets by them or users that they are following.

	Any error records on the input files will be wriiten to the error.txt file and the application will ignore the record and continue processing.


	INPUT & OUTPUT
	Input Files:
	user.txt	-	Contains User Records
	tweet.txt	-	Contains Tweet Records
	Output File:
	error.txt	-	Contains User & Tweet Error Records


	RECORD FORMATS
	The expected format of the user records is:
	Ward follows Alan

	The expected format of the tweet record is:
	Alan> If you have a procedure with 10 parameters, you probably missed some.

	The format of the error record is:
	Error Record:Invalid User Record: Ward followsssssss Alan

UNIT TEST PROJECT
This project consists of unit test to test the main functionality of the AGFeed application.
