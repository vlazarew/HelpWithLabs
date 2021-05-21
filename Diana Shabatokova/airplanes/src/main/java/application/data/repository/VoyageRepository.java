package application.data.repository;

import application.data.model.Airport;
import application.data.model.Voyage;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;
import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

import java.time.LocalDate;

@Repository
public interface VoyageRepository extends CrudRepository<Voyage, Long> {
    Page<Voyage> findByFromDateBetweenOrderByPriceAsc(LocalDate fromDate, LocalDate toDate, Pageable pageable);

    Page<Voyage> findAll(Pageable pageable);

    Page<Voyage> findByFrom_City_NameAndTo_City_NameAndFromDateBetweenOrderByPriceAsc(String fromCityName,
                                                                                      String toCityName,
                                                                                      LocalDate fromDate,
                                                                                      LocalDate toDate, Pageable pageable);
}
