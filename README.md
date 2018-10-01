# CharacterSheetCreator
A Web-based D&amp;D Character Creator


### Setup Web Site
1. Clone & Checkout Repo to C:/Checkouts/CharacterSheetCreator
2. Install IIS: https://msdn.microsoft.com/en-us/library/ms181052(v=vs.80).aspx
3. Install Microsoft Visual Studio (best for this type of project)
4. Open IIS
5. Click the dropdown in Connections (on the left) next to your computer name
6. Click the dropdown that says 'Sites'
7. Right click on 'Default Web Site'
8. Click 'Add Application'
9. In the Alias field write 'characterSheet'
10. In the physical path write: 'C:/Checkouts/CharacterSheetCreator/DDCharacterSheet'
11. Open your favorite Web Browser and navigate to: localhost/characterSheet
12. You should see the Website! Woohoo!


### Setup WebAPI
1. Clone & Checkout Repo to C:/Checkouts/CharacterSheetCreator
2. Install IIS: https://msdn.microsoft.com/en-us/library/ms181052(v=vs.80).aspx
3. Install Microsoft Visual Studio (best for this type of project)
4. Open IIS
5. Click the dropdown in Connections (on the left) next to your computer name
6. Click the dropdown that says 'Sites'
7. Right click on 'Default Web Site'
8. Click 'Add Application'
9. In the Alias field write 'CharacterSheetWebAPI'
10. In the physical path write: 'C:/Checkouts/CharacterSheetCreator/CharacterSheetWebAPI'
11. Open the DDCharacterSheet solution in Microsoft Visual Studio (MAKE SURE TO RUN AS ADMINISTRATOR)
12. In the Solution Explorer right click on "CharacterSheetWebAPI" then click 'Properties'
13. Go to the 'Web' tab
14. Under the 'Servers' section click the dropdown and change it from 'IIS Express' to 'Local IIS'
15. Click 'Create Virtual Directory'
16. In the Solution Explorer right click on "CharacterSheetWebAPI" then click 'Rebuild'
17. In the Solution Explorer right click on "CharacterSheetWebAPI" then click 'Debug -> Start New Instance'
18. A browser window should open and you should see an API Web Page. Woohoo!



### Setup Database
