package application.controller;

import application.data.model.City;
import application.service.CityService;
import lombok.AccessLevel;
import lombok.RequiredArgsConstructor;
import lombok.experimental.FieldDefaults;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.ArrayList;

@RestController
@FieldDefaults(level = AccessLevel.PRIVATE)
@RequiredArgsConstructor
@RequestMapping(value = "/cities", produces = "application/json")
@CrossOrigin("*")
public class CityController {

    @Autowired
    CityService cityService;

    @GetMapping(params = {"template"}, produces = "application/json")
    public ArrayList<City> getCitiesByTemplate(@RequestParam("template") String template) {
        return cityService.getCitiesByTemplate(template);
    }

    @GetMapping(produces = "application/json")
    public ArrayList<City> getAllCities() {
        return cityService.getAllCities();
    }

}
