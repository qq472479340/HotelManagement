
insert into RoomTypes values ('Regular', 100);
insert into RoomTypes values ('Deluxe', 200);
insert into RoomTypes values ('Super Deluxe', 300);
insert into RoomTypes values ('Super Deluxe+', 400);

--DBCC CHECKIDENT ( [Customers], RESEED, 0 )

insert into Rooms values (1, 'FALSE')
insert into Rooms values (1, 'TRUE')
insert into Rooms values (1, 'FALSE')
insert into Rooms values (1, 'FALSE')

insert into Rooms values (2, 'FALSE')
insert into Rooms values (2, 'FALSE')
insert into Rooms values (2, 'TRUE')
insert into Rooms values (2, 'TRUE')

insert into Rooms values (3, 'FALSE')
insert into Rooms values (3, 'FALSE')
insert into Rooms values (3, 'TRUE')
insert into Rooms values (3, 'FALSE')

insert into Rooms values (4, 'TRUE')
insert into Rooms values (4, 'FALSE')
insert into Rooms values (4, 'TRUE')
insert into Rooms values (4, 'TRUE')

insert into Customers values (1, 'Billy Little', '8956 Lakeview Ave. Wilmette, IL 60091', '(496) 580-2486', 'snunez@icloud.com', '2021-08-20 15:00:00', 1, 3, 10)
insert into Customers values (3, 'Fernando Newton', '9741 E. Pumpkin Hill Dr. Dawsonville, GA 30534', '(788) 899-1606', 'fwitness@att.net', '2021-08-25 15:00:00', 2, 6, 20)
insert into Customers values (4, 'Bonnie Farmer', '9327 E. Country St. Old Bridge, NJ 08857', '(810) 439-6595', 'marcs@me.com', '2021-08-23 15:00:00', 3, 4, 10)
insert into Customers values (5, 'Mable Brown', '7834 W. Willow Drive San Antonio, TX 78213', '(996) 591-9593', 'eimear@mac.com', '2021-08-18 15:00:00', 1, 12, 50)
insert into Customers values (6, 'Cindy Nguyen', '7472 Charles Lane Hammonton, NJ 08037', '(416) 649-7264', 'aracne@gmail.com', '2021-08-28 15:00:00', 2, 3, 10)
insert into Customers values (9, 'Delia Wright', '20 SW. Delaware St. Freeport, NY 11520', '(608) 414-7525', 'thaljef@yahoo.ca', '2021-08-10 15:00:00', 1, 20, 50)
insert into Customers values (10, 'Francis Gross', '3 Addison Rd. Garden City, NY 11530', '(403) 425-7786', 'cliffordj@mac.com', '2021-08-29 15:00:00', 2, 5, 10)
insert into Customers values (12, 'Ray Richardson', '216 Valley Dr. Tewksbury, MA 01876', '(785) 354-2716', 'xnormal@gmail.com', '2021-07-28 15:00:00', 1, 25, 50)
insert into Customers values (14, 'Bradley Poole', '751 Kirkland Ave. Apopka, FL 32703', '(542) 450-9442', 'jfmulder@att.net', '2021-07-23 15:00:00', 2, 40, 50)

insert into [Services] values (1, 'Breakfast', 10, '2021-08-21 08:00:00')
insert into [Services] values (1, 'Lunch', 20, '2021-08-21 12:00:00')

insert into [Services] values (3, 'Breakfast', 10, '2021-08-26 08:00:00')
insert into [Services] values (3, 'Lunch', 20, '2021-08-26 12:00:00')

insert into [Services] values (4, 'Breakfast', 10, '2021-08-24 08:00:00')
insert into [Services] values (4, 'Lunch', 20, '2021-08-24 12:00:00')

insert into [Services] values (5, 'Breakfast', 10, '2021-08-19 08:00:00')
insert into [Services] values (5, 'Lunch', 20, '2021-08-19 12:00:00')

insert into [Services] values (6, 'Breakfast', 10, '2021-08-29 08:00:00')
insert into [Services] values (6, 'Lunch', 20, '2021-08-29 12:00:00')

insert into [Services] values (9, 'Breakfast', 10, '2021-08-11 08:00:00')
insert into [Services] values (9, 'Lunch', 20, '2021-08-11 12:00:00')

insert into [Services] values (10, 'Breakfast', 10, '2021-08-30 08:00:00')
insert into [Services] values (10, 'Lunch', 20, '2021-08-30 12:00:00')

insert into [Services] values (12, 'Breakfast', 10, '2021-07-29 08:00:00')
insert into [Services] values (12, 'Lunch', 20, '2021-07-29 12:00:00')

insert into [Services] values (14, 'Breakfast', 10, '2021-07-24 08:00:00')
insert into [Services] values (14, 'Lunch', 20, '2021-07-24 12:00:00')