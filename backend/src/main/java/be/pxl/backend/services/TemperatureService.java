package be.pxl.backend.services;

import java.util.*;

import be.pxl.backend.exceptions.TemperatureException;
import be.pxl.backend.jms.JmsSender;
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
    private JmsSender jmsSender;

    @Autowired
    private TemperatureRepository temperatureRepository;

    public Temperature addtemperature(Temperature temperature) {
        if (temperature.getTemperature() > -50 && temperature.getTemperature() < 50) {
            temperature = temperatureRepository.save(temperature);
            jmsSender.sendMessage("adding temperature with id:" + temperature.getId());
            return temperature;
        } else {
            TemperatureException temperatureException = new TemperatureException();
            jmsSender.sendMessage("adding temperature: " + temperatureException.getMessage());
            throw temperatureException;
        }
    }

    public List<Temperature> getTemperaturesForSession(int id) {
        List<Temperature> temperatures = temperatureRepository.getTemperaturesForSession(id);
        jmsSender.sendMessage("get temperatures for session id:" + id);
        return temperatures;
    }

}


