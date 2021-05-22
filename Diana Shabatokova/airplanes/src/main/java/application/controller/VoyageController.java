package application.controller;

import application.data.model.City;
import application.data.model.Voyage;
import application.service.CityService;
import application.service.VoyageService;
import com.google.gson.Gson;
import com.google.gson.JsonElement;
import com.google.gson.JsonObject;
import com.google.gson.JsonParser;
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
@RequestMapping(value = "/voyages", produces = "application/json")
@CrossOrigin("*")
public class VoyageController {

    @Autowired
    VoyageService voyageService;



    @GetMapping(params = {"numberOfPage", "voyagesOnPage"}, produces = "application/json")
    public ArrayList<Object> getAllVoyages(@RequestParam("numberOfPage") int numberOfPage,
                                           @RequestParam("voyagesOnPage") int voyagesOnPage) {
        ArrayList result = new ArrayList<>();
        Page<Voyage> queryResult = voyageService.getPageOfVoyages(numberOfPage, voyagesOnPage);
        result.add(queryResult.getContent());
        result.add(queryResult.getTotalElements());
        result.add(queryResult.getTotalPages());

        return result;
    }

    @GetMapping(params = {"numberOfPage", "voyagesOnPage", "targetDate"}, produces = "application/json")
    public ArrayList<Object> getVoyagesByDate(@RequestParam("numberOfPage") int numberOfPage,
                                              @RequestParam("voyagesOnPage") int voyagesOnPage,
                                              @RequestParam("targetDate") String targetDateString) {
        ArrayList result = new ArrayList<>();
        Page<Voyage> queryResult = voyageService.getPageOfVoyagesByDate(numberOfPage, voyagesOnPage, targetDateString);
        result.add(queryResult.getContent());
        result.add(queryResult.getTotalElements());
        result.add(queryResult.getTotalPages());

        return result;
    }

    @GetMapping(params = {"fromCity", "toCity", "date", "numberOfPage", "voyagesOnPage"}, produces = "application/json")
    public ArrayList<Object> getVoyagesByFromCityToCityFromDate(@RequestParam("fromCity") String fromCity,
                                                                @RequestParam("toCity") String toCity,
                                                                @RequestParam("date") String targetDateString,
                                                                @RequestParam("numberOfPage") int numberOfPage,
                                                                @RequestParam("voyagesOnPage") int voyagesOnPage) {
        ArrayList result = new ArrayList<>();
        Page<Voyage> queryResult = voyageService.getVoyagesByFromCityToCityFromDate(fromCity, toCity, targetDateString, numberOfPage, voyagesOnPage);
        result.add(queryResult.getContent());
        result.add(queryResult.getTotalElements());
        result.add(queryResult.getTotalPages());

        return result;
    }

    @PostMapping(value = "/calculateVoyages", produces = "application/json")
    public ArrayList<ArrayList<Voyage>> calculateVoyages(@RequestBody String voyages) {
        return voyageService.getAllPossibleWays(voyages);
    }

}
