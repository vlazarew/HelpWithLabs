package application.data.repository;

import application.data.model.City;
import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

import java.util.ArrayList;

@Repository
public interface CityRepository extends CrudRepository<City, Long> {

    ArrayList<City> findByNameContaining(String template);

    ArrayList<City> findAll();

}
