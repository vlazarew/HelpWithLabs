-- MySQL Script generated by MySQL Workbench
-- Wed May 26 02:17:17 2021
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema buildings
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `buildings` ;

-- -----------------------------------------------------
-- Schema buildings
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `buildings` DEFAULT CHARACTER SET utf8 ;
USE `buildings` ;

-- -----------------------------------------------------
-- Table `buildings`.`customer`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `buildings`.`customer` ;

CREATE TABLE IF NOT EXISTS `buildings`.`customer` (
  `contract_id` INT NOT NULL,
  `name` VARCHAR(50) NOT NULL,
  `working_hours` VARCHAR(50) NOT NULL,
  `type_of_payment` VARCHAR(50) NOT NULL,
  `payment_amount` INT NULL,
  PRIMARY KEY (`contract_id`))
ENGINE = InnoDB;

CREATE UNIQUE INDEX `contract_id_UNIQUE` ON `buildings`.`customer` (`contract_id` ASC) VISIBLE;


-- -----------------------------------------------------
-- Table `buildings`.`building`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `buildings`.`building` ;

CREATE TABLE IF NOT EXISTS `buildings`.`building` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(50) NOT NULL,
  `type` VARCHAR(50) NULL,
  `year` INT NULL,
  `location` VARCHAR(50) NULL,
  `condition` VARCHAR(50) NULL,
  `customer_contract_id` INT NOT NULL,
  `team` VARCHAR(50) NULL,
  PRIMARY KEY (`id`),
  CONSTRAINT `fk_building_customer`
    FOREIGN KEY (`customer_contract_id`)
    REFERENCES `buildings`.`customer` (`contract_id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;

CREATE UNIQUE INDEX `id_UNIQUE` ON `buildings`.`building` (`id` ASC) VISIBLE;

CREATE INDEX `fk_building_customer_idx` ON `buildings`.`building` (`customer_contract_id` ASC) VISIBLE;


-- -----------------------------------------------------
-- Table `buildings`.`materials`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `buildings`.`materials` ;

CREATE TABLE IF NOT EXISTS `buildings`.`materials` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `building_type` VARCHAR(50) NOT NULL,
  `materials_amount` VARCHAR(50) NOT NULL,
  `type_of_materials` VARCHAR(50) NOT NULL,
  `customer_contract_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  CONSTRAINT `fk_materials_customer1`
    FOREIGN KEY (`customer_contract_id`)
    REFERENCES `buildings`.`customer` (`contract_id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;

CREATE UNIQUE INDEX `id_UNIQUE` ON `buildings`.`materials` (`id` ASC) VISIBLE;

CREATE INDEX `fk_materials_customer1_idx` ON `buildings`.`materials` (`customer_contract_id` ASC) VISIBLE;


-- -----------------------------------------------------
-- Table `buildings`.`office`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `buildings`.`office` ;

CREATE TABLE IF NOT EXISTS `buildings`.`office` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `building_names` VARCHAR(50) NOT NULL,
  `payment` VARCHAR(50) NULL,
  `name` VARCHAR(50) NOT NULL,
  `customer_contract_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  CONSTRAINT `fk_office_customer1`
    FOREIGN KEY (`customer_contract_id`)
    REFERENCES `buildings`.`customer` (`contract_id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;

CREATE UNIQUE INDEX `id_UNIQUE` ON `buildings`.`office` (`id` ASC) VISIBLE;

CREATE INDEX `fk_office_customer1_idx` ON `buildings`.`office` (`customer_contract_id` ASC) VISIBLE;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;