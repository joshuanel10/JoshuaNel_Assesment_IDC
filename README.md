In order to run the following application, the following steps must be followed:

Database:

In SQL Server Management Studio right click Databases on left pane (Object Explorer)
Click Restore Database
Choose Device, click the “…” icon and add the IDC_Assesment.bak file
Click OK, then OK again

Visual Studio:

Open the following pages: 
	a. ClientCapture.aspx.cs 
	b. ClientOverView.aspx.cs 
	c. PaymentCapture.aspx.cs d. 
Use ctrl+f to fine the following lines of code: 
	a. SqlConnection con = new SqlConnection(@"Data Source=CUR002-5CD80-61;Initial Catalog=IDC_Assesment; Integrated Security=True");
Find your own server’s name in SQL Server Management Studio: 
	a. Right click the server’s name in the left pane (Object Explorer) – it will be the topmost item. 
	b. Click on Properties 
	c. Copy the value under name.
Replace the value after Data Source= with your server’s name
The new Connection string should like this: 
	a. SqlConnection con = new SqlConnection(@"Data Source=(your server name);Initial Catalog=farmersDB; Integrated Security=True"); 
	b. Put your server’s name in the brackets and then remove the brackets
Close all windows and run the web application.
