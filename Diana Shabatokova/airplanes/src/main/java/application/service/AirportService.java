package application.service;

import application.data.model.Airport;
import application.data.repository.AirportRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.PageRequest;
import org.springframework.stereotype.Service;

@Service
public class AirportService {
    @Autowired
    private AirportRepository airportRepository;

    public Page<Airport> getPageOfAirports(int numberOfPage, int airportsOnPage) {
        PageRequest page = PageRequest.of(numberOfPage, airportsOnPage);

        return airportRepository.findAll(page);
    }

    public void saveAirport(Airport airport) {
        airportRepository.save(airport);
    }

}
