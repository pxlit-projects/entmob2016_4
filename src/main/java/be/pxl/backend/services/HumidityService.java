package be.pxl.backend.services;

import be.pxl.backend.models.Humidity;
import be.pxl.backend.repositories.HumidityRepository;
import org.springframework.beans.factory.annotation.Autowired;

import java.util.List;

/**
 * Created by Jonas on 14/10/16.
 */
public class HumidityService {

    @Autowired
    private HumidityRepository humidityRepository;

    public Humidity addhumidity(Humidity humidity) {
        return humidityRepository.save(humidity);
    }

    public List<Humidity> getHumidityForSession(int id) {
        return humidityRepository.getHumidityForSessesion(id);
    }

}
