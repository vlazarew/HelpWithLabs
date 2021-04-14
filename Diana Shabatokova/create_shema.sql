create schema traveller;

create table traveller.city
(
    id   bigint      NOT NULL PRIMARY KEY,
    name varchar(50) NOT NULL
);

create table traveller.type_of_room
(
    id   bigint      NOT NULL PRIMARY KEY,
    name varchar(50) NOT NULL
);

create table traveller.type_of_transport
(
    id   bigint      NOT NULL PRIMARY KEY,
    name varchar(50) NOT NULL
);

create table traveller.hotel
(
    id              bigint      NOT NULL PRIMARY KEY,
    city_id         bigint      NOT NULL,
    name            varchar(50) NOT NULL,
    type_of_room_id bigint      NOT NULL,
    price_per_day   int         NOT NULL check ( price_per_day > 0 )
);

create table traveller.transport
(
    id                   bigint      NOT NULL PRIMARY KEY,
    city_id              bigint      NOT NULL,
    type_of_transport_id bigint      NOT NULL,
    destination_id       bigint      NOT NULL,
    name_of_voyage       varchar(50) NOT NULL,
    price                int         NOT NULL check ( price > 0 )
);

alter table traveller.hotel
    add constraint city_fk FOREIGN KEY (city_id) REFERENCES traveller.city (id)
        ON UPDATE CASCADE
        ON DELETE CASCADE;

alter table traveller.hotel
    add constraint type_of_room_fk FOREIGN KEY (type_of_room_id) REFERENCES traveller.type_of_room (id)
        ON UPDATE CASCADE
        ON DELETE CASCADE;

alter table traveller.transport
    add constraint city_fk FOREIGN KEY (city_id) REFERENCES traveller.city (id)
        ON UPDATE CASCADE
        ON DELETE CASCADE;

alter table traveller.transport
    add constraint type_of_transport_fk FOREIGN KEY (type_of_transport_id) REFERENCES traveller.type_of_transport (id)
        ON UPDATE CASCADE
        ON DELETE CASCADE;

alter table traveller.transport
    add constraint destination_fk FOREIGN KEY (destination_id) REFERENCES traveller.city (id)
        ON UPDATE CASCADE
        ON DELETE CASCADE;