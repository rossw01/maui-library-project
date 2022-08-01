# LibraryProject
Simple library program I created to test .NET Maui after completing the Microsoft course.

Allows the user to create an account, select specific branches and browse and filter through said branch's books.
There is also the option for an Admin to create an Admin account where they can delete prexisting branches, create new branches, remove prexisting books from specific branches, and add new books to branches.

Storage for the program is handled with SQLite.Net-PCL, as this was what was recommended during the .NET Maui course on the Microsoft website.
This introduced a limitation - SQLite cannot directly handle storage of images, therefore images stored in the database had to be converted into a Byte array in order to be stored as a BLOB.
Because of this, I created 2 branch classes: Branch and SelectableBranch as a workaround in order allow me to present the branches in a collection view with their associated images.

