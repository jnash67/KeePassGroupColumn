# GroupColumn
GroupColumn is a plugin for [KeePass](http://keepass.info). It provides a column in the main entry list that shows the Group an Entry is in.  This can be helpful when the "Show Entries of Subgroups" option in the View menu is enabled and the 'Grouping in Entry List' option is off.

Sometimes you want to sort by something like 'Title' across groups.  You therefore have the 'Grouping in Entry List' off.  You now potentially have a huge list and no idea which of potentially many groups an entry is in.  This column provides that information.

The column shows the full path of the Group.  If the top level is called Database, you have a subgroup called Email and a sub-subgroup called Work, the column will show "Database/Email/Work".  It will also show two numbers.  The first number is the number of items total are in that group, excluding sub-groups.  The second number is the number of items total including sub-groups.  The second number should therefore always be greater than or equal to the first number.

![Screenshot](https://github.com/jnash67/KeePassGroupColumn/blob/master/Screenshots/screenshot-1.png)

## Installation

 - Download the dll from the root directory [here](https://github.com/jnash67/KeePassGroupColumn/blob/master/GroupColumn.dll)
 - Copy the GroupColumn.dll file to the KeePass plugins directory and restart the application.


## Usage

At first you have to activate the column. Therefore navigate to
 - View -> Configure Columns -> (Scroll down) -> Check "Group"


If you have activated, it should show you the column.

## Additional Information
This is my first KeePass plugin.  It was based on a couple of good existing projects:
https://keepass.info/extensions/v2/qualitycolumn/QualityColumn-1.3-Source.zip
https://github.com/tiuub/KP2faChecker