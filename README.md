# _Hair Salon_

#### _A program for a hair salon client-list management system, 05.10.2019_

#### By _Stuart McKay_

## Description
_This program creates client-lists for distinct (hair) stylists_

## Specs

| Behavior | Input | Output |
| ------------- |:-------------:| -----:|
| Saves stylist name to database and assign a primary key Id | Krystal | Id = 1, Krystal  |
| Save client name to database and assign a primary key Id | Mr. Clean | Id = 1, Mr. Clean |
| Add stylist primary key to client table and use it as a foreign key to separate client lists |Id = 1, Mr Clean | Id = 1, Mr. Clean, stylistId = 1 |
| Navigate by clicking to display a stylist's client list | Stylists: Krystal, Jamie, Mark [Clicking on a specific stylist's name (Krystal)]  | Displays client List for Krystal |
| Click on client name to display name and servicing stylist | Mr Clean | Name: Mr. Clean, Stylist: Krystal |


## Known Bugs

* _When generating a new client instance without returning to the stylist list, client will get saved under stylistId = 0, returning an inaccessible client list to the server and displaying a client list without a stylist attached to it._

## Support and contact details

_Should any problems occur, or any bugs discovered, please contact Stuart McKay @ stuart51994@gmail.com_

## Technologies Used

_This program was written in C# with MAMP._

### License

*This software is licensed under MIT license.*

Copyright (c) 2019 **_Stuart McKay_**
