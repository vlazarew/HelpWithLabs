package application.data.repository;

import application.data.model.Voyage;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;
import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface VoyageRepository extends CrudRepository<Voyage, Long> {
    Page<Voyage> findByFromTSBetweenOrderByPriceAsc(Long fromDate, Long toDate, Pageable pageable);

    Page<Voyage> findAll(Pageable pageable);

    Page<Voyage> findByFrom_City_NameAndTo_City_NameAndFromTSGreaterThanAndFromTSLessThanOrderByPrice(String from_city_name,
                                                                                                      String to_city_name,
                                                                                                      Long fromTS,
                                                                                                      Long fromTS2,
                                                                                                      Pageable pageable);
}
