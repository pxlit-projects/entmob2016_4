package be.pxl.backend.services;

import be.pxl.backend.exceptions.HumidityException;
import be.pxl.backend.models.Humidity;
import be.pxl.backend.repositories.HumidityRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

/**
 * Created by Jonas on 14/10/16.
 */
@Service
public class HumidityService {

    @Autowired
    private HumidityRepository humidityRepository;

    public Humidity addhumidity(Humidity humidity) throws HumidityException {
        if (humidity.getHumidity() >= 0 && humidity.getHumidity() <= 100) {
            return humidityRepository.save(humidity);
        } else {
            throw new HumidityException();
        }
    }

    public List<Humidity> getHumidityForSession(int id) {
        return humidityRepository.getHumidityForSession(id);
    }

}
