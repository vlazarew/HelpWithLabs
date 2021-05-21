package application.service;

import application.data.model.Voyage;
import application.data.repository.VoyageRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.PageRequest;
import org.springframework.data.domain.Sort;
import org.springframework.stereotype.Service;

import java.time.LocalDate;
import java.time.LocalDateTime;
import java.time.LocalTime;
import java.time.format.DateTimeFormatter;

@Service
public class VoyageService {

    @Autowired
    private VoyageRepository voyageRepository;

    public Page<Voyage> getPageOfVoyages(int numberOfPage, int voyagesOnPage) {
        PageRequest page = PageRequest.of(numberOfPage, voyagesOnPage, Sort.by("price"));
        return voyageRepository.findAll(page);
    }

    public Page<Voyage> getPageOfVoyagesByDate(int numberOfPage, int voyagesOnPage, String targetDateString) {
        PageRequest page = PageRequest.of(numberOfPage, voyagesOnPage, Sort.by("price"));

        LocalDate targetDate = LocalDate.parse(targetDateString, DateTimeFormatter.ofPattern("dd.MM.yyyy"));
        LocalDateTime startOfDay = targetDate.atStartOfDay();
        LocalDateTime endOfDay = LocalDateTime.of(targetDate, LocalTime.MAX);

        return voyageRepository.findByFromDateBetweenOrderByPriceAsc(
                startOfDay.toLocalDate(), endOfDay.toLocalDate(), page);

    }

    public Page<Voyage> getVoyagesByFromCityToCityFromDate(String fromCity, String toCity, String targetDateString, int numberOfPage, int voyagesOnPage) {
        PageRequest page = PageRequest.of(numberOfPage, voyagesOnPage, Sort.by("price"));

        LocalDate targetDate = LocalDate.parse(targetDateString, DateTimeFormatter.ofPattern("dd.MM.yyyy"));
        LocalDateTime startOfDay = targetDate.atStartOfDay();
        LocalDateTime endOfDay = LocalDateTime.of(targetDate, LocalTime.MAX);

        return voyageRepository.findByFrom_City_NameAndTo_City_NameAndFromDateBetweenOrderByPriceAsc(fromCity, toCity,
                startOfDay.toLocalDate(), endOfDay.toLocalDate(), page);

    }

    public void saveVoyage(Voyage voyage) {
        voyageRepository.save(voyage);
    }
}
