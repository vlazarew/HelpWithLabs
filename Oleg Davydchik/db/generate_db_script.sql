-- MySQL Script generated by MySQL Workbench
-- Thu Apr 15 21:38:23 2021
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema communal_services
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `communal_services` ;

-- -----------------------------------------------------
-- Schema communal_services
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `communal_services` DEFAULT CHARACTER SET utf8 ;
USE `communal_services` ;

-- -----------------------------------------------------
-- Table `communal_services`.`address_register`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `communal_services`.`address_register` ;

CREATE TABLE IF NOT EXISTS `communal_services`.`address_register` (
  `id` BIGINT NOT NULL,
  `street` VARCHAR(50) NOT NULL,
  `house` VARCHAR(10) NOT NULL,
  `flat` INT NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;

CREATE UNIQUE INDEX `id_UNIQUE` ON `communal_services`.`address_register` (`id` ASC) VISIBLE;


-- -----------------------------------------------------
-- Table `communal_services`.`consumer`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `communal_services`.`consumer` ;

CREATE TABLE IF NOT EXISTS `communal_services`.`consumer` (
  `id` BIGINT NOT NULL,
  `name` VARCHAR(50) NOT NULL,
  `surname` VARCHAR(80) NOT NULL,
  `phone_number` VARCHAR(11) NOT NULL,
  `address_register_id` BIGINT NOT NULL,
  `login` VARCHAR(45) NOT NULL,
  `password` VARCHAR(45) NOT NULL,
  `type_of_consumer_id` BIGINT NOT NULL,
  PRIMARY KEY (`id`),
  CONSTRAINT `fk_consumer_address_register1`
    FOREIGN KEY (`address_register_id`)
    REFERENCES `communal_services`.`address_register` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_consumer_type_of_consumer1`
    FOREIGN KEY (`type_of_consumer_id`)
    REFERENCES `communal_services`.`type_of_consumer` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

CREATE INDEX `fk_consumer_address_register1_idx` ON `communal_services`.`consumer` (`address_register_id` ASC) VISIBLE;

CREATE UNIQUE INDEX `login_UNIQUE` ON `communal_services`.`consumer` (`login` ASC) VISIBLE;

CREATE INDEX `fk_consumer_type_of_consumer1_idx` ON `communal_services`.`consumer` (`type_of_consumer_id` ASC) INVISIBLE;

CREATE INDEX `name_surname` ON `communal_services`.`consumer` (`name` ASC, `surname` ASC) VISIBLE;

CREATE UNIQUE INDEX `id_UNIQUE` ON `communal_services`.`consumer` (`id` ASC) VISIBLE;

CREATE UNIQUE INDEX `phone_number_UNIQUE` ON `communal_services`.`consumer` (`phone_number` ASC) VISIBLE;


-- -----------------------------------------------------
-- Table `communal_services`.`consumer_card`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `communal_services`.`consumer_card` ;

CREATE TABLE IF NOT EXISTS `communal_services`.`consumer_card` (
  `id` BIGINT NOT NULL,
  `date_of_pay` TIMESTAMP NOT NULL,
  `consumer_id` BIGINT NOT NULL,
  `type_of_service_id` BIGINT NOT NULL,
  PRIMARY KEY (`id`),
  CONSTRAINT `fk_consumer_card_consumer1`
    FOREIGN KEY (`consumer_id`)
    REFERENCES `communal_services`.`consumer` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_consumer_card_type_of_service1`
    FOREIGN KEY (`type_of_service_id`)
    REFERENCES `communal_services`.`type_of_service` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

CREATE INDEX `fk_consumer_card_consumer1_idx` ON `communal_services`.`consumer_card` (`consumer_id` ASC) VISIBLE;

CREATE INDEX `fk_consumer_card_type_of_service1_idx` ON `communal_services`.`consumer_card` (`type_of_service_id` ASC) VISIBLE;

CREATE UNIQUE INDEX `id_UNIQUE` ON `communal_services`.`consumer_card` (`id` ASC) VISIBLE;


-- -----------------------------------------------------
-- Table `communal_services`.`payments`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `communal_services`.`payments` ;

CREATE TABLE IF NOT EXISTS `communal_services`.`payments` (
  `id` INT NOT NULL,
  `deadline` TIMESTAMP NOT NULL,
  `consumer_card_id` BIGINT NOT NULL,
  PRIMARY KEY (`id`),
  CONSTRAINT `fk_payments_consumer_card1`
    FOREIGN KEY (`consumer_card_id`)
    REFERENCES `communal_services`.`consumer_card` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

CREATE INDEX `fk_payments_consumer_card1_idx` ON `communal_services`.`payments` (`consumer_card_id` ASC) VISIBLE;

CREATE UNIQUE INDEX `id_UNIQUE` ON `communal_services`.`payments` (`id` ASC) VISIBLE;


-- -----------------------------------------------------
-- Table `communal_services`.`type_of_consumer`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `communal_services`.`type_of_consumer` ;

CREATE TABLE IF NOT EXISTS `communal_services`.`type_of_consumer` (
  `id` BIGINT NOT NULL,
  `name` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;

CREATE UNIQUE INDEX `name_UNIQUE` ON `communal_services`.`type_of_consumer` (`name` ASC) VISIBLE;

CREATE UNIQUE INDEX `id_UNIQUE` ON `communal_services`.`type_of_consumer` (`id` ASC) VISIBLE;


-- -----------------------------------------------------
-- Table `communal_services`.`type_of_service`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `communal_services`.`type_of_service` ;

CREATE TABLE IF NOT EXISTS `communal_services`.`type_of_service` (
  `id` BIGINT NOT NULL,
  `name` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;

CREATE UNIQUE INDEX `name_UNIQUE` ON `communal_services`.`type_of_service` (`name` ASC) VISIBLE;

CREATE UNIQUE INDEX `id_UNIQUE` ON `communal_services`.`type_of_service` (`id` ASC) VISIBLE;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;