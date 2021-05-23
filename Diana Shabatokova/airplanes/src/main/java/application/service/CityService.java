package application.service;

import application.data.model.City;
import application.data.repository.CityRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.ArrayList;

@Service
public class CityService {
    @Autowired
    private CityRepository cityRepository;

    public ArrayList<City> getCitiesByTemplate(String template) {
        return cityRepository.findByNameContaining(template);
    }

    public ArrayList<City> getAllCities() {
        return cityRepository.findAll();
    }
}
