package be.pxl.backend.services;

import java.util.*;

import be.pxl.backend.exceptions.TemperatureException;
import be.pxl.backend.models.Temperature;
import be.pxl.backend.repositories.TemperatureRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

/**
 * Created by Jonas on 14/10/16.
 */
@Service
public class TemperatureService {

    @Autowired
    private TemperatureRepository temperatureRepository;

    public Temperature addtemperature(Temperature temperature) throws TemperatureException {
        if (temperature.getTemperature() > -50 && temperature.getTemperature() < 50) {
            return temperatureRepository.save(temperature);
        } else {
            throw new TemperatureException();
        }
    }

    public List<Temperature> getTemperaturesForSession(int id) {
        return temperatureRepository.getTemperaturesForSession(id);
    }

}


