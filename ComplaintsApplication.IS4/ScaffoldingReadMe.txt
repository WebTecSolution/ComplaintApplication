Support for ASP.NET Core Identity was added to your project.

For setup and configuration information, see https://go.microsoft.com/fwlink/?linkid=2116645.

# PackageManagerConsole commands
Must select the ComplaintApplication.IS4 as a Default project and then execute the below commands.
1. update-database -c ApplicationDBCOntext -verbose
2. update-database -c ConfigurationDBContext -verbose
3. update-database -c PersistedGrantDBContext -verbose

Then select the project as start up projects.

Use the below argument on first start to seed the default data to the database
right click on the ComplaintApplication.IS4 Project and select properties and then clickon the Debug. 
Add the below argument in the Application Argument for seeding data.
/seed

It may took little time to execute based on the computer CPU Load and RAM. 
If it prompt the 503 than on 2nd build or execution remove the argument and reexecute.