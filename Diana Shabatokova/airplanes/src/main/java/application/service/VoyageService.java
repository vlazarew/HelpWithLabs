package application.service;

import application.data.model.City;
import application.data.model.Voyage;
import application.data.repository.VoyageRepository;
import com.google.gson.Gson;
import com.google.gson.JsonElement;
import com.google.gson.JsonObject;
import com.google.gson.JsonParser;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.PageRequest;
import org.springframework.data.domain.Sort;
import org.springframework.stereotype.Service;

import java.time.*;
import java.time.format.DateTimeFormatter;
import java.util.ArrayList;

@Service
public class VoyageService {

    @Autowired
    private VoyageRepository voyageRepository;

    @Autowired
    CityService cityService;

    public Page<Voyage> getPageOfVoyages(int numberOfPage, int voyagesOnPage) {
        PageRequest page = PageRequest.of(numberOfPage, voyagesOnPage, Sort.by("price"));
        return voyageRepository.findAll(page);
    }

    public Page<Voyage> getPageOfVoyagesByDate(int numberOfPage, int voyagesOnPage, String targetDateString) {
        PageRequest page = PageRequest.of(numberOfPage, voyagesOnPage, Sort.by("price"));

        LocalDate targetDate = LocalDate.parse(targetDateString, DateTimeFormatter.ofPattern("dd.MM.yyyy"));
        LocalDateTime startOfDay = targetDate.atStartOfDay();
        LocalDateTime endOfDay = LocalDateTime.of(targetDate, LocalTime.MAX);
        ZonedDateTime zdtStart = startOfDay.atZone(ZoneId.of("Europe/Moscow"));
        ZonedDateTime zdtEnd = endOfDay.atZone(ZoneId.of("Europe/Moscow"));

        return voyageRepository.findByFromTSBetweenOrderByPriceAsc(
                zdtStart.toInstant().getEpochSecond(), zdtEnd.toInstant().getEpochSecond(), page);

    }

    public Page<Voyage> getVoyagesByFromCityToCityFromDate(String fromCity, String toCity, String targetDateString,
                                                           int numberOfPage, int voyagesOnPage) {
        PageRequest page = PageRequest.of(numberOfPage, voyagesOnPage, Sort.by("price"));

        LocalDate targetDate = LocalDate.parse(targetDateString, DateTimeFormatter.ofPattern("dd.MM.yyyy"));
        LocalDateTime startOfDay = LocalDateTime.of(targetDate, LocalTime.MIN);
        LocalDateTime endOfDay = LocalDateTime.of(targetDate, LocalTime.MAX);
        ZonedDateTime zdtStart = startOfDay.atZone(ZoneId.of("Europe/Moscow"));
        ZonedDateTime zdtEnd = endOfDay.atZone(ZoneId.of("Europe/Moscow"));

        return voyageRepository.findByFrom_City_NameAndTo_City_NameAndFromTSGreaterThanAndFromTSLessThanOrderByPrice(fromCity, toCity,
                zdtStart.toInstant().getEpochSecond(), zdtEnd.toInstant().getEpochSecond(), page);

    }

    public ArrayList<ArrayList<Voyage>> getAllPossibleWays(String voyages) {
        ArrayList<ArrayList<Voyage>> voyageArrayList = new ArrayList<ArrayList<Voyage>>();
        ArrayList<City> query = new ArrayList<>();
        parseInputJson(voyages, voyageArrayList, query);
        ArrayList<ArrayList<Voyage>> result = new ArrayList<ArrayList<Voyage>>();

        int currentLevel = 0;
        if (voyageArrayList.size() > 0) {
            for (int i = 0; i < voyageArrayList.get(0).size(); i++) {
                ArrayList<Voyage> possibleWay = new ArrayList<>();
                possibleWay.add(voyageArrayList.get(0).get(i));

                makeRecursion(voyageArrayList, result, currentLevel, possibleWay);
            }
        }

        return result;

    }

    private void makeRecursion(ArrayList<ArrayList<Voyage>> voyageArrayList, ArrayList<ArrayList<Voyage>> result, int currentLevel, ArrayList<Voyage> possibleWay) {
        if (voyageArrayList.size() > currentLevel + 1) {
            for (int k = 0; k < voyageArrayList.get(currentLevel + 1).size(); k++) {
                ArrayList<Voyage> tempPossibleWay = new ArrayList<>(possibleWay);
                getNextAirport(voyageArrayList, tempPossibleWay, currentLevel + 1, result, k);
            }
        }

        if (voyageArrayList.size() == currentLevel + 1) {
            result.add(possibleWay);
        }
    }

    private void getNextAirport(ArrayList<ArrayList<Voyage>> voyageArrayList, ArrayList<Voyage> possibleWay, int currentLevel,
                                ArrayList<ArrayList<Voyage>> result, int index) {

        if (possibleWay.get(possibleWay.size() - 1).getToTS() < voyageArrayList.get(currentLevel).get(index).getFromTS()) {
            possibleWay.add(voyageArrayList.get(currentLevel).get(index));
            makeRecursion(voyageArrayList, result, currentLevel, possibleWay);
        }
    }

    private void parseInputJson(String voyages, ArrayList<ArrayList<Voyage>> voyageArrayList, ArrayList<City> query) {
        JsonParser parser = new JsonParser();
        JsonElement elements = parser.parse(voyages);
        Gson gson = new Gson();

        for (JsonElement element : elements.getAsJsonArray()) {
            JsonObject elemObject = element.getAsJsonObject();
            ArrayList<Voyage> subVoyageArrayList = new ArrayList<>();

            query.add(cityService.getCitiesByTemplate(elemObject.get("cityFrom").getAsString()).get(0));
            for (JsonElement voyageElem : elemObject.get("voyages").getAsJsonArray()) {
                JsonObject voyageObj = voyageElem.getAsJsonObject();
                subVoyageArrayList.add(gson.fromJson(voyageObj, Voyage.class));
            }
            voyageArrayList.add(subVoyageArrayList);

        }
    }

    public void saveVoyage(Voyage voyage) {
        voyageRepository.save(voyage);
    }
}
