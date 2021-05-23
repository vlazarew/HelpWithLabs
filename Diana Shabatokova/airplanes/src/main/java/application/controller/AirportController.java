package application.controller;

import application.data.model.Airport;
import application.service.AirportService;
import lombok.AccessLevel;
import lombok.RequiredArgsConstructor;
import lombok.experimental.FieldDefaults;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.Page;
import org.springframework.web.bind.annotation.*;

import java.util.ArrayList;

@RestController
@FieldDefaults(level = AccessLevel.PRIVATE)
@RequiredArgsConstructor
@RequestMapping(value = "/airports", produces = "application/json")
@CrossOrigin("*")
public class AirportController {
    @Autowired
    AirportService airportService;

    @GetMapping(params = {"numberOfPage", "airportsOnPage"}, produces = "application/json")
    public ArrayList<Object> getAllAirports(@RequestParam("numberOfPage") int numberOfPage,
                                            @RequestParam("airportsOnPage") int airportsOnPage) {
        ArrayList result = new ArrayList<>();
        Page<Airport> queryResult = airportService.getPageOfAirports(numberOfPage, airportsOnPage);
        result.add(queryResult.getContent());
        result.add(queryResult.getTotalElements());
        result.add(queryResult.getTotalPages());

        return result;
    }

    @PostMapping(consumes = "application/json", produces = "application/json")
    public void addAirport(@RequestBody Airport airport) {
        airportService.saveAirport(airport);
    }
}
