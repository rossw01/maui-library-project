# LibraryProject
Simple library program I created to test .NET MAUI after completing the Microsoft course.

Allows the user to create an account, and select specific branches. The function to browse through the selected library's books has not yet been implemented.
There is also the option for an Admin to create an Admin account where they can delete prexisting branches or create new branches.

Storage for the program is handled with SQLite.Net-PCL, as this was what was recommended during the .NET MAUI course on the Microsoft website.
This introduced a limitation - SQLite cannot directly handle storage of images, therefore images stored in the database had to be converted into a Byte array in order to be stored as a BLOB.
Because of this, I had to created 2 branch classes: Branch and SelectableBranch as a workaround in order allow me to present the branches in a collection view with their associated images (select branch page), as well as store them in the sqlite3 db.
