# GroupColumn
GroupColumn is a plugin for [KeePass](http://keepass.info). It provides a column in the main entry list that shows the Group an Entry is in.  This can be helpful when the "Show Entries of Subgroups" option in the View menu is enabled and the 'Grouping in Entry List' option is off.

Sometimes you want to sort by something like 'Title' across groups.  You therefore have the 'Grouping in Entry List' off.  You now potentially have a huge list and no idea which of potentially many groups an entry is in.  This column provides that information.

The column shows the full path of the Group.  If the top level is called Database, you have a subgroup called Email and a sub-subgroup called Work, the column will show "Database/Email/Work".  It will also show two numbers.  The first number is the number of items total are in that group, excluding sub-groups.  The second number is the number of items total including sub-groups.  The second number should therefore always be greater than or equal to the first number.

## Installation

 - Download the latest release [here](https://github.com/tiuub/KP2faChecker/releases/latest)
 - Copy the KP2faChecker.plgx in the KeePass plugins directory and restart the application.


## Usage

At first you have to activate the column. Therefore navigate to
 - View -> Configure Columns -> (Scroll down) -> Check "2FA Support"


If you have activated, it should show you the column.

![Column](Screenshots/screenshot-1.PNG)

