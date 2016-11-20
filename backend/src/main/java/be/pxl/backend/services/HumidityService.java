package be.pxl.backend.services;

import be.pxl.backend.exceptions.HumidityException;
import be.pxl.backend.jms.JmsSender;
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
    private JmsSender jmsSender;

    @Autowired
    private HumidityRepository humidityRepository;

    public Humidity addhumidity(Humidity humidity) throws HumidityException {
        if (humidity.getHumidity() >= 0 && humidity.getHumidity() <= 100) {
            humidity = humidityRepository.save(humidity);
            jmsSender.sendMessage("add humidity with id:" + humidity.getId());
            return humidity;
        } else {
            HumidityException humidityException = new HumidityException();
            jmsSender.sendMessage("add humidity:" + humidityException.getMessage());
            throw humidityException;
        }
    }

    public List<Humidity> getHumidityForSession(int id) {
        List<Humidity> humidities = humidityRepository.getHumidityForSession(id);
        jmsSender.sendMessage("get humidity for session id:" + id);
        return humidities;
    }

}
