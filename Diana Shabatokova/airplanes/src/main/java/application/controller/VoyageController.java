package application.controller;

import application.data.model.Voyage;
import application.service.VoyageService;
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
@RequestMapping(value = "/voyage", produces = "application/json")
@CrossOrigin("*")
public class VoyageController {

    @Autowired
    VoyageService voyageService;

        @GetMapping(params = {"numberOfPage", "voyagesOnPage", "targetDate"}, produces = "application/json")
    public ArrayList<Object> getAllVoyages(@RequestParam("numberOfPage") int numberOfPage,
                                           @RequestParam("voyagesOnPage") int voyagesOnPage,
                                           @RequestParam("targetDate") String targetDateString) {
        ArrayList result = new ArrayList<>();
        Page<Voyage> queryResult = voyageService.getPageOfVoyages(numberOfPage, voyagesOnPage, targetDateString);
        result.add(queryResult.getContent());
        result.add(queryResult.getTotalElements());
        result.add(queryResult.getTotalPages());

        return result;
    }

    @PostMapping(consumes = "application/json", produces = "application/json")
    public void addVoyage(@RequestBody Voyage voyage) {
        voyageService.saveVoyage(voyage);
    }

}
