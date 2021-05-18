package application.data.repository;

import application.data.model.Airport;
import org.springframework.data.repository.CrudRepository;
import org.springframework.data.repository.PagingAndSortingRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface AirportRepository extends PagingAndSortingRepository<Airport, Long> {

//    Page<Airport> findAll(Pageable page);
}
